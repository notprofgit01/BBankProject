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

namespace BBankProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P6NJK2N;Initial Catalog=BBDB_1;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {
            Adminlogin Adm = new Adminlogin();
            Adm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTb1='" + EmpIdTb.Text + "' and EmpPassword= '" + EmpPassTb.Text + "'", Con);
            
                DataTable dt = new DataTable();
            _ = sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Mainform Main = new Mainform();
                Main.Show();
                this.Hide();
                Con.Close();

            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();
        }
    }
}
