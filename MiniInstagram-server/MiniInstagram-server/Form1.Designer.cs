namespace MiniInstagram_server
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
            this.components = new System.ComponentModel.Container();
            this.ip = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iplabel = new System.Windows.Forms.Label();
            this.portlabel = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.memberList = new System.Windows.Forms.ListView();
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.accountListLabel = new System.Windows.Forms.Label();
            this.logLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ip
            // 
            this.ip.Enabled = false;
            this.ip.Location = new System.Drawing.Point(70, 16);
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Size = new System.Drawing.Size(324, 21);
            this.ip.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // iplabel
            // 
            this.iplabel.AutoSize = true;
            this.iplabel.Location = new System.Drawing.Point(25, 21);
            this.iplabel.Name = "iplabel";
            this.iplabel.Size = new System.Drawing.Size(20, 12);
            this.iplabel.TabIndex = 2;
            this.iplabel.Text = "IP:";
            // 
            // portlabel
            // 
            this.portlabel.AutoSize = true;
            this.portlabel.Location = new System.Drawing.Point(449, 19);
            this.portlabel.Name = "portlabel";
            this.portlabel.Size = new System.Drawing.Size(31, 12);
            this.portlabel.TabIndex = 3;
            this.portlabel.Text = "Port:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(486, 16);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(87, 21);
            this.port.TabIndex = 4;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(612, 14);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(124, 23);
            this.start.TabIndex = 5;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // memberList
            // 
            this.memberList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Index,
            this.ID,
            this.Password});
            this.memberList.GridLines = true;
            this.memberList.Location = new System.Drawing.Point(12, 85);
            this.memberList.Name = "memberList";
            this.memberList.Size = new System.Drawing.Size(297, 353);
            this.memberList.TabIndex = 6;
            this.memberList.UseCompatibleStateImageBehavior = false;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(336, 85);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(452, 353);
            this.logTextBox.TabIndex = 7;
            // 
            // accountListLabel
            // 
            this.accountListLabel.AutoSize = true;
            this.accountListLabel.Location = new System.Drawing.Point(13, 67);
            this.accountListLabel.Name = "accountListLabel";
            this.accountListLabel.Size = new System.Drawing.Size(126, 12);
            this.accountListLabel.TabIndex = 8;
            this.accountListLabel.Text = "Member Account List";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(334, 67);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(66, 12);
            this.logLabel.TabIndex = 9;
            this.logLabel.Text = "Server Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.accountListLabel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.memberList);
            this.Controls.Add(this.start);
            this.Controls.Add(this.port);
            this.Controls.Add(this.portlabel);
            this.Controls.Add(this.iplabel);
            this.Controls.Add(this.ip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label iplabel;
        private System.Windows.Forms.Label portlabel;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ListView memberList;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label accountListLabel;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Password;
    }
}

