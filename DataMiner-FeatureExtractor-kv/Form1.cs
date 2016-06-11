using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
//Emgu
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
//Acord
using Accord.Statistics;
using Accord.Math;

namespace DataMiner_FeatureExtractor_kv
{
    public partial class Form1 : Form
    {
        //Global
        string fPath = "";
        string featurePath = "";
        string facesPath = "";
        string haarPath = "";
        bool headerDone = false;

        public Form1()
        {
            InitializeComponent();
            radio_LBP.Checked = true;    
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Input_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if(folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fPath = folderDialog.SelectedPath;
                LOG("File succesfully opened: \n\t" + fPath, false);
                //Get features from pictures       
            }
            else
            {
                LOG("Error opening file", true);
            }
        }//End of btn_Input

        private void LOG(string msg, Boolean error)
        {
            if (error)
                rtb_Log.SelectionColor = Color.Red;
            else
                rtb_Log.SelectionColor = Color.Black;

            rtb_Log.AppendText(msg);
            rtb_Log.AppendText("\n");
            rtb_Log.Refresh();
        }//End of LOG
    

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if(fPath == "")
            {
                LOG("Error! File not selected!", true);
            }
            else if(featurePath == "")
            {
                LOG("Error! Location for features not selected!", true);
            }
            else if(facesPath == "")
            {
                LOG("Error! Location for faces not selected!", true);
            }
            else if(haarPath == "")
            {
                LOG("Error! Location for haar traing set not selected!", true);
            }
            else
            {
                getFeatures(fPath);                          
            }
           
        }//End of btn_Start



        private void getFeatures(string path)
        {
            LOG("Feature extraction started!", false);
            Bitmap bitmap;
            String bpPath;
            int folderCounter = 1, fileCounter = 1;
            bool fEndOfDirectory = false, fEndOfAllData = false, firstStartInnerDo = true;
            Stopwatch timer = new Stopwatch();

            timer.Start();
            do
            {

                do
                {
                    //Create path to picture
                    bpPath = path + "\\" + folderCounter + "\\" + fileCounter + ".jpg";
                    try {
                        bitmap = new Bitmap(bpPath);
                        if (bitmap == null)
                        {
                            LOG("Error! Failed to load a picture: " + bpPath, true);
                            fEndOfDirectory = true;                                               
                        }//End of if

                        else
                        {
                            LOG("Picture loaded: " + bpPath, false);
                            //Get features
                            getFeatureArray(bitmap, fileCounter.ToString(), folderCounter.ToString());
                            fileCounter++;
                            firstStartInnerDo = false;

                            //Increment progress bar
                        }//End of else

                        
                    }
                    catch (Exception e)
                    {
                        LOG("Error! Failed to load a picture: " + bpPath, true);
                        fEndOfDirectory = true;
                        if (firstStartInnerDo)
                            fEndOfAllData = true;
                        LOG("error message: " + e.Message, true);
                    }
                }//End of do
                while (!fEndOfDirectory) ;

                fileCounter = 1;
                fEndOfDirectory = false;
                firstStartInnerDo = true;
                folderCounter++;
                LOG("New folder!\n\t" + folderCounter, false);
            }
            while (!fEndOfAllData);

            timer.Stop();
            LOG("\n\n\tPROGRAM FINISHED!\n", false);
            LOG("time: \t" + (timer.ElapsedMilliseconds / 1000).ToString() + " s", false);

        }//End of getFeatures

        private bool getFeatureArray(Bitmap bmp, string fileCounter, string folderCounter)
        {
            Image<Bgr, byte> ImageFrame = new Image<Bgr, byte>(bmp);
            //Convert to gray scale
            Image<Gray, byte> grayFrame = ImageFrame.Convert<Gray, byte>();

            //Classifier
            CascadeClassifier classifier = new CascadeClassifier(haarPath + "\\haarcascade_frontalface_alt_tree.xml");
            //Detect faces. gray scale, windowing scale factor (closer to 1 for better detection),minimum number of nearest neighbours
            //min and max size in pixels. Start to search with a window of 800 and go down to 100 
            Rectangle[] rectangles = classifier.DetectMultiScale(grayFrame, 1.4, 0, new Size(50,50), new Size(800,800));

            if (rectangles == null)
            {
                LOG("No face!", true);
                return false;
            }
            LOG("Face number: " + rectangles.Length.ToString(), false);

            int[] feature;
            double[,] featurePCA;
            double[] featurePCA_toWrite;

            for (int counter = 0; counter < rectangles.Length; counter++)
            {
                //Get LBP or PCA BUT FIRST CUT FACE OUT AND RESIZE IMG
                if (radio_LBP.Checked)
                {
                    feature = calculateLBP(CutFaceOut(bmp, rectangles[counter], fileCounter, folderCounter, counter.ToString()));
                    writeToFile(feature, folderCounter);
                }
                    
                else if (radio_PCA.Checked){
                    featurePCA = calculatePCA(CutFaceOut(bmp, rectangles[counter], fileCounter, folderCounter, counter.ToString()));
                    LOG("PCA Calculated!", false);
                    featurePCA_toWrite = Array2DTo1D(featurePCA);
                    writeToFile(featurePCA_toWrite, folderCounter);
                }  
                          
            }

            return true;
        }

        private Bitmap CutFaceOut(Bitmap srcBitmap, Rectangle section, string FileCounter, string FolderCounter, string RectangleCounter)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);

            Rectangle destRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            g.DrawImage(srcBitmap, destRect, section, GraphicsUnit.Pixel);

            g.Dispose();
            //Create directory and save image
            if(!System.IO.Directory.Exists(facesPath + "\\" + FolderCounter))
            {
                System.IO.Directory.CreateDirectory(facesPath + "\\" + FolderCounter);
            }
            bmp = resizeImage(bmp);
            bmp.Save(facesPath + "\\"+ FolderCounter + "\\"+ FileCounter + "-" + RectangleCounter+".bmp");

            LOG("Picture saved! \t" + facesPath + "\\" + FolderCounter + "\\" + FileCounter + "-" + RectangleCounter + ".bmp", false);

            return bmp;
        }

        private Bitmap resizeImage(Bitmap bmp)
        {
            int newWidth = 48, newHeight = 48;
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);
            }
            LOG("Resize image", false);
            return newImage;
        }


        //LBP
        private int[] calculateLBP(Bitmap bmp)
        {
            List<int> LBPfeatures = new List<int>();
            int currentFeature;


            //Calculate LBP
            for (int i = 1; i < bmp.Height; i = i + 3)
            {

                for (int j = 1; j < bmp.Width; j = j + 3)
                {

                    currentFeature = calculateCurrentLBP(j,i,bmp);
                    //Write to array
                    LBPfeatures.Add(currentFeature);
                }//End of inner for

            }//End of outer for
            LOG("LBP Calculated", false);

            List<int> uniformLBPfeatures = new List<int>();

            //For each 8-bit binary, if it's uniform get its count from LBPfeatures
            for (int i = 0; i < 256; i++)
            {
                if (isUniform(i))
                {
                    int uc = LBPfeatures.FindAll(x => x == i).Count; //x so that x == i
                    //Add this number to the uniformLBPFeatures
                    uniformLBPfeatures.Add(uc);
                }
            }

            //Count all non-uniform
            int nuc = LBPfeatures.FindAll(x => !isUniform(x)).Count; //x so that x is not uniform
            uniformLBPfeatures.Add(nuc);

            LOG("Uniform LBP Calculated", false);

            //Convert List<int> to int[] and return it
            return uniformLBPfeatures.ToArray();
        }

        private int calculateCurrentLBP(int i, int j, Bitmap bmp)
        {
            double[] arrayNeighbours = new double[8];
            int counter = 0;
            double temp;
            double centerValue = (bmp.GetPixel(i, j).R + bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).B) / 3;
            for (int a = -1; a < 2; a++)
            {

                for(int b = -1; b < 2; b++)
                {
                    if (a == 0 && b == 0)
                        continue;

                    temp = bmp.GetPixel(i + a, j + b).R + bmp.GetPixel(i + a, j + b).G + bmp.GetPixel(i + a, j + b).B;
                    temp /= 3;

                    if (temp > centerValue)
                        arrayNeighbours[counter] = 1;
                    else
                        arrayNeighbours[counter] = 0;
                    counter++;
                }//End of for
            }//End of for

            String binaryCombination;
            //Order them clockwise
            binaryCombination = arrayNeighbours[0].ToString() + arrayNeighbours[1].ToString() + arrayNeighbours[2].ToString() +
                arrayNeighbours[4].ToString() + arrayNeighbours[7].ToString() + arrayNeighbours[6].ToString() +
                arrayNeighbours[5].ToString() + arrayNeighbours[3].ToString();

            try
            {
                int returnNumb = Convert.ToInt32(binaryCombination, 2);

                return returnNumb;
            }
            catch (Exception)
            {
                LOG("Error! Error occured while converting binary to integer", true);
                return -1;
            }
            
        }

        //Check if 8-bit value is uniform
        private bool isUniform(int value)
        {
            int counter = 0;
            //From weight 0 to weight 6
            for (int i = 1; i <= 64; i = i<<1)
            {
                //If current and next bit are different increase the counter
                int currentBit = value & i;
                int nextBit = value & (i << 1);
                if (currentBit != (nextBit >> 1))
                    counter++;
            }
            //If counter is greater than 2 return false
            return counter > 2 ? false : true;
        }//End of isUniform


        //PCA
        private double[,] calculatePCA(Bitmap bmp)
        {
            double[,] sourceMatrix = getSourceMatrix(bmp);
            var pca = new Accord.Statistics.Analysis.PrincipalComponentAnalysis(sourceMatrix, Accord.Statistics.Analysis.AnalysisMethod.Center);
            // Compute the Principal Component Analysis
            pca.Compute();
            //Eigenvalues
            double[] eigenvalues = pca.Eigenvalues;
            double[,] eigenvectors = pca.ComponentMatrix;
            double temp = eigenvalues.Max();
            double[,] output = new double[1, eigenvalues.Length];

            int maxRow = eigenvalues.IndexOf(temp);
            for(int i = 0; i < eigenvalues.Length; i++)
            {
                output[0, i] = eigenvectors[maxRow, i];
            }
            // Creates a projection considering 1x dimensions
            //double[,] components = pca.Transform(eigenvectors, 1);
            //Write to PCA_features.txt file

            //ZNAČI OVAKO OVO JE NEŠTO SJEBANO JA NEZZ ŠTA TU TREBA ODABRATI HAHA, UGL OVO SU NEKI EIGENVEKTORI I TO SAM ODABRAO TAJ JEDAN RED PO NAJVEČOJ VRIJEDNOSTI IZ
            //EIGENVALUE SAD JA NEMAM POJMA JEL TO VALJA TAKO, ILI IZABRATI TE EIGEN VALUE-E PA PROBATI UGL RETURN MORA SLATI NAZAD DOUBLE[,] TAKO DA JEDNOSTAVNO JE PRETVORITI
            //IZ DOUBLE[] U 2D TO EVO OVA MOJA FOR PETLJA IZNAD RADI.... AKO OVO BUDE IMALO SLAB RATE PROBAJ S EIGENVALUES KAO FEATUREIMA, AKO NE TREBAMO PO NETU TRAZIT JOŠ KAKO SE
            //TO GOVNO KORISTI.... UGL PROBAJ NA 10-20 POLITIČARA OBA DA NE TRAJE DUGO PA DA VIDIMO ŠTA ĆE BITI TJ. AKO TI SE DA
            return output;

        }//End of calculatePCA

        private double[,] getSourceMatrix(Bitmap bmp)
        {
            double[,] matrix = new double[bmp.Height, bmp.Width];
            for(int i = 0; i < bmp.Height; i++)
            {
                for(int j = 0; j < bmp.Width; j++)
                {
                    matrix[i, j] = (bmp.GetPixel(i, j).R + bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).B) / 3;
                }                
            }

            return matrix;
        }//End of getSourceMatrix


        private double[] Array2DTo1D(double[,] array)
        {
            double[] newArray = new double[array.Length];
            Buffer.BlockCopy(array, 0, newArray, 0, array.Length * sizeof(double) );
            return newArray;
        }//End of Array2DTo1D

        private void writeToFile(int[] features, String className)
        {
            String textToWrite = "";
            String header = "";
            String name = "LBP_features.tsv";

            //Header
            for (int i = 0; i < features.Length; i++)
            {
                header +="F" + i.ToString() + "\t";
            }//End of for
            header += "Class";


            for (int i = 0; i < features.Length; i++)
            {
                textToWrite += features[i].ToString() + "\t";
            }
            textToWrite += className;
            try
            {
                if (!headerDone)
                {
                    System.IO.File.AppendAllText(featurePath + "\\" + name, header + Environment.NewLine);
                    headerDone = true;
                }
                System.IO.File.AppendAllText(featurePath + "\\" + name, textToWrite + Environment.NewLine);
                LOG("Feature written", false);
            }
            catch (Exception)
            {
                LOG("Error! Feature writing failed!", true);
            }
            
        }//End of writeToFile

        private void writeToFile(double[] features, String className)
        {
            String textToWrite = "";
            String header = "";
            String name = "PCA_features.tsv";

            //Header
            for (int i = 0; i < features.Length; i++)
            {
                header += "F" + i.ToString() + "\t";
            }//End of for
            header += "Class";


            for (int i = 0; i < features.Length; i++)
            {
                textToWrite += features[i].ToString() + "\t";
            }
            textToWrite += className;
            try
            {
                if (!headerDone)
                {
                    System.IO.File.AppendAllText(featurePath + "\\" + name, header + Environment.NewLine);
                    headerDone = true;
                }
                System.IO.File.AppendAllText(featurePath + "\\" + name, textToWrite + Environment.NewLine);
                LOG("Feature written", false);
            }
            catch (Exception)
            {
                LOG("Error! Feature writing failed!", true);
            }

        }//End of writeToFile

        private void originalPicture_Click(object sender, EventArgs e)
        {
            
        }

        private void FacePicture_Click(object sender, EventArgs e)
        {
            
        }

        private void rtb_Log_TextChanged(object sender, EventArgs e)
        {
            rtb_Log.SelectionStart = rtb_Log.Text.Length;
            // scroll it automatically
            rtb_Log.ScrollToCaret();
        }

        private void btn_fOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                featurePath = folderDialog.SelectedPath;
                LOG("Location succesfully selected: \n\t" + featurePath, false);
                //Get features from pictures       
            }
            else
            {
                LOG("Error selecting location", true);
            }
        }

        private void btn_facesOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                facesPath = folderDialog.SelectedPath;
                LOG("Location succesfully selected: \n\t" + facesPath, false);
                //Get features from pictures       
            }
            else
            {
                LOG("Error selecting location", true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                haarPath = folderDialog.SelectedPath;
                LOG("Location succesfully selected: \n\t" + haarPath, false);
                //Get features from pictures       
            }
            else
            {
                LOG("Error selecting location", true);
            }
        }
    }//End of Class

}//End of namespace
