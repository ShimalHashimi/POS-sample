using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSSystem
{
    public partial class frm2Report : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frm2Report()
        {
            InitializeComponent();
        }

        private void frm2Report_Load(object sender, EventArgs e)
        {
            btnFilter2.Visible = false;
            label5.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            panel1.Size = new System.Drawing.Size(300, 120);
            reportload();
        }

        private void reportload()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%soldout%'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnFilter1_Click(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            reportload();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            btnFilter2.Visible = false;
            label5.Visible = false;
            dateTimePicker2.Visible = false;
            btnFilter1.Visible = true;
            label3.Text = "Date :";
            panel1.Size = new System.Drawing.Size(300, 120);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            btnFilter1.Visible = false;
            btnFilter2.Visible = true;
            label3.Text = "From :";
            label5.Visible = true;
            label5.Text = "TO :";
            dateTimePicker2.Visible = true;
            panel1.Size = new System.Drawing.Size(300, 160);
        }

        private void reportload2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%soldout%'", con);

                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnFilter2_Click(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            reportload2();
        }
    }
}
