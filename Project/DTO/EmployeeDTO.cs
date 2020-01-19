using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class EmployeeDTO:UserDTO
    {
        string destination;
        double salary;
        DateTime dateOfJoining;

        public string Destination { get => destination; set => destination = value; }
        public double Salary { get => salary; set => salary = value; }
        public DateTime DateOfJoining { get => dateOfJoining; set => dateOfJoining = value; }
    }
}
