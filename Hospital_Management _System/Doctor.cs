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
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        private void DetailsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Details dt = new Details();
            dt.Show();
        }

        private void MedicineBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicine_And_Test mt = new Medicine_And_Test();
            mt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}
