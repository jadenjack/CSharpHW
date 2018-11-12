using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MiniInstagram_client
{
    public partial class Form_search : Form
    {
        public Form1 parentForm;
        public bool isSearch = false;
        public Socket socket;
        public Form_search()
        {
            InitializeComponent();
        }

        public void linkParent(Form1 form1)
        {
            parentForm = form1;
            this.socket = parentForm.socket;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (!parentForm.connected) { 
                MessageBox.Show("서버 연결을 먼저 해주세요");
                return;
            }

            string findIDTarget = this.textBox_search.Text;
            //send request
            Send("findid:"+findIDTarget);
            //wait
            while (parentForm.receivedComplte == false)
            {

            }
            string receivedMessage = parentForm.byteToString(parentForm.receivedBuffer);
            string[] findIDs = receivedMessage.Split(':');
            parentForm.receivedComplte = false;
            //clear items list
            this.listBox_searchList.Items.Clear();
            //add items
            foreach (string eachID in findIDs)
            {
                if (eachID.Length != 0)
                {
                    if (eachID.Equals(this.parentForm.connectedID))
                        continue;
                    this.listBox_searchList.Items.Add(eachID);
                }
            }
            this.listBox_searchList.Refresh();
        }

        private void Form_search_Load(object sender, EventArgs e)
        {

        }

        private void Send(string msg)
        {
            byte[] sendBuffer = Encoding.UTF8.GetBytes(msg);
            socket.Send(sendBuffer);
        }

        private void listBox_searchList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox_searchList.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                isSearch = true;
                string selectedID = this.listBox_searchList.SelectedItem.ToString();
                if (selectedID == null)
                    return;

                this.parentForm.showOther(selectedID);
            }
        }
    }
}
