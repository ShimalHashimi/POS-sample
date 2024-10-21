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
    public partial class frmCodetext : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public frmCodetext()
        {
            InitializeComponent();
        }

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt2.Focus();
            }
        }

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt3.Focus();
            }
        }

        private void txt3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt4.Focus();
            }
        }

        private void txt4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt5.Focus();
            }
        }

        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt6.Focus();
            }
        }

        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt7.Focus();
            }
        }

        private void txt7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt8.Focus();
            }
        }

        private void txt8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt9.Focus();
            }
        }

        private void txt9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt0.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Update codetext set text = @txt1 where id = 1", con);
                cmd1.Parameters.AddWithValue("@txt1", txt1.Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("Update codetext set text = @txt2 where id = 2", con);
                cmd2.Parameters.AddWithValue("@txt2", txt2.Text);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("Update codetext set text = @txt3 where id = 3", con);
                cmd3.Parameters.AddWithValue("@txt3", txt3.Text);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("Update codetext set text = @txt4 where id = 4", con);
                cmd4.Parameters.AddWithValue("@txt4", txt4.Text);
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand("Update codetext set text = @txt5 where id = 5", con);
                cmd5.Parameters.AddWithValue("@txt5", txt5.Text);
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand("Update codetext set text = @txt6 where id = 6", con);
                cmd6.Parameters.AddWithValue("@txt6", txt6.Text);
                cmd6.ExecuteNonQuery();
                SqlCommand cmd7 = new SqlCommand("Update codetext set text = @txt7 where id = 7", con);
                cmd7.Parameters.AddWithValue("@txt7", txt7.Text);
                cmd7.ExecuteNonQuery();
                SqlCommand cmd8 = new SqlCommand("Update codetext set text = @txt8 where id = 8", con);
                cmd8.Parameters.AddWithValue("@txt8", txt8.Text);
                cmd8.ExecuteNonQuery();
                SqlCommand cmd9 = new SqlCommand("Update codetext set text = @txt9 where id = 9", con);
                cmd9.Parameters.AddWithValue("@txt9", txt9.Text);
                cmd9.ExecuteNonQuery();
                SqlCommand cmd0 = new SqlCommand("Update codetext set text = @txt0 where id = 0", con);
                cmd0.Parameters.AddWithValue("@txt0", txt0.Text);
                cmd0.ExecuteNonQuery();
                SqlCommand cmd10 = new SqlCommand("Update codetext set text = @txt10 where id = 10", con);
                cmd10.Parameters.AddWithValue("@txt10", txt10.Text);
                cmd10.ExecuteNonQuery();
                MessageBox.Show("Updated...");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally { con.Close(); }
        }

        private void frmCodetext_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select text from codetext where id = 1", con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    txt1.Text = Convert.ToString(reader1["text"]);
                }
                reader1.Close();
                SqlCommand cmd2 = new SqlCommand("select text from codetext where id = 2", con);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    txt2.Text = Convert.ToString(reader2["text"]);
                }
                reader2.Close();
                SqlCommand cmd3 = new SqlCommand("select text from codetext where id = 3", con);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    txt3.Text = Convert.ToString(reader3["text"]);
                }
                reader3.Close();
                SqlCommand cmd4 = new SqlCommand("select text from codetext where id = 4", con);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    txt4.Text = Convert.ToString(reader4["text"]);
                }
                reader4.Close();
                SqlCommand cmd5 = new SqlCommand("select text from codetext where id = 5", con);
                SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    txt5.Text = Convert.ToString(reader5["text"]);
                }
                reader5.Close();
                SqlCommand cmd6 = new SqlCommand("select text from codetext where id = 6", con);
                SqlDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    txt6.Text = Convert.ToString(reader6["text"]);
                }
                reader6.Close();
                SqlCommand cmd7 = new SqlCommand("select text from codetext where id = 7", con);
                SqlDataReader reader7 = cmd7.ExecuteReader();
                while (reader7.Read())
                {
                    txt7.Text = Convert.ToString(reader7["text"]);
                }
                reader7.Close();
                SqlCommand cmd8 = new SqlCommand("select text from codetext where id = 8", con);
                SqlDataReader reader8 = cmd8.ExecuteReader();
                while (reader8.Read())
                {
                    txt8.Text = Convert.ToString(reader8["text"]);
                }
                reader8.Close();
                SqlCommand cmd9 = new SqlCommand("select text from codetext where id = 9", con);
                SqlDataReader reader9 = cmd9.ExecuteReader();
                while (reader9.Read())
                {
                    txt9.Text = Convert.ToString(reader9["text"]);
                }
                reader9.Close();
                SqlCommand cmd0 = new SqlCommand("select text from codetext where id = 0", con);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                while (reader0.Read())
                {
                    txt0.Text = Convert.ToString(reader0["text"]);
                }
                reader0.Close(); 
                SqlCommand cmd10 = new SqlCommand("select text from codetext where id = 10", con);
                SqlDataReader reader10 = cmd10.ExecuteReader();
                while (reader10.Read())
                {
                    txt10.Text = Convert.ToString(reader10["text"]);
                }
                reader10.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally { con.Close(); }
            
        }
    }
}
