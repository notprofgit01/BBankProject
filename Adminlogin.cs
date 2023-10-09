using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBankProject
{
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void Password_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter admin password");
            }
            else if(AdminPassTb.Text=="Password")
            {
                Employees Emp = new Employees();
                Emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password.Contact the system Admin");
                AdminPassTb.Text = "";
            }
        }
    }
}
