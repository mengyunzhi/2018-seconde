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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        static int order = 0;
        static int[] numbers=new int[3] { 0,0,0};
       
        private void Insert_Click(object sender, EventArgs e)
        {
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string file = File.ReadAllText("d:\\Data.txt", UTF8Encoding.Default);
            string total = (int.Parse (this.textBox3.Text) + int.Parse (this.textBox4.Text) + int.Parse (this.textBox5.Text)).ToString ();
            string average= ((int.Parse(this.textBox3.Text) + int.Parse(this.textBox4.Text) + int.Parse(this.textBox5.Text))/3).ToString();
            if (int.Parse(this.textBox1.Text.ToString()) >= 60 && int.Parse(this.textBox1.Text.ToString()) < 70)
            {

            }
            string num;
            num = (++order).ToString();
            string newrecord = this.textBox1.Text + " " + this.textBox2.Text + " " + this.textBox3.Text + " " + this.textBox4.Text + " " + this.textBox5.Text + " "+total+" "+average +" "+num+"\r\n";
            //追加记录到txt文件中
            File.AppendAllText("d:\\Data.txt", newrecord, UTF8Encoding.Default);
            
            //结束form2的调用
            this.Dispose(false);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Text = "";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
