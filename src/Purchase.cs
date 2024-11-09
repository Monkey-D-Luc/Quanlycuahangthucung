using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BAITAP.cartcontrol;
namespace BAITAP
{
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            CultureInfo cul = new CultureInfo("vi-VN");
            label6.Text= totalPrice.ToString("C", cul); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
