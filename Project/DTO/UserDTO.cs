using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Travel_and_Tours
{
    class UserDTO
    {
        int id;
        string firstName;
        string lastName;
        string email;
        string password;
        string idCardNo;
        string contactNo;
        int isAdmin;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string IdCardNo { get => idCardNo; set => idCardNo = value; }
        public string ContactNo { get => contactNo; set => contactNo = value; }
        public string Password { get => password; set => password = value; }
        public int IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
