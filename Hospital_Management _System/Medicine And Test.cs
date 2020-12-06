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

namespace Hospital_Management__System
{

    public partial class Medicine_And_Test : Form
    {
        readonly SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = LoginDatabase; Integrated Security = True");
        public Medicine_And_Test()
        {
            InitializeComponent();
        }

        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Patienttbl";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Medicine_And_Test_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "")
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LoginDatabase; Integrated Security = True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Patienttbl where name= '" + NameTextBox.Text + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }


        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Patienttbl set Medicine='" + MedicineTextBox.Text + "',Test='" + TestTextBox.Text + "'where Name='" + NameTextBox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Data Save Successfully");

            disp_data();

            NameTextBox.Clear();
            AddressTextBox.Clear();
            ContactTextBox.Clear();
            AgeTextBox.Clear();
            comboGender.ResetText();
            BloodGroupTextBox.Clear();
            AnyOtherTextBox.Clear();
            MedicineTextBox.Clear();
            TestTextBox.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTextBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            AddressTextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ContactTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            AgeTextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboGender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            BloodGroupTextBox.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            AnyOtherTextBox.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor dct = new Doctor();
            dct.Show();
        }
    }
}
