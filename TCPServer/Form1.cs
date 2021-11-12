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
using System.Net;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server sv = new Server(IPAddress.Parse(textBox1.Text), Int32.Parse(textBox2.Text), "", 8 * 1024);
             sv.Start();
            MessageBox.Show("server dang chay");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Input IP") return;
            textBox1.Text = " ";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "Input Port") return;
            textBox2.Text = " ";
            textBox2.ForeColor = Color.Black;
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

        private void Automatic(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                textBox1.Text = "127.0.0.1";
                textBox2.Text = "8080";
            }    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
