using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ИЗ12
{
    class Database
    {
        public static List<User> database = new List<User>();
        public static DataGridView dgv2;
        public static DataGridView dgv5;
        private static TimeSpan age;


        public static void DownLoadDataForm2()
        {
            for (int i = dgv2.Rows.Count-1; i >= 0; i--)
            {
                dgv2.Rows.RemoveAt(i);
            }
            for (int i = 0; i < database.Count; i++)
            {
                age = DateTime.Now - database[i].Birthday;
                dgv2.Rows.Add(database[i].FirstName, database[i].SecondName, (int)age.TotalDays / 365, database[i].userRole, database[i].Email, database[i].Office);
                dgv2.Rows[i].DefaultCellStyle.BackColor = database[i].enable == 0 ? Color.FromArgb(255,255,255) : database[i].enable == 1 ? Color.FromArgb(146, 170, 131) : Color.FromArgb(242, 66, 59);
            }
        }

        public static void DownLoadDataForm5(int logIndex)
        {
            for (int i = dgv5.Rows.Count - 1; i >= 0; i--)
            {
                dgv5.Rows.RemoveAt(i);
            }
            
            for (int i = 0; i < database[logIndex].loginDates.Count; i++)
            {
                dgv5.Rows.Add(database[logIndex].loginDates[i].Date.ToString(), database[logIndex].loginDates[i].TimeOfDay.Hours.ToString()+ " : "+database[logIndex].loginDates[i].TimeOfDay.Minutes.ToString(), database[logIndex].logoutDates[i].TimeOfDay.Hours.ToString()+ " : "+database[logIndex].logoutDates[i].TimeOfDay.Minutes.ToString(), (database[logIndex].logoutDates[i].TimeOfDay-database[logIndex].loginDates[i].TimeOfDay).Hours.ToString()+ " : " + (database[logIndex].logoutDates[i].TimeOfDay - database[logIndex].loginDates[i].TimeOfDay).Hours.ToString(), "");
            }
        }
    }
}
