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
    public partial class frmCat : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmCat()
        {
            InitializeComponent();
        }

        private void frmCat_Load(object sender, EventArgs e)
        {
            loadcat();
        }

        private void loadcat()
        {
            try
            {
                con.Open();

                // Clear existing rows in the DataGridView
                gunaDataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Type_item", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvCode"].Value = reader["code"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["name"];
                    gunaDataGridView1.Refresh();

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTcode.Text.ToLower();
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    string cellValue = row.Cells["dgvCode"].Value?.ToString().ToLower();

                    bool matchFound = !string.IsNullOrEmpty(cellValue) && cellValue.Contains(searchText);

                    row.Visible = matchFound;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtName.Text.ToLower();
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    string cellValue = row.Cells["dgvName"].Value?.ToString().ToLower();

                    bool matchFound = !string.IsNullOrEmpty(cellValue) && cellValue.Contains(searchText);

                    row.Visible = matchFound;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            loadcat();
            txtTcode.Clear();
            txtName.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtCat.Text == "")
            {
                MessageBox.Show("Empty Value");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into Type_item(name, code) values(@TN, @CD)", con);
                    cmd2.Parameters.AddWithValue("@TN", txtCat.Text);
                    cmd2.Parameters.AddWithValue("@CD", txtCode.Text);

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
                    loadcat();
                    txtCode.Text = "";
                    txtCat.Text = "";
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

                    txtCat.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvName"].FormattedValue.ToString();
                    txtCode.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvCode"].FormattedValue.ToString();
                    //types();
                }
            }

            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("delete from Type_item where name=@NM", con);
                cmd2.Parameters.AddWithValue("@NM", txtCat.Text);

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
                loadcat();
                txtCat.Text = "";
                txtCode.Text = "";
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCat.Focus();
            }
        }

        private void txtCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCode.Text == "" || txtCat.Text == "")
                {
                    MessageBox.Show("Empty Value");
                }
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("insert into Type_item(name, code) values(@TN, @CD)", con);
                        cmd2.Parameters.AddWithValue("@TN", txtCat.Text);
                        cmd2.Parameters.AddWithValue("@CD", txtCode.Text);

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
                        loadcat();
                        txtCode.Text = "";
                        txtCat.Text = "";
                    }

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtCat.Text == "")
            {
                MessageBox.Show("Empty Value");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("update Type_item set name = @NM where code = @PCODE", con);
                    cmd2.Parameters.AddWithValue("@PCODE", txtCode.Text);
                    cmd2.Parameters.AddWithValue("@NM", txtCat.Text);

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
                    loadcat();
                    txtCode.Text = "";
                    txtCat.Text = "";
                }

            }
        }
    }
}
