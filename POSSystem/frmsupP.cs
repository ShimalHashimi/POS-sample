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
    public partial class frmsupP : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmsupP()
        {
            InitializeComponent();
        }

        private void loadsupplier()
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
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
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

        private void frmsupP_Load(object sender, EventArgs e)
        {
            loadsupplier();
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

        private void txtTcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTcode.Text.ToLower();
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    string cellValue = row.Cells["dgvSID"].Value?.ToString().ToLower();

                    bool matchFound = !string.IsNullOrEmpty(cellValue) && cellValue.Contains(searchText);

                    row.Visible = matchFound;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event Action<string> supClicked;
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string SID = Convert.ToString(gunaDataGridView1.CurrentRow.Cells["dgvSID"].Value);
                // Raise the event with the MainID value
                supClicked?.Invoke(SID);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
