using ABC_Travel_and_Tours;
using Project.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.BL
{
    class LoginBL
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        List<UserDTO> userList;

        public LoginBL()
        {
            userList = new List<UserDTO>();
            sqlCon = new SqlConnection("Data Source=DESKTOP-63Q74F5;Initial Catalog=Project;Integrated Security=True");
            cmd = new SqlCommand();
        }
        public bool Login(UserDTO u)
        {
            UserDTO obj = new UserDTO();
            obj.FirstName = "Fawad";
            obj.LastName = "Ahmed";
            obj.Id = 0;
            obj.IdCardNo = "35102";
            obj.Password = "fawad";
            obj.Email = "fawadafzal";
            obj.ContactNo = "03334713097";
            
            userList.Add(obj);

            foreach (UserDTO user in userList)
            {
                if(user.Email == u.Email && user.Password == u.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
            
        }

        public Boolean EmployeeLogin(string email,string pass)
        {
            bool flag = false;

            sqlCon.Open();
            cmd.CommandText = "Select * From Employees Where email = '" + email + "' And password = '"+pass+"' And isAdmin = '"+1+"'";
            cmd.Connection = sqlCon;
            SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (dr["email"].ToString().Equals(email) && dr["password"].ToString().Equals(pass))
                    {
                        flag = true;
                    }

                }
            sqlCon.Close();
            return flag;
        }
    }
}
