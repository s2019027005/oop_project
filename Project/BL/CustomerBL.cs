using ABC_Travel_and_Tours;
using Project.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class CustomerBL
    {
        List<CustomerDTO> custList;

        public CustomerBL()
        {
            custList = new List<CustomerDTO>();
        }



        public void addCustomer(CustomerDTO obj)
        {
            
            custList.Add(obj);
        }

        public List<CustomerDTO> getCustomersList()
        {
            return custList;
        }

    }
}
