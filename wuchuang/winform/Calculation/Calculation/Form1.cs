using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation
{
    public partial class Form1 : Form
    {
        private Stack1 number = new Stack1();       // 存入操作数
        private Stack2 operators = new Stack2();    // 存入操作符
        private int operators_num = 0;              // 记录操作符栈执行次数
        private char dot = '#';                     // 小数点
        private int status = 0;                     // 判断除数是否为0
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void num_1(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
            if (!number.is_Empty())
            {
                //  判断中间是否执行过操作符栈，用来分辨操作数栈是否存1，2还是12
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 1;
                    number.Push(x);
                }
                else
                {
                    number.Push(1);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(1);
        }

        private void num_2(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 2;
                    number.Push(x);
                }
                else
                {
                    number.Push(2);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(2);
        }
    

        private void num_3(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 3;
                    number.Push(x);
                }
                else
                {
                    number.Push(3);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(3);
        }

        private void num_4(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 4;
                    number.Push(x);
                }
                else
                {
                    number.Push(4);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(4);
        }

        private void num_5(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 5;
                    number.Push(x);
                }
                else
                {
                    number.Push(5);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(5);
        }

        private void num_6(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 6;
                    number.Push(x);
                }
                else
                {
                    number.Push(6);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(6);
        }

        private void num_7(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 7;
                    number.Push(x);
                }
                else
                {
                    number.Push(7);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(7);
        }

        private void num_8(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 8;
                    number.Push(x);
                }
                else
                {
                    number.Push(8);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(8);
        }

        private void num_9(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 9;
                    number.Push(x);
                }
                else
                {
                    number.Push(9);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(9);
        }
        private void num_0(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
            if (!number.is_Empty())
            {
                if (operators_num == operators.getNum())
                {
                    double x;
                    x = number.Popout();
                    x = x * 10 + 0;
                    number.Push(x);
                }
                else
                {
                    number.Push(0);
                    operators_num = operators.getNum();
                }
            }
            else
                number.Push(0);
        }

        class Stack1
        {
            Node top;                       // 栈顶元素
            public void Push(double data)
            {// 入栈
             // 根据当前栈顶元素新构建一个新的栈顶，并将当前栈顶的NextItem指向原来的top
                top = new Node(top, data);
            }
            public double getTop()
            {
                if (top == null)
                    throw new InvalidOperationException();
                double result = top.data;
                return result;
            }

            public double Popout()
            { // 出栈
                if (top == null)
                    throw new InvalidOperationException();
                double result = top.data;
                top = top.nextItem;             // 重新指定栈顶
                return result;
            }


            public bool is_Empty()
            {
                if (top == null)
                    return true;
                else return false;
            }
            // 栈的数据格式，用链表来实现栈
            class Node
            {
                public Node nextItem;                       // 栈的下一个数据，自栈顶往下
                public double data;                         // 栈顶数据
                public Node(Node sNext, double sData)
                {
                    this.nextItem = sNext;
                    this.data = sData;
                }
            }

        }

        class Stack2
        {
            int num;
            Node top;                   // 栈顶元素
            public Stack2()
            {
                num = 0;
            }
            public void Push(char data)
            {// 入栈
             // 根据当前栈顶元素新构建一个新的栈顶，并将当前栈顶的NextItem指向原来的top
                top = new Node(top, data);
            }

            public void Init_num()
            {
                num = 0;
            }

            public char getTop()
            {
                if (top == null)
                    throw new InvalidOperationException();
                char result = top.data;
                return result;
            }

            public char Popout()
            {   // 出栈
                if (top == null)
                    throw new InvalidOperationException();
                char result = top.data;
                top = top.nextItem;                         // 重新指定栈顶
                return result;
            }

            public int setNum()
            {
                return num++;
            }

            public int getNum()
            {
                return num;
            }

            public bool is_Empty()
            {
                if (top == null)
                    return true;
                else return false;
            }
                                                        // 栈的数据格式，用链表来实现栈
            class Node
            {
                public Node nextItem;                   // 栈的下一个数据，自栈顶往下
                public char data;                       // 栈顶数据
                public Node(Node sNext, char sData)
                {
                    this.nextItem = sNext;
                    this.data = sData;
                }
            }

        }

        private void equal(object sender, EventArgs e)
        {
            double x = 0, y = 0;
            char z;
            if (status == 1)
            {
                x = 99999.9999;             // 若除数为0，则输出此数
            }
            else
            {
                if (dot == '.')             // 小数点运算
                {
                    double m, n;
                    m = number.Popout();
                    n = number.Popout();
                    while (m >= 1)
                    {
                        m = m / 10;
                    }
                    n = n + m;
                    number.Push(n);
                    dot = '#';
                }
                while (!operators.is_Empty())
                {
                    z = operators.Popout();
                    switch (z)
                    {
                        case '+':
                            {
                                x = number.Popout();
                                y = number.Popout();
                                x = x + y;
                                number.Push(x);
                                break;
                            }
                        case '-':
                            {
                                x = number.Popout();
                                y = number.Popout();
                                x = y - x;
                                number.Push(x);
                                break;
                            }
                        case '*':
                            {
                                x = number.Popout();
                                y = number.Popout();
                                x = x * y;
                                number.Push(x);
                                break;
                            }
                        case '/':
                            {
                                if (x == 0)
                                {
                                    status = 1;
                                    break;
                                }
                                x = number.Popout();
                                y = number.Popout();
                                x = y / x;
                                number.Push(x);
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
            number.Popout();
        }

        // 弹出栈顶两个元素进行运算后，将结果重新作为栈顶，存入+运算符
        private void Add(object sender, EventArgs e)
        {
            if (dot == '.')
            {
                double x, y;
                x = number.Popout();
                y = number.Popout();
                while (x >= 1)
                {
                    x = x / 10;
                }
                y = y + x;
                number.Push(y);
                dot = '#';
            }
            operators.setNum();
            this.textBox1.Text += "+";

            if (!operators.is_Empty())
            {
                char z;
                double x, y;
                z = operators.Popout();
                x = number.Popout();
                y = number.Popout();
                switch (z)
                {
                    case '+':
                        {
                            x = x + y;
                            number.Push(x);
                            break;
                        }
                    case '-':
                        {
                            x = y - x;
                            number.Push(x);
                            break;
                        }

                    case '*':
                        {
                            x = x * y;
                            number.Push(x);
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
                            number.Push(x);
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

        private void subtract(object sender, EventArgs e)
        {
            if (dot == '.')
            {
                double m, n;
                m = number.Popout();
                n = number.Popout();
                while (m >= 1)
                {
                    m = m / 10;
                }
                n = n + m;
                number.Push(n);
                dot = '#';
            }
            operators.setNum();
            this.textBox1.Text += "-";
            if (!operators.is_Empty())
            {
                char z;
                double x, y;
                z = operators.Popout();
                x = number.Popout();
                y = number.Popout();
                switch (z)
                {
                    case '+':
                        {
                            x = x + y;
                            number.Push(x);
                            break;
                        }
                    case '-':
                        {
                            x = y - x;
                            number.Push(x);
                            break;
                        }
                    case '*':
                        {
                            x = x * y;
                            number.Push(x);
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
                            number.Push(x);
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

        // 若运算符栈顶元素符优先级小于*，则*进栈，否则同+运算符操作
        private void multiply(object sender, EventArgs e)
        {
            if (dot == '.')
            {
                double m, n;
                m = number.Popout();
                n = number.Popout();
                while (m >= 1)
                {
                    m = m / 10;
                }
                n = n + m;
                number.Push(n);
                dot = '#';
            }
            operators.setNum();
            this.textBox1.Text += "*";
            if (!operators.is_Empty())
            {
                if (operators.getTop() == '+' || operators.getTop() == '-')
                {
                    operators.Push('*');
                }
                else
                {
                    char z;
                    double x, y;
                    z = operators.Popout();
                    x = number.Popout();
                    y = number.Popout();
                    switch (z)
                    {
                        case '+':
                            {
                                x = x + y;
                                number.Push(x);
                                break;
                            }
                        case '-':
                            {
                                x = y - x;
                                number.Push(x);
                                break;
                            }
                        case '*':
                            {
                                x = x * y;
                                number.Push(x);
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
                                number.Push(x);
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

        private void divide(object sender, EventArgs e)
        {
            if (dot == '.')
            {
                double m, n;
                m = number.Popout();
                n = number.Popout();
                while (m >= 1)
                {
                    m = m / 10;
                }
                n = n + m;
                number.Push(n);
                dot = '#';
            }
            operators.setNum();
            this.textBox1.Text += "/";
            if (!operators.is_Empty())
            {
                if (operators.getTop() == '+' || operators.getTop() == '-')
                {
                    operators.Push('/');
                }
                else
                {
                    char z;
                    double x, y;
                    z = operators.Popout();
                    x = number.Popout();
                    y = number.Popout();
                    switch (z)
                    {
                        case '+':
                            {
                                x = x + y;
                                number.Push(x);
                                break;
                            }
                        case '-':
                            {
                                x = y - x;
                                number.Push(x);
                                break;
                            }
                        case '*':
                            {
                                x = x * y;
                                number.Push(x);
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
                                number.Push(x);
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

        private void is_dot(object sender, EventArgs e)
        {
            operators.setNum();
            this.textBox1.Text += ".";
            dot = '.';
        }

        // 清除所有数据，重新开始运算
        private void clear(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            operators.Init_num();
            while (!number.is_Empty())
            {
                number.Popout();
            }
            while (!operators.is_Empty())
            {
                operators.Popout();
            }
            dot = '#';
            operators_num = 0;
            status = 0;
        }
    }
}
