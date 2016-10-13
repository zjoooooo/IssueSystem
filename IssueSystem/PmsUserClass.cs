using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssueSystem
{
    class PmsUserClass
    {
        private string username, pwd, level, expiredDate;

        public string Name
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return pwd; }
            set { pwd = value; }
        }
        public string Level
        {
            get { return level; }
            set { level = value; }
        }
        public string ExpiredDate
        {
            get { return expiredDate; }
            set { expiredDate = value; }
        }
       

    }
}
