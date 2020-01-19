using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class OfficeDTO
    {
        private string offAddress;
        private double offRent;
        private double offExpense;
        private double offEmp;

        public string OffAddress { get => offAddress; set => offAddress = value; }
        public double OffEmp { get => offEmp; set => offEmp = value; }
        public double OffRent { get => offRent; set => offRent = value; }
        public double OffExpense { get => offExpense; set => offExpense = value; }

        public OfficeDTO()
        {
            OffAddress = "";
            OffEmp = 0;
            offRent = 0.0;
            OffExpense = 0.0;
        }
    }
}
