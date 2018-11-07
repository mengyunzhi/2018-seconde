using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1实验二
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string a,b;
            a = Convert.ToString(Convert.ToDouble(this.textBox3.Text) + Convert.ToDouble(this.textBox4.Text)+ Convert.ToDouble(this.textBox5.Text));
            b = Convert.ToString(Convert.ToDouble(a) / 3.0);
            string newrecord = this.textBox1.Text + " " + this.textBox2.Text + " " + this.textBox3.Text + " " + this.textBox4.Text + " " + this.textBox5.Text +" "+a +" "+b+"\r\n";
            File.AppendAllText("E:\\wenjian.txt", newrecord, UTF8Encoding.Default);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //结束form2的调用
            this.Dispose(false);
        }
    }
}
