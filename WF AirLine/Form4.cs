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
    public partial class Form4 : Form
    {
        int chosenIndex;
        public Form4(int i)
        {
            InitializeComponent();
            int chosenIndex = i;
            firstNameTB.Text = Database.database[chosenIndex].FirstName;
            lastNameTB.Text = Database.database[chosenIndex].SecondName;
            emailTB.Text = Database.database[chosenIndex].Email;
            comboBox1.Text = Database.database[chosenIndex].Office;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var curUser = Database.database.First(x => x.FirstName == Database.database[Database.dgv2.SelectedCells[0].RowIndex].FirstName);
            curUser.FirstName = firstNameTB.Text;
            curUser.SecondName = lastNameTB.Text;
            curUser.Email = emailTB.Text;
            curUser.Office = comboBox1.Text;
            curUser.userRole = UserRadio.Checked ? "user" : AdminRadio.Checked ? "admin" : curUser.userRole;
            Database.DownLoadDataForm2();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
