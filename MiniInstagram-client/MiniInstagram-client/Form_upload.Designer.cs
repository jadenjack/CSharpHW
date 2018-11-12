namespace MiniInstagram_client
{
    partial class Form_upload
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
            this.button_upload = new System.Windows.Forms.Button();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_upload
            // 
            this.button_upload.Location = new System.Drawing.Point(27, 380);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(371, 39);
            this.button_upload.TabIndex = 9;
            this.button_upload.Text = "Upload the content";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(28, 267);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(370, 106);
            this.textBox_content.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 208);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(123, 11);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(275, 21);
            this.textBox_path.TabIndex = 6;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(28, 10);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 5;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form_upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 428);
            this.Controls.Add(this.button_upload);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_search);
            this.Name = "Form_upload";
            this.Text = "Form_upload";
            this.Load += new System.EventHandler(this.Form_upload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}