using Guna.UI.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POSSystem
{
    public partial class frmProduct : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            clear();
            frmCatP frmCat = new frmCatP();
            frmCat.CatClicked += FrmCat_CatClicked;
            frmCat.ShowDialog();
            
        }

        string type;
        private void FrmCat_CatClicked(string type)
        {
            type = type;
            cmbType.Text = type.ToString();
        }

        private void clear()
        {
            cmbType.Text = "";
            cmbType.Items.Clear();
            cmbSname.Items.Clear();
            txtCode.Text = "";
            txtName.Text = "";
            txtCost.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtTcode.Text = "";
            txtSID.Text = "";
            cmbSname.Text = "";
            txtTcode.Focus();
        }

        private void types()
        {
            SqlCommand cmd = new SqlCommand("select * from Type_item", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbType.Items.Add(dr["name"]);
            }
            con.Close();
        }

        private void supplierload()
        {
            SqlCommand cmd = new SqlCommand("select * from supplier", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbSname.Items.Add(dr["name"]);
            }
            con.Close();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            txtTcode.Focus();
            types();
            supplierload();
            export();
            textBox1.Visible = false;
            textBox2.Visible = false;
            gunaButton2.Visible = false;
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
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSID"].Value = reader["supplierID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvSname"].Value = reader["supplierName"];
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

        private void GetTotal()
        {
            try
            {
                double total = 0;
                txtTotal.Text = "";

                foreach (DataGridViewRow item in gunaDataGridView2.Rows)
                {
                    total += double.Parse(item.Cells["dgvTotal2"].Value.ToString());
                }

                txtTotal.Text = total.ToString("N2");
                txtPayment.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || cmbType.Text == "" || txtName.Text == "" || txtCost.Text == "" || txtPrice.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("Missing infomation");
            }
            else
            {
                try
                {
                    con.Open();
                    int code = Convert.ToInt32(txtCode.Text);
                    string name = Convert.ToString(txtName.Text);
                    string type = Convert.ToString(cmbType.Text);
                    string sid = Convert.ToString(txtSID.Text);
                    string sname = Convert.ToString(cmbSname.Text);
                    int cost = Convert.ToInt32(txtCost.Text);
                    int price = Convert.ToInt32(txtPrice.Text);
                    int qty = Convert.ToInt32(txtQty.Text);

                    gunaDataGridView2.Rows.Add(new object[] { code, name, type, sid, sname, cost, price, qty, qty*cost });
                    GetTotal();
                    textBox1.Text = sname;
                    textBox2.Text = sid;
                    clear();
                    con.Close();

                    gunaButton2.Visible = true;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally { con.Close(); }

            }
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
                    txtSID.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvSID"].FormattedValue.ToString();
                    cmbSname.Text = gunaDataGridView1.Rows[e.RowIndex].Cells["dgvSname"].FormattedValue.ToString();
                    //types();
                }
            }

            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
             if (txtCode.Text == "" || cmbType.Text =="" || txtName.Text == "" || txtCost.Text == "" || txtPrice.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("Missing infomation");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update product set name = @PN, type = @PT, supplierID = @SID,supplierName = @Sname ,cost = @PCOST,price = @PP, qty = @PQ where code = @PCODE", con);
                    cmd.Parameters.AddWithValue("@PCODE", txtCode.Text);
                    cmd.Parameters.AddWithValue("@PN", txtName.Text);
                    cmd.Parameters.AddWithValue("@PT", cmbType.Text);
                    cmd.Parameters.AddWithValue("@SID", txtSID.Text);
                    cmd.Parameters.AddWithValue("@Sname", cmbSname.Text);
                    cmd.Parameters.AddWithValue("@PCOST", txtCost.Text);
                    cmd.Parameters.AddWithValue("@PP", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@PQ", txtQty.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been updated.");
                    cmbType.DataSource = null;
                    con.Close();
                    export();
                    gunaDataGridView1.Refresh();
                    clear();
                    types();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { con.Close(); }
            }
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.Close(); }
        }

        private void cmbType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = cmbType.Text.ToLower();
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    string cellValue = row.Cells["dgvType"].Value?.ToString().ToLower();

                    bool matchFound = !string.IsNullOrEmpty(cellValue) && cellValue.Contains(searchText);

                    row.Visible = matchFound;
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("select code from Type_item where name = @NM", con);
                cmd2.Parameters.AddWithValue("@NM", cmbType.Text);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    txtTcode.Text = Convert.ToString(reader2["code"]);
                }
                reader2.Close();
                SqlCommand cmd = new SqlCommand("SELECT MAX(code) AS MaxCode FROM product WHERE type = @type", con);
                cmd.Parameters.AddWithValue("@type", cmbType.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int oldcode = Convert.ToInt32(reader["MaxCode"]);
                    int newcode = oldcode + 1;
                    txtCode.Text = newcode.ToString();

                }

                con.Close();


            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtCode.Text == "")
            {
                MessageBox.Show("Missing infomation");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from product where code=@PCODE", con);
                    cmd.Parameters.AddWithValue("@PCODE", txtCode.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted.");
                    cmbType.DataSource = null;
                    con.Close();
                    export();
                    gunaDataGridView1.Refresh();
                    clear();
                    types();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally { con.Close(); }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gunaDataGridView1.Refresh();
            clear();
            types();
            supplierload();
        }

        private void txtTcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select name from Type_item where code = @code", con);
                    cmd.Parameters.AddWithValue("@code", txtTcode.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        cmbType.Text = Convert.ToString(reader["name"]);
                    }
                    con.Close();
                }
                catch(Exception ex)
                {
                    
                }
                finally { con.Close(); 
                    txtName.Focus();
                }
                
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                

            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSID.Focus();
            }
        }

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            frmsupP frmsupP = new frmsupP();
            frmsupP.supClicked += FrmsupP_supClicked;
            frmsupP.ShowDialog();
        }

        private void FrmsupP_supClicked(String SID)
        {
            txtSID.Text = SID.ToString();
            cmbSname.Focus();
        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from supplier where supplierID = @SID", con);
            cmd.Parameters.AddWithValue("SID", txtSID.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbSname.Text = Convert.ToString(reader["name"]);
            }
            con.Close();
        }

        private void txtSID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               cmbSname.Focus();
            }
        }

        private void cmbSname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCost.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCode.Text == "" || cmbType.Text == "" || txtName.Text == "" || txtCost.Text == "" || txtPrice.Text == "" || txtQty.Text == "")
                {
                    MessageBox.Show("Missing infomation");
                }
                else
                {
                    try
                    {
                        con.Open();
                        int code = Convert.ToInt32(txtCode.Text);
                        string name = Convert.ToString(txtName.Text);
                        string type = Convert.ToString(cmbType.Text);
                        string sid = Convert.ToString(txtSID.Text);
                        string sname = Convert.ToString(cmbSname.Text);
                        int cost = Convert.ToInt32(txtCost.Text);
                        int price = Convert.ToInt32(txtPrice.Text);
                        int qty = Convert.ToInt32(txtQty.Text);

                        gunaDataGridView2.Rows.Add(new object[] { code, name, type, sid, sname, cost, price, qty, qty * cost });
                        GetTotal();
                        textBox1.Text = sname;
                        textBox2.Text = sid;
                        clear();
                        con.Close();
                        gunaButton2.Visible = true;
                    }
                    catch { }
                } 
            }
        }

        int id;
        string status;
        int searchcode;
        int oldqty;

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT MAX(purchesingID) AS MaxID FROM purchesing", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int oldpurchesingID = Convert.ToInt32(reader["MaxID"]);
                    id = oldpurchesingID + 1;
                }
                reader.Close();

                SqlCommand cmd1 = new SqlCommand("INSERT INTO purchesing VALUES(@purchesingID, @pDate, @supplierID, @supplierName, @total, @paid, @balance, @status);", con);
                cmd1.Parameters.AddWithValue("@purchesingID", id);
                cmd1.Parameters.AddWithValue("@pDate", Convert.ToDateTime(DateTime.Now.Date));
                cmd1.Parameters.AddWithValue("@supplierID", textBox2.Text);
                cmd1.Parameters.AddWithValue("@supplierName", textBox1.Text);
                cmd1.Parameters.AddWithValue("@total", Convert.ToDouble(txtTotal.Text));
                cmd1.Parameters.AddWithValue(@"paid", Convert.ToDouble(txtPayment.Text));
                cmd1.Parameters.AddWithValue(@"balance", Convert.ToDouble(txtBalance.Text));
                cmd1.Parameters.AddWithValue(@"status", status);
                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in gunaDataGridView2.Rows)
                {

                    int code = Convert.ToInt32(row.Cells["dgvCode2"].Value);
                    string name = Convert.ToString(row.Cells["dgvName2"].Value);
                    string type = Convert.ToString(row.Cells["dgvCat2"].Value);
                    string SID = Convert.ToString(row.Cells["dgvSID2"].Value);
                    string SName = Convert.ToString(row.Cells["dgvSname2"].Value);
                    int cost = Convert.ToInt32(row.Cells["dgvCost2"].Value);
                    int price = Convert.ToInt32(row.Cells["dgvPrice2"].Value);
                    int qty = Convert.ToInt32(row.Cells["dgvQTY2"].Value);

                    SqlCommand cmd3 = new SqlCommand("SELECT code, qty FROM product WHERE code = @CD", con);
                    cmd3.Parameters.AddWithValue ("@CD", code);
                    SqlDataReader reader2 = cmd3.ExecuteReader();
                    while (reader2.Read())
                    {
                        searchcode = Convert.ToInt32(reader2["code"]);
                        oldqty = Convert.ToInt32(reader2["qty"]);
                    }
                    reader2.Close();

                    if (searchcode == 0 )
                    {

                        SqlCommand cmd2 = new SqlCommand("INSERT INTO product VALUES(@pID, @code, @name,@type,@supplierID, @supplierName, @cost, @price, @qty)", con);

                        cmd2.Parameters.AddWithValue("@pID", id);
                        cmd2.Parameters.AddWithValue("@code", code);
                        cmd2.Parameters.AddWithValue("@name", name);
                        cmd2.Parameters.AddWithValue("@type", type);
                        cmd2.Parameters.AddWithValue("@supplierID", SID);
                        cmd2.Parameters.AddWithValue("@supplierName", SName);
                        cmd2.Parameters.AddWithValue("@cost", cost);
                        cmd2.Parameters.AddWithValue("@qty", qty);
                        cmd2.Parameters.AddWithValue("@price", price);

                        cmd2.ExecuteNonQuery();
                    }
                    else
                    {
                        int newqty = oldqty + qty;
                        SqlCommand cmd4 = new SqlCommand("UPDATE product SET qty = @QTY WHERE code = @CODE", con);
                        cmd4.Parameters.AddWithValue("@CODE", code);
                        cmd4.Parameters.AddWithValue("@QTY", newqty);


                        cmd4.ExecuteNonQuery();

                    }
                }

                MessageBox.Show("Data has been added.");
                if (con.State == ConnectionState.Closed) { con.Open(); };
                if (con.State == ConnectionState.Open) { con.Close(); }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                export();
                con.Close(); 
                gunaDataGridView2.Rows.Clear();
                textBox1.Clear();
                textBox2.Clear();
                txtTotal.Text = "0";
                txtPayment.Text = "0";
                txtBalance.Text = "0";

                gunaDataGridView1.Refresh();
                clear();
                types();
                supplierload();
                gunaButton2.Visible = false;
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(txtTotal.Text);
                double payment = Convert.ToDouble(txtPayment.Text);

                double balance = (payment - total) * -1;
                txtBalance.Text = balance.ToString();

                if (balance == 0)
                {
                    status = "Complete";
                }
                else
                {
                    status = "Pending";
                }
            }

            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.Close(); }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
