using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace POSSystem
{
    public partial class frmLogin : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmLogin()
        {
            InitializeComponent();
        }

        private void getData()
        {
            if(txtName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Missing Information...");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Name = @NM", con);
                    cmd.Parameters.AddWithValue("@NM", txtName.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string name = Convert.ToString(reader["Name"]);
                            string password = Convert.ToString(reader["Password"]);
                            if (txtPass.Text == password)
                            {
                                if (id == 1)
                                {
                                    this.Hide();
                                    frmMenu frmMenu = new frmMenu();
                                    frmMenu.ShowDialog();
                                    
                                    
                                }
                                if (id == 2)
                                {
                                    this.Hide();
                                    frm2Menu frmTmenu = new frm2Menu();
                                    frmTmenu.ShowDialog();

                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid User Name or Password");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Name or Password");
                        }
                    }
                    con.Close();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.Close();}
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            getData();
            btnLogin.BaseColor = Color.Red;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var A = MessageBox.Show("Are you Sure...", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (A == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtName.Text == "")
                {
                    
                }
                else
                {

                    txtPass.Focus();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtName.Text == "")
                {

                }
                else
                {
                    getData();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
