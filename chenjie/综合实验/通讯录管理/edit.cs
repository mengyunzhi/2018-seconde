using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace MailList
{
    public partial class Edit : Form
    {
        private Person person;
        public Edit(Person oldPerson)
        {
            InitializeComponent();
            person = oldPerson;
            // 将person的各个属性写到文本框内
            idTextBox.Text = oldPerson.Id;
            nameTextBox.Text = oldPerson.Name;
            workPlacetextBox.Text = oldPerson.WorkPlace;
            phoneTextBox.Text = oldPerson.Phone;
            emailTextBox.Text = oldPerson.Email;
            if (oldPerson.Sex == "male") {
                male.Checked = true;
            } else femaleRadio.Checked = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sex = "male";
            if (femaleRadio.Checked) {
                sex = "female";
            }
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string newrecord = idTextBox.Text + " " +
                               nameTextBox.Text + " " +
                               sex + " " +
                               workPlacetextBox.Text + " " +
                               phoneTextBox.Text + " " +
                               emailTextBox.Text + "\r\n";
            File.AppendAllText("C:\\Users\\某杰\\Desktop\\MailList.txt", newrecord, UTF8Encoding.Default);
            //结束edit的调用
            Dispose(true);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            string sex = "male";
            if (femaleRadio.Checked)
            {
                sex = "female";
            }
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string newrecord = person.Id + " " +
                               person.Name + " " +
                               sex + " " +
                               person.WorkPlace + " " +
                               person.Phone + " " +
                               person.Email + "\r\n";
            File.AppendAllText("C:\\Users\\某杰\\Desktop\\MailList.txt", newrecord, UTF8Encoding.Default);
            //结束edit的调用
            Dispose(true);
        }
    }
}
