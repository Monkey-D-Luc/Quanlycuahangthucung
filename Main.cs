using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }
        public void modog()
        {
            dogcontrol1.BringToFront();
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
            Program.login.Show();
            
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
    }
}
