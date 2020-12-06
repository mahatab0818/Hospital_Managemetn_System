using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hospital_Management__System.Connection;

namespace Hospital_Management__System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UserNameTextBox.Select();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration register = new Registration();
            register.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;

            }
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=LoginDatabase;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Logintbl where username='" + UserNameTextBox.Text + "'and password='" + PasswordTextBox.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            string cmbItemvalue = comboBox1.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Usertype"].ToString() == cmbItemvalue)
                    {
                        MessageBox.Show("You are login as " + dt.Rows[i][6]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            Admin ad = new Admin();
                            ad.Show();
                            this.Hide();
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            Staff st = new Staff();
                            st.Show();
                            this.Hide();
                        }
                        else
                        {
                            Doctor dc = new Doctor();
                            dc.Show();
                            this.Hide();
                            
                        }
                    }
                }
            }
            
            else
            {
                MessageBox.Show("The Username or Password is incorrect ");
            }
        }
    }
}
