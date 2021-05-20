using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ИЗ12
{
    class User
    {
        public string Email;
        public string FirstName;
        public string SecondName;
        public string Office;
        public DateTime Birthday;

        public string password;
        public string userRole;

        public int enable;

        public List<DateTime> loginDates;
        public List<DateTime> logoutDates;

        public Dictionary<int, string> crashes;
        public User(string _email, string _firstName, string _secondName, string _office, string _password, DateTime _birthday)
        {
            Email = _email;
            FirstName = _firstName;
            SecondName = _secondName;
            Office = _office;
            password = _password;
            Birthday = _birthday;
            userRole = "user";
            enable = 0;
            loginDates = new List<DateTime>();
            logoutDates = new List<DateTime>();
            crashes = new Dictionary<int, string>();
        }
    }
}
