using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BBankProject
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPassword.Text == "" )
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "Update EmployeeTb1 set EmpId= '" + EmpName.Text + "', EmpPass=" + EmpPassword.Text + "' where EmpNum=" + key + ";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully  Updated");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P6NJK2N;Initial Catalog=BBDB_1;Integrated Security=True");

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        private void Reset()
        {
            EmpName.Text = "";
            EmpPassword.Text = "";
            key = 0;
        }
        private void populate()
        {
            Con.Open();
            string Query = "Select * from EmployeeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPassword.Text == "")
            {
                MessageBox.Show("Information missing");
            }
            else
            {
                try
                {
                    string query = "insert into EmployeeTb1 values ('" + EmpName.Text + "','" + EmpPassword.Text + "')";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Saved");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpName.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpPassword.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (EmpName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
