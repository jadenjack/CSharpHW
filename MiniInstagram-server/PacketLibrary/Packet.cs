using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace PacketLibrary
{
    public enum PacketType
    {
        초기화 = 0,
        로그인
    }
    public enum PacketSendError
    {
        정상 = 0,
        에러
    }
    [Serializable]
    public class Packet
    {
        public Account account;

        public Packet()
        {
            account = new Account();
        }
        public Packet(Account a)
        {
            this.account = a;
        }
        public static byte[] Serialize(object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(bt.Length);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }

        [Serializable]
        public class Initialize : Packet
        {
            public int Data = 0;

        }

        [Serializable]
        public class Login : Packet
        {
            public string m_strID;
            public Login()
            {
                this.m_strID = null;
            }
        }

        [Serializable]
        public class Article
        {
            public string account;
            public string filename;
            public string content;
            public Image image;
            public string profile_text;
            public Image profile_image;
            
            public Article(string accountName, string fileName)
            {
                this.account = accountName;
                this.filename = fileName;
            }
        }
        [Serializable]
        public class Account
        {
            public int articleCount = 0;
            public string name = null;
            public Image profileImage = null;
            public string profileContent = null;
            public LinkedList<Article> contents;
        }
    }
   

}
