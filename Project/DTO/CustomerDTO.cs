using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class CustomerDTO:UserDTO
    {
        string details;

        public string Details { get => details; set => details = value; }
    }
}
