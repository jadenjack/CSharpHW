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
using System.Reflection;
using static PacketLibrary.Packet;

namespace MiniInstagram_server
{
    

    public partial class Form1 : Form
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        private Thread m_Threader;

        Socket listenSocket;

        public bool m_bStop = false;

        private TcpListener m_listener;
        private Thread m_thServer;
        public Thread receiveThread;

        public bool m_bConnect = false;
        public Socket clientSocket;//연결된 클라이언트 소켓

        public String ROOT_DIR = Directory.GetCurrentDirectory();
        public const String ACCOUNT_DIR = "\\accounts";
        public const String IMAGE_DIR = "\\images";
        public const String CONTENT_DIR = "\\content";
        public const String PASSWORD_FILE_NAME = "password.txt";
        public const String ARTICLES_FILE_NAME = "articles.txt";
        public const String PROFILE_FILE_NAME = "\\profile.bmp";
        public const String PROFILE_CONTENT_NAME = "\\profiletext.txt";
        public String CONTENT_LIST = "\\list.txt";

        public String IP_ADDRESS;
        public int accountIndex = 0;
        public Image p = null;


        public string messageType;
        public string accountDirPath;
        public string articleListPath;

        DirectoryInfo[] accountDirList;
        DirectoryInfo accountDir;

        public Packet.Account currentAccount = null;

        TextBox log;

        Assembly _assembly;
        Stream _imageStream;

        public int bufferSize = 0;

        delegate void ReloadListView();

        public Form1()
        {
            InitializeComponent();
            log = this.logTextBox;
            IP_ADDRESS = getMyIP();
            this.ip.Text = IP_ADDRESS;
        }

        public string getMyIP()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
            this.Close();

            _assembly = Assembly.GetExecutingAssembly();
            _imageStream = _assembly.GetManifestResourceStream("profile_img.jpg");
        }

        private void start_Click(object sender, EventArgs e)
        {
            //Start눌렀을때
            if(this.start.Text == "Start")
            {
                
                int portnum;

                //포트번호 넣었는지 확인
                if(this.port.Text.Length ==0)
                {
                    MessageBox.Show("Port번호를 입력해주세요");
                    return;
                }
                try
                {
                    portnum = int.Parse(this.port.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("포트번호에는 숫자만 입력해주세요");
                    return;
                }
                this.start.Text = "Stop";
                this.start.ForeColor = Color.Red;
                this.port.ReadOnly = true;
                this.port.Enabled = false;
                //서비스시작
                startService(portnum);
            }
            else
            {
                //스탑버튼눌렀을때
                this.start.Text = "Start";
                this.start.ForeColor = Color.Black;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    log.AppendText("Server stoped \r\n");
                }));
                Disconnect();
                ServerStop();
                this.port.ReadOnly = false;
                this.port.Enabled = true;
            }
        }

        public void startService(int portnum)
        {
            //int port = 13000;
            IPAddress local = IPAddress.Parse(IP_ADDRESS);

            //유저 목록 로드
            serviceInit();
            //서비스 쓰레드 실행
            m_thServer = new Thread(new ThreadStart(Listen));
            m_thServer.IsBackground = true;
            m_thServer.Start();
            
        }
        
        public void Listen()
        {
            IPAddress iPAddress = IPAddress.Parse(IP_ADDRESS);
            IPEndPoint endPoint = new IPEndPoint(iPAddress, int.Parse(this.port.Text));

            listenSocket = new Socket
            (
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );
            
            listenSocket.Bind(endPoint);
            listenSocket.Listen(10);

            this.Invoke(new MethodInvoker(delegate ()
            {
                log.AppendText("서버가 시작되었습니다.\n");
                log.AppendText("Storage Path : " + ROOT_DIR + "\n");
                log.AppendText("클라이언트 요청 대기중\n");
            }));
            try
            {
                //연결
                clientSocket = listenSocket.Accept();

                this.Invoke(new MethodInvoker(delegate ()
                {
                    log.AppendText("클라이언트 접속됨\n");
                }));
                receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch
            {

            }
        }

        private void Receive()
        {
            while (true)
            {
                try
                {
                    byte[] receiveBuffer;
                    if (bufferSize == 0)
                        receiveBuffer = new byte[512];
                    else
                        receiveBuffer = new byte[bufferSize];

                    int length = clientSocket.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
                    string msg = Encoding.UTF8.GetString(receiveBuffer,0,length);
                    
                    //this.Invoke(new MethodInvoker(delegate ()
                    //{
                        //log.AppendText("수신 : " + msg + "\r\n");
                    //}));
                    
                    requestProcess(msg);

                }catch(SocketException ex)
                {
                    clientSocket.Close();
                }catch(ObjectDisposedException ex)
                {
                    Disconnect();
                }
            }
        }
        private void Send(string msg)
        {
            byte[] sendBuffer = Encoding.UTF8.GetBytes(msg);
            Send(sendBuffer);
        }
        private void Send(byte[] msg)
        {
            clientSocket.Send(msg);
        }


        public void requestProcess(string message)
        {
            string[] splitedMessage = message.Split(':');
            messageType = splitedMessage[0];
            string secondMessage;
            try
            {
                secondMessage = splitedMessage[1];
            }catch(IndexOutOfRangeException ex)
            {
                //클라이언트 강제종료시 발생
                return;
            }
            switch (messageType)
            {
                case "login":
                    processLogin(secondMessage);
                    bufferSize = 0;
                    break;
                case "signup":
                    processSignUp(secondMessage);
                    bufferSize = 0;
                    break;
                case "logout":
                    processLogout(secondMessage);
                    bufferSize = 0;
                    break;
                case "findid":
                    processFindID(secondMessage);
                    bufferSize = 0;
                    break;
                case "uploadinfo":
                    processImageInfo(splitedMessage);
                    break;
                case "mypage":
                    processMypage(secondMessage);
                    break;
                case "updateprofile":
                    processProfileUpdate(splitedMessage);
                    break;
                case "homepage":
                    processHomePage();
                    break;

            }
            if(p!=null)
                p.Dispose();
        }

        public void processHomePage()
        {
            string listPath = accountDirPath + CONTENT_LIST;
            Account entireAccount = new Account();
            entireAccount.contents = new LinkedList<Article>();
            int count = 0;

            if (!File.Exists(listPath))
            {
                byte[] emtpyAccount = ObjectToByteArray(entireAccount);
                SendPacket(emtpyAccount);
                return;
            }
            string line;
            StreamReader sr = new StreamReader(listPath, System.Text.Encoding.UTF8);
            Article a = null;
            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split(':');
                string id = split[0];
                string imageName = split[1];
                a = new Article(id, imageName);
                a.image = Image.FromFile(accountDirPath + "\\" + id + IMAGE_DIR + "\\" + imageName);
                a.content = File.ReadAllText(accountDirPath + "\\" + id + CONTENT_DIR + "\\" + imageName + ".txt");
                string profileImage = accountDirPath + "\\" + id + PROFILE_FILE_NAME;
                if (File.Exists(profileImage))
                {
                    a.profile_image = Image.FromFile(profileImage);
                }
                else {
                    a.profile_image = Properties.Resources.profile_img;
                }
                
                count++;
                entireAccount.contents.AddFirst(a);
            }
            Packet p = new Packet(entireAccount);
            p.account.articleCount = count;
            byte[] accountPacket = Packet.Serialize(p);
            Send(accountPacket);

            if (a != null)
            {
                a.profile_image.Dispose();
                a.image.Dispose();
                a = null;
            }
            sr.Close();
           
        }


        public void processProfileUpdate(string[] splitedMessage)
        {
            int size = int.Parse(splitedMessage[1]);
            string requestID = splitedMessage[2];
            string requestContent = splitedMessage[3];

            byte[] imageData = new byte[size];
            clientSocket.Receive(imageData, imageData.Length, SocketFlags.None);

            string updatedAccountPath = this.accountDirPath + "\\" + requestID;
            string updatedProfileImagePath = updatedAccountPath + PROFILE_FILE_NAME;
            string updatedProfileContentPAth = updatedAccountPath + PROFILE_CONTENT_NAME;


            if (File.Exists(updatedProfileContentPAth))
                File.Delete(updatedProfileContentPAth);

            File.WriteAllText(updatedProfileContentPAth, requestContent, Encoding.UTF8);
            /*
            FileStream fs = File.Create(updatedProfileContentPAth);
            byte[] bytesContent = Encoding.UTF8.GetBytes(requestContent);
            fs.Write(bytesContent, 0,requestContent.Length);
            fs.Close();
            */

            processImageUpload(updatedProfileImagePath, imageData);
        }

        public void processImageUpload(string path, byte[] imageData)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            
            Image i = (Bitmap)((new ImageConverter()).ConvertFrom(imageData));
            i.Save(path);
            i.Dispose();
            i = null;
        }


        public void processMypage(string requestID)
        {
            initAccount(requestID);
            byte[] byteArray = ObjectToByteArray(this.currentAccount);
            SendPacket(byteArray);
        }

        private void SendPacket(byte[] byteArray)
        {
            Initialize init = new Initialize();
            init.account = this.currentAccount;

            
            byte[] accountPacket = Packet.Serialize(init);
            Send(accountPacket);          
        }
        public void processImageInfo(string[] messages)
        {
            /*
             * messages array
             * 0 : "uploadinfo:"
             * 1 : image size
             * 2 : account id
             * 3 : image name
             */

             //이미지저장
            int size = int.Parse(messages[1]);
            byte[] imageData = new byte[size];
            clientSocket.Receive(imageData, imageData.Length, SocketFlags.None);
            processImageUpload(messages[2], messages[3], imageData);


            //컨텐츠(내용) 저장
            byte[] contentData = new byte[512];
            clientSocket.Receive(contentData, contentData.Length, SocketFlags.None);
            processContentsOfImage(messages[3],messages[2],contentData);

            //contents.txt.파일에추가
            addContentList(messages);

            //전체 리스트에 추가
            string listPath = accountDirPath + CONTENT_LIST;
            if (!File.Exists(listPath))
                File.Create(listPath).Close();

            FileStream fs = new FileStream(listPath,FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.WriteLine(messages[2] + ":" + messages[3]);
            sw.Close();
            fs.Close();
        }
        
        public void addContentList(string[] messages)
        {
            /*
            string size = messages[1];
            */

            string account = messages[2];
            string imageName = messages[3];
            //파일 저장된 로그기록 형식
            string accountPath = ROOT_DIR + ACCOUNT_DIR + "\\" + account;
            string articlesListFilePath = accountPath + "\\" + ARTICLES_FILE_NAME;

            StreamWriter sw = File.AppendText(articlesListFilePath);
            sw.WriteLine(imageName);
            sw.Close();
        }

        public void processContentsOfImage(string imagename, string id, byte[] contentData)
        {
            string contentDir = accountDirPath + "\\" + id + CONTENT_DIR;
            if (!Directory.Exists(contentDir))
            {
                Directory.CreateDirectory(contentDir);
            }
            string contentPath = contentDir + "\\" + imagename + ".txt";
            ByteArrayToFile(contentPath, contentData);
        }

        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    log.AppendText("파일쓰기 실패");
                }));
                return false;
            }
        }

        public void processImageUpload(string id,string imageName, byte[] imageData)
        {
            Image i = (Bitmap)((new ImageConverter()).ConvertFrom(imageData));
            Image newImage = new Bitmap(i);
            i.Dispose();
            i = null;
            string imagePath = accountDirPath + "\\" + id + IMAGE_DIR;
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            newImage.Save(imagePath + "\\" + imageName);

            /*
            this.Invoke(new MethodInvoker(delegate ()
            {
                log.AppendText("이미지 수신완료\n");
            }));
            */

        }

        public void processFindID(string findID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            foreach(DirectoryInfo acc in accountDirList)
            {
                //아이디가 일치하는 부분을 포함하고있으면 
                if (acc.Name.Contains(findID))
                {
                    sb.Append(acc.Name);
                    sb.Append(":");//아이디별로 구분문자
                }
            }
            Send(sb.ToString());
        }

        public void processLogout(string logoutID)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                log.AppendText(logoutID + " >> LogOut\n");
            }));
        }

        public void processLogin(string message)
        {
            string[] splitedMessage = message.Split('/');
            string requestID = splitedMessage[0];
            string requestPW = splitedMessage[1];

            try
            {
                foreach (DirectoryInfo acc in accountDirList)
                {
                    if (acc.Name.Equals(requestID))
                    {
                        StreamReader fileStream = new StreamReader(accountDirPath + "\\" + acc.Name + "\\" + PASSWORD_FILE_NAME, System.Text.Encoding.UTF8);
                        string correctPW = fileStream.ReadLine();
                        if (correctPW == requestPW)
                        {
                            //로그인성공
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                log.AppendText(requestID + " >> LogIn\n");
                            }));
                            Send("SUCCESS_LOGIN");

                            initAccount(requestID);
                        }
                        else
                        {
                            Send("FAIL_LOGIN");
                            //비밀번호가 달라서 로그인실패
                        }
                        fileStream.Close();
                        return;
                    }
                }
                Send("NO_ACCOUNT");
                //해당하는 아이디없음
            }
            catch
            {
                MessageBox.Show("데이터 전송 실패 in processLogin");
            }
        }

        public void initAccount(string requestID)
        {
            currentAccount = new Account();
            currentAccount.name = requestID;
            initAccountArticles(currentAccount);
        }

        public void initAccountArticles(Account a)
        {
            a.contents = new LinkedList<Article>();
            int numOfArticles = 0;
            //ROOT/account/
            string accountPath = ROOT_DIR + ACCOUNT_DIR + "\\" + a.name;
            string articlesListFilePath = accountPath + "\\" + ARTICLES_FILE_NAME;

            try
            {
                if (!File.Exists(articlesListFilePath))
                    File.Create(articlesListFilePath).Close();
            }catch(ArgumentException ar)
            {
                return;
            }

            StreamReader sr = new StreamReader(articlesListFilePath, System.Text.Encoding.UTF8);
            StreamReader contentReader = null;

            string articleName;
            string contentPath = accountPath + CONTENT_DIR + "\\";
            string imagePath = accountPath + IMAGE_DIR + "\\";

            //로그인 한 후에 계정 클래스 초기화
            while((articleName = sr.ReadLine()) != null)
            {
                //게시글의 이름, 작성자 초기화
                Article addItem = new Article(a.name,articleName);
                contentReader = new StreamReader(contentPath + articleName + ".txt", System.Text.Encoding.UTF8);
                //게시글의 내용 초기화
                addItem.content = contentReader.ReadToEnd();
                //게시글의 이미지 초기화
                addItem.image = Image.FromFile(imagePath + articleName);
                numOfArticles++;
                a.contents.AddLast(addItem);
            }
            a.articleCount = numOfArticles;
            sr.Close();
            if(contentReader!=null)
                contentReader.Close();

            //프로필사진초기화
            //문제
            string profilePath = accountPath + PROFILE_FILE_NAME;
            if (File.Exists(profilePath))
            {
                p = Image.FromFile(profilePath);
                a.profileImage = p;
                
            }
            else
            {
                a.profileImage = new Bitmap(MiniInstagram_server.Properties.Resources.profile_img);
            }

            //프로필내용초기화
            string profileContentPath = accountPath + PROFILE_CONTENT_NAME;
            if (File.Exists(profileContentPath))
            {
                StreamReader s = new StreamReader(profileContentPath, System.Text.Encoding.UTF8);
                a.profileContent = s.ReadLine();
                s.Close();
            }
        }
        public void processSignUp(string message)
        {
            string[] splitedMessage = message.Split('/');
            string requestID = splitedMessage[0];
            string requestPW = splitedMessage[1];

            try
            {
                string newAccountPath = accountDirPath + "\\" + requestID;
                if (Directory.Exists(newAccountPath))
                {
                    //이미 존재하는 아이디
                    Send("OCCUPIED");
                    return;
                }

                //존재하지 않는아이디이므로 가입.
                byte[] pwBytes = Encoding.UTF8.GetBytes(requestPW);
                DirectoryInfo newAccount = Directory.CreateDirectory(newAccountPath);
                string newAccountPWPath = newAccountPath + "\\" + PASSWORD_FILE_NAME;
                FileStream newAccountPWFile = File.Create(newAccountPWPath);
                newAccountPWFile.Write(pwBytes, 0, pwBytes.Length);
                newAccountPWFile.Close();

                Send("SUCCESS_SIGNUP");
                //가입후 리스트뷰 다시로드
                crossThreadListViewReload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("메시지 전송 실패 in requestProcess");
            }
        }

        private void crossThreadListViewReload()
        {
            if (this.InvokeRequired)
            {
                ReloadListView reload = new ReloadListView(crossThreadListViewReload);
                this.Invoke(reload, new Object[] { });
            }
            else
            {
                this.memberList.Items.Clear();
                loadMemberListView();
            }
        }

        private void serviceInit()
        {
            //ip, port번호 초기화
            accountDirPath = Directory.GetCurrentDirectory() + ACCOUNT_DIR;

            //account 관리하는 폴더가 없으면 만들기
            if (!Directory.Exists(accountDirPath)){
                Directory.CreateDirectory(accountDirPath);
            }
            //this.ip.Text = IP_ADDRESS;

            //아이디 리스트 불러오기
            loadMemberListView();
            loadContents();
        }

        public void loadContents()
        {
            LinkedList<Article> articleList = new LinkedList<Article>();
            articleListPath = Directory.GetCurrentDirectory() + ARTICLES_FILE_NAME;

            if (!File.Exists(articleListPath))
                File.Create(articleListPath).Close();

            StreamReader sr = new StreamReader(articleListPath, System.Text.Encoding.UTF8);
            string line;
            while((line = sr.ReadLine()) != null)
            {
                //파일분류
            }
        }

        public void loadMemberListView()
        {
            DirectoryInfo accountDir = new DirectoryInfo(accountDirPath);//root/account
            accountIndex = 0;
            ListView memberListView = this.memberList;
            //accountDirList = accountDir.GetDirectories("*", System.IO.SearchOption.AllDirectories);
            accountDirList = accountDir.GetDirectories("*");
            foreach (DirectoryInfo acc in accountDirList)
            {
                var lvwItem = new ListViewItem(new string[memberListView.Columns.Count]);
                accountIndex++;
                lvwItem.SubItems[0].Text = accountIndex.ToString();
                lvwItem.SubItems[1].Text = acc.Name;

                // filename : root/account/a_acount/password.txt
                StreamReader fileStream = new StreamReader(accountDirPath + "\\" + acc.Name + "\\" + PASSWORD_FILE_NAME, System.Text.Encoding.UTF8);
                lvwItem.SubItems[2].Text = fileStream.ReadLine();
                fileStream.Close();

                memberListView.Items.Add(lvwItem);
            }
            memberListView.Refresh();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listViewInit();
        }

        private void listViewInit()
        {
            ListView memberListView = this.memberList;
            memberListView.View = View.Details;
            memberListView.Columns.Add("Index", "Index");
            memberListView.Columns.Add("ID", "ID");
            memberListView.Columns.Add("Password", "Password");
            memberListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for(int i=0;i<memberListView.Columns.Count;i++)
            {
                memberListView.Columns[i].TextAlign = HorizontalAlignment.Left;
            }
            
            memberListView.Columns[0].Text = "Index";
            memberListView.Columns[1].Text = "ID";
            memberListView.Columns[2].Text = "Password";
        }

        public void ServerStop()
        {
            if (!m_bStop)
                return;


            m_listener.Stop();
            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_Stream.Close();
            m_Threader.Abort();
            m_thServer.Abort();
            receiveThread.Abort();


        }

        public void Disconnect()
        {
            if (m_bConnect)
                return;

            m_bConnect = false;

            if(m_Read!=null)
                m_Read.Close();

            if(m_Write!=null)
                m_Write.Close();

            if(m_Stream!=null)
                m_Stream.Close();

            if(m_Threader!=null)
                m_Threader.Abort();

            if (receiveThread != null)
                receiveThread.Abort();

            currentAccount = null;
            listenSocket.Close();
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

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
    }
}
