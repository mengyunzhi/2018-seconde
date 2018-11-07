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
using System.Text.RegularExpressions;

namespace 大实验成绩管理
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Display_Click(object sender, EventArgs e)
        {
            string file = File.ReadAllText(@"D:\\Data.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records1 = Regex.Split(file, "\r\n");
            string[] records = new string[records1.Length - 1];
            for(int i = 0; i < records1.Length-1; i++)
            {
                records[i] = records1[i];

            }
            //开始更新视图
            this.listView1.BeginUpdate();
            //清空原有视图
            this.listView1.Items.Clear();
            Array.Sort(records, compare);

            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length ; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                //生成listview的一行
                components[7] = (index + 1).ToString ();
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.AliceBlue  ;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
            //视图更新结束
            this.listView1.EndUpdate();
        }

        private int compare(string x, string y)
        {
            string[] a = Regex.Split(x, " ");
            string[] b = Regex.Split(y, " ");   
            return double.Parse(b[5].ToString()).CompareTo(double.Parse(a[5].ToString()));
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int x;
            x = this.listView1.SelectedItems[0].Index;
            listView1.Items.RemoveAt(this.listView1.SelectedItems[0].Index);
            int counter = 0;
            String line;
            List<String> lines = new List<String>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"D:\Data.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (counter != x)
                {
                    lines.Add(line);
                }
                counter++;
            }
            file.Close();
            File.WriteAllLines(@"D:\Data.txt", lines, UTF8Encoding.Default);

        }

        private void Query_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            string file = File.ReadAllText("d:\\Data.txt", UTF8Encoding.Default);
            
        }

       
        
    }
}
