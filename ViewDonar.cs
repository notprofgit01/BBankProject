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
    public partial class ViewDonar : Form
    {
        public ViewDonar()
        {
            InitializeComponent();
            populate();
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
            DonarDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ViewDonar_Load(object sender, EventArgs e)
        {

        }

        private void DonarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
