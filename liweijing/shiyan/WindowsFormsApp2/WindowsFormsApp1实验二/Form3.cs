using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1实验二
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //结束form3的调用
            this.Dispose(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = this.textBox1.Text;
            //把txt文件内容读入到file中，然后对string对象file进行相关处理
            string file = File.ReadAllText("E:\\wenjian.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            for (int index = 0; index < records.Length; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                if (q == components[0] || q == components[1])
                {
                    this.textBox2.Text = components[2];
                    this.textBox3.Text = components[3];
                    this.textBox4.Text = components[4];
                    break;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
