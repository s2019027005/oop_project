using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class BookingDTO
    {
        private string cusName;
        private DateTime bookDate;
        private DateTime bookends;
        private string book;
        private string bookinDetails;

        public string CusName { get => cusName; set => cusName = value; }
        public string Book { get => book; set => book = value; }
        public string BookinDetails { get => bookinDetails; set => bookinDetails = value; }
        public DateTime BookDate { get => bookDate; set => bookDate = value; }
        public DateTime Bookends { get => bookends; set => bookends = value; }
    }
}
