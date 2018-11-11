using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 大实验计算器
{
    public partial class Form1 : Form
    {
        /* 操作数的栈 */
        class Stack1
        {
            Node top;                                                   // 栈顶元素
            public void Push(double data)                               // 入栈
            {
             /* 根据当前栈顶元素新构建一个新的栈顶，并将当前栈顶的NextItem指向原来的top */
                top = new Node(top, data);
            }
            public double getTop()                                      // 获取栈顶元素
            {
                if (top == null)
                    throw new InvalidOperationException();
                double result = top.data;
                return result;
            }

            public double Popout()                                      // 出栈
            {                                                           
                if (top == null)
                    throw new InvalidOperationException();
                double result = top.data;
                top = top.nextItem;                                     // 重新指定栈顶
                return result;
            }

            public bool Empty()                                         // 判断栈空
            {
                if (top == null)
                    return true;
                else return false;
            }
            /* 栈的数据格式，用链表来实现栈 */
            class Node
            {
                public Node nextItem;                                   // 栈的下一个数据，自栈顶往下
                public double data;                                     // 栈顶数据
                public Node(Node sNext, double sData)
                {
                    this.nextItem = sNext;
                    this.data = sData;
                }
            }

        }

        /* 运算符的栈 */
        class Stack2
        {
            int num;
            Node top;                                                  // 栈顶元素
            public Stack2()
            {
                num = 0;
            }
            public void Push(char data)                                // 入栈
            {
             /* 根据当前栈顶元素新构建一个新的栈顶，并将当前栈顶的NextItem指向原来的top */
                top = new Node(top, data);
            }
            public char GetTop()                                       // 获取栈顶元素
            {
                if (top == null)
                    throw new InvalidOperationException();
                char result = top.data;
                return result;
            }

            public char Popout()                                       // 出栈
            {
                if (top == null)
                    throw new InvalidOperationException();
                char result = top.data;                                // 获取栈顶元素
                top = top.nextItem;                                    // 重新指定栈顶
                return result;
            }

            public int SetNum()
            {
                return num++;
            }

            public int GetNum()
            {
                return num;
            }

            public bool Empty()
            {
                if (top == null)
                    return true;
                else
                    return false;
            }
            /* 栈的数据格式，用链表来实现栈 */
            class Node
            {
                public Node nextItem;                                   // 栈的下一个数据，自栈顶往下
                public char data;                                       // 栈顶数据
                public Node(Node sNext, char sData)
                {
                    this.nextItem = sNext;
                    this.data = sData;
                }
            }

        }


        private Stack1 operand = new Stack1();
        private Stack2 operators = new Stack2();
        private int operators_num = 0;
        private char dot = '#';
        private int status = 0;                                    // 判断除数是否为0

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void On0_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum ())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 0;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(0);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand .Push(0);
        }

        private void On1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 1;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(1);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(1);
        }

        private void On2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 2;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(2);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(2);
        }

        private void On3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 3;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(3);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(3);
        }

        private void On4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 4;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(4);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(4);
        }


        private void On5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 5;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(5);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(5);
        }

        private void On6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 6;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(6);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(6);
        }

        private void On7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 7;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(7);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(7);
        }

        private void On8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 8;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(8);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(8);
        }


        private void On9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
            if (!operand.Empty())
            {
                if (operators_num == operators.GetNum())
                {
                    double x;
                    x = operand.Popout();
                    x = x * 10 + 9;
                    operand.Push(x);
                }
                else
                {
                    operand.Push(9);
                    operators_num = operators.GetNum();
                }
            }
            else
                operand.Push(9);
        }
        private void Onpoint_Click(object sender, EventArgs e)
        {
            operators.SetNum();
            this.textBox1.Text += ".";
            dot = '.';
        }
        private void OnAC_Click(object sender, EventArgs e)        // 归零
        {
            if(operand .Empty ())
                this.textBox1.Clear();
            else
            {
                do
                {
                    operand.Popout();
                } while (!operand.Empty());
                this.textBox1.Clear();
            }
                

        }

        private void Onequal_Click(object sender, EventArgs e)     // 等于
        {
            double x = 0, y = 0;
            char z;
            if (status == 1)                                       // 除数为0
            {
                x = 99999.9999;
            }
            else                                                   // 除数不为0 
            {
                if (dot == '.')                                    // 有小数点
                {
                    double m, n;
                    m = operand .Popout();
                    n = operand.Popout();
                    while (m >= 1)
                    {
                        m = m / 10;
                    }
                    n = n + m;
                    operand.Push(n);
                    dot = '#';
                }
                while (!operators.Empty())
                {
                    z = operators.Popout();
                    switch (z)
                    {
                        case '+':
                            {
                                x = operand.Popout();
                                y = operand .Popout();
                                x = x + y;
                                operand.Push(x);
                                break;
                            }
                        case '-':
                            {
                                x = operand.Popout();
                                y = operand.Popout();
                                x = y - x;
                                operand.Push(x);
                                break;
                            }
                        case '*':
                            {
                                x = operand.Popout();
                                y = operand.Popout();
                                x = x * y;
                                operand.Push(x);
                                break;
                            }
                        case '/':
                            {
                                if (x == 0)
                                {
                                    status = 1;
                                    break;
                                }
                                x = operand.Popout();
                                y = operand.Popout();
                                x = y / x;
                                operand.Push(x);
                                break;
                            }
                        case '%':
                            {
                                if (x == 0)
                                {
                                    status = 1;
                                    break;
                                }
                                x = operand.Popout();
                                y = operand.Popout();
                                x = y % x;
                                operand.Push(x);
                                break;
                            }
                    }

                }
                if (status == 1)
                {
                    x = 99999.9999;
                }
            }
            this.textBox1.Text = x.ToString();
        }

        private void OnAdd_Click(object sender, EventArgs e)      // 加法
        { 
            if (dot == '.')
            {
                double x, y;
                x = operand.Popout();
                y = operand.Popout();
                while (x >= 1)
                {
                    x = x / 10;
                }
                y = y + x;
                operand.Push(y);
                dot = '#';
            }
            operators.SetNum();
            this.textBox1.Text += "+";
            if (!operators.Empty())
            {
                char z;
                double x, y;
                z = operators.Popout();
                x = operand.Popout();
                y = operand.Popout();
                switch (z)
                {
                    case '+':
                        {
                            x = x + y;
                            operand.Push(x);
                            break;
                        }
                    case '-':
                        {
                            x = y - x;
                            operand.Push(x);
                            break;
                        }

                    case '*':
                        {
                            x = x * y;
                            operand.Push(x);
                            break;
                        }

                    case '/':
                        {
                            if (x == 0)
                            {
                                status = 1;
                                break;
                            }
                            x = y / x;
                            operand.Push(x);
                            break;
                        }
                }
                operators.Push('+');
            }
            else
            {
                operators.Push('+');
            }
        }

        private void OnSubtract_Click(object sender, EventArgs e) // 减法
        {
            if (dot == '.')
            {
                double m, n;
                m = operand.Popout();
                n = operand.Popout();
                while (m >= 1)
                {
                    m = m / 10;
                }
                n = n + m;
                operand.Push(n);
                dot = '#';
            }
            operators.SetNum();
            this.textBox1.Text += "-";
            if (!operators.Empty())
            {
                char z;
                double x, y;
                z = operators.Popout();
                x = operand.Popout();
                y = operand.Popout();
                switch (z)
                {
                    case '+':
                        {
                            x = x + y;
                            operand.Push(x);
                            break;
                        }
                    case '-':
                        {
                            x = y - x;
                            operand.Push(x);
                            break;
                        }
                    case '*':
                        {
                            x = x * y;
                            operand.Push(x);
                            break;
                        }
                    case '/':
                        {
                            if (x == 0)
                            {
                                status = 1;
                                break;
                            }
                            x = y / x;
                            operand.Push(x);
                            break;
                        }
                }
                operators.Push('-');
            }
            else
            {
                operators.Push('-');
            }
        }

        private void multiply_Click(object sender, EventArgs e)   // 乘法
        {
            if (dot == '.')
            {
                double m, n;
                m = operand.Popout();
                n = operand.Popout();
                while (m >= 1)
                {
                    m = m / 10;
                }
                n = n + m;
                operand.Push(n);
                dot = '#';
            }
            operators.SetNum();
            this.textBox1.Text += "*";
            if (!operators.Empty())
            {
                if (operators.GetTop() == '+' || operators.GetTop() == '-')
                {
                    operators.Push('*');
                }
                else
                {
                    char z;
                    double x, y;
                    z = operators.Popout();
                    x = operand.Popout();
                    y = operand.Popout();
                    switch (z)
                    {
                        case '+':
                            {
                                x = x + y;
                                operand.Push(x);
                                break;
                            }
                        case '-':
                            {
                                x = y - x;
                                operand.Push(x);
                                break;
                            }
                        case '*':
                            {
                                x = x * y;
                                operand.Push(x);
                                break;
                            }
                        case '/':
                            {
                                if (x == 0)
                                {
                                    status = 1;
                                    break;
                                }
                                x = y / x;
                                operand.Push(x);
                                break;
                            }
                    }
                    operators.Push('*');
                }
            }
            else
            {
                operators.Push('*');
            }
        }

        private void divide_Click(object sender, EventArgs e)     // 除法
        {
            if (dot == '.')
            {
                double m, n;
                m = operand.Popout();
                n = operand.Popout();
                while (m >= 1)
                {
                    m = m / 10;
                }
                n = n + m;
                operand.Push(n);
                dot = '#';
            }
            operators.SetNum();
            this.textBox1.Text += "/";
            if (!operators.Empty())
            {
                if (operators.GetTop() == '+' || operators.GetTop() == '-')
                {
                    operators.Push('/');
                }
                else
                {
                    char z;
                    double x, y;
                    z = operators.Popout();
                    x = operand.Popout();
                    y = operand.Popout();
                    switch (z)
                    {
                        case '+':
                            {
                                x = x + y;
                                operand.Push(x);
                                break;
                            }
                        case '-':
                            {
                                x = y - x;
                                operand.Push(x);
                                break;
                            }
                        case '*':
                            {
                                x = x * y;
                                operand.Push(x);
                                break;
                            }
                        case '/':
                            {
                                if (x == 0)
                                {
                                    status = 1;
                                    break;
                                }
                                x = y / x;
                                operand.Push(x);
                                break;
                            }
                    }
                    operators.Push('/');
                }
            }
            else
            {
                operators.Push('/');
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (pos == 1)
            {
                i++;
                if (i%3==0)
                {
                    this.BackColor = Color.Orange;
                   


                }
                else
                    this.BackColor = Color.LightBlue ;
            }
        }

        int pos = -1;           // 设置标志位，如果为0停止计时，如果为1则开始计时
        int i = 0;              // 设置临时变量
        int temp = 0;           // 指定的间隔秒数

        private void button18_Click(object sender, EventArgs e)
        {
            pos = 0;
            

        }

        private void Start_Click(object sender, EventArgs e)
        {
            temp = Convert.ToInt32(textBox2.Text);  // 获取指定的间隔秒数
            i = 0;
            pos = 1;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            temp = 3;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
