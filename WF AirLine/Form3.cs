using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИЗ12
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.database.Add(new User(emailTB.Text, firstNameTB.Text, lastNameTB.Text, comboBox1.Text, passwordTB.Text, new DateTime(Convert.ToInt32(birthdayTB.Text.Split('/')[2]), Convert.ToInt32(birthdayTB.Text.Split('/')[1]), Convert.ToInt32(birthdayTB.Text.Split('/')[0]))));
            Database.DownLoadDataForm2();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
