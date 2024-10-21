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
    public partial class frmPending : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmPending()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmPending_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblMain WHERE status = 'PENDING' ", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvMainID"].Value = reader["MainID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBillno"].Value = reader["billID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvTime"].Value = reader["aTime"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvStatus"].Value = reader["status"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvTotal"].Value = reader["total"];
                    gunaDataGridView1.Refresh();

                }
                con.Close();
            }
            catch { }
        }


        public event Action<int> EditClicked;
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    int MainID = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvMainID"].Value);
                    // Raise the event with the MainID value
                    EditClicked?.Invoke(MainID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
