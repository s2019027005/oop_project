using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class BusDTO:CompanyDTO
    {
        private string busRoute;
        private string busType;
        private string busModel;

        public string BusRoute { get => busRoute; set => busRoute = value; }
        public string BusType { get => busType; set => busType = value; }
        public string BusModel { get => busModel; set => busModel = value; }

        public BusDTO()
        {
            BusRoute = "";
            BusType = "";
            busModel = "";
        }
        public BusDTO(string a)
        {
            Console.WriteLine(BusRoute + BusType + busModel);
        }
    }
}
