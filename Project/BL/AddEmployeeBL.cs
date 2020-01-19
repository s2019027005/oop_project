using ABC_Travel_and_Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class AddEmployeeBL
    {
        List<EmployeeDTO> empList;

        public AddEmployeeBL()
        {
            empList = new List<EmployeeDTO>();
        }



        public void addEmployee(EmployeeDTO obj)
        {

            empList.Add(obj);
        }

        public List<EmployeeDTO> getEmployeesList()
        {
            return empList;
        }
    }
}
