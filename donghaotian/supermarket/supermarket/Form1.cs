using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static supermarket.Imagebox;

namespace supermarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
             InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse (this.textBox1.Text);
            ImageBox box = new ImageBox(x);
            box.Dock = DockStyle.Fill;
            box.ImageSize = new Size(500, 500);
            this.Controls.Add(box);
        }
    }
}