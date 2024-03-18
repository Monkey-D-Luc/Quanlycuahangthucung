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
        
        public static string cnt = "Data Source=LAPTOP-50DBODNC;Initial Catalog=Petshop;Integrated Security=True;Encrypt=False";
        
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
