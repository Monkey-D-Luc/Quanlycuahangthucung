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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection=new SqlConnection(cnt))
            {
                connection.Open();
                string query = String.Format("INSERT INTO Login (username,password,role) values('{0}','{1}',N'Người dùng')", textBox1.Text, textBox2.Text);
                
                SqlCommand cmd = new SqlCommand(query,connection);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Đăng kí thành công");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
