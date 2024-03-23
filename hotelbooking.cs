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
    public partial class hotelbooking : UserControl
    {
        string username = "sss";
        public hotelbooking()
        {
            InitializeComponent();
            showTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string sqlQuery = $"INSERT INTO Booking VALUES (N'sss', '{formattedDate}', N'{comboBox1.Text}', N'{comboBox3.Text}', N'{textBox1.Text}')";
            SqlConnection connection = new SqlConnection(cnt);
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        private void showTable()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string querry = $"SELECT * FROM Booking ";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
