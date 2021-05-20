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
    public partial class Form5 : Form
    {
        int logIndex;
        Form1 form1;
        DateTime start;
        public Form5(int i, Form1 f1)
        {
            InitializeComponent();
            Database.dgv5 = dataGridView1;
            Database.DownLoadDataForm5(i);
            Database.database[i].loginDates.Add(DateTime.Now);
            logIndex = i;
            label1.Text = $"Hi {Database.database[i].FirstName}, Welcome to AMONIC Airlines.";
            timer.Enabled = true;
            start = DateTime.Now;
            form1 = f1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.database[logIndex].logoutDates.Add(DateTime.Now);
            form1.Show();
            Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - start;
            label2.Text = $"Time spent on system {interval.Hours} : {interval.Minutes} : {interval.Seconds}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
