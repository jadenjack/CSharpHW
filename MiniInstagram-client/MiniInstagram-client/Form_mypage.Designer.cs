namespace MiniInstagram_client
{
    partial class Form_mypage
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
            this.label_count = new System.Windows.Forms.Label();
            this.label_articles = new System.Windows.Forms.Label();
            this.button_editProfile = new System.Windows.Forms.Button();
            this.textBox_profileText = new System.Windows.Forms.TextBox();
            this.button_viewType_Tiles = new System.Windows.Forms.Button();
            this.button_ViewType_list = new System.Windows.Forms.Button();
            this.panel_post = new System.Windows.Forms.Panel();
            this.pictureBox_profile = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_profile)).BeginInit();
            this.SuspendLayout();
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Location = new System.Drawing.Point(289, 32);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(11, 12);
            this.label_count.TabIndex = 1;
            this.label_count.Text = "0";
            // 
            // label_articles
            // 
            this.label_articles.AutoSize = true;
            this.label_articles.Location = new System.Drawing.Point(291, 48);
            this.label_articles.Name = "label_articles";
            this.label_articles.Size = new System.Drawing.Size(46, 12);
            this.label_articles.TabIndex = 2;
            this.label_articles.Text = "articles";
            // 
            // button_editProfile
            // 
            this.button_editProfile.Location = new System.Drawing.Point(204, 69);
            this.button_editProfile.Name = "button_editProfile";
            this.button_editProfile.Size = new System.Drawing.Size(197, 60);
            this.button_editProfile.TabIndex = 3;
            this.button_editProfile.Text = "Edit profile";
            this.button_editProfile.UseVisualStyleBackColor = true;
            this.button_editProfile.Click += new System.EventHandler(this.button_editProfile_Click);
            // 
            // textBox_profileText
            // 
            this.textBox_profileText.Location = new System.Drawing.Point(13, 136);
            this.textBox_profileText.Multiline = true;
            this.textBox_profileText.Name = "textBox_profileText";
            this.textBox_profileText.Size = new System.Drawing.Size(388, 41);
            this.textBox_profileText.TabIndex = 4;
            this.textBox_profileText.TextChanged += new System.EventHandler(this.textBox_profileText_TextChanged);
            // 
            // button_viewType_Tiles
            // 
            this.button_viewType_Tiles.Location = new System.Drawing.Point(25, 183);
            this.button_viewType_Tiles.Name = "button_viewType_Tiles";
            this.button_viewType_Tiles.Size = new System.Drawing.Size(151, 23);
            this.button_viewType_Tiles.TabIndex = 5;
            this.button_viewType_Tiles.Text = "Tiles";
            this.button_viewType_Tiles.UseVisualStyleBackColor = true;
            this.button_viewType_Tiles.Click += new System.EventHandler(this.button_viewType_Tiles_Click);
            // 
            // button_ViewType_list
            // 
            this.button_ViewType_list.Location = new System.Drawing.Point(220, 183);
            this.button_ViewType_list.Name = "button_ViewType_list";
            this.button_ViewType_list.Size = new System.Drawing.Size(151, 23);
            this.button_ViewType_list.TabIndex = 6;
            this.button_ViewType_list.Text = "List";
            this.button_ViewType_list.UseVisualStyleBackColor = true;
            this.button_ViewType_list.Click += new System.EventHandler(this.button_ViewType_list_Click);
            // 
            // panel_post
            // 
            this.panel_post.AutoScroll = true;
            this.panel_post.Location = new System.Drawing.Point(13, 213);
            this.panel_post.Name = "panel_post";
            this.panel_post.Size = new System.Drawing.Size(399, 203);
            this.panel_post.TabIndex = 7;
            // 
            // pictureBox_profile
            // 
            this.pictureBox_profile.Image = global::MiniInstagram_client.Properties.Resources.profile_img;
            this.pictureBox_profile.InitialImage = global::MiniInstagram_client.Properties.Resources.profile_img;
            this.pictureBox_profile.Location = new System.Drawing.Point(13, 13);
            this.pictureBox_profile.Name = "pictureBox_profile";
            this.pictureBox_profile.Size = new System.Drawing.Size(184, 116);
            this.pictureBox_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_profile.TabIndex = 0;
            this.pictureBox_profile.TabStop = false;
            this.pictureBox_profile.Click += new System.EventHandler(this.pictureBox_profile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // Form_mypage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 428);
            this.Controls.Add(this.panel_post);
            this.Controls.Add(this.button_ViewType_list);
            this.Controls.Add(this.button_viewType_Tiles);
            this.Controls.Add(this.textBox_profileText);
            this.Controls.Add(this.button_editProfile);
            this.Controls.Add(this.label_articles);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.pictureBox_profile);
            this.Name = "Form_mypage";
            this.Text = "Form_account";
            this.Load += new System.EventHandler(this.Form_mypage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_profile;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Label label_articles;
        private System.Windows.Forms.Button button_editProfile;
        private System.Windows.Forms.TextBox textBox_profileText;
        private System.Windows.Forms.Button button_viewType_Tiles;
        private System.Windows.Forms.Button button_ViewType_list;
        private System.Windows.Forms.Panel panel_post;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}