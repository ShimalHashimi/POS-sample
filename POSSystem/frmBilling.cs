using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using ZXing.QrCode.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POSSystem
{
    public partial class frmBilling : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public frmBilling()
        {
            InitializeComponent();
        }

        public string status;
        public string bill;

        private void clear()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtDis.Clear();
            txtCode.Focus();
        }

        private void getProduct()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from product where code = @code", con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = (string)reader["name"];
                    txtPrice.Text = Convert.ToString(reader["price"]);
                    int priceFromDataGridView = Convert.ToInt32(reader["cost"]);
                    string pcode = ConvertNumericToCode(priceFromDataGridView);
                    txtCost.Text = pcode;
                    txtQty.Text = Convert.ToString(1);
                }
                reader.Close();

                SqlCommand cmd2 = new SqlCommand("Select Percentage from discount where Id = 1", con);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    txtDis.Text = Convert.ToString(reader2["Percentage"]);
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getProduct();
                txtPrice.Focus();
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            frmDis frmDis = new frmDis();
            frmDis.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }


        private void frmBilling_Load(object sender, EventArgs e)
        {
            bill = "Sales";
            btnSales.Visible = false;
            txtCode.Focus();
            pictureBox1.Visible = false;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            clear();
            gunaDataGridView1.Rows.Clear();
            txtTotal.Clear();
            txtRec.Text = "0";
            txtBal.Text = "0";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            bill = "Return";
            btnSales.Visible = true; 
            btnReturn.Visible = false;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            bill = "Sales";
            btnSales.Visible = false;
            btnReturn.Visible = true;
        }

        private string ConvertNumericToCode(int value)
        {
            string code = "";
            char lastLetter = 'K';
            while (value > 0)
            {
                int remainder = value % 10;
                char letter = GetLetterFromRemainder(remainder);


                if (letter == lastLetter)
                {
                    code = "K" + code;
                }
                else
                {
                    code = letter.ToString() + code;
                }

                lastLetter = letter;
                value = value / 10;
            }
            return code;
        }

        private char GetLetterFromRemainder(int remainder)
        {
            
            switch (remainder)
            {
                case 0:
                    return 'S';
                case 1:
                    return 'P';
                case 2:
                    return 'A';
                case 3:
                    return 'R';
                case 4:
                    return 'L';
                case 5:
                    return 'Y';
                case 6:
                    return 'M';
                case 7:
                    return 'E';
                case 8:
                    return 'N';
                case 9:
                    return 'T';
                default:
                    throw new ArgumentException("Invalid remainder.");
            }
        }

        public int ln = 1;

        private void GetTotal()
        {
            try
            {
                double total = 0;
                txtTotal.Text = "";

                foreach (DataGridViewRow item in gunaDataGridView1.Rows)
                {
                    total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
                }

                txtTotal.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void addTobill()
        {

            try
            {
                int dis = Convert.ToInt32(txtDis.Text);
                int price = Convert.ToInt32(txtPrice.Text);

                int disprice = price - ((price / 100) * dis);

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from product where code = @code", con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    if(bill == "Sales")
                    {
                        int qty = Convert.ToInt32(txtQty.Text);
                         int QTY = Convert.ToInt32(reader["qty"]);
                        int newqty = QTY - qty;
                        if(newqty < 0)
                        {
                            MessageBox.Show("out of stock");
                            txtQty.Clear();
                        }
                        else
                        {
                            int cost = Convert.ToInt32(reader["cost"]);
                            gunaDataGridView1.Rows.Add(new object[] { 0,bill, reader["code"], reader["name"], "", cost, disprice, qty, disprice * qty });
                        }
                    }
                    if (bill == "Return")
                    {
                        int qty = Convert.ToInt32(txtQty.Text) * -1;
                        int cost = Convert.ToInt32(reader["cost"]);
                        gunaDataGridView1.Rows.Add(new object[] { 0, bill, reader["code"], reader["name"], "", cost, price, qty, price * qty  });

                    }
                }
                clear();
                con.Close();
                GetTotal();
                ln++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            addTobill();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gunaDataGridView1.Columns["dgvDel"].Index && e.RowIndex >= 0)
            {
                gunaDataGridView1.Rows.RemoveAt(e.RowIndex);
                GetTotal();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDis.Focus();
            }
        }

        private void txtDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addTobill() ;
                txtCode.Focus();
            }
        }

        private void txtRes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(txtTotal.Text);
                double received = Convert.ToDouble(txtRec.Text);

                double change = received - total;
                txtBal.Text = change.ToString();
            }

            catch { }
        }

        DateTime date = DateTime.Now;
        int No = 0, PrQty, costt, cost;

        private void btnCash_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            status = "PENDING";

            try
            {
                billSave();
                
                MessageBox.Show("Saved...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close();
                gunaDataGridView1.Rows.Clear();
                txtTotal.Clear();
                txtRec.Text = "0";
                txtBal.Text = "0";
                status = "Sales";
            }

            
        }

        string PrName, code, Price, TTotal, billtype;

        private void btnPendingview_Click(object sender, EventArgs e)
        {
            frmPending pending = new frmPending();
            pending.EditClicked += pending_EditClicked;
            pending.ShowDialog();
        }

        private void print()
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }


        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                status = "SOLD";
                billSave();
                con.Open();
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    code = "" + row.Cells["dgvCode"].Value;
                    PrQty = Convert.ToInt32(row.Cells["dgvQty"].Value);

                    SqlCommand cmd3 = new SqlCommand("select qty from product where code = @code", con);
                    cmd3.Parameters.AddWithValue("@code", code);
                    int oldqty = Convert.ToInt32(cmd3.ExecuteScalar());

                    int newqty = oldqty - PrQty;

                    SqlCommand cmd4 = new SqlCommand("update product set qty = @qty where code = @code", con);
                    cmd4.Parameters.AddWithValue("@code", code);
                    cmd4.Parameters.AddWithValue("@qty", newqty);
                    cmd4.ExecuteNonQuery();
                }


                con.Close();
                print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                gunaDataGridView1.Rows.Clear();
                txtTotal.Clear();
                txtRec.Text = "0";
                txtBal.Text = "0";
            }
        }

        private void pending_EditClicked(int MainID)
        {
            if (MainID > 0)
            {
                gunaDataGridView1.Rows.Clear();
                id = MainID;
                LoadEntries();
                GetTotal();

            }
        }

        string  PType;
        int pos = 180;

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

            string billdate = DateTime.Now.ToString("Md");

            // Draw the bill number at the top of the page
            string Text = Convert.ToString(BillID);

            e.Graphics.DrawImage(bm, 10, 0);
            e.Graphics.DrawString("BROTHERS BAKERS", new Font("Arial Black", 11, FontStyle.Bold), Brushes.Black, new Point(88, 5));
            e.Graphics.DrawString("& RESTAURANT", new Font("Arial Black", 11, FontStyle.Bold), Brushes.Black, new Point(105, 20));

            e.Graphics.DrawString("NO. 650, NC ROAD,TRINCOMALEE.", new Font("Aptos (Body)", 7, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString("TEL: 0267119002", new Font("Aptos (Body)", 7, FontStyle.Regular), Brushes.Black, new Point(135, 50));
            e.Graphics.DrawString("---------------------------------------", new Font("Lucida Calligraphy", 16, FontStyle.Regular), Brushes.Black, new Point(0, 55));


            e.Graphics.DrawString("Bill No", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(10, 80));
            e.Graphics.DrawString("Order Type", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(10, 95));
            e.Graphics.DrawString("Table No", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(10, 110));
            e.Graphics.DrawString("Waiter Name", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(10, 125));

            e.Graphics.DrawString(": " + Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(80, 80));
            e.Graphics.DrawString(": " + Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(80, 95));
            e.Graphics.DrawString(": " + Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(80, 110));
            e.Graphics.DrawString(": " + Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(80, 125));

            e.Graphics.DrawString("Date: " + DateTime.Today.ToShortDateString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(180, 80));
            //e.Graphics.DrawString("Time: " + DateTime.Now.ToShortTimeString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(180, 125));
            e.Graphics.DrawString("---------------------------------------", new Font("Lucida Calligraphy", 16, FontStyle.Regular), Brushes.Black, new Point(0, 135));

            e.Graphics.DrawString("Ln", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(5, 155));
            e.Graphics.DrawString("Item Name", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(25, 155));
            e.Graphics.DrawString("Qty", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(155, 155));
            e.Graphics.DrawString("Price", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(185, 155));
            e.Graphics.DrawString("Total", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(220, 155));
            e.Graphics.DrawString("Cts.", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(260, 158));
            e.Graphics.DrawString("---------------------------------------", new Font("Lucida Calligraphy", 16, FontStyle.Regular), Brushes.Black, new Point(0, 158));
            foreach (DataGridViewRow row in gunaDataGridView1.Rows)
            {
                No = No + 1;
                PType = "" + row.Cells["dgvType"].Value;
                PrName = "" + row.Cells["dgvName"].Value;
                Price = Convert.ToString(row.Cells["dgvPrice"].Value);
                PrQty = Convert.ToInt32(row.Cells["dgvQty"].Value);
                TTotal = Convert.ToString(row.Cells["dgvAmount"].Value);



                e.Graphics.DrawString("" + No, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(8, pos));
                e.Graphics.DrawString("" + PrName, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(25, pos));
                e.Graphics.DrawString("" + PType + " ", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(25, pos + 12));
                e.Graphics.DrawString("" + PrQty, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(160, pos));
                e.Graphics.DrawString("" + Price, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(185, pos));
                e.Graphics.DrawString("" + TTotal, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(220, pos));
                e.Graphics.DrawString(".00", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(260, pos));

                pos = pos + 30;

            }
            e.Graphics.DrawString("---------------------------------------", new Font("Lucida Calligraphy", 16, FontStyle.Regular), Brushes.Black, new Point(0, pos - 10));
            e.Graphics.DrawString("Sub Total", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(160, pos + 15));
            e.Graphics.DrawString("Pay", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(160, pos + 30));
            e.Graphics.DrawString("Change", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(160, pos + 45));
            e.Graphics.DrawString(": " + Text+".00", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(215, pos + 15));
            e.Graphics.DrawString(": " + Text + ".00", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(215, pos + 30));
            e.Graphics.DrawString(": " + Text + ".00", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(215, pos + 45));
            e.Graphics.DrawString("---------------------------------------", new Font("Lucida Calligraphy", 16, FontStyle.Regular), Brushes.Black, new Point(0, pos + 55));

            e.Graphics.DrawString("!!! Thank You, Come Again !!!", new Font("Agency FB", 11, FontStyle.Bold), Brushes.Black, new Point(40, pos + 75));
            e.Graphics.DrawString("This Software Solution By HSMTechie", new Font("Agency FB", 9, FontStyle.Regular), Brushes.Black, new Point(40, pos + 95));
            e.Graphics.DrawString("(hsmtechie@gmail.com/0775212143)", new Font("Agency FB", 8, FontStyle.Regular), Brushes.Black, new Point(50, pos + 110));

            gunaDataGridView1.Refresh();
            pos = 180;
            No = 0;
        }

        private void LoadEntries()
        {
            
            try
            {
                // MessageBox.Show(""+id);
                string qry = @"select * from tblMain m 
                                    inner join tblDetails d on m.MainID = d.MainID
                                    inner join product p on p.code = d.code where m.MainID = " + id + "";


                SqlCommand cmd2 = new SqlCommand(qry, con);
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                foreach (DataRow item in dt2.Rows)
                {

                    string detailID = item["DetailID"].ToString();
                    string code = item["code"].ToString();
                    string Type = item["billType"].ToString();
                    string name = item["name"].ToString();
                    string type = item["Type"].ToString();
                    string cost = item["cost"].ToString();
                    string price = item["price"].ToString();
                    string qty = item["qty"].ToString();
                    string amount = item["amount"].ToString();
                    
                    object[] obj = { detailID, Type, code, name, type, cost, price, qty, amount };
                    gunaDataGridView1.Rows.Add(obj);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }


        }

        int id = 0;
        int BillID;
        string Ptype;

        private void Bill()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT aDate, billID, MainID  FROM tblMain WHERE MainID = (SELECT MAX(MainID) FROM tblMain)", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime billdate = (DateTime)reader["aDate"];
                BillID = Convert.ToInt32(reader["billID"]);
                if (billdate == DateTime.Now.Date)
                {
                    BillID++;
                }                
                else
                {
                    string billNo = Convert.ToString(10001);
                    BillID = Convert.ToInt32(billNo);

                }
            }
            
            con.Close();
        }
        
        private void billSave()
        {
            if (gunaCheckBox1.Checked == true)
            {
                Ptype = "Card";
            }
            else
            {
                Ptype = "Cash";
            }
            Bill();
            try
            {
                if (id == 0)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO tblMain VALUES(@billID,@aDate, @aTime, @status, @total, @received, @change, @paymentType); SELECT SCOPE_IDENTITY();", con);
                    cmd1.Parameters.AddWithValue("@paymentType", Ptype);
                    cmd1.Parameters.AddWithValue("@billID", BillID);
                    cmd1.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
                    cmd1.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
                    cmd1.Parameters.AddWithValue("@status", status);
                    cmd1.Parameters.AddWithValue("@total", Convert.ToDouble(txtTotal.Text));
                    cmd1.Parameters.AddWithValue(@"received", Convert.ToDouble(txtRec.Text));
                    cmd1.Parameters.AddWithValue(@"change", Convert.ToDouble(txtBal.Text));
                    if (con.State == ConnectionState.Closed) { con.Open(); };
                    if (id == 0) { id = Convert.ToInt32(cmd1.ExecuteScalar()); } else { cmd1.ExecuteNonQuery(); }
                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
                else
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("update tblMain set  paymentType =  @paymentType, status= @status, total = @total, received = @received, change =@change where MainID = @ID", con);
                    cmd1.Parameters.AddWithValue("@paymentType", Ptype);
                    cmd1.Parameters.AddWithValue("@ID", id);
                    cmd1.Parameters.AddWithValue("@status", status);
                    cmd1.Parameters.AddWithValue("@total", Convert.ToDouble(txtTotal.Text));
                    cmd1.Parameters.AddWithValue(@"received", Convert.ToDouble(txtRec.Text));
                    cmd1.Parameters.AddWithValue(@"change", Convert.ToDouble(txtBal.Text));
                    if (con.State == ConnectionState.Closed) { con.Open(); };
                    if (id == 0) { id = Convert.ToInt32(cmd1.ExecuteScalar()); } else { cmd1.ExecuteNonQuery(); }
                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    con.Open();
                    code = "" + row.Cells["dgvCode"].Value;
                    Price = "" + row.Cells["dgvPrice"].Value;
                    PrQty = Convert.ToInt32(row.Cells["dgvQty"].Value);
                    TTotal = "" + row.Cells["dgvAmount"].Value;
                    billtype = "" + row.Cells["dgvBilltype"].Value;
                    int detailID = Convert.ToInt32(row.Cells["dgvID"].Value);

                    if(detailID == 0)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO tblDetails VALUES(@MainID,@date, @billtype, @code, @qty, @price, @amount)", con);

                        int TCOST = PrQty * cost;
                        cmd2.Parameters.AddWithValue("@MainID", id);
                        cmd2.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now.Date));
                        cmd2.Parameters.AddWithValue("@billtype", billtype);
                        cmd2.Parameters.AddWithValue("@code", code);
                        cmd2.Parameters.AddWithValue("@qty", PrQty);
                        cmd2.Parameters.AddWithValue("@price", Price);
                        cmd2.Parameters.AddWithValue("@amount", TTotal);

                        if (con.State == ConnectionState.Closed) { con.Open(); };
                        cmd2.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open) { con.Close(); }
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("update tblDetails set date = @date, code = @code, qty = @qty, price = @price, amount = @amount where DetailID = @ID ", con);

                        int TCOST = PrQty * cost;
                        cmd2.Parameters.AddWithValue(@"ID", detailID);
                        cmd2.Parameters.AddWithValue("@MainID", id);
                        cmd2.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now.Date));
                        cmd2.Parameters.AddWithValue("@billtype", billtype);
                        cmd2.Parameters.AddWithValue("@code", code);
                        cmd2.Parameters.AddWithValue("@qty", PrQty);
                        cmd2.Parameters.AddWithValue("@price", Price);
                        cmd2.Parameters.AddWithValue("@amount", TTotal);

                        if (con.State == ConnectionState.Closed) { con.Open(); };
                        cmd2.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open) { con.Close(); }
                    }

                    con.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close();
                id = 0;
                bill = "Sales";
                gunaCheckBox1.Checked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                status = "SOLD";
                billSave();
                con.Open();
                foreach (DataGridViewRow row in gunaDataGridView1.Rows)
                {
                    code = "" + row.Cells["dgvCode"].Value;
                    PrQty = Convert.ToInt32(row.Cells["dgvQty"].Value);

                    SqlCommand cmd3 = new SqlCommand("select qty from product where code = @code", con);
                    cmd3.Parameters.AddWithValue("@code", code);
                    int oldqty = Convert.ToInt32(cmd3.ExecuteScalar());

                    int newqty = oldqty - PrQty;

                    SqlCommand cmd4 = new SqlCommand("update product set qty = @qty where code = @code", con);
                    cmd4.Parameters.AddWithValue("@code", code);
                    cmd4.Parameters.AddWithValue("@qty", newqty);
                    cmd4.ExecuteNonQuery();
                }


                con.Close();
                MessageBox.Show("Saved...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                gunaDataGridView1.Rows.Clear();
                txtTotal.Clear();
                txtRec.Text = "0";
                txtBal.Text = "0";
            }
        }
    }
}
