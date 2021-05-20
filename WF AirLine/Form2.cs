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
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            Database.dgv2 = dataGridView1;
            Database.DownLoadDataForm2();
            form1 = f1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            var f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form1.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void changeRole(object sender, EventArgs e)
        {
            var f4 = new Form4();
            f4.Show();
        }

        private void edUser_Click(object sender, EventArgs e)
        {
            User element = Database.database[dataGridView1.SelectedCells[0].RowIndex];
            if (element.enable == 0)
            {
                element.enable = -1;
                Database.DownLoadDataForm2();
                return;
            }
            element.enable *= -1;
            Database.DownLoadDataForm2();
        }
    }
}
