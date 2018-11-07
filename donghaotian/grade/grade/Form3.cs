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

namespace 大实验成绩管理
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            string q = this.textBox1.Text;
            // 把txt文件内容读入到file中，然后对string对象file进行相关处理
            string file = File.ReadAllText("D:\\Data.txt", UTF8Encoding.Default);

            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");

            for (int index = 0; index < records.Length; index++)
            {   
                // 分割每行记录的各个字段
                string[] Form1 = Regex.Split(records[index], " ");
                if (q == Form1[0] || q == Form1[1])
                {
                    this.textBox2.Text = Form1[2];
                    this.textBox3.Text = Form1[3];
                    this.textBox4.Text = Form1[4];
                    break;

                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

       