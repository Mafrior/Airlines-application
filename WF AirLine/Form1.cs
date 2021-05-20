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
    public partial class Form1 : Form
    {
        Form2 form2;
        Form5 form5;
        DateTime start;
        int errCount = 0;
        bool canLogIn = true;
        public Form1()
        {
            InitializeComponent();
            Database.database.Add(new User("ADMIN", "Ivan", "Orlov", "1C", "", new DateTime(2003, 06, 20)));
            Database.database.Add(new User("USER", "Pavel", "Grisha", "1C", "user", new DateTime(2005, 02, 20)));
            Database.database[0].userRole = "admin";
            form2 = new Form2(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paserror.Visible = false;
            blockerr.Visible = false;
            if (!canLogIn)
            {
                return;
            }
            User user = Database.database.FirstOrDefault(x => x.Email == UserName.Text && x.password == Password.Text);
            if(user == null)
            {
                paserror.Visible = true;
                errCount++;
                if(errCount >= 3)
                {
                    timer.Enabled = true;
                    start = DateTime.Now;
                    canLogIn = false;
                }
                return;
            }
            errCount = 0;
            if (user.enable == -1)
            {
                blockerr.Visible = true;
                Database.database.First(x => x.Email == UserName.Text).crashes.Add(Database.database.First(x => x.Email == UserName.Text).crashes.Count+1, "PowerOutage");
                Database.database.First(x => x.Email == UserName.Text).loginDates.Add(DateTime.Now);
                Database.database.First(x => x.Email == UserName.Text).logoutDates.Add(DateTime.Now);
                return;
            }
            if(user.userRole == "admin")
            {
                form2.Show();
            }
            else{
                form5 = new Form5(Database.database.FindIndex(x => x.Email == UserName.Text), this);
                form5.Show();
            }
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void blockerr_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - start;
            timerL.Text = "Too much tries: 3. Wait " + (10 - interval.Seconds).ToString() + " seconds";
            if (interval.Seconds == 10)
            {
                timer.Enabled = false;
                timerL.Text = "";
                canLogIn = true;
            }
        }
    }
}
