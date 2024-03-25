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
    public partial class spabooking : UserControl
    {
        public spabooking()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string sqlQuery = $"INSERT INTO Booking VALUES (N'{Login.id}', '{formattedDate}', N'{comboBox1.Text}', N'{comboBox3.Text}', N'{textBox1.Text}')";
            SqlConnection connection = new SqlConnection(cnt);
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            showTable();
        }
        private void sttColumn(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.Rows[row.Index].Cells[0].Value = (row.Index + 1).ToString();
            }
        }
        public void showTable()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string querry = $"SELECT ngayHen, thuCung, canNang, moTa FROM Booking WHERE username= '{Login.id}'; ";
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
                    dt.Columns["ngayHen"].ColumnName = "Ngày hẹn";
                    dt.Columns["thuCung"].ColumnName = "Thú cưng";
                    dt.Columns["canNang"].ColumnName = "Cân nặng";
                    dt.Columns["moTa"].ColumnName = "Mô tả";
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

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            if (selectedIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                int idToDelete = Convert.ToInt32(selectedRow.Cells[0].Value);
                DataRow deletedRow = ((DataRowView)selectedRow.DataBoundItem).Row;

                DeleteFromDatabase(idToDelete);


                AddToCart(deletedRow);

                // Sau khi xóa, load lại dữ liệu vào DataGridView
                pictureBox6_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thú cưng bạn muốn đưa vào giỏ.");
            }
        }
        private void DeleteFromDatabase(int id)
        {
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "DELETE FROM Booking WHERE Dog_id = @Dog_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dog_id", id);
                command.ExecuteNonQuery();
            }
        }
        }
    }
}
