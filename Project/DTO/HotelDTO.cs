using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class HotelDTO:CompanyDTO { 
        private string hStatus;
        private string hRoomtype;
        private string hLocation;
        private double hRoom;

        public string HStatus { get => hStatus; set => hStatus = value; }
        public string HRoomtype { get => hRoomtype; set => hRoomtype = value; }
        public double HRoom { get => hRoom; set => hRoom = value; }
        public string HLocation { get => hLocation; set => hLocation = value; }

        public HotelDTO()
        {
            HStatus = "";
            HRoomtype = "";
            HRoom = 00;
            HLocation = "";
        }
        public HotelDTO(string locate)
        {
            Console.WriteLine(HRoomtype + HStatus + HRoom + HLocation);
        }
    }
}
