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
    public partial class frmPurchesingReport : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmPurchesingReport()
        {
            InitializeComponent();
        }

        private async void export()
        {

            try
            {
                con.Open();

                // Clear existing rows in the DataGridView
                gunaDataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT TOP 15 * FROM purchesing ORDER BY purchesingID DESC", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPID"].Value = reader["purchesingID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["pDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSname"].Value = reader["supplierName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["total"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPaid"].Value = reader["paid"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBalance"].Value = reader["balance"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvStatus"].Value = reader["status"];
                    gunaDataGridView1.Refresh();

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }

        }

        private void frmPurchesingReport_Load(object sender, EventArgs e)
        {
            export();
        }

        public event Action<int> EditClicked;
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gunaDataGridView1.Columns["dgvEdit"].Index && e.RowIndex >= 0)
                {

                    try
                    {
                        DataGridViewCell cell1 = gunaDataGridView1.Rows[e.RowIndex].Cells[0];
                        string cellValue1 = cell1.Value.ToString();
                        DataGridViewCell cell2 = gunaDataGridView1.Rows[e.RowIndex].Cells[1];
                        string cellValue2 = cell2.Value.ToString();
                        DataGridViewCell cell4 = gunaDataGridView1.Rows[e.RowIndex].Cells[3];
                        string cellValue4 = cell4.Value.ToString();
                        DataGridViewCell cell5 = gunaDataGridView1.Rows[e.RowIndex].Cells[4];
                        string cellValue5 = cell5.Value.ToString();
                        DataGridViewCell cell6 = gunaDataGridView1.Rows[e.RowIndex].Cells[5];
                        string cellValue6 = cell6.Value.ToString();
                        DataGridViewCell cell7 = gunaDataGridView1.Rows[e.RowIndex].Cells[6];
                        string cellValue7 = cell7.Value.ToString();


                        frmEditpurches editpurches = new frmEditpurches(cellValue1, cellValue2, cellValue4, cellValue5, cellValue6, cellValue7);
                        editpurches.ShowDialog();
                        export();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    DataGridViewCell cell1 = gunaDataGridView1.Rows[e.RowIndex].Cells[0];
                    string pID = cell1.Value.ToString();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM product WHERE ", con);

                    MessageBox.Show("FUCK" + pID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFilter1_Click(object sender, EventArgs e)
        {
            if(cmbStatus.Text == "All")
            {
                try
                {
                    con.Open();

                    // Clear existing rows in the DataGridView
                    gunaDataGridView1.Rows.Clear();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM purchesing WHERE supplierName LIKE '%" + txtSname.Text + "%' order by purchesingID DESC", con);
                    //cmd.Parameters.AddWithValue("@SNAME", txtSname.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Add a new row to the DataGridView
                        int rowIndex = gunaDataGridView1.Rows.Add();

                        // Populate each cell in the row
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvPID"].Value = reader["purchesingID"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["pDate"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvSname"].Value = reader["supplierName"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["total"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvPaid"].Value = reader["paid"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvBalance"].Value = reader["balance"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvStatus"].Value = reader["status"];
                        gunaDataGridView1.Refresh();

                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    con.Open();

                    // Clear existing rows in the DataGridView
                    gunaDataGridView1.Rows.Clear();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM purchesing WHERE supplierName LIKE '%" + txtSname.Text + "%' AND status LIKE '%" + cmbStatus.Text + "%' order by purchesingID DESC", con);
                    //cmd.Parameters.AddWithValue("@SNAME", txtSname.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Add a new row to the DataGridView
                        int rowIndex = gunaDataGridView1.Rows.Add();

                        // Populate each cell in the row
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvPID"].Value = reader["purchesingID"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["pDate"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvSname"].Value = reader["supplierName"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["total"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvPaid"].Value = reader["paid"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvBalance"].Value = reader["balance"];
                        gunaDataGridView1.Rows[rowIndex].Cells["dgvStatus"].Value = reader["status"];
                        gunaDataGridView1.Refresh();

                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.Close(); 
                    label4.Visible = false;
                }
            }
        }

        private void txtSname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Clear existing rows in the DataGridView
                gunaDataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT * FROM purchesing WHERE supplierName LIKE '%" + txtSname.Text + "%' order by purchesingID DESC", con);
                //cmd.Parameters.AddWithValue("@SNAME", txtSname.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPID"].Value = reader["purchesingID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["pDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSname"].Value = reader["supplierName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["total"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPaid"].Value = reader["paid"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBalance"].Value = reader["balance"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvStatus"].Value = reader["status"];
                    gunaDataGridView1.Refresh();

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {

                label4.Visible = false;
                con.Open();

                // Clear existing rows in the DataGridView
                gunaDataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT * FROM purchesing order by purchesingID DESC", con);
                //cmd.Parameters.AddWithValue("@SNAME", txtSname.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPID"].Value = reader["purchesingID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["pDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSname"].Value = reader["supplierName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["total"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPaid"].Value = reader["paid"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBalance"].Value = reader["balance"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvStatus"].Value = reader["status"];
                    gunaDataGridView1.Refresh();

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
