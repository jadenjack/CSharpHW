using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using static PacketLibrary.Packet;
using System.IO;

namespace MiniInstagram_client
{
    public partial class Form_mypage : Form
    {

        public bool isUpdated = false;

        public Form1 parentForm;
        public Socket socket;
        
        public Button GetButton()
        {
            return this.button_editProfile;
        }
        public Socket passSocket
        {
            get { return this.socket; }
            set { this.socket = value; }
        }
        public Form_mypage()
        {
            InitializeComponent();
        }

        public void linkParent(Form1 form1)
        {
            parentForm = form1;
            socket = parentForm.socket;
        }

        public PictureBox GetPictureBox()
        {
            return this.pictureBox_profile;
        }
        public TextBox GetTextBox()
        {
            return this.textBox_profileText;
        }
        public Label GetLabelCount()
        {
            return this.label_count;
        }
        public Panel GetPanel()
        {
            return this.panel_post;
        }

        private void Form_mypage_Load(object sender, EventArgs e)
        {

        }

        private void button_ViewType_list_Click(object sender, EventArgs e)
        {
            this.panel_post.Controls.Clear();
            Initialize initPacket = parentForm.initialize;
            LinkedList<Article> contentsList = initPacket.account.contents;
            this.panel_post.HorizontalScroll.Enabled = true;

            int profileImageHeight = 30;
            int imageHeight = this.panel_post.Height - 20;
            int contentHeight = 100;

            int eachArticleSize = profileImageHeight + imageHeight + contentHeight; 
            for(int i= initPacket.account.articleCount-1;i>=0;i--)
            {
                int locationIndex = initPacket.account.articleCount - i - 1;
                Article nextArticle = contentsList.ElementAt(i);
                addProfileBox(initPacket.account, locationIndex, eachArticleSize, profileImageHeight);
                addPictureBox(nextArticle, locationIndex, eachArticleSize,profileImageHeight,imageHeight);
                addContentBox(nextArticle, locationIndex, eachArticleSize,profileImageHeight,imageHeight);
            }
            this.panel_post.Visible = true;
        }
        public void addProfileBox(Account a, int i, int articleSize, int profileImageHeight)
        {
            //프로필사진추가
            int profileImageWidth = 30;
            PictureBox pb = new PictureBox();
            pb.Image = a.profileImage;
            pb.Size = new Size(profileImageWidth, profileImageHeight); // 30,30
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Location = new Point(0, i * articleSize);
            this.panel_post.Controls.Add(pb);

            //프로필아이디추가
            Label tb = new Label();
            tb.Text = a.name;
            tb.Location = new Point(profileImageWidth + 5, i * articleSize);
            this.panel_post.Controls.Add(tb);
        }

        public void addPictureBox(Article article, int i, int articleSize, int profileImageHeight, int imageHeight)
        {
            
            PictureBox pb = new PictureBox();
            pb.Image = article.image;
            pb.Size = new System.Drawing.Size(this.panel_post.Width,imageHeight);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Location = new Point(0, i * articleSize + profileImageHeight);
            this.panel_post.Controls.Add(pb);
        }
        public void addContentBox(Article article, int i, int articleSize, int profileImageHeight, int imageHeight)
        {
            TextBox tb = new TextBox();
            tb.Size = new System.Drawing.Size(this.panel_post.Width, tb.Size.Height);
            tb.Multiline = true;
            tb.Text = article.content;
            tb.Location = new Point(0, i * articleSize + profileImageHeight + imageHeight);
            this.panel_post.Controls.Add(tb);
        }

        private void button_editProfile_Click(object sender, EventArgs e)
        {
            //프로필수정 버튼을 누르면 사진이랑 콘텐츠전송후 서버에저장
            if (isUpdated == false) {
                MessageBox.Show("업데이트할 사진을 선택하세요");
                return;
            }
            if (textBox_profileText.Text.Contains(':'))
            {
                MessageBox.Show("내용에는 ':' 문자가 들어갈 수 없습니다");
                return;
            }

            Byte[] _imageData = ImageToByteArray(this.pictureBox_profile.Image);
            //파일 크기 전송

            //보낼 버퍼 작성
            int size = _imageData.Length;
            string id = parentForm.connectedID;
            string content = this.textBox_profileText.Text;
            string infoMessage = makeImageInfoString(size, id, content);
            //upload:ID:imageData
            Send(infoMessage);
            Send(_imageData);
            
            MessageBox.Show("프로필 업데이트 완료");
            isUpdated = true;
            reload();
        }

        public void reload()
        {
            this.panel_post.Controls.Clear();
            Initialize initPacket = parentForm.initialize;
            LinkedList<Article> contentsList = initPacket.account.contents;
            this.panel_post.HorizontalScroll.Enabled = true;

            int profileImageHeight = 30;
            int imageHeight = this.panel_post.Height - 20;
            int contentHeight = 100;

            int eachArticleSize = profileImageHeight + imageHeight + contentHeight;
            for(int i=initPacket.account.articleCount-1;i>=0;i--)
            {
                int locationIndex = initPacket.account.articleCount - i - 1;
                Article nextArticle = contentsList.ElementAt(i);
                initPacket.account.profileImage = this.pictureBox_profile.Image;
                addProfileBox(initPacket.account, locationIndex, eachArticleSize, profileImageHeight);
                addPictureBox(nextArticle, locationIndex, eachArticleSize, profileImageHeight, imageHeight);
                addContentBox(nextArticle, locationIndex, eachArticleSize, profileImageHeight, imageHeight);
            }
            this.panel_post.Visible = true;
        }

        public string makeImageInfoString(int size, string account, string content)
        {
            //upload:id:imagename:imageData
            StringBuilder sb = new StringBuilder();
            sb.Append("updateprofile:");
            sb.Append(size);
            sb.Append(":");
            sb.Append(account);
            sb.Append(":");
            sb.Append(content);

            return sb.ToString();
        }

        private void Send(string msg)
        {
            byte[] sendBuffer = Encoding.UTF8.GetBytes(msg);
            Send(sendBuffer);
            System.Threading.Thread.Sleep(100);
        }
        private void Send(byte[] msg)
        {
            socket.Send(msg);
        }

        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void pictureBox_profile_Click(object sender, EventArgs e)
        {
            //사진파일을누르면 사진 프로필 변경
            this.openFileDialog1.Title = "Open Image";
            this.openFileDialog1.Filter = "이미지 파일 | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";


            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                this.pictureBox_profile.Image = new Bitmap(fileName);
                isUpdated = true;
                openFileDialog1.Dispose();
            }
        }

        private void textBox_profileText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button_viewType_Tiles_Click(object sender, EventArgs e)
        {
            this.panel_post.Controls.Clear();
            int tileWidth = 120;
            int tileHeight = 120;
            int padding = 5;
            int interval = 10;

            Initialize initPacket = parentForm.initialize;
            LinkedList<Article> contentsList = initPacket.account.contents;
            this.panel_post.HorizontalScroll.Enabled = true;
            int maxColumn = 3;

            for(int i=initPacket.account.articleCount-1;i>=0;i--)
            {
                Article nextArticle = contentsList.ElementAt(i);
                addTilePictureBox(nextArticle, initPacket.account.articleCount-i-1, tileHeight, maxColumn, interval, padding);
            }
            this.panel_post.Visible = true;
        }

        public void addTilePictureBox(Article article, int i, int articleHeight, int maxColumn, int interval, int padding)
        {
            int row = i / maxColumn;
            int col = i % maxColumn;
            int startX = padding + col * (articleHeight + interval);
            int startY = padding + row * (articleHeight + interval);

            PictureBox pb = new PictureBox();
            pb.Image = article.image;
            pb.Size = new System.Drawing.Size(articleHeight,articleHeight);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Location = new Point(startX, startY);
            this.panel_post.Controls.Add(pb);
        }
    }
}
