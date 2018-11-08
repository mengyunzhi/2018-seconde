using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace MailList
{
    public partial class Index : Form {
        private Insert insertForm;  // 增加数据窗口
        private Edit editForm;      // 编辑数据窗口
        public Index() {
            InitializeComponent();
            this.listView1.Columns.Add("学号", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("姓名", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("性别", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("工作单位", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("电话号码", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("E-mail", 100, HorizontalAlignment.Center);
            this.listView1.View = System.Windows.Forms.View.Details;
        }

        private void Index_Load(object sender, EventArgs e) {
            // 加载数据
            Display();
        }

        private void AddButton_Click(object sender, EventArgs e) {
            insertForm = new Insert();
            // 此窗口打开时不可以进行其他窗口的操作
            insertForm.ShowDialog();
            // 重新加载数据
            Display();
        }

        private void DisplayButton_Click(object sender, EventArgs e) {
            // 加载数据，清空搜索框
            Display();
            ClearAllTextBox();
        }

        // 加载数据
        private void Display() {
            string file = File.ReadAllText("C:\\Users\\某杰\\Desktop\\MailList.txt", UTF8Encoding.Default);
            // 统计male和female的个数
            maleNum.Text = StringNum(file, " male ").ToString();
            femaleNum.Text = StringNum(file, " female ").ToString();

            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            // 更新视图
            UpdateView(records);
        }

        // 更新视图
        private void UpdateView(string[] records) {
            //开始更新视图
            listView1.BeginUpdate();
            //清空原有视图
            listView1.Items.Clear();
            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length; index++) {   
                //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                //生成listview的一行
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.White;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
            //视图更新结束
            listView1.EndUpdate();
        }

        // 统计index字符串中s字符串出现的个数
        private int StringNum(string index, string s) {
            string pat = @s;//正则表达式
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(index);
            int matchCount = 0;
            while (m.Success) {
                ++matchCount;//次数累加
                m = m.NextMatch();
            }
            return matchCount;
        }

        // 点击删除按钮
        private void DeleteButton_Click(object sender, EventArgs e) {
            DeleteSelectCol();
        }

        // 删除被选中的行的数据
        public void DeleteSelectCol() {
            // 如果有被选中的项
            if (listView1.SelectedItems.Count != 0) {
                int x;
                x = this.listView1.SelectedItems[0].Index;
                listView1.Items.RemoveAt(this.listView1.SelectedItems[0].Index);
                int counter = 0;
                String line;
                List<String> lines = new List<String>();

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\\Users\\某杰\\Desktop\\MailList.txt");
                while ((line = file.ReadLine()) != null) {
                    if (counter != x) {
                        lines.Add(line);
                    }
                    counter++;
                }
                file.Close();
                File.WriteAllLines(@"C:\\Users\\某杰\\Desktop\\MailList.txt", lines, UTF8Encoding.Default);
            }
        }
        // 点击编辑按钮
        private void EditButton_Click(object sender, EventArgs e) {
            // 如果有被选中的项
            if (listView1.SelectedItems.Count != 0) {
                // 将选中行的信息封装到person中
                Person editPerson = new Person {
                    Id = listView1.SelectedItems[0].SubItems[0].Text,
                    Name = listView1.SelectedItems[0].SubItems[1].Text,
                    Sex = listView1.SelectedItems[0].SubItems[2].Text,
                    WorkPlace = listView1.SelectedItems[0].SubItems[3].Text,
                    Phone = listView1.SelectedItems[0].SubItems[4].Text,
                    Email = listView1.SelectedItems[0].SubItems[5].Text
                };

                // 打开编辑窗口，将person传入
                editForm = new Edit(editPerson);
                editForm.ShowDialog();
                
                // 删除选中行的信息
                DeleteSelectCol();

                // 重新加载数据
                Display();
            }
        }
        // 点击clear按钮
        private void ClearButton_Click(object sender, EventArgs e) {            
            maleNum.Text = "0";
            femaleNum.Text = "0";
            listView1.Items.Clear();  //只移除所有的项
            List<String> lines = new List<String>();
            File.WriteAllLines(@"C:\\Users\\某杰\\Desktop\\MailList.txt", lines, UTF8Encoding.Default);
            ClearAllTextBox();
        }

        // 按ID进行查询
        private string[] SearchById(string id)
        {
            string file = File.ReadAllText("C:\\Users\\某杰\\Desktop\\MailList.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            List<String> results = new List<String>();

            // 比较每一行的id是否和搜索的id相同，如果则将该行存到results中
            for (int i = 0, j = 0;i<records.Length - 1;i++) {
                string[] col = Regex.Split(records[i], " ");
                if (col[0].Equals(id)){
                    results.Add(records[i]);
                }                
            }
            return results.ToArray();
        }
        // 按名字进行查询
        private string[] SearchByName(string name) {
            string file = File.ReadAllText("C:\\Users\\某杰\\Desktop\\MailList.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            List<String> results = new List<String>();

            // 比较每一行的name是否和搜索的name相同，如果则将该行存到results中
            for (int i = 0, j = 0; i < records.Length - 1; i++) {
                string[] col = Regex.Split(records[i], " ");
                if (col[1].Equals(name)) {
                    results.Add(records[i]);
                }
            }
            return results.ToArray();
        }
        // 按电话号码进行查询
        private string[] SearchByPhone(string phone) {
            string file = File.ReadAllText("C:\\Users\\某杰\\Desktop\\MailList.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            List<String> results = new List<String>();

            // 比较每一行的phone是否和搜索的phone相同，如果则将该行存到results中
            for (int i = 0, j = 0; i < records.Length - 1; i++) {
                string[] col = Regex.Split(records[i], " ");
                if (col[4].Equals(phone)) {
                    results.Add(records[i]);
                }
            }
            return results.ToArray();
        }

        private void SerachByIdButton_Click(object sender, EventArgs e) {
            if (SearchByIdTextBox.Text != "") {
                string input = SearchByIdTextBox.Text.Trim().Replace("\r\n", "");
                string[] results = SearchById(input);
                // 更新视图
                UpdateView(results);
            }
        }

        private void SerachByNameButton_Click(object sender, EventArgs e) {
            if (SearchByNameTextBox.Text != "") {
                string input = SearchByNameTextBox.Text.Trim().Replace("\r\n", "");
                string[] results = SearchByName(input);
                // 更新视图
                UpdateView(results);
            }
        }

        private void SerachByPhoneButton_Click(object sender, EventArgs e) {
            if (SearchByPhoneTextBox.Text != "")
            {
                string input = SearchByPhoneTextBox.Text.Trim().Replace("\r\n", "");
                string[] results = SearchByPhone(input);
                // 更新视图
                UpdateView(results);
            }
        }
        // 清空所有搜索框
        private void ClearAllTextBox() {
            SearchByIdTextBox.Clear();
            SearchByNameTextBox.Clear();
            SearchByPhoneTextBox.Clear();
        }
    }
}
