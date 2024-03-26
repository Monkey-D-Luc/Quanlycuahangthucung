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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace BAITAP
{
    public partial class infocontrol : UserControl
    {
        public infocontrol()
        {
            InitializeComponent();
            load_info();
            
        }
        private void load_info()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                string query = String.Format("SELECT * FROM Login WHERE username ='{0}'", username);
                da = new SqlDataAdapter(query, connection);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0]["name"].ToString();
                textBox2.Text = dt.Rows[0]["andress"].ToString();
                textBox3.Text = dt.Rows[0]["phone_number"].ToString();
                textBox4.Text = dt.Rows[0]["birthday"].ToString();
                label9.Text = dt.Rows[0]["role"].ToString();
                textBox7.Text = dt.Rows[0]["email"].ToString();
                label10.Text = dt.Rows[0]["password"].ToString();
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void infocontrol_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = String.Format("UPDATE Login SET name = '{0}', andress = '{1}', phone_number='{2}',birthday='{3}',email='{4}' WHERE username='{5}';", textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox7.Text,username);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("OK!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_password cp=new change_password();
            cp.ShowDialog();
            load_info();
            
        }
    }
}
