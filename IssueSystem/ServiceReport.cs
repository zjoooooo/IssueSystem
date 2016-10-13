using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssueSystem
{
    public class ServiceReport
    {
        private string followby, item, itemqty, submitby, starttime, endtime, otstarttime, otendtime, reportsubmittime, solution;

        public string Followby
        {
            get { return followby; }
            set { followby = value; }
        }
        public string Item
        {
            get { return item; }
            set { item = value; }
        }
        public string Itemqty
        {
            get { return itemqty;}
            set { itemqty = value; }
        }
        public string Submitby
        {
            get { return submitby; }
            set { submitby = value; }
        }

        public string Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }
        public string Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }
        public string Otstarttime
        {
            get { return otstarttime; }
            set { otstarttime = value; }
        }
        public string Otendtime
        {
            get { return otendtime; }
            set { otendtime = value; }
        }
        public string Reportsubmittime
        {
            get { return reportsubmittime; }
            set { reportsubmittime = value; }
        }
        public string Solution
        {
            get { return solution; }
            set { solution = value; }
        }


    }
}
