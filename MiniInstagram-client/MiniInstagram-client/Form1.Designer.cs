namespace MiniInstagram_client
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_LOGO = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_NoAccount = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.Button_Connect = new System.Windows.Forms.Button();
            this.Button_Login = new System.Windows.Forms.Button();
            this.Button_SignUp = new System.Windows.Forms.Button();
            this.pictureBox_home = new System.Windows.Forms.PictureBox();
            this.pictureBox_search = new System.Windows.Forms.PictureBox();
            this.pictureBox_upload = new System.Windows.Forms.PictureBox();
            this.pictureBox_mypage = new System.Windows.Forms.PictureBox();
            this.panel_main = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_upload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mypage)).BeginInit();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(52, 29);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 12);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP :";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(42, 62);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(39, 12);
            this.label_Port.TabIndex = 1;
            this.label_Port.Text = "Port : ";
            // 
            // label_LOGO
            // 
            this.label_LOGO.AutoSize = true;
            this.label_LOGO.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_LOGO.Location = new System.Drawing.Point(27, 117);
            this.label_LOGO.Name = "label_LOGO";
            this.label_LOGO.Size = new System.Drawing.Size(154, 24);
            this.label_LOGO.TabIndex = 2;
            this.label_LOGO.Text = "MINI Instagram";
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(55, 167);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(28, 12);
            this.label_ID.TabIndex = 3;
            this.label_ID.Text = "ID : ";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(9, 201);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(74, 12);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password : ";
            // 
            // label_NoAccount
            // 
            this.label_NoAccount.AutoSize = true;
            this.label_NoAccount.Location = new System.Drawing.Point(74, 252);
            this.label_NoAccount.Name = "label_NoAccount";
            this.label_NoAccount.Size = new System.Drawing.Size(76, 12);
            this.label_NoAccount.TabIndex = 5;
            this.label_NoAccount.Text = "No account?";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(89, 25);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 21);
            this.textBox_IP.TabIndex = 6;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(89, 62);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 21);
            this.textBox_Port.TabIndex = 7;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Enabled = false;
            this.textBox_ID.Location = new System.Drawing.Point(89, 158);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(100, 21);
            this.textBox_ID.TabIndex = 8;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Enabled = false;
            this.textBox_Password.Location = new System.Drawing.Point(89, 192);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.ReadOnly = true;
            this.textBox_Password.Size = new System.Drawing.Size(100, 21);
            this.textBox_Password.TabIndex = 9;
            // 
            // Button_Connect
            // 
            this.Button_Connect.Location = new System.Drawing.Point(195, 25);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(86, 58);
            this.Button_Connect.TabIndex = 10;
            this.Button_Connect.Text = "Connect";
            this.Button_Connect.UseVisualStyleBackColor = true;
            this.Button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // Button_Login
            // 
            this.Button_Login.Enabled = false;
            this.Button_Login.Location = new System.Drawing.Point(195, 161);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(86, 51);
            this.Button_Login.TabIndex = 11;
            this.Button_Login.Text = "Login";
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // Button_SignUp
            // 
            this.Button_SignUp.Enabled = false;
            this.Button_SignUp.Location = new System.Drawing.Point(156, 247);
            this.Button_SignUp.Name = "Button_SignUp";
            this.Button_SignUp.Size = new System.Drawing.Size(75, 23);
            this.Button_SignUp.TabIndex = 12;
            this.Button_SignUp.Text = "SignUp";
            this.Button_SignUp.UseVisualStyleBackColor = true;
            this.Button_SignUp.Click += new System.EventHandler(this.Button_SignUp_Click);
            // 
            // pictureBox_home
            // 
            this.pictureBox_home.Image = global::MiniInstagram_client.Properties.Resources.button_home;
            this.pictureBox_home.Location = new System.Drawing.Point(474, 495);
            this.pictureBox_home.Name = "pictureBox_home";
            this.pictureBox_home.Size = new System.Drawing.Size(74, 63);
            this.pictureBox_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_home.TabIndex = 13;
            this.pictureBox_home.TabStop = false;
            this.pictureBox_home.Click += new System.EventHandler(this.pictureBox_home_Click);
            // 
            // pictureBox_search
            // 
            this.pictureBox_search.Image = global::MiniInstagram_client.Properties.Resources.button_search;
            this.pictureBox_search.Location = new System.Drawing.Point(554, 495);
            this.pictureBox_search.Name = "pictureBox_search";
            this.pictureBox_search.Size = new System.Drawing.Size(74, 63);
            this.pictureBox_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_search.TabIndex = 14;
            this.pictureBox_search.TabStop = false;
            this.pictureBox_search.Click += new System.EventHandler(this.pictureBox_search_Click);
            // 
            // pictureBox_upload
            // 
            this.pictureBox_upload.Image = global::MiniInstagram_client.Properties.Resources.button_upload;
            this.pictureBox_upload.Location = new System.Drawing.Point(634, 495);
            this.pictureBox_upload.Name = "pictureBox_upload";
            this.pictureBox_upload.Size = new System.Drawing.Size(74, 63);
            this.pictureBox_upload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_upload.TabIndex = 15;
            this.pictureBox_upload.TabStop = false;
            this.pictureBox_upload.Click += new System.EventHandler(this.pictureBox_upload_Click);
            // 
            // pictureBox_mypage
            // 
            this.pictureBox_mypage.Image = global::MiniInstagram_client.Properties.Resources.button_mypage;
            this.pictureBox_mypage.Location = new System.Drawing.Point(714, 495);
            this.pictureBox_mypage.Name = "pictureBox_mypage";
            this.pictureBox_mypage.Size = new System.Drawing.Size(74, 63);
            this.pictureBox_mypage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_mypage.TabIndex = 16;
            this.pictureBox_mypage.TabStop = false;
            this.pictureBox_mypage.Click += new System.EventHandler(this.pictureBox_mypage_Click);
            // 
            // panel_main
            // 
            this.panel_main.Location = new System.Drawing.Point(346, 12);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(440, 467);
            this.panel_main.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.pictureBox_mypage);
            this.Controls.Add(this.pictureBox_upload);
            this.Controls.Add(this.pictureBox_search);
            this.Controls.Add(this.pictureBox_home);
            this.Controls.Add(this.Button_SignUp);
            this.Controls.Add(this.Button_Login);
            this.Controls.Add(this.Button_Connect);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label_NoAccount);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.label_LOGO);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_upload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mypage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_LOGO;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_NoAccount;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Button Button_Connect;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.Button Button_SignUp;
        private System.Windows.Forms.PictureBox pictureBox_home;
        private System.Windows.Forms.PictureBox pictureBox_search;
        private System.Windows.Forms.PictureBox pictureBox_upload;
        private System.Windows.Forms.PictureBox pictureBox_mypage;
        private System.Windows.Forms.Panel panel_main;
    }
}

