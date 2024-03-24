﻿using System;
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
    public partial class cartcontrol : UserControl
    {
        public cartcontrol()
        {
            InitializeComponent();
            showTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void cartcontrol_Load(object sender, EventArgs e)
        {

        }
        private void showTable()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string querry = $"SELECT * FROM Cart ; ";
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

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            if (selectedIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                int idToDelete = Convert.ToInt32(selectedRow.Cells[0].Value);
                DataRow deletedRow = ((DataRowView)selectedRow.DataBoundItem).Row;

                DeleteFromDatabase(idToDelete);


                AddToDog(deletedRow);
                MessageBox.Show("mua thanh cong");
            }
           
        }
        private void DeleteFromDatabase(int id)
        {
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "DELETE FROM Cart WHERE Dog_id = @Dog_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dog_id", id);
                command.ExecuteNonQuery();
            }
        }
        private void AddToDog(DataRow deletedRow)
        {
            // Chuyển dữ liệu từ hàng đã xóa vào bảng Cart
            // Ví dụ: Sử dụng một SqlCommand để chèn dữ liệu vào bảng Cart
            // Đảm bảo rằng bạn đã thiết lập đúng chuỗi kết nối và cấu trúc của bảng Cart
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "INSERT INTO Dog (Dog_id, Dog_name,Dog_type,Dog_gender,Dog_age,Dog_price) VALUES (@Dog_id, @Dog_name,@Dog_type,@Dog_gender,@Dog_age,@Dog_price)"; // Thay đổi ColumnName1, ColumnName2, ... và VALUES tương ứng
                SqlCommand command = new SqlCommand(query, connection);
                // Thay đổi các tham số và giá trị tương ứng
                command.Parameters.AddWithValue("@Dog_id", deletedRow["Dog_id"]);
                command.Parameters.AddWithValue("@Dog_name", deletedRow["Dog_name"]);
                command.Parameters.AddWithValue("@Dog_type", deletedRow["Dog_type"]);
                command.Parameters.AddWithValue("@Dog_gender", deletedRow["Dog_gender"]);
                command.Parameters.AddWithValue("@Dog_age", deletedRow["Dog_age"]);
                command.Parameters.AddWithValue("@Dog_price", deletedRow["Dog_price"]);
                command.ExecuteNonQuery();
            }
        }
    }
}
