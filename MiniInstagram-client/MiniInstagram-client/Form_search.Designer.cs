namespace MiniInstagram_client
{
    partial class Form_search
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
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.listBox_searchList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(34, 26);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(255, 21);
            this.textBox_search.TabIndex = 0;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(310, 23);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 1;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // listBox_searchList
            // 
            this.listBox_searchList.FormattingEnabled = true;
            this.listBox_searchList.ItemHeight = 12;
            this.listBox_searchList.Location = new System.Drawing.Point(34, 69);
            this.listBox_searchList.Name = "listBox_searchList";
            this.listBox_searchList.Size = new System.Drawing.Size(351, 340);
            this.listBox_searchList.TabIndex = 2;
            this.listBox_searchList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_searchList_MouseDoubleClick);
            // 
            // Form_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 428);
            this.Controls.Add(this.listBox_searchList);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Name = "Form_search";
            this.Text = "Form_search";
            this.Load += new System.EventHandler(this.Form_search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ListBox listBox_searchList;
    }
}