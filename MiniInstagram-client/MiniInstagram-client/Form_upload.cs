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
using System.IO;
using static PacketLibrary.Packet;
using System.Runtime.Serialization.Formatters.Binary;

namespace MiniInstagram_client
{
    public partial class Form_upload : Form
    {
        public Form1 parentForm;
        public Socket socket;
        public OpenFileDialog openFileDialog;
        public bool isUpdated = false;


        public Form_upload()
        {
            InitializeComponent();
        }
        public void linkParent(Form1 form1)
        {
            parentForm = form1;
            this.socket = parentForm.socket;
            this.socket.NoDelay = true;
        }

        private void Form_upload_Load(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            //this.pictureBox1 = new PictureBox();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open Image";
            openFileDialog.Filter = "이미지 파일 | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.textBox_path.Text = fileName;
                this.pictureBox1.Image = new Bitmap(fileName);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            if (this.textBox_path.Text == "")
            {
                MessageBox.Show("업로드할 사진을 선택하세요");
                return;
            }
            Byte[] _imageData = ImageToByteArray(this.pictureBox1.Image);
            FileStream fs = new FileStream(this.textBox_path.Text,FileMode.Open,FileAccess.Read);
            Byte[] imageBuf = new Byte[_imageData.Length];
            fs.Read(imageBuf, 0, _imageData.Length);

            //파일 크기 전송

            //이미지 이름 구하기
            string imageName = this.textBox_path.Text.Substring(this.textBox_path.Text.LastIndexOf('\\') + 1);
            //보낼 버퍼 작성
            int size = _imageData.Length;
            string id = parentForm.connectedID;
            string infoMessage = makeImageInfoString(size, id, imageName);
            //upload:ID:imageData
            Send(infoMessage);

            Send(imageBuf);

            Send(this.textBox_content.Text);
            this.textBox_path.Text = "";
            this.textBox_content.Text = "";
            this.pictureBox1.Image = null;
            MessageBox.Show("성공적으로 업로드되었습니다. 마이페이지에서 확인하세요");
            isUpdated = true;
        }

        public string makeImageInfoString(int size, string id, string imagename)
        {
            //upload:id:imagename:imageData
            StringBuilder sb = new StringBuilder();
            sb.Append("uploadinfo:");
            sb.Append(size);
            sb.Append(":");
            sb.Append(id);
            sb.Append(":");
            sb.Append(imagename);
            return sb.ToString();
        }

        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, getFormat(image));
            //image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public System.Drawing.Imaging.ImageFormat getFormat(Image img)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return System.Drawing.Imaging.ImageFormat.Bmp;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return System.Drawing.Imaging.ImageFormat.Png;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
                return System.Drawing.Imaging.ImageFormat.Emf;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
                return System.Drawing.Imaging.ImageFormat.Exif;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return System.Drawing.Imaging.ImageFormat.Gif;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                return System.Drawing.Imaging.ImageFormat.Icon;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
                return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return System.Drawing.Imaging.ImageFormat.Tiff;
            else
                return System.Drawing.Imaging.ImageFormat.Wmf;
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
            System.Threading.Thread.Sleep(100);
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
