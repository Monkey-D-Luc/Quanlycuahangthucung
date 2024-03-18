using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAP
{
    internal static class Program
    {
        public static Login login;  
        
        public class ConnectionManager
        {
            public static SqlConnection connection = new SqlConnection(@"Data Source=MSI;Initial Catalog=Petshop;Integrated Security=True;Encrypt=False");
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login = new Login();
            Application.Run(login);

        }
    }
}
