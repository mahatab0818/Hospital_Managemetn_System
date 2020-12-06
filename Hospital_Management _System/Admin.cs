using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management__System
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Control_Admin cll = new Control_Admin();
            cll.Show();

        }

        private void DoctorBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Control_Doctor dct = new Control_Doctor();
            dct.Show();

        }

        private void StaffBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Control_Staff stf = new Control_Staff();
            stf.Show();

        }
    }
}
