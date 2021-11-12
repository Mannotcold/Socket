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
namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //can tim cach tach ra 1 class rieng lun phan nay là connect
            IPEndPoint IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(IP);
            //gui thong bao cho server
            byte[] buf = Encoding.UTF8.GetBytes("test");
            client.Send(buf);


            MessageBox.Show("Kết nối thành công");

            //chuyen qua form client
            Client add = new Client();
            add.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tat form
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                textBox1.Text = "127.0.0.1";
                textBox2.Text = "8080";
            }
        }

        private void textBox2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "Input Port") return;
            textBox2.Text = " ";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "Input IP") return;
            textBox1.Text = " ";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "") return;
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Input IP";
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "") return;
            textBox2.ForeColor = Color.Gray;
            textBox2.Text = "Input Port";
        }
    }
}
