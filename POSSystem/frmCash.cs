using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSSystem
{
    public partial class frmCash : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public frmCash()
        {
            InitializeComponent();
        }

        public string status;

        DateTime Date = DateTime.Today;


        private async void Save()
        {
            try
            {
                if (status == "cashIn")
                {
                    int amt = 1 * Convert.ToInt32(txtAmount.Text);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into cash(date,status, title, amount) values(@DATE, @STS,@title,@amt)", con);
                    cmd.Parameters.AddWithValue("@DATE", Date);
                    cmd.Parameters.AddWithValue("@STS", status);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@amt", amt);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(" Added successfylly...");
                }

                else if (status == "cashOut")
                {
                    int amt = 1 * Convert.ToInt32(txtAmount.Text);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into cash(date,status, title, amount) values(@DATE, @STS,@title,@amt)", con);
                    cmd.Parameters.AddWithValue("@DATE", Date);
                    cmd.Parameters.AddWithValue("@STS", status);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@amt", amt);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(" Added successfylly...");
                }
                else
                {
                    MessageBox.Show("Select In or Out");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
            label4.ForeColor = Color.Blue;
            status = "cashIn";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
            label6.ForeColor = Color.Blue;
            status = "cashOut";
        }

        private void frmCash_Load(object sender, EventArgs e)
        {
            
        }
    }
}
