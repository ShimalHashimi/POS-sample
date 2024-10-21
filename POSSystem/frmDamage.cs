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
    public partial class frmDamage : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmDamage()
        {
            InitializeComponent();
            
        }

        private void clear()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            cmbType.Text = "";
            gunaDataGridView1.Refresh();
        }

        private async void export()
        {

            try
            {
                con.Open();

                // Clear existing rows in the DataGridView
                gunaDataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT * FROM product", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["id"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvCode"].Value = reader["code"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["name"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["type"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvCost"].Value = reader["cost"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
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
        private void getProduct()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from product where code = @code", con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = (string)reader["name"];
                    txtCost.Text = Convert.ToString(reader["cost"]);
                    txtPrice.Text = Convert.ToString(reader["price"]);
                    cmbType.Text = Convert.ToString(reader["type"]);
                }
               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getProduct();
                txtQty.Focus();
            }
        }

        private void frmDamage_Load(object sender, EventArgs e)
        {
            export();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtCode.Text.ToLower();
            foreach (DataGridViewRow row in gunaDataGridView1.Rows)
            {
                string cellValue = row.Cells["dgvCode"].Value?.ToString().ToLower();

                bool matchFound = !string.IsNullOrEmpty(cellValue) && cellValue.Contains(searchText);

                row.Visible = matchFound;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = Convert.ToInt32(txtQty.Text);
                con.Open();
                SqlCommand cmd3 = new SqlCommand("select qty from product where code = @PCODE", con);
                cmd3.Parameters.AddWithValue("@PCODE", txtCode.Text);
                object QTY = cmd3.ExecuteScalar();
                con.Close();
                int stock = Convert.ToInt32(QTY);
                int newqty = stock - qty;
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update product set qty = @PQ where code = @PCODE", con);
                    cmd.Parameters.AddWithValue("@PCODE", txtCode.Text);
                    cmd.Parameters.AddWithValue("@PQ", newqty);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("insert into damage(code,name,Type,qty) values(@PCODE,@PN,@PT,@PQ)", con);
                    cmd2.Parameters.AddWithValue("@PCODE", txtCode.Text);
                    cmd2.Parameters.AddWithValue("@PN", txtName.Text);
                    cmd2.Parameters.AddWithValue("@PT", cmbType.Text);
                    cmd2.Parameters.AddWithValue("@PQ", txtQty.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Data has been updated.");
                    cmbType.DataSource = null;
                    cmbType.DataSource = null;
                    con.Close();
                    export();
                    gunaDataGridView1.Refresh();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gunaDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    gunaDataGridView1.CurrentRow.Selected = true;

                    cmbType.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvType"].FormattedValue.ToString();
                    txtName.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvName"].FormattedValue.ToString();
                    txtCode.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvCode"].FormattedValue.ToString();
                    txtCost.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvCost"].FormattedValue.ToString();
                    txtPrice.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvPrice"].FormattedValue.ToString();
                    //types();
                }
            }

            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
        }
    }
}
