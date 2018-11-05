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

namespace Calculator
{
    public partial class Form1 : Form
    {
        private bool tags = true;   // 表示是否可以输入"."
        public Form1() {
            InitializeComponent();
        }

        // 获取字符串最后一个字符
        public char Last(String s) {
            int length = textBox1.Text.Length;
            char last = textBox1.Text[length - 1];
            return last;
        }

        // 按钮AC
        private void OnAc(object sender, EventArgs e) {
            if (tags == false) {
                tags = !tags;
            }
            textBox1.Clear();
        }

        // 退格按钮
        private void back(object sender, EventArgs e) {
            // 如果字符串不为空
            if (textBox1.Text != "") {
                // 如果删除了"."，则改变其可用状态 
                int length = textBox1.Text.Length;
                char last = textBox1.Text[length - 1];
                if (last == '.') {
                    tags = !tags;
                }
                textBox1.Text = textBox1.Text.Substring(0, length - 1);
            }
        }

        private void OnZero(object sender, EventArgs e) {
            textBox1.Text += "0";
        }

        private void On1(object sender, EventArgs e) {
            textBox1.Text += "1";
        }

        private void On2(object sender, EventArgs e) {
            textBox1.Text += "2";
        }

        private void On3(object sender, EventArgs e) {
            textBox1.Text += "3";
        }

        private void On4(object sender, EventArgs e) {
            textBox1.Text += "4";
        }

        private void On5(object sender, EventArgs e) {
            textBox1.Text += "5";
        }

        private void On6(object sender, EventArgs e) {
            textBox1.Text += "6";
        }

        private void On7(object sender, EventArgs e) {
            textBox1.Text += "7";
        }

        private void On8(object sender, EventArgs e) {
            textBox1.Text += "8";
        }

        private void On9(object sender, EventArgs e) {
            textBox1.Text += "9";
        }

        // 点击+号
        private void OnAdd(object sender, EventArgs e) {
            // 当输入的字符串为空，则加+
            if (textBox1.Text == "") {
                textBox1.Text += "+";
            } else {// 若不为空
                // 如果最后一个字符为符号，则用加号进行替换
                int length = textBox1.Text.Length;
                char last = Last(textBox1.Text);
                if (last == '+' || last == '-' || last == '*' || last == '/') {
                    textBox1.Text = textBox1.Text.Substring(0, length - 1);
                    textBox1.Text += "+";
                } else {
                    textBox1.Text += "+";
                }
                // 如果.不可用，则置为可用
                if (tags == false) {
                    tags = !tags;
                }
            }
        }

        // 点击-号
        private void OnReduce(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                int length = textBox1.Text.Length;
                char last = textBox1.Text[length - 1];
                if (last == '+' || last == '-' || last == '*' || last == '/') {
                    textBox1.Text = textBox1.Text.Substring(0, length - 1);
                    textBox1.Text += "-";
                    if (tags == false) {
                        tags = !tags;
                    }
                } else {
                    textBox1.Text += "-";
                }
            } else {
                textBox1.Text += "-";
            }
        }

        // 点击*号
        private void OnMultiply(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                int length = textBox1.Text.Length;
                char last = textBox1.Text[length - 1];
                if (last == '+' || last == '-' || last == '*' || last == '/') {
                    if (length != 1) {
                        textBox1.Text = textBox1.Text.Substring(0, length - 1);
                        textBox1.Text += "*";
                        if (tags == false) {
                            tags = !tags;
                        }
                    }
                } else if (last >= '0' && last <= '9') {
                    textBox1.Text += "*";
                }
            }
        }

        // 点击/号
        private void OnDivide(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                textBox1.Text += "error";
            } else {
                int length = textBox1.Text.Length;
                char last = textBox1.Text[length - 1];
                if (last == '+' || last == '-' || last == '*' || last == '/') {
                    if (length != 1) {
                        textBox1.Text = textBox1.Text.Substring(0, length - 1);
                        textBox1.Text += "/";
                        if (tags == false) {
                            tags = !tags;
                        }
                    }
                } else if (last >= '0' && last <= '9') {
                    textBox1.Text += "/";
                }
            }
        }

        // 点击.符号
        private void OnPoint(object sender, EventArgs e) {
            // 如果.可用
            if (tags) {
                // 当输入字符串为空时，则生成"0."，且将.的状态置为不可用
                if (textBox1.Text == "") {
                    textBox1.Text += "0.";
                    tags = !tags;
                } else {// 如果不为空
                    int length = textBox1.Text.Length;
                    char lastChar = textBox1.Text[length - 1];

                    // 如果最后一个字符是数字，则直接添加"."，且将.的状态置为不可用
                    if (lastChar <= '9' && lastChar >= '0') {
                        textBox1.Text += ".";
                        tags = !tags;
                    } else if (lastChar > '9' || lastChar < '0') {// 则生成"0."，且将.的状态置为不可用
                        textBox1.Text += "0.";
                        tags = !tags;
                    }
                }
            }
        }

        class Stack {
            Node top;// 栈顶元素          
            public void Push(object data){   
                // 根据当前栈顶元素新构建一个新的栈顶，并将当前栈顶的NextItem指向原来的top
                top = new Node(top, data);
            }
            public object Pop() {   
                if (top == null)
                    throw new InvalidOperationException();
                object result = top.data;
                top = top.nextItem;//重新指定栈顶
                return result;
            }
            public bool IsEmpty() {
                if (top == null) {
                    return true;
                } else {
                    return false;
                }
            }
            public object getTop() {
                return top.data;
            }
            // 栈的数据格式，用链表来实现栈
            class Node {
                public Node nextItem;// 栈的下一个数据，自栈顶往下
                public object data;// 栈顶数据
                public Node(Node sNext, object sData) {
                    this.nextItem = sNext;
                    this.data = sData;
                }
            }
        }

        // 点击=号
        private void OnCalculate(object sender, EventArgs e) {
            // 当输入字符串不为空时
            if (textBox1.Text != "") {
                string myoperator = string.Empty, mynumber = string.Empty;
                char text;
                //获取运算符
                for (int index = 0; index < textBox1.Text.Length; index++) {
                    text = textBox1.Text[index];
                    //数字
                    if ((text == '+' || text == '-') && index == 0) {
                        mynumber += text.ToString();
                        continue;
                    }
                    if (text >= '0' && text <= '9' || text == '.') {
                        mynumber += text.ToString();
                    } else {
                        //保存当前的运算符,运算符之间用空格分开
                        myoperator += text.ToString() + " ";
                        //操作数之间用空格分开
                        mynumber += " ";
                    }
                }
                //去掉末尾的空格
                mynumber = mynumber.TrimEnd();
                myoperator = myoperator.TrimEnd();

                double result = Calculate(myoperator, mynumber);
                //返回运算结果到前端界面
                textBox1.Text = result.ToString();
            }
        }
        // 进行运算
        private double Calculate(string operators, string numbers) {
            // 将数字和操作符字符串存到数组当中
            string[] numberarray = Regex.Split(numbers, " ");
            string[] operatorarray = Regex.Split(operators, " ");
            Stack numberStack = new Stack();// 数字栈
            Stack operatorStack = new Stack();// 操作符栈

            // 先将前两个数字和一个操作符push到栈中
            numberStack.Push(Convert.ToDouble(numberarray[0]));
            numberStack.Push(Convert.ToDouble(numberarray[1]));
            operatorStack.Push(operatorarray[0]);
            
            // 当遍历完操作符数组且栈中操作符为空时跳出循环
            for (int i = 1; i < operatorarray.Length || !operatorStack.IsEmpty();) {
                // 当操作符栈为空时，push一个数字和一个操作符
                if (operatorStack.IsEmpty()) {
                    numberStack.Push(Convert.ToDouble(numberarray[i + 1]));
                    operatorStack.Push(operatorarray[i]);
                    i++;continue;
                }
                // 当栈顶操作符为+或者-时
                if (operatorStack.getTop().Equals("+") || operatorStack.getTop().Equals("-")) {
                    if (i < operatorarray.Length) { // 当下一个操作符不是最后一个操作符时
                        // 如果下一个操作符为*或者/，则push一个数字和操作符
                        if (operatorarray[i].Equals("*") || operatorarray[i].Equals("/")) {
                            numberStack.Push(Convert.ToDouble(numberarray[i + 1]));
                            operatorStack.Push(operatorarray[i]);
                            i++;
                        } else {// 否则，栈内进行加减运算，将结果push到栈顶，下同
                            double after = Convert.ToDouble(numberStack.Pop());
                            double pre = Convert.ToDouble(numberStack.Pop());
                            string op = operatorStack.Pop().ToString();
                            switch (op) {
                                case "+": { numberStack.Push(pre + after); continue; }
                                case "-": { numberStack.Push(pre - after); continue; }
                                default: continue;
                            }
                        }
                    } else {// 如果没有下一个操作符，则栈内进行加减运算
                        double after = Convert.ToDouble(numberStack.Pop());
                        double pre = Convert.ToDouble(numberStack.Pop());
                        string op = operatorStack.Pop().ToString();
                        switch (op) {
                            case "+": { numberStack.Push(pre + after); continue; }
                            case "-": { numberStack.Push(pre - after); continue; }
                            default: continue;
                        }
                    }
                } else {// 如果栈顶操作符为*或者/，则栈内直接进行乘除运算
                    double after = Convert.ToDouble(numberStack.Pop());
                    double pre = Convert.ToDouble(numberStack.Pop());
                    string op = operatorStack.Pop().ToString();
                    switch (op) {
                        case "*": { numberStack.Push(pre * after); continue; }
                        case "/": { numberStack.Push(pre / after); continue; }
                        default: continue;
                    }
                }
            }
            // 取出栈顶元素作为结果返回
            object result = numberStack.Pop();
            return Convert.ToDouble(result);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
