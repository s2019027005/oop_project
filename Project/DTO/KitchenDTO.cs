using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class KitchenDTO
    {
        private int itmId;
        private string itmName;
        private int itmQty;

        public int ItmId { get => itmId; set => itmId = value; }
        public string ItmName { get => itmName; set => itmName = value; }
        public int ItmQty { get => itmQty; set => itmQty = value; }

        public KitchenDTO()
        {
            itmId = 0;
            itmName = "";
            itmQty = 0;
        }
        public KitchenDTO(int itmId)
        {
            Console.WriteLine(ItmName + + ItmQty + + ItmId);
        }
    }
}
