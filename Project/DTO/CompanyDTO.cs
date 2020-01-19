using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class CompanyDTO
    {
        private string cName;
        private string cAddress;
        private string cService;
        private DateTime cContractStart;
        private DateTime cRecontractRenew;
        private double cDiscount;

        public string CName { get => cName; set => cName = value; }
        public string CAddress { get => cAddress; set => cAddress = value; }
        public string CService { get => cService; set => cService = value; }
        public DateTime CContractStart { get => cContractStart; set => cContractStart = value; }
        public DateTime CRecontractRenew { get => cRecontractRenew; set => cRecontractRenew = value; }
        public double CDiscount { get => cDiscount; set => cDiscount = value; }

        public CompanyDTO()
        {
            CName = "";
            CAddress = "";
            CService = "";
            CContractStart = DateTime.Now;
            CRecontractRenew = DateTime.Now;
            CDiscount = 0.0;
        }
    }
}
