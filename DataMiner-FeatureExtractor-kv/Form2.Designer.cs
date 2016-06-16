namespace DataMiner_FeatureExtractor_kv
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Errors = new System.Windows.Forms.ListBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_OpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Images with no faces";
            // 
            // lb_Errors
            // 
            this.lb_Errors.FormattingEnabled = true;
            this.lb_Errors.ItemHeight = 16;
            this.lb_Errors.Location = new System.Drawing.Point(12, 44);
            this.lb_Errors.Name = "lb_Errors";
            this.lb_Errors.Size = new System.Drawing.Size(708, 276);
            this.lb_Errors.TabIndex = 3;
            this.lb_Errors.SelectedIndexChanged += new System.EventHandler(this.lb_Errors_SelectedIndexChanged);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(49, 326);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(274, 46);
            this.btn_Open.TabIndex = 4;
            this.btn_Open.Text = "Open Picture";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_OpenFolder
            // 
            this.btn_OpenFolder.Location = new System.Drawing.Point(329, 326);
            this.btn_OpenFolder.Name = "btn_OpenFolder";
            this.btn_OpenFolder.Size = new System.Drawing.Size(274, 46);
            this.btn_OpenFolder.TabIndex = 5;
            this.btn_OpenFolder.Text = "Open Folder";
            this.btn_OpenFolder.UseVisualStyleBackColor = true;
            this.btn_OpenFolder.Click += new System.EventHandler(this.btn_OpenFolder_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 380);
            this.Controls.Add(this.btn_OpenFolder);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.lb_Errors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "No faces";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_Errors;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_OpenFolder;
    }
}