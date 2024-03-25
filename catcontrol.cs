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
    public partial class catcontrol : UserControl
    {
        public catcontrol()
        {
            InitializeComponent();
            LoadCatType();
            showTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadCatType()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string query = "SELECT Cat_type FROM Cat";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Cat_type", typeof(string));

            while (rdr.Read())
            {
                if (!dt.AsEnumerable().Any(row => rdr["Cat_type"].ToString() == row.Field<string>("Cat_type")))
                {
                    dt.Rows.Add(rdr["Cat_type"].ToString());
                }
            }
            dt.Load(rdr);
            comboBox1.ValueMember = "Cat_type";
            comboBox1.DataSource = dt;
            connection.Close();
        }
        private void showTable()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string querry = $"SELECT * FROM Cat;";
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
                    dt.Columns["Cat_id"].ColumnName = "ID";
                    dt.Columns["Cat_name"].ColumnName = "Tên pet";
                    dt.Columns["Cat_type"].ColumnName = "Giống pet";
                    dt.Columns["Cat_gender"].ColumnName = "Giới tính";
                    dt.Columns["Cat_age"].ColumnName = "Tuổi pet";
                    dt.Columns["Cat_price"].ColumnName = "Giá cả";
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            showTable();
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
                MessageBox.Show("Thêm vào giỏ thành công");
                showTable();
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
                string query = "DELETE FROM Cat WHERE Cat_id = @Cat_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cat_id", id);
                command.ExecuteNonQuery();
            }
        }
        private void AddToCart(DataRow deletedRow)
        {

            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "INSERT INTO Cart VALUES (@Cat_id, @Cat_name,@Cat_type,@Cat_gender,@Cat_age,@Cat_price,N'Mèo')";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cat_id", deletedRow["ID"]);
                command.Parameters.AddWithValue("@Cat_name", deletedRow["Tên pet"]);
                command.Parameters.AddWithValue("@Cat_type", deletedRow["Giống pet"]);
                command.Parameters.AddWithValue("@Cat_gender", deletedRow["Giới tính"]);
                command.Parameters.AddWithValue("@Cat_age", deletedRow["Tuổi pet"]);
                command.Parameters.AddWithValue("@Cat_price", deletedRow["Giá cả"]);
                command.ExecuteNonQuery();
            }
        }
    }
}
