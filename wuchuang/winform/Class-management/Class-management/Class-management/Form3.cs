using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serve
{
    public partial class Form3 : Form
    {

        public static Form1 parent;

        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newrecord = this.textBox1.Text;
            String line;
            int num = 0;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"e:\data.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] array = Regex.Split(line, " ");
                if (array[0] == newrecord)
                {
                    Form3.parent.result(num);
                    break;
                }
                num++;
            }
            this.Dispose(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
        }
    }
}
