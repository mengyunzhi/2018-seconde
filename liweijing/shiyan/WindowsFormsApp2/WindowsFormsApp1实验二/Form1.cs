using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1实验二
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.listView1.Columns.Add("学号", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("姓名", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("数学", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("英语", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("政治", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("总分", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("平均分", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("名次", 100, HorizontalAlignment.Center);
            this.listView1.View = System.Windows.Forms.View.Details;
            string file = File.ReadAllText("E:\\wenjian.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                //生成listview的一行
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.Pink;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //把txt文件内容读入到file中，然后对string对象file进行相关处理
            string file = File.ReadAllText("E:\\wenjian.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            for (int index = 0; index < records.Length; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                string a, b, c, d;
                a = components[4];
                b = components[3];
                c = components[2];
                d = Convert.ToString(Convert.ToDouble(a) + Convert.ToDouble(b) + Convert.ToDouble(c));
                string newrecord = components[0] + " " + components[1] + " " + components[2] + " " + components[3] + " " + components[4] + " " + d + "\r\n";
                File.AppendAllText("E:\\fujian.txt", newrecord, UTF8Encoding.Default);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //把txt文件内容读入到file中，然后对string对象file进行相关处理
            string file = File.ReadAllText("E:\\wenjian.txt", UTF8Encoding.Default);
            //写文件，把string对象file中的内容写入txt文件中
            File.WriteAllText("E:\\wenjian.txt", file, UTF8Encoding.Default);


            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            //开始更新视图
            this.listView1.BeginUpdate();
            //清空原有视图
            this.listView1.Items.Clear();
            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                //生成listview的一行
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.Pink;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
            //视图更新结束
            this.listView1.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x;
            x = this.listView1.SelectedItems[0].Index;
            listView1.Items.RemoveAt(this.listView1.SelectedItems[0].Index);
            int counter = 0;
            String line;
            List<String> lines = new List<String>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"E:\wenjian.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (counter != x)
                {
                    lines.Add(line);
                }
                counter++;
            }
            file.Close();
            File.WriteAllLines(@"E:\wenjian.txt", lines, UTF8Encoding.Default);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            string newrecord = "分数段" + " " + "数学" + " " + "英语" + " " + "政治" + "\r\n";
            File.AppendAllText("E:\\fujian.txt", newrecord, UTF8Encoding.Default);
            //把txt文件内容读入到file中，然后对string对象file进行相关处理
            string file = File.ReadAllText("E:\\wenjian.txt", UTF8Encoding.Default);
            int m1 = 0,m2 =0,m3 = 0,m4 = 0,m5 = 0;
            int n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0;
            int k1 = 0, k2 = 0, k3 = 0, k4 = 0, k5 = 0;
            string[] records = Regex.Split(file, "\r\n");
            for (int index = 0; index < records.Length-1; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                string u;
                double w= 0.0;
                u = components[2];
                u = u.Trim(' ');
                w = Convert.ToDouble(u);
                if (w >= 0.0 && w < 60.0)
                    m1++;
                if (w >= 60.0 && w < 70.0)
                    m2++;
                if (w >= 70.0 && w < 80.0)
                    m3++;
                if (w >= 80.0 && w < 90.0)
                    m4++;
                if (w >= 90.0 && w <=100.0)
                    m5++;
                // 对英语人数进行统计
                u = components[3];
                u = u.Trim(' ');
                w = Convert.ToDouble(u);
                if (w >= 0 && w < 60)
                    n1++;
                if (w >= 60 && w < 70)
                    n2++;
                if (w >= 70 && w < 80)
                    n3++;
                if (w >= 80 && w < 90)
                    n4++;
                if (w >= 90 && w <= 100)
                    n5++;
                // 对政治人数进行统计
                u = components[4];
                u = u.Trim(' ');
                w = Convert.ToDouble(u);
                if (w >= 0 && w < 60)
                    k1++;
                if (w >= 60 && w < 70)
                    k2++;
                if (w >= 70 && w < 80)
                    k3++;
                if (w >= 80 && w < 90)
                    k4++;
                if (w >= 90 && w <= 100)
                    k5++;
            }
            newrecord = ">60" + " " + m1 + " " + n1 + " " + k1 + "\r\n";
            File.AppendAllText("E:\\wenjian.txt", newrecord, UTF8Encoding.Default);
            newrecord = "60~69" + " " + m2 + " " + n2 + " " + k2 + "\r\n";
            File.AppendAllText("E:\\wenjian.txt", newrecord, UTF8Encoding.Default);
            newrecord = "70~79" + " " + m3 + " " + n3 + " " + k3 + "\r\n";
            File.AppendAllText("E:\\wenjian.txt", newrecord, UTF8Encoding.Default);
            newrecord = "80~89" + " " + m4 + " " + n4 + " " + k4 + "\r\n";
            File.AppendAllText("E:\\wenjian.txt", newrecord, UTF8Encoding.Default);
            newrecord = "90~100" + " " + m5 + " " + n5 + " " + k5 + "\r\n";
            File.AppendAllText("E:\\wenjian.txt", newrecord, UTF8Encoding.Default);
        }
    }
}
