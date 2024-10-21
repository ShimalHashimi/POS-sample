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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace POSSystem
{
    public partial class frmSupplier : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmSupplier()
        {
            InitializeComponent();
        }

        private void loadSupplier()
        {
            try
            {
                con.Open();

                // Clear existing rows in the DataGridView
                gunaDataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT * FROM supplier", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSid"].Value = reader["supplierID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["name"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvCon1"].Value = reader["contact1"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvCon2"].Value = reader["contact2"];
                    gunaDataGridView1.Refresh();

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSID.Text == "" || txtSname.Text == ""|| txtCon1.Text == "")
            {
                MessageBox.Show("Empty Value");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into supplier(supplierID, name, contact1, contact2) values(@SID, @SNM, @SC1, @SC2)", con);
                    cmd2.Parameters.AddWithValue("@SID", txtSID.Text);
                    cmd2.Parameters.AddWithValue("@SNM", txtSname.Text);
                    cmd2.Parameters.AddWithValue("@SC1", txtCon1.Text);
                    cmd2.Parameters.AddWithValue("@SC2", txtCon2.Text);

                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Data has been added.");
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    con.Close();
                    loadSupplier();
                    txtSID.Text = "";
                    txtSname.Text = "";
                    txtCon1.Text = "";
                    txtCon2.Text = "";
                    txtSID.Focus();
                }

            }
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            loadSupplier();
        }

        private void txtSID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSname.Focus();
            }
        }

        private void txtSname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCon1.Focus();
            }
        }

        private void txtCon1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCon2.Focus();
            }
        }

        private void txtCon2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSID.Text == "" || txtSname.Text == "" || txtCon1.Text == "")
                {
                    MessageBox.Show("Empty Value");
                }
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("insert into supplier(supplierID, name, contact1, contact2) values(@SID, @SNM, @SC1, @SC2)", con);
                        cmd2.Parameters.AddWithValue("@SID", txtSID.Text);
                        cmd2.Parameters.AddWithValue("@SNM", txtSname.Text);
                        cmd2.Parameters.AddWithValue("@SC1", txtCon1.Text);
                        cmd2.Parameters.AddWithValue("@SC2", txtCon2.Text);

                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Data has been added.");
                        con.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    finally
                    {
                        con.Close();
                        loadSupplier();
                        txtSID.Text = "";
                        txtSname.Text = "";
                        txtCon1.Text = "";
                        txtCon2.Text = "";
                        txtSID.Focus();
                    }

                } 
            }
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gunaDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    gunaDataGridView1.CurrentRow.Selected = true;

                    txtSID.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvSID"].FormattedValue.ToString();
                    txtSname.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvName"].FormattedValue.ToString();
                    txtCon1.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvCon1"].FormattedValue.ToString();
                    txtCon2.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvCon2"].FormattedValue.ToString();
                    //types();
                }
            }

            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSID.Text == "" || txtSname.Text == "" || txtCon1.Text == "")
            {
                MessageBox.Show("Empty Value");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("update Supplier set name = @NM, contact1 = @C1, contact2 = @C2 where supplierID = @SID", con);
                    cmd2.Parameters.AddWithValue("@NM", txtSname.Text);
                    cmd2.Parameters.AddWithValue("@C1", txtCon1.Text);
                    cmd2.Parameters.AddWithValue("@C2", txtCon2.Text);
                    cmd2.Parameters.AddWithValue("@SID", txtSID.Text);

                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Data has been updated.");
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    con.Close();
                    loadSupplier();
                    txtSID.Text = "";
                    txtSname.Text = "";
                    txtCon1.Text = "";
                    txtCon2.Text = "";
                    txtSID.Focus();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("delete from supplier where supplierID=@SID", con);
                cmd2.Parameters.AddWithValue("@SID", txtSID.Text);

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Data has been deleted.");



                SqlCommand cmd = new SqlCommand("select * from Type_item", con);

                SqlDataReader dr = cmd.ExecuteReader();

                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                con.Close();
                loadSupplier();
                txtSID.Text = "";
                txtSname.Text = "";
                txtCon1.Text = "";
                txtCon2.Text = "";
                txtSID.Focus();
            }
        }
    }
}
