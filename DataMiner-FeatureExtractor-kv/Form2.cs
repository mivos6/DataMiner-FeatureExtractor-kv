using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiner_FeatureExtractor_kv
{
    public partial class Form2 : Form
    {
        List<String> noFacesError = new List<string>();
        String path = Form1.facesPathForm2;
        String temp = "";
        public Form2()
        {
            InitializeComponent();
            this.noFacesError = Form1.noFacesError;
           
            foreach (String error in noFacesError)
            {
                temp = path + @"\" + error;
                lb_Errors.Items.Add(temp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_Errors_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            String link = (String)lb_Errors.SelectedItem;
            System.Diagnostics.Process.Start(link);
        }

        private void btn_OpenFolder_Click(object sender, EventArgs e)
        {
            String link = (String)lb_Errors.SelectedItem;
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", link));           
        }

    }
}
