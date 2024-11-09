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
        //LAPTOP-50DBODNC- May tinh cua Hoang
        //SETSUNA\SQLEXPRESS - May tinh cua Tuyn
        //MSI - May tinh cua Son
        
        public static string cnt = @"Data Source=MSI;Initial Catalog=Petshop;Integrated Security=True;Encrypt=False";
        public static string username;
        public static string password;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login login = new Login();
            Application.Run(login);

        }
    }
}
