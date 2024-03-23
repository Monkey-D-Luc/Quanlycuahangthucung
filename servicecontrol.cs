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
    public partial class servicecontrol : UserControl
    {
        public Main MainForm
        {
            get; set;
        }
        public servicecontrol()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm.mospaprice();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm.mohotelprice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.mospabooking();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm.mohotelbooking();
        }
    }
}
