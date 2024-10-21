using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSSystem
{
    public partial class frm2Menu : Form
    {
        public frm2Menu()
        {
            InitializeComponent();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            var A = MessageBox.Show("Are you Sure...", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (A == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            label2.Text = "Sales";
            frm2Billing billing = new frm2Billing();
            billing.TopLevel = false;
            panel6.Controls.Add(billing);
            billing.BringToFront();
            billing.Show();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening on-screen keyboard: " + ex.Message);
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening calculator: " + ex.Message);
            }
        }

        private void frm2Menu_Load(object sender, EventArgs e)
        {
            label2.Text = "Sales";
            frm2Billing billing = new frm2Billing();
            billing.TopLevel = false;
            panel6.Controls.Add(billing);
            billing.BringToFront();
            billing.Show();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            frmCash frmCash = new frmCash();
            frmCash.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            frm2Report frmReport = new frm2Report();
            frmReport.TopLevel = false;
            panel6.Controls.Add(frmReport);
            frmReport.BringToFront();
            frmReport.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu frmMenu = new frmMenu();
            frmMenu.ShowDialog();
        }

        private void btnPurchesing_Click(object sender, EventArgs e)
        {
            label2.Text = "Manage Products";
            frmProduct product = new frmProduct();
            product.TopLevel = false;
            panel6.Controls.Add(product);
            product.BringToFront();
            product.Show();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            frmBarcode frmBarcode = new frmBarcode();
            frmBarcode.ShowDialog();
        }
    }
}
