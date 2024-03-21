using System;
using System.Collections;
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
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                string query = String.Format("SELECT * FROM Login WHERE username ='{0}'",username);
                da = new SqlDataAdapter(query,connection);
                da.Fill(dt);
            }
            textBox1.Text = dt.Rows[0]["name"].ToString();
            textBox2.Text = dt.Rows[0]["andress"].ToString();
            textBox3.Text = dt.Rows[0]["phone_number"].ToString();
            textBox4.Text = dt.Rows[0]["birthday"].ToString();
            label9.Text= dt.Rows[0]["role"].ToString();
            textBox7.Text = dt.Rows[0]["email"].ToString();
            textBox8.Text = dt.Rows[0]["password"].ToString();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void infocontrol_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
