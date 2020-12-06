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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Patient ad = new Add_Patient();
            ad.Show();
         }

        private void DoctorBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Patient up = new Update_Patient();
            up.Show();
        }

        private void StaffBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete_Patient dl = new Delete_Patient();
            dl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}
