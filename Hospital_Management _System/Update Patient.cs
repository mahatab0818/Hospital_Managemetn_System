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
    public partial class Update_Patient : Form
    {
        readonly SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = LoginDatabase; Integrated Security = True");
        public Update_Patient()
        {
            InitializeComponent();
        }

        private void Update_Patient_Load(object sender, EventArgs e)
        {
            disp_data();
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            Int64 contact = Convert.ToInt64(ContactTextBox.Text);
            int age = Convert.ToInt32(AgeTextBox.Text);

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Patienttbl set Address='" + AddressTextBox.Text + "',Contact_Number=" + contact + ",Age=" + age + ",Gender='" + comboGender.Text + "',[Blood Group]='" + BloodGroupTextBox.Text + "',Any_Other='" + AnyOtherTextBox.Text + "'where Name='" + NameTextBox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Data Update Successfully");

            disp_data();

            NameTextBox.Clear();
            AddressTextBox.Clear();
            ContactTextBox.Clear();
            AgeTextBox.Clear();
            comboGender.ResetText();
            BloodGroupTextBox.Clear();
            AnyOtherTextBox.Clear();

            MessageBox.Show("Data Update Successfully");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff st = new Staff();
            st.Show();
        }
    }
}
