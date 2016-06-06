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
            this.cb_nThreads = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_fOutput = new System.Windows.Forms.Button();
            this.btn_facesOutput = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(563, 273);
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
            this.btn_Start.Location = new System.Drawing.Point(451, 273);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(106, 44);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // cb_nThreads
            // 
            this.cb_nThreads.FormattingEnabled = true;
            this.cb_nThreads.Location = new System.Drawing.Point(15, 96);
            this.cb_nThreads.Name = "cb_nThreads";
            this.cb_nThreads.Size = new System.Drawing.Size(103, 24);
            this.cb_nThreads.TabIndex = 4;
            this.cb_nThreads.SelectedIndexChanged += new System.EventHandler(this.cb_nThreads_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thread number";
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
            this.btn_facesOutput.Location = new System.Drawing.Point(167, 155);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 496);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_facesOutput);
            this.Controls.Add(this.btn_fOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_nThreads);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.rtb_Log);
            this.Controls.Add(this.btn_Input);
            this.Controls.Add(this.btn_Exit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ComboBox cb_nThreads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_fOutput;
        private System.Windows.Forms.Button btn_facesOutput;
        private System.Windows.Forms.Button button1;
    }
}

