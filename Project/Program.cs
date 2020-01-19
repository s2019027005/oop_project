using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    static class Program
    {
        
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //LoginController c = new LoginController();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.LoginForm());

            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-63Q74F5;Initial Catalog=ABC;Integrated Security=True;");
        }
    }
}
