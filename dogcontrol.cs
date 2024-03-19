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
        {   try
            {
                if (radioButton1.Checked)
                {
                    dataGridView1.Sort(dataGridView1.Columns["Dog_price"], ListSortDirection.Ascending);
                }
            }
            catch (Exception){ MessageBox.Show("Vui lòng chọn một loại chó từ danh sách"); }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked)
                {
                    dataGridView1.Sort(dataGridView1.Columns["Dog_price"], ListSortDirection.Descending);
                }
            }
            catch (Exception) { MessageBox.Show("Vui lòng chọn một loại chó từ danh sách"); }
        }
    }
}
