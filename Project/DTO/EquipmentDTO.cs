using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class EquipmentDTO
    {
        private int eqpId;
        private string eqpName;
        private int eqpQty;
        private string eqpAsgn;

        public int EqpId { get => eqpId; set => eqpId = value; }
        public string EqpName { get => eqpName; set => eqpName = value; }
        public int EqpQty { get => eqpQty; set => eqpQty = value; }
        public string EqpAsgn { get => eqpAsgn; set => eqpAsgn = value; }

        public EquipmentDTO()
        {
            EqpId = 0;
            EqpName = "";
            EqpQty = 0;
            EqpAsgn = "";
        }
        public EquipmentDTO(int id)
        {
            Console.WriteLine(EqpId + EqpName + EqpQty + EqpAsgn);
        }
        public EquipmentDTO(string name)
        {
            Console.WriteLine(EqpId + EqpName + EqpQty + EqpAsgn);
        }
    }
}
