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
    public partial class change_password : Form
    {
        public change_password()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection=new SqlConnection(cnt))
            {
                connection.Open();
                if (textBox1.Text == password)
                {
                    if(textBox2.Text==textBox3.Text)
                    {
                        string query2 = string.Format("UPDATE Login SET password='{0}'WHERE username ='{1}'", textBox3.Text, username);
                        SqlCommand cmd = new SqlCommand(query2, connection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập lại đúng mật khẩu!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu cũ!");
                }

                
            }
            
            

        }
    }
}
