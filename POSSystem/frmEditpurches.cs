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
    public partial class frmEditpurches : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public frmEditpurches()
        {
            InitializeComponent();
        }

        int id;

        public frmEditpurches(string cellValue1, string cellValue2, string cellValue4, string cellValue5, string cellValue6, string cellValue7)
        {
            InitializeComponent();
            gunaDateTimePicker1.Value = Convert.ToDateTime(cellValue2);
            label3.Text = Convert.ToString(cellValue4);
            txtTotal.Text = Convert.ToString(cellValue5);
            txtPaid.Text = Convert.ToString(cellValue6);
            txtBalance.Text = Convert.ToString(cellValue7);
            id = Convert.ToInt32(cellValue1);
        }

        string status;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                

                int paid = Convert.ToInt32(txtPaid.Text);
                int payment = Convert.ToInt32(txtPayment.Text);
                int balance = Convert.ToInt32(txtBalance.Text);

                int newpaid = paid + payment;
                int newbalance = balance - payment;
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE purchesing set paid = @paid, balance = @balance, status = @status WHERE purchesingID = @PID", con);
                cmd.Parameters.AddWithValue("@paid", newpaid);
                cmd.Parameters.AddWithValue("@balance", newbalance);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@PID", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved...");
                con.Close();
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int newbalance2;

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double balance = Convert.ToDouble(txtBalance.Text);
                double payment = Convert.ToDouble(txtPayment.Text);

                newbalance2 = Convert.ToInt32(balance - payment);
                txtNewbal.Text = newbalance2.ToString();
                if (newbalance2 == 0)
                {
                    status = "Complete";
                }
                else
                {
                    status = "Pending";
                }
            }

            catch { }
        }
    }
}
