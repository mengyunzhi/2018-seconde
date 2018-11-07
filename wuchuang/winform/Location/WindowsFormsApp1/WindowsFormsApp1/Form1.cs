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

    public class testForm : Form
    {
        public testForm()
        {
            //InitializeComponent();

            ImageBox box = new ImageBox();
            box.Dock = DockStyle.Fill;
            box.ImageSize = new Size(200, 150);
            this.Controls.Add(box);
        }
    }

}
