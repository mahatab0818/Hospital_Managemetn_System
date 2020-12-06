using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_Management__System.Connection;

namespace Hospital_Management__System
{
    public partial class Registration : Form
    {
        public object ServerConnection { get; private set; }

        public Registration()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearControls();
            FirstNameTextBox.Select();
        }

        private void clearControls()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            loadUserData();
            FirstNameTextBox.Select();

        }

        private void loadUserData()
        {
            DataTable userData = SqlServerConnection.executeSQL("SELECT (First_Name +' '+Last_Name)AS Fullname,Username from Logintbl ");
            dataGridView1.DataSource = userData;
            dataGridView1.Columns[0].HeaderText = "FullName";
            dataGridView1.Columns[1].HeaderText = "Username";
            dataGridView1.Columns[0].Width = 234;
            dataGridView1.Columns[1].Width = 234;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Save Data";

            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter First Name",caption,btn,ico);
                FirstNameTextBox.Select();
                return;
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                MessageBox.Show("Please enter Last Name", caption, btn, ico);
                LastNameTextBox.Select();
                return;
            }

            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                MessageBox.Show("Please enter User Name", caption, btn, ico);
                UsernameTextBox.Select();
                return;
            }

            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Please enter Password", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }

            if (string.IsNullOrEmpty(ReenterTextBox.Text))
            {
                MessageBox.Show("Please Confirm Password", caption, btn, ico);
                ReenterTextBox.Select();
                return;
            }

            if (PasswordTextBox.Text != ReenterTextBox.Text)
            {
                MessageBox.Show("Your Password dose not match", caption, btn, ico);
                ReenterTextBox.Select();
                return;
            }

            string yourSQL = "SELECT username FROM Logintbl WHERE username ='" + UsernameTextBox.Text + "'";
            DataTable checkDuplicates = Hospital_Management__System.Connection.SqlServerConnection.executeSQL(yourSQL);

            if (checkDuplicates.Rows.Count > 0)
            {
                MessageBox.Show("The Username already exist,please try another username",
                    "Registration Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UsernameTextBox.SelectAll();
                return;
            }

            DialogResult result;
            result = MessageBox.Show("Do you want to save the Data", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                string mySQL = string.Empty;

                mySQL += "INSERT INTO Logintbl (First_Name,Last_Name,Email_Address,Username,Password,Usertype)";
                mySQL += "VALUES ('" + FirstNameTextBox.Text + "','" + LastNameTextBox.Text + "','" + EmailTextBox.Text + "','"+UsernameTextBox.Text+"','"+PasswordTextBox.Text+"','"+UserTypeTextBox.Text+"')";

                Hospital_Management__System.Connection.SqlServerConnection.executeSQL(mySQL);

                MessageBox.Show("The Data has been saved Successfully", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadUserData();
                //clearControls();
            }

        }

        //private void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Do You want to delete permanently?", "Delete Data",
        //            MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)
        //            == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            SqlServerConnection.executeSQL("DELETE FROM Logintbl WHERE Username='" + dataGridView1.CurrentRow.Cells[1].Value + "'");
        //            loadUserData();

        //            MessageBox.Show("The Record has been deleted. ", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
