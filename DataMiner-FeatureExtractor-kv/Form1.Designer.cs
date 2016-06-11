namespace DataMiner_FeatureExtractor_kv
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Input = new System.Windows.Forms.Button();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_fOutput = new System.Windows.Forms.Button();
            this.btn_facesOutput = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.radio_LBP = new System.Windows.Forms.RadioButton();
            this.radio_PCA = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(563, 238);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(106, 44);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Input
            // 
            this.btn_Input.Location = new System.Drawing.Point(12, 12);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(106, 51);
            this.btn_Input.TabIndex = 1;
            this.btn_Input.Text = "Input";
            this.btn_Input.UseVisualStyleBackColor = true;
            this.btn_Input.Click += new System.EventHandler(this.btn_Input_Click);
            // 
            // rtb_Log
            // 
            this.rtb_Log.Location = new System.Drawing.Point(15, 329);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(654, 155);
            this.rtb_Log.TabIndex = 2;
            this.rtb_Log.Text = "";
            this.rtb_Log.TextChanged += new System.EventHandler(this.rtb_Log_TextChanged);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(451, 238);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(106, 44);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_fOutput
            // 
            this.btn_fOutput.Location = new System.Drawing.Point(12, 155);
            this.btn_fOutput.Name = "btn_fOutput";
            this.btn_fOutput.Size = new System.Drawing.Size(106, 51);
            this.btn_fOutput.TabIndex = 9;
            this.btn_fOutput.Text = "Feature output";
            this.btn_fOutput.UseVisualStyleBackColor = true;
            this.btn_fOutput.Click += new System.EventHandler(this.btn_fOutput_Click);
            // 
            // btn_facesOutput
            // 
            this.btn_facesOutput.Location = new System.Drawing.Point(178, 155);
            this.btn_facesOutput.Name = "btn_facesOutput";
            this.btn_facesOutput.Size = new System.Drawing.Size(103, 51);
            this.btn_facesOutput.TabIndex = 10;
            this.btn_facesOutput.Text = "Faces output";
            this.btn_facesOutput.UseVisualStyleBackColor = true;
            this.btn_facesOutput.Click += new System.EventHandler(this.btn_facesOutput_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 51);
            this.button1.TabIndex = 11;
            this.button1.Text = "haar test input";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radio_LBP
            // 
            this.radio_LBP.AutoSize = true;
            this.radio_LBP.Location = new System.Drawing.Point(75, 54);
            this.radio_LBP.Name = "radio_LBP";
            this.radio_LBP.Size = new System.Drawing.Size(108, 21);
            this.radio_LBP.TabIndex = 12;
            this.radio_LBP.TabStop = true;
            this.radio_LBP.Text = "Uniform LBP";
            this.radio_LBP.UseVisualStyleBackColor = true;
            // 
            // radio_PCA
            // 
            this.radio_PCA.AutoSize = true;
            this.radio_PCA.Location = new System.Drawing.Point(75, 82);
            this.radio_PCA.Name = "radio_PCA";
            this.radio_PCA.Size = new System.Drawing.Size(56, 21);
            this.radio_PCA.TabIndex = 13;
            this.radio_PCA.TabStop = true;
            this.radio_PCA.Text = "PCA";
            this.radio_PCA.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Feature extraction method:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radio_LBP);
            this.groupBox1.Controls.Add(this.radio_PCA);
            this.groupBox1.Location = new System.Drawing.Point(305, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 115);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_facesOutput);
            this.Controls.Add(this.btn_fOutput);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.rtb_Log);
            this.Controls.Add(this.btn_Input);
            this.Controls.Add(this.btn_Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Feature Extraction";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_fOutput;
        private System.Windows.Forms.Button btn_facesOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radio_LBP;
        private System.Windows.Forms.RadioButton radio_PCA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

