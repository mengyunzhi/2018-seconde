using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string number1 = null, number2 = null,number3 = null, flag = null,flag2 = null;
        int j = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "2";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "2";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "2";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
            if(flag == null && flag2 == null)
            {
                number1 = number1 + "1";
            }
            if(flag!=null && flag2 == null)
            {
                number2 = number2 + "1";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "1";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "4";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "4";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "4";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "7";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "7";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "7";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "8";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "8";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "9";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "9";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "9";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "+";
            if (flag != null)
                flag2 = "+";
            else
                flag = "+";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "3";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "3";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "3";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "5";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "5";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "6";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "6";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "6";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ".";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + ".";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + ".";
            }
            if(flag!=null&&flag2!=null)
            {
                number3 = number3 + ".";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
            if (flag == null && flag2 == null)
            {
                number1 = number1 + "0";
            }
            if (flag != null && flag2 == null)
            {
                number2 = number2 + "0";
            }
            if (flag != null && flag2 != null)
            {
                number3 = number3 + "0";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        { 
            string a = null;
            string b = null;  // 用于交换存储数据
            for (int i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    if ((flag == "+" || flag == "-") && (flag2 == "*" || flag2 == "/"))
                    {
                        b = number1;
                        number1 = number2;
                        number2 = number3;
                        number3 = b;
                        b = flag;
                        flag = flag2;
                        flag2 = flag;
                    }
                    a = flag;
                }
                if(i == 2)
                {
                    a = flag2;
                    number2 = number3;
                }
                switch (a)
                {
                    case "null":break;
                    case "+":
                        number1 = Convert.ToString(Convert.ToDouble(number1) + Convert.ToDouble(number2));
                        break;
                    case "-":
                        number1 = Convert.ToString(Convert.ToDouble(number1) - Convert.ToDouble(number2));
                        break;
                    case "*":
                        number1 = Convert.ToString(Convert.ToDouble(number1) * Convert.ToDouble(number2));
                        break;
                    case "/":
                        number1 = Convert.ToString(Convert.ToDouble(number1) / Convert.ToDouble(number2));
                        break;
                    case "123":
                        number1 = Convert.ToString(Convert.ToDouble(number1) * Convert.ToDouble(number1));
                        break;
                    case "log":
                        number1 = Convert.ToString( Math.Log(Convert.ToDouble(number2), Convert.ToDouble(number1)));
                        break;
                    case "sqrt":
                        number1 = Convert.ToString(Math.Sqrt(Convert.ToDouble(number1)));
                        break;
                    case "ln":
                        number1 = Convert.ToString(Math.Log(Convert.ToDouble(number1), Math.E));
                        break;
                }
            }
            textBox1.Text = number1 ;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            j++;
            if(j == 7)
            {
                j = 1;
            }
            switch (j)
            {
                case 1:
                    this.BackColor = Color.Red;
                    break;
                case 2:
                    this.BackColor = Color.Blue;
                    break;
                case 3:
                    this.BackColor = Color.Green;
                    break;
                case 4:
                    this.BackColor = Color.Gray;
                    break;
                case 5:
                    this.BackColor = Color.Gold;
                    break;
                case 6:
                    this.BackColor = Color.Pink;
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch(e.Node.Text)
            {
                case "红":
                    this.BackColor = Color.Red;
                    break;
                case "蓝":
                    this.BackColor = Color.Blue;
                    break;
                case "绿":
                    this.BackColor = Color.Green;
                    break;
                case "灰":
                    this.BackColor = Color.Gray;
                    break;
                case "金":
                    this.BackColor = Color.Gold;
                    break;
                case "粉":
                    this.BackColor = Color.Pink;
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "的平方";
            flag = "123";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "log";
            flag = "log";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "ln";
            flag = "ln";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "开方";
            flag = "sqrt";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "-";
            if (flag != null)
                flag2 = "-";
            else
            flag = "-";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.textBox1.Text =null;
            number1 = null;
            number2 = null;
            flag = null;
            flag2 = null;
            number3 = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "*";
            if (flag != null)
                flag2 = "*";
            else
            flag = "*";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "/";
            if (flag != null)
                flag2 = "/";
            else
            flag = "/";
        }
    }
}
