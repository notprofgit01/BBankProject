using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BBankProject
{
    public partial class ViewPatients : Form
    {
        public ViewPatients()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P6NJK2N;Initial Catalog=BBDB_1;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string Query = "Select * from PatientTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0;

        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAgeTb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PPhoneTb.Text = PatientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PGenCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PBGroupCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString();
            PAddressTb.Text = PatientsDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PPhoneTb.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAddressTb.Text = "";
            key = 0;
        }
        

        private void ViewPatients_Load(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Patient to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTb1 where PId =" + key + ";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient info Successfully Deleted");
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

        private void label5_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            Pat.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        
            if (PNameTb.Text == "" || PPhoneTb.Text == "" || PAgeTb.Text == "" || PGenCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAddressTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "Update PatientTb1 set Pname= '"+PNameTb.Text+"', Page="+PAgeTb.Text+",Pphone='"+PPhoneTb.Text+"',PGender='"+PGenCb.SelectedItem.ToString()+"',PBGroup='"+PBGroupCb.SelectedItem.ToString()+"',Paddress'"+PAddressTb.Text+"'where PId="+key +";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient info Successfully Updated");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //if(key == 0)
            //{
            //    MessageBox.Show("Select the Patient to Delete");
            //}
            //else
            //{
            //    try
            //    {
            //        string query = "Delete from PatientTb1 where PId ="+key+";";

            //        Con.Open();
            //        SqlCommand cmd = new SqlCommand(query, Con);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Patient info Successfully Deleted");
            //        Con.Close();
            //        Reset();
            //        populate();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }
    }
}
