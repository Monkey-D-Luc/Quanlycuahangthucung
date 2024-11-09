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
    public partial class shopcontrol : UserControl
    { 
        public Main MainForm
        {
            get;set;
        }
        public shopcontrol()
        {
            InitializeComponent();
        }

        private void shopcontrol_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MainForm.modog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MainForm.mocat();
        }



        private void label8_Click(object sender, EventArgs e)
        {
            MainForm.mocat();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MainForm.modog();
        }
    }
}
