using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket
{
    public partial class Form2 : Form
    {
        public Form2() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                int number = Convert.ToInt32(textBox1.Text);
                Form1 form1 = new Form1(number);
                form1.Show();
                this.Dispose(false);
            } else {
                MessageBox.Show("请输入内容");
            }           
        }
    }
}
