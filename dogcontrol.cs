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
using static BAITAP.Main;

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
            SqlConnection connection = ConnectionManager.connection2;
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
            if (!string.IsNullOrEmpty(selectedDogType))
            {
                SqlConnection connection=ConnectionManager.connection2;
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
    }
}
