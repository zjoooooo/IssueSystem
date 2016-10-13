using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssueSystem
{
    class PmsVehicleClass
    {
        private string name, iu, plate,expiredDate;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string IU
        {
            get { return iu; }
            set { iu = value; }
        }
        public string Plate
        {
            get { return plate; }
            set { plate = value; }
        }
        public string ExpiredDate
        {
            get { return expiredDate; }
            set { expiredDate = value; }
        }
       

    }
}
