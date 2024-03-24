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
    public partial class dogcontrol : UserControl
    {
        
        public dogcontrol()
        {
            InitializeComponent();
            LoadDogType();
            showTable();
        }
        private void LoadDogType()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string query = "SELECT dog_type FROM Dog";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("dog_type", typeof(string));

            while (rdr.Read())
            {
                if (!dt.AsEnumerable().Any(row => rdr["dog_type"].ToString() == row.Field<string>("dog_type")))
                {
                    dt.Rows.Add(rdr["dog_type"].ToString());
                }
            }
            dt.Load(rdr);
            comboBox1.ValueMember = "dog_type";
            comboBox1.DataSource = dt;
            connection.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string selectedDogType = comboBox1.Text;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (!string.IsNullOrEmpty(selectedDogType))
            {
                SqlConnection connection=new SqlConnection(cnt);
                string querry = "SELECT * FROM Dog WHERE dog_type =@DogType";
                SqlCommand cmd = new SqlCommand(querry, connection);
                cmd.Parameters.AddWithValue("@DogType", selectedDogType);
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
                    if (connection.State == ConnectionState.Open) {
                    connection.Close();}
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại chó từ danh sách");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {  
                if (radioButton1.Checked)
                {
                    dataGridView1.Sort(dataGridView1.Columns["Dog_price"], ListSortDirection.Ascending);
                }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                if (radioButton2.Checked)
                {
                    dataGridView1.Sort(dataGridView1.Columns["Dog_price"], ListSortDirection.Descending);
                }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                string query = "DELETE FROM Dog WHERE Dog_id = @Dog_id"; 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dog_id", id);
                command.ExecuteNonQuery();
            }
        }
        private void AddToCart(DataRow deletedRow)
        {
            // Chuyển dữ liệu từ hàng đã xóa vào bảng Cart
            // Ví dụ: Sử dụng một SqlCommand để chèn dữ liệu vào bảng Cart
            // Đảm bảo rằng bạn đã thiết lập đúng chuỗi kết nối và cấu trúc của bảng Cart
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "INSERT INTO Cart VALUES (@Dog_id, @Dog_name,@Dog_type,@Dog_gender,@Dog_age,@Dog_price,N'Chó')"; // Thay đổi ColumnName1, ColumnName2, ... và VALUES tương ứng
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
        private void showTable()
        {
            SqlConnection connection = new SqlConnection(cnt);
            string querry = $"SELECT * FROM Dog;";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            showTable();
        }
    }
}
