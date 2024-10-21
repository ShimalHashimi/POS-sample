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
using System.Xml.Linq;

namespace POSSystem
{
    public partial class frmDis : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public frmDis()
        {
            InitializeComponent();
        }

        private void disLoad()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Percentage from discount where Id = 1", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtPerecntage.Text = (string)reader["Percentage"];
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void frmDis_Load(object sender, EventArgs e)
        {
            disLoad();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update discount set Percentage = @PN where Id = 1", con);
                cmd.Parameters.AddWithValue("@PN", txtPerecntage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void txtPerecntage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update discount set Percentage = @PN where Id = 1", con);
                    cmd.Parameters.AddWithValue("@PN", txtPerecntage.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.Close(); }
            }
        }
    }
}
