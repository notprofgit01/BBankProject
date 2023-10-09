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
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P6NJK2N;Initial Catalog=BBDB_1;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string Query = "Select * from DonarTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonarsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bloodStock()
        {
            Con.Open();
            string Query = "Select * from BloodTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }

        private void DonarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonarsDGV.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTb.Text = DonarsDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void reset()
        {
            DNameTb.Text = "";
            BGroupTb.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "")
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    int stock = 1;
                    string query = "Update BloodTb1 set BStock=" + stock + "where BGroup='" + BGroupTb.Text + "';";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dunation Successfully");
                    Con.Close();
                    reset();
                    bloodStock();
                                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
