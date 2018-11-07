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

namespace Serve
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
            Form2.form1 = this;
            Form3.parent = this;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = File.ReadAllText("E:\\data.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            //开始更新视图
            this.listView1.BeginUpdate();
            //清空原有视图
            this.listView1.Items.Clear();
            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length - 1; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                //生成listview的一行
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.White;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
            //视图更新结束
            this.listView1.EndUpdate();


        }

        public void result(int x)
        {
            this.listView1.Items[x].Selected = true;//设定选中            
            this.listView1.Items[x].EnsureVisible();//保证可见
            this.listView1.Items[x].Focused = true;
            this.listView1.Select();
        }

        public void show()
        {
            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                int x;
                x = this.listView1.SelectedItems[0].Index;
                listView1.Items.RemoveAt(this.listView1.SelectedItems[0].Index);
                int counter = 0;
                String line;
                List<String> lines = new List<String>();

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"e:\data.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != x)
                    {
                        lines.Add(line);
                    }
                    counter++;
                }
                file.Close();
                File.WriteAllLines(@"e:\data.txt", lines, UTF8Encoding.Default);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string line;
            int line_num = 0;
            double[] order_temp = new double[10];
            double[] order = new double[10];
            for (int j = 0; j < 10; j++)
            {
                order_temp[j] = 0;
                order[j] = 0;
            }
            System.IO.StreamReader file1 =
                new System.IO.StreamReader(@"e:\data.txt");
            while ((line = file1.ReadLine()) != null)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] array = Regex.Split(line, " ");
                    order_temp[line_num] = Convert.ToDouble(array[5]);
                    order[line_num] = Convert.ToDouble(array[5]);
                    line_num++;
                }
            }
            file1.Close();
            double t;
            bool tag = true;

            for (int i = line_num - 1; i >= 1 && tag; i--)
            {
                tag = false;
                for (int j = 0; j < i; j++) //for循环进行冒泡排序
                {
                    if (order_temp[j] < order_temp[j + 1])
                    {
                        t = order_temp[j];
                        order_temp[j] = order_temp[j + 1];
                        order_temp[j + 1] = t;
                        tag = true;
                    }
                }
            }
            List<String> lines = new List<String>();
            string line1;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"e:\data.txt");
            int k = 0, status = 0;
            while ((line1 = file.ReadLine()) != null)
            {
                for (int i = 0; i < line_num; i++)
                {
                    if (order[k] == order_temp[i])
                    {
                        string line2;
                        line2 = line1;

                        string[] array = Regex.Split(line2, " ");
                        if (array.Length < 8)
                        {
                            string[] records = Regex.Split(line2, "\r\n");


                            line2 = records[0] + " " + (i + 1).ToString();
                            lines.Add(line2);
                        }
                        else
                        {
                            string line3 = "";
                            for (int m = 0; m < 7; m++)
                            {
                                line3 = line3 + array[m] + " ";
                            }
                            array[7] = (i + 1).ToString();
                            line3 = line3 + array[7];
                            lines.Add(line3);
                        }

                        k++;
                        i = 0;

                    }
                    if (status != k)
                    {
                        status = k;
                        break;
                    }
                }
            }
            file.Close();
            File.WriteAllLines(@"e:\data.txt", lines, UTF8Encoding.Default);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<String> lines = new List<String>();
            File.WriteAllLines(@"e:\data.txt", lines, UTF8Encoding.Default);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[,] count = new int[5, 3];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 3; j++)
                    count[i, j] = 0;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"e:\data.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                double x, y, z;
                string[] array = Regex.Split(line, " ");
                x = Convert.ToDouble(array[2]);
                y = Convert.ToDouble(array[3]);
                z = Convert.ToDouble(array[4]);
                if (x <= 60)
                    count[0, 0]++;
                if (x >61  && x <= 70)
                    count[1, 0]++;
                if (x > 71 && x <= 80)
                    count[2, 0]++;
                if (x > 81 && x <= 90)
                    count[3, 0]++;
                if (x > 91 && x <= 100)
                    count[4, 0]++;


                if (y <= 60)
                    count[0, 1]++;
                if (y > 61 && x <= 70)
                    count[1, 1]++;
                if (y > 71 && x <= 80)
                    count[2, 1]++;
                if (y > 81 && x <= 90)
                    count[3, 1]++;
                if (y > 91 && x <= 100)
                    count[4, 1]++;

                if (z <= 60)
                    count[0, 2]++;
                if (z > 61 && x <= 70)
                    count[1, 2]++;
                if (z > 71 && x <= 80)
                    count[2, 2]++;
                if (z > 81 && x <= 90)
                    count[3, 2]++;
                if (z > 91 && x <= 100)
                    count[4, 2]++;

            }
            Form4 form4 = new Form4(count);
            form4.Show();
        }
    }

}
