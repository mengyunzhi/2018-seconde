using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace location
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // InitializeComponent();
            ImageBox box = new ImageBox(4);
            box.Dock = DockStyle.Fill;
            box.ImageSize = new Size(200, 150);
            this.Controls.Add(box);
        }

        private void InitializeComponent()
        {

            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}
