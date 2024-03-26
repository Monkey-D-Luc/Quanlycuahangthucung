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

    public partial class cartcontrol : UserControl
    {
        public cartcontrol()
        {
            InitializeComponent();
            showTable();
            
        }
        private void showTotal()
        {
            double totalPrice = 0;
            bool hasPrice = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["Price"].Value != null && row.Cells["Price"].Value != DBNull.Value)
                {
                    double price;
                    if (double.TryParse(row.Cells["Price"].Value.ToString(), out price))
                    {
                        totalPrice += price;
                        hasPrice = true; 
                    }
                }
            }
            if (!hasPrice)
            {
                label1.Text = "Chọn sản phẩm từ cửa hàng";
            }
            else
            {
                label1.Text = totalPrice.ToString("C");
            }
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                }
                else
                {
                    dataGridView1.Visible = false;
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
            Purchase purchase = new Purchase();
            purchase.ShowDialog();
        }
        private void DeleteFromDatabase(int id)
        {
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "DELETE FROM Cart WHERE  Id = @Dog_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dog_id", id);
                command.ExecuteNonQuery();
            }
        }
        private void AddToDog(DataRow deletedRow)
        {
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "INSERT INTO Dog (Dog_id, Dog_name,Dog_type,Dog_gender,Dog_age,Dog_price) VALUES (@Dog_id, @Dog_name,@Dog_type,@Dog_gender,@Dog_age,@Dog_price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dog_id", deletedRow["Id"]);
                command.Parameters.AddWithValue("@Dog_name", deletedRow["PetName"]);
                command.Parameters.AddWithValue("@Dog_type", deletedRow["PetType"]);
                command.Parameters.AddWithValue("@Dog_gender", deletedRow["Gender"]);
                command.Parameters.AddWithValue("@Dog_age", deletedRow["Age"]);
                command.Parameters.AddWithValue("@Dog_price", deletedRow["Price"]);
           
                command.ExecuteNonQuery();
            }
        }
        private void AddToCat(DataRow deletedRow)
        {
            using (SqlConnection connection = new SqlConnection(cnt))
            {
                connection.Open();
                string query = "INSERT INTO Cat (Cat_id, Cat_name,Cat_type,Cat_gender,Cat_age,Cat_price) VALUES (@Cat_id, @Cat_name,@Cat_type,@Cat_gender,@Cat_age,@Cat_price)"; 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cat_id", deletedRow["Id"]);
                command.Parameters.AddWithValue("@Cat_name", deletedRow["PetName"]);
                command.Parameters.AddWithValue("@Cat_type", deletedRow["PetType"]);
                command.Parameters.AddWithValue("@Cat_gender", deletedRow["Gender"]);
                command.Parameters.AddWithValue("@Cat_age", deletedRow["Age"]);
                command.Parameters.AddWithValue("@Cat_price", deletedRow["Price"]);

                command.ExecuteNonQuery();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            if (selectedIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                int idToDelete = Convert.ToInt32(selectedRow.Cells["Id"].Value); 
                DataRow deletedRow = ((DataRowView)selectedRow.DataBoundItem).Row;
                DeleteFromDatabase(idToDelete);
                string species = deletedRow["Species"].ToString();
                if (species == "Chó")
                {
                    AddToDog(deletedRow);
                    MessageBox.Show("Xóa đơn hàng thành công");
                }
                else if (species == "Mèo")
                {
                    AddToCat(deletedRow);
                    MessageBox.Show("Xóa đơn hàng thành công");
                }
                else
                {
                    MessageBox.Show("Loại không được hỗ trợ");
                }

                showTable();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            showTotal();
            showTable();        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
