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
    public partial class frmMenu : Form
    {
        public frmMenu()
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

        private void btnDash_Click(object sender, EventArgs e)
        {
            label2.Text = "Dashboard";
            frmDashboard dashboard = new frmDashboard();
            dashboard.TopLevel = false;
            panel6.Controls.Add(dashboard);
            dashboard.BringToFront();
            dashboard.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

            productTransition.Start();
            label2.Text = "Manage Products";
            frmProduct product = new frmProduct();
            product.TopLevel = false;
            panel6.Controls.Add(product);
            product.BringToFront();
            product.Show();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            label2.Text = "Sales";
            frmBilling billing = new frmBilling();
            billing.TopLevel = false;
            panel6.Controls.Add(billing);
            billing.BringToFront();
            billing.Show();

        }

        
        bool productExpand = false;
        bool reportExpand = false;
        private void frmMenu_Load(object sender, EventArgs e)
        {

            label2.Text = "Sales";
            frmBilling billing = new frmBilling();
            billing.TopLevel = false;
            panel6.Controls.Add(billing);
            billing.BringToFront();
            billing.Show();
        }

        private void productTransition_Tick(object sender, EventArgs e)
        {
            if (productExpand == false)
            {
                productContainer.Height += 10;
                panel5.Location = new Point(panel5.Location.X, panel5.Location.Y + 10); // Adjust Y coordinate
                
                if (productContainer.Height >= 130 && panel5.Location.Y >= 160)
                {
                    productTransition.Stop();
                    productExpand = true;
                }
            }
            else
            {
                productContainer.Height -= 10;
                panel5.Location = new Point(panel5.Location.X, panel5.Location.Y - 10); // Adjust Y coordinate
                
                if (productContainer.Height <= 62 && panel5.Location.Y <= 50)
                {
                    productTransition.Stop();
                    productExpand = false;
                }
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Manage Products";
            frmProduct product = new frmProduct();
            product.TopLevel = false;
            panel6.Controls.Add(product);
            product.BringToFront();
            product.Show();
        }

        private void btnDamage_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Damages";
            frmDamage damage = new frmDamage();
            damage.TopLevel = false;
            panel6.Controls.Add(damage);
            damage.BringToFront();
            damage.Show();

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Code Text";
            frmCodetext codetext = new frmCodetext();
            codetext.TopLevel = false;
            panel6.Controls.Add(codetext);
            codetext.BringToFront();
            codetext.Show();
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

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock stock = new frmStock();
            stock.Show();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            frmCash frmCash = new frmCash();
            frmCash.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
           
            reportTransition.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm2Menu frm2Menu = new frm2Menu();
            frm2Menu.Show();
        }

        private void btnManage_Click_1(object sender, EventArgs e)
        {
            productTransition.Start();
        }

        private void reportTransition_Tick(object sender, EventArgs e)
        {
            if (reportExpand == false)
            {
                reportContainer.Height += 10;
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 10); // Adjust Y coordinate

                if (reportContainer.Height >= 120 && panel1.Location.Y >= 140)
                {
                    reportTransition.Stop();
                    reportExpand = true;
                }
            }
            else
            {
                reportContainer.Height -= 10;
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 10); // Adjust Y coordinate

                if (reportContainer.Height <= 62 && panel1.Location.Y <= 90)
                {
                    reportTransition.Stop();
                    reportExpand = false;
                }
            }
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Sales";
            frmCat category = new frmCat();
            category.TopLevel = false;
            panel6.Controls.Add(category);
            category.BringToFront();
            category.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Sales";
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.TopLevel = false;
            panel6.Controls.Add(frmSupplier);
            frmSupplier.BringToFront();
            frmSupplier.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Sales";
            frmCat category = new frmCat();
            category.TopLevel = false;
            panel6.Controls.Add(category);
            category.BringToFront();
            category.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            productTransition.Start();
            label2.Text = "Sales";
            frmCat category = new frmCat();
            category.TopLevel = false;
            panel6.Controls.Add(category);
            category.BringToFront();
            category.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            reportTransition.Start();
            label2.Text = "";
            frmReport frmReport = new frmReport();
            frmReport.TopLevel = false;
            panel6.Controls.Add(frmReport);
            frmReport.BringToFront();
            frmReport.Show();
        }

        private void btnPurchesingreport_Click(object sender, EventArgs e)
        {
            reportTransition.Start();
            label2.Text = "Sales";
            frmPurchesingReport purchesingReport = new frmPurchesingReport();
            purchesingReport.TopLevel = false;
            panel6.Controls.Add(purchesingReport);
            purchesingReport.BringToFront();
            purchesingReport.Show();
        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            reportTransition.Start();
            label2.Text = "Sales";
            frmCat category = new frmCat();
            category.TopLevel = false;
            panel6.Controls.Add(category);
            category.BringToFront();
            category.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

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
