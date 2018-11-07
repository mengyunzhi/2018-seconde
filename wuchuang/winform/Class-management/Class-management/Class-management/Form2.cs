using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serve
{
    public partial class Form2 : Form
    {

        public static Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string newrecord = this.textBox1.Text + " " + this.textBox2.Text + " " + this.textBox3.Text + " " + this.textBox4.Text + " " + this.textBox5.Text;
            string[] numberarray = Regex.Split(newrecord, " ");
            double x = 0, y = 0;
            for (int j = 2; j < 5; j++)
            {
                x += Convert.ToDouble(numberarray[j]);
                if (j == 4)
                    y = x / 3;
            }

            newrecord = newrecord + " " + x.ToString("f2") + " " + y.ToString("f2") + "\r\n";
            File.AppendAllText("E:\\data.txt", newrecord, UTF8Encoding.Default);

            Form2.form1.show();
            //结束form2的调用
            this.Dispose(false);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
        }
    }
}
