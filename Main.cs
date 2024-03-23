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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            shopcontrol1.MainForm = this;
            servicecontrol1.MainForm = this;
        }
       
        public void modog()
        {
            dogcontrol1.BringToFront();
        }
        public void mocat()
        {
            catcontrol1.BringToFront();
        }

        public void mospaprice()
        {
            spapricecontrol1.BringToFront();
        }
        
        public void mohotelprice()
        {
            hotelpricecontrol1.BringToFront();
        }
        public void mospabooking()
        {
            spabooking1.BringToFront();
        }

        public void mohotelbooking()
        {
            hotelbooking1.BringToFront();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Main_FormClosing(object sender, FormClosedEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            infocontrol1.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            shopcontrol1.BringToFront();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            servicecontrol1.BringToFront();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            cartcontrol1.BringToFront();
            
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
          Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shopcontrol1_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void spapricecontrol2_Load(object sender, EventArgs e)
        {

        }

        private void spapricecontrol1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void infocontrol1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
