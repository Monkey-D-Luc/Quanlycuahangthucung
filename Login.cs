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

namespace BAITAP
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String username, password;
                username = textBox1.Text;
                password = textBox2.Text;
                SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-50DBODNC;Initial Catalog=BAITAP;Integrated Security=True;Encrypt=False");
                connection.Open();
                String query = "SELECT * FROM login WHERE username ='" + username + "' AND password = '" + password + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Main main = new Main();
                    main.ShowDialog();
                    connection.Close();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!");
                    textBox1.Clear();
                    textBox2.Clear();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Console.WriteLine("abc");
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
            this.Close();
            
        }
    }
}
