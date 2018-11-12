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

namespace MiniInstagram_client
{
    public partial class Form_home : Form
    {
        public Form1 parentForm;
        public Socket socket;
        public Form_home()
        {
            InitializeComponent();
        }

        public void linkParent(Form1 form1)
        {
            parentForm = form1;
            this.socket = parentForm.socket;
        }

        private void Form_home_Load(object sender, EventArgs e)
        {
            this.panel1.HorizontalScroll.Enabled = true;
        }

        public Panel getPanel()
        {
            return this.panel1;
        }
    }
}
