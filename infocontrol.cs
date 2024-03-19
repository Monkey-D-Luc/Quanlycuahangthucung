using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BAITAP.Program;
namespace BAITAP
{
    public partial class infocontrol : UserControl
    {
        public infocontrol()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void infocontrol_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cnt);

        }
    }
}
