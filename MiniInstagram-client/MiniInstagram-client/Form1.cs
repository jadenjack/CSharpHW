using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using PacketLibrary;
using static PacketLibrary.Packet;


namespace MiniInstagram_client
{
    public partial class Form1 : Form
    {
        //point current form 
        public static int currentPanelFormIndex = -1;
        public MiniInstagram_client.Form_home form_home = new MiniInstagram_client.Form_home();
        public MiniInstagram_client.Form_search form_Search = new MiniInstagram_client.Form_search();
        public MiniInstagram_client.Form_upload form_upload = new MiniInstagram_client.Form_upload();
        public MiniInstagram_client.Form_mypage form_mypage = new MiniInstagram_client.Form_mypage();
        public Form_empty form_empty = new Form_empty();

        public TcpClient client;
        public bool login = false;
        public string connectedID = null;
        public Socket socket;
        public Thread receiveThread;//대화수신용
        //public Thread imageReceiveThread;//이미지전용

        public NetworkStream networkStream;
        public StreamReader streamReader;
        public StreamWriter streamWriter;
        public bool connected = false;
        public Thread threadServer;
        public byte[] receivedBuffer;
        public bool receivedComplte = false;
        public int receivedLength;

        public Initialize initialize;
        public Packet entireInitialize;

        public Form1()
        {
            InitializeComponent();
            this.textBox_IP.Text = getMyIP();
        }

        public string getMyIP()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }

        public void loadForm(Form f)
        {
            //Console.WriteLine(this.panel_main.Controls.Contains(f));
            //Console.WriteLine(this.panel_main.Controls.Equals(f));
            //Console.WriteLine(this.panel_main.Controls.ToString());

            f.TopLevel = false;
            f.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Controls.Clear();
            this.panel_main.Controls.Add(f);
            f.FormBorderStyle = FormBorderStyle.None; // 상단 캡션 삭제
            f.Dock = DockStyle.Fill; // 화면에 가득 채움
            f.Show();
            //if (f.Equals(typeof(MiniInstagram_client.Form_home)))
        }

        private void pictureBox_home_Click(object sender, EventArgs e)
        {
            if (!login) return; 
            if (currentPanelFormIndex == 0)
                return;
            this.pictureBox_home.BackColor = Color.SkyBlue;
            this.pictureBox_search.BackColor = Color.White;
            this.pictureBox_upload.BackColor = Color.White;
            this.pictureBox_mypage.BackColor = Color.White;

            currentPanelFormIndex = 0;
            passSocket();
            loadForm(form_home);
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {
            if (!login) return;
            if (currentPanelFormIndex == 1)
                return;
            this.pictureBox_home.BackColor = Color.White;
            this.pictureBox_search.BackColor = Color.SkyBlue;
            this.pictureBox_upload.BackColor = Color.White;
            this.pictureBox_mypage.BackColor = Color.White;

            currentPanelFormIndex = 1;
            passSocket();
            loadForm(form_Search);
        }

        private void pictureBox_upload_Click(object sender, EventArgs e)
        {
            if (!login) return;
            if (currentPanelFormIndex == 2)
                return;

            this.pictureBox_home.BackColor = Color.White;
            this.pictureBox_search.BackColor = Color.White;
            this.pictureBox_upload.BackColor = Color.SkyBlue;
            this.pictureBox_mypage.BackColor = Color.White;

            currentPanelFormIndex = 2;
            passSocket();
            loadForm(form_upload);
        }

        private void pictureBox_mypage_Click(object sender, EventArgs e)
        {
            if (!login) return;
            
            if (currentPanelFormIndex == 3)
                return;

            this.pictureBox_home.BackColor = Color.White;
            this.pictureBox_search.BackColor = Color.White;
            this.pictureBox_upload.BackColor = Color.White;
            this.pictureBox_mypage.BackColor = Color.SkyBlue;

            this.form_mypage.GetPictureBox().Enabled = true;
            this.form_mypage.GetTextBox().ReadOnly = false;
            this.form_mypage.GetTextBox().Enabled = true;
            this.form_mypage.GetButton().Enabled = true;

            currentPanelFormIndex = 3;
            passSocket();
            loadForm(form_mypage);
            loadProfile();
            if (this.form_upload.isUpdated == true || this.form_mypage.isUpdated == true || this.form_Search.isSearch == true)
            {
                this.form_mypage.reload();
                requestHome();
                this.form_upload.isUpdated = false;
                this.form_mypage.isUpdated = false;
                this.form_Search.isSearch = false;
            }
        }

        public void loadProfile()
        {
            form_mypage.GetPictureBox().Image = this.initialize.account.profileImage;
            form_mypage.GetTextBox().Text = this.initialize.account.profileContent;
            form_mypage.GetLabelCount().Text = this.initialize.account.articleCount.ToString();
        }

        private void Button_Connect_Click(object sender, EventArgs e)
        {
            if (this.Button_Connect.Text.Equals("Connect"))
            {
                if (this.textBox_Port.Text == "")
                {
                    MessageBox.Show("포트 번호를 입력해주세요");
                    return;
                }
                this.Button_Connect.Text = "Disconnect";
                this.Button_Connect.ForeColor = Color.Red;
                connect();
            }
            else
            {
                this.Button_Connect.Text = "Connect";
                this.Button_Connect.ForeColor = Color.Black;
                disconnect();
            }
        }

        public void activate()
        {
            this.textBox_ID.ReadOnly = false;
            this.textBox_ID.Enabled = true;
            this.textBox_Password.ReadOnly = false;
            this.textBox_Password.Enabled = true;
            this.Button_Login.Enabled = true;
            this.Button_SignUp.Enabled = true;
            this.textBox_IP.ReadOnly = true;
            this.textBox_IP.Enabled = false;
            this.textBox_Port.ReadOnly = true;
            this.textBox_Port.Enabled = false;
        }
        public void deactivate()
        {
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Enabled = false;
            this.textBox_Password.ReadOnly = true;
            this.textBox_Password.Enabled = false;
            this.Button_Login.Enabled = false;
            this.Button_SignUp.Enabled = false;
            this.textBox_IP.ReadOnly = false;
            this.textBox_Port.ReadOnly = false;
            this.textBox_IP.Enabled = true;
            this.textBox_Port.Enabled = true;
        }

        private void connect()
        {
            string ipStr = this.textBox_IP.Text;
            string portStr = this.textBox_Port.Text;
            try
            {
                client = new TcpClient();
                IPAddress localAddr = IPAddress.Parse(ipStr);
                int port = int.Parse(portStr);
                IPEndPoint endPoint = new IPEndPoint(localAddr, port);
                socket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );
                socket.Connect(endPoint);
                receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.IsBackground = true;
                receiveThread.Start();
                connected = true;
                MessageBox.Show("서버에 연결되었습니다.");

                activate();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("서버에 연결할 수 없습니다.");
                this.Button_Connect.Text = "Connect";
                this.Button_Connect.ForeColor = Color.Black;
            }
            finally
            {
                client.Close();
            }
        }

        private void ImageReceive()
        {
            while (true)
            {
                byte[] imageBuffer = new byte[1024 * 1024 * 25];
                int length = socket.Receive(imageBuffer, imageBuffer.Length, SocketFlags.None);
            }
        }

        private void Receive()
        {
            while (true)
            {
                try {
                    receivedBuffer = new byte[1024 * 1024 * 25];
                    receivedLength = socket.Receive(receivedBuffer, receivedBuffer.Length, SocketFlags.None);
                    //receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, length);
                    receivedComplte = true;
                }
                catch(SocketException){
                }
            }
        }

        private void Send(string msg)
        {
            byte[] sendBuffer = Encoding.UTF8.GetBytes(msg);
            if(socket!=null)
                socket.Send(sendBuffer);
        }

        private void disconnect()
        {
            if(client!=null)
                client.Close();
            if(streamReader!=null)
                streamReader.Close();

            if(streamWriter!=null)
                streamWriter.Close();

            if(networkStream!=null)
                networkStream.Close();

            if(threadServer!=null)
                threadServer.Abort();
            if(receiveThread!=null)
                receiveThread.Abort();

            connected = false;
            this.textBox_IP.Text = getMyIP();
            this.textBox_Port.Text = "";

            deactivate();
        }

        private void Button_Login_Click(object sender, EventArgs e)
        {

            if(!connected)
            {
                MessageBox.Show("서버에 연결을 먼저 해주세요");
                return;
            }

            if (this.Button_Login.Text == "Login")
            {
                this.panel_main.Visible = true;
                loadForm(form_empty);
                currentPanelFormIndex = -1;
                requestLogin();
            }
            else
            {
                requestLogOut();
                this.panel_main.Visible = false;
            }
        }

        public void requestLogin()
        {
            string requestID = this.textBox_ID.Text;
            string requestPW = this.textBox_Password.Text;
            Send("login:"+requestID + "/" + requestPW);
            while (receivedComplte==false)
            {

            }
            string loginStatus = byteToString(receivedBuffer);
            processLoginStatus(loginStatus, requestID);
            receivedComplte = false;
        }
        
        public void processLoginStatus(string loginStatus, string id)
        {
            if (loginStatus.Contains("SUCCESS_LOGIN"))
            {
                connectedID = id;
                login = true;
                this.Button_Login.Text = "Logout";
                this.Button_Login.ForeColor = Color.Red;
            }
            else if (loginStatus.Contains("FAIL_LOGIN"))
            {
                MessageBox.Show("비밀번호가 다릅니다");
            }
            else
            {
                MessageBox.Show("존재하지 않는 아이디입니다.");
            }
        }
        
        public void requestLogOut()
        {
            login = false;
            Send("logout:" + connectedID);
            connectedID = null;
            this.Button_Login.Text = "Login";
            this.Button_Login.ForeColor = Color.Black;
            this.textBox_ID.Text = "";
            this.textBox_Password.Text = "";
            this.pictureBox_home.BackColor = Color.White;
            this.pictureBox_mypage.BackColor = Color.White;
            this.pictureBox_search.BackColor = Color.White;
            this.pictureBox_upload.BackColor = Color.White;
            
        }

        private void Button_SignUp_Click(object sender, EventArgs e)
        {
            string requestID = this.textBox_ID.Text;
            string requestPW = this.textBox_Password.Text;
            if (requestID == "")
            {
                MessageBox.Show("아이디를 입력 후 회원가입을 눌러주세요");
                return;
            }
            if (requestID.Contains(':'))
            {
                MessageBox.Show("아이디에는 ':' 이 들어갈 수 없습니다.");
                return;
            }
            if(requestPW == "")
            {
                MessageBox.Show("비밀번호를 입력 후 회원가입을 눌러주세요");
                return;
            }
            
            requestSignUp(requestID, requestPW);
        }

        public void requestSignUp(string requestID, string requestPW)
        {
            Send("signup:" + requestID + "/" + requestPW);
            while (receivedComplte==false)
            {

            }
            string signupStatus = byteToString(receivedBuffer);
            processSignupStatus(signupStatus, requestID);
            receivedComplte = false;
        }

        public void processSignupStatus(string loginStatus, string id)
        {

            if (loginStatus.Contains("SUCCESS_SIGNUP"))
            {
                MessageBox.Show("회원가입 되었습니다.");
            }
            else if(loginStatus.Contains("OCCUPIED"))
            {
                MessageBox.Show("이미 존재하는 아이디입니다.");
            }
            else
            {
                MessageBox.Show("회원가입에 문제가 발생하였습니다.");
            }
        }
        
        public void passSocket()
        {
            switch (currentPanelFormIndex)
            {
                case 0:
                    form_home.linkParent(this);
                    requestHome();
                    break;
                case 1:
                    form_Search.linkParent(this);
                    break;
                case 2:
                    form_upload.linkParent(this);
                    break;
                case 3:
                    form_mypage.linkParent(this);
                    requestMypage();
                    break;
            
            }

        }

        public void requestHome()
        {
            if (!login)
                return;
            
            Send("homepage:" + connectedID);
            while (receivedComplte == false)
            {

            }
            this.entireInitialize = (Packet)Packet.Desserialize(receivedBuffer);
            receivedComplte = false;
            showEntireArticles();
        }

        private void showEntireArticles()
        {
            try
            {
                Packet initPacket = this.entireInitialize;
                LinkedList<Article> contentsList = initPacket.account.contents;
                Panel p = form_home.getPanel();
                p.Controls.Clear();
                p.HorizontalScroll.Enabled = true;
                p.Visible = true;

                int profileImageHeight = 30;
                int imageHeight = p.Height - 20;
                int contentHeight = 100;

                int eachArticleSize = profileImageHeight + imageHeight + contentHeight;
                for(int i= initPacket.account.articleCount-1;i>=0;i--)
                {
                    Article nextArticle = contentsList.ElementAt(i);
                    addProfileBox(p, nextArticle, initPacket.account, i, eachArticleSize, profileImageHeight);
                    addPictureBox(p, nextArticle, i, eachArticleSize, profileImageHeight, imageHeight);
                    addContentBox(p, nextArticle, i, eachArticleSize, profileImageHeight, imageHeight);
                }
                p.Visible = true;
            }
            catch(NullReferenceException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void addProfileBox(Panel p,Article nextArticle,Account a, int i, int articleSize, int profileImageHeight)
        {
            //프로필사진추가
            int profileImageWidth = 30;
            PictureBox pb = new PictureBox();
            Image profileImage = nextArticle.profile_image;
            if (profileImage == null)
                pb.Image = Properties.Resources.profile_img;
            else
                pb.Image = profileImage;
            pb.Size = new Size(profileImageWidth, profileImageHeight); // 30,30
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Location = new Point(0, i * articleSize);
            p.Controls.Add(pb);

            //프로필아이디추가
            Label tb = new Label();
            tb.Text = nextArticle.account;
            tb.Location = new Point(profileImageWidth + 5, i * articleSize);
            p.Controls.Add(tb);
        }

        public void addPictureBox(Panel p, Article article, int i, int articleSize, int profileImageHeight, int imageHeight)
        {

            PictureBox pb = new PictureBox();
            pb.Image = article.image;
            pb.Size = new System.Drawing.Size(p.Width, imageHeight);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Location = new Point(0, i * articleSize + profileImageHeight);
            p.Controls.Add(pb);
        }
        public void addContentBox(Panel p, Article article, int i, int articleSize, int profileImageHeight, int imageHeight)
        {
            TextBox tb = new TextBox();
            tb.Size = new System.Drawing.Size(p.Width, tb.Size.Height);
            tb.Multiline = true;
            tb.Text = article.content;
            tb.Location = new Point(0, i * articleSize + profileImageHeight + imageHeight);
            tb.ReadOnly = true;
            tb.Enabled = false;
            p.Controls.Add(tb);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            requestLogOut();
            disconnect();
        }

        private void requestMypage()
        {
            if (!login)
                return;

            Send("mypage:" + connectedID);
            while (receivedComplte ==false)
            {

            }
            processRequestMypage(receivedBuffer);
            receivedComplte = false;
        }

        public void processRequestMypage(byte[] buf)
        {
            this.initialize = (Initialize)Packet.Desserialize(buf);
            //MessageBox.Show("계정정보 수신완료");

        }

        public static byte[] Decode(byte[] packet)
        {
            var i = packet.Length - 1;
            while (packet[i] == 0)
            {
                --i;
            }
            var temp = new byte[i + 1];
            Array.Copy(packet, temp, i + 1);
            MessageBox.Show(temp.Length.ToString());
            return temp;
        }
        
        public byte[] stringToByte(string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }

        public string byteToString(byte[] b)
        {
            return Encoding.ASCII.GetString(b);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void showOther(string otherID)
        {
            if (!login)
                return;

            if (currentPanelFormIndex == 3)
                return;

            this.pictureBox_home.BackColor = Color.White;
            this.pictureBox_search.BackColor = Color.White;
            this.pictureBox_upload.BackColor = Color.White;
            this.pictureBox_mypage.BackColor = Color.SkyBlue;

            this.form_mypage.GetPanel().Controls.Clear();
            Send("mypage:" + otherID);
            while (receivedComplte == false)
            {

            }
            processRequestMypage(receivedBuffer);
            receivedComplte = false;

            this.form_mypage.GetButton().Enabled = false;
            this.form_mypage.GetTextBox().Enabled = false;
            this.form_mypage.GetTextBox().ReadOnly = true;
            this.form_mypage.GetPictureBox().Enabled = false;

            currentPanelFormIndex = 3;
            form_mypage.linkParent(this);
            loadForm(form_mypage);
            loadProfile();
            form_mypage.reload();
            
        }
    }
}
