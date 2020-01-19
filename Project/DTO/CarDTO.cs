using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class CarDTO:CompanyDTO
    {
        private string carCity;
        private string carDriver;
        private string carType;

        public string CarCity { get => carCity; set => carCity = value; }
        public string CarDriver { get => carDriver; set => carDriver = value; }
        public string CarType { get => carType; set => carType = value; }

        public CarDTO()
        {
            CarCity = "";
            CarDriver = "";
            CarType = "";
        }
        public CarDTO(bool driver)
        {
            if(driver==true)
            {
                Console.WriteLine("Car has been booked with driver");
            }
            else
            {
                Console.WriteLine("Car has been selected without Driver");
            }
        }
    }
}
