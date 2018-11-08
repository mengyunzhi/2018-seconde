using System;
using System.Drawing;
using System.Windows.Forms;

namespace supermarket
{
    public partial class Form1 : Form
    {
        public Form1(int number) {
            InitializeComponent();
            ImageBox box = new ImageBox(number) {
                Dock = DockStyle.Fill,
                ImageSize = new Size(500, 400)
            };
            this.Controls.Add(box);            
        }
    }
}
