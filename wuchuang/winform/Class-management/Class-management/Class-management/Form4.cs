using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serve
{
    public partial class Form4 : Form
    {
        public Form4(int[,] count)
        {
            InitializeComponent();
            label10.Text = count[0, 0].ToString();
            label11.Text = count[0, 1].ToString();
            label12.Text = count[0, 2].ToString();

            label18.Text = count[1, 0].ToString();
            label17.Text = count[1, 1].ToString();
            label16.Text = count[1, 2].ToString();

            label15.Text = count[2, 0].ToString();
            label14.Text = count[2, 1].ToString();
            label13.Text = count[2, 2].ToString();

            label21.Text = count[3, 0].ToString();
            label20.Text = count[3, 1].ToString();
            label19.Text = count[3, 2].ToString();

            label24.Text = count[4, 0].ToString();
            label23.Text = count[4, 1].ToString();
            label22.Text = count[4, 2].ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
        }
    }
}
