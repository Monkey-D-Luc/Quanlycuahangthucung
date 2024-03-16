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
using static BAITAP.Main;

namespace BAITAP
{
    public partial class dogcontrol : UserControl
    {
        
        public dogcontrol()
        {
            InitializeComponent();
            SqlConnection connection = ConnectionManager.connection2;
            string query = "SELECT dog_type FROM Dog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader rdr;
            connection.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("dog_type", typeof(string));
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (!dt.AsEnumerable().Any(row => rdr["dog_type"].ToString()== row.Field<string>("dog_type")))
                {
                    dt.Rows.Add(rdr["dog_type"].ToString());
                }
            }
            dt.Load(rdr);
            comboBox1.ValueMember = "dog_type";
            comboBox1.DataSource = dt;
            connection.Close();
          

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
