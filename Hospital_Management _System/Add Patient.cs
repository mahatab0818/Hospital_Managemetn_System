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
    public partial class Add_Patient : Form
    {
        readonly SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = LoginDatabase; Integrated Security = True");
        public Add_Patient()
        {
            InitializeComponent();
        }

        private void Add_Patient_Load(object sender, EventArgs e)
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
            cmd.CommandText = "insert into Patienttbl values('" + NameTextBox.Text + "','" + AddressTextBox.Text + "'," + contact + "," + age + ",'" + comboGender.Text + "','" + BloodGroupTextBox.Text + "','" + AnyOtherTextBox.Text + "','" + MedicineTextBox.Text + "','" + TestTextBox.Text + "')";
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
