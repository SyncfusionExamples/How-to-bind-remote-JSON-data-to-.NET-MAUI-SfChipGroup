using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipGroupSample
{
    public class Model
    {
        public double OrderID { get; set; }

        public string CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public double Freight { get; set; }

        public string ShipCity { get; set; }

        public bool Verified { get; set; }

        public string OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }

        public string ShippedDate { get; set; }

        public string ShipAddress { get; set; }

    }
}
