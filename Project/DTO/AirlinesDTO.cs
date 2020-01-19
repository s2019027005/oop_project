using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class AirlinesDTO:CompanyDTO
    {
        private string airDestin;

        public string AirDestin { get => airDestin; set => airDestin = value; }

        public AirlinesDTO()
        {
            AirDestin = "";
        }
        public AirlinesDTO(string dest)
        {

        }
    }

}
