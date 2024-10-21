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
    public partial class frmReport : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["getstring"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public frmReport()
        {
            InitializeComponent();
        }

        private void othercash()
        {
            gunaDataGridView2.Rows.Clear();
            gunaDataGridView3.Rows.Clear();
            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select date,title,amount from cash where date = @date AND status LIKE '%cashin%' ", con);
                cmd2.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView3.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView3.Rows[rowIndex].Cells["dgvDate2"].Value = reader2["Date"];
                    gunaDataGridView3.Rows[rowIndex].Cells["dgvTitle2"].Value = reader2["title"];
                    gunaDataGridView3.Rows[rowIndex].Cells["dgvAmount2"].Value = reader2["amount"];
                    gunaDataGridView3.Refresh();
                }
                con.Close();
                con.Open();
                SqlCommand cmd3 = new SqlCommand("select date,title,amount from cash where date = @date AND status LIKE '%cashout%'", con);
                cmd3.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView2.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView2.Rows[rowIndex].Cells["dgvDate3"].Value = reader3["Date"];
                    gunaDataGridView2.Rows[rowIndex].Cells["dgvTitle3"].Value = reader3["title"];
                    gunaDataGridView2.Rows[rowIndex].Cells["dgvAmount3"].Value = reader3["amount"];
                    gunaDataGridView2.Refresh();
                }
                con.Close();
                double total = 0.0;
                double total1 = 0.0;
                double total2 = 0.0;

                for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(gunaDataGridView1.Rows[i].Cells["dgvAmount"].Value);

                }
                label9.Text =  total.ToString();
                int a = Convert.ToInt32(total);


                for (int j = 0; j < gunaDataGridView2.Rows.Count; j++)
                {
                    total1 += Convert.ToDouble(gunaDataGridView2.Rows[j].Cells["dgvAmount3"].Value);
                }
                label10.Text =  total1.ToString();
                int b = Convert.ToInt32(total1);


                for (int k = 0; k < gunaDataGridView3.Rows.Count; k++)
                {
                    total2 += Convert.ToDouble(gunaDataGridView3.Rows[k].Cells["dgvAmount2"].Value);
                }
                label11.Text = total2.ToString();
                int c = Convert.ToInt32(total2);

                int d = a + c - b;
                label12.Text =  Convert.ToString(d);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void othercashDaterange()
        {
            gunaDataGridView2.Rows.Clear();
            gunaDataGridView3.Rows.Clear();
            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select date,title,amount from cash where date between @date1 and @date2 AND status LIKE '%cashin%' ", con);
                cmd2.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd2.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView3.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView3.Rows[rowIndex].Cells["dgvDate2"].Value = reader2["Date"];
                    gunaDataGridView3.Rows[rowIndex].Cells["dgvTitle2"].Value = reader2["title"];
                    gunaDataGridView3.Rows[rowIndex].Cells["dgvAmount2"].Value = reader2["amount"];
                    gunaDataGridView3.Refresh();
                }
                con.Close();
                con.Open();
                SqlCommand cmd3 = new SqlCommand("select date,title,amount from cash where date between @date1 and @date2  AND status LIKE '%cashout%'", con);
                cmd3.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd3.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView2.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView2.Rows[rowIndex].Cells["dgvDate3"].Value = reader3["Date"];
                    gunaDataGridView2.Rows[rowIndex].Cells["dgvTitle3"].Value = reader3["title"];
                    gunaDataGridView2.Rows[rowIndex].Cells["dgvAmount3"].Value = reader3["amount"];
                    gunaDataGridView2.Refresh();
                }
                con.Close();
                double total = 0.0;
                double total1 = 0.0;
                double total2 = 0.0;

                for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(gunaDataGridView1.Rows[i].Cells["dgvAmount"].Value);

                }
                label9.Text = total.ToString();
                int a = Convert.ToInt32(total);


                for (int j = 0; j < gunaDataGridView2.Rows.Count; j++)
                {
                    total1 += Convert.ToDouble(gunaDataGridView2.Rows[j].Cells["dgvAmount3"].Value);
                }
                label10.Text = total1.ToString();
                int b = Convert.ToInt32(total1);


                for (int k = 0; k < gunaDataGridView3.Rows.Count; k++)
                {
                    total2 += Convert.ToDouble(gunaDataGridView3.Rows[k].Cells["dgvAmount2"].Value);
                }
                label11.Text = total2.ToString();
                int c = Convert.ToInt32(total2);

                int d = a + c - b;
                label12.Text = Convert.ToString(d);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            btnFilter2.Visible = false;
            label5.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            panel1.Size = new System.Drawing.Size(435, 210);
            reportload();
            othercash();
        }



        private void label6_Click(object sender, EventArgs e)
        {
            btnFilter2.Visible = false;
            label5.Visible = false;
            dateTimePicker2.Visible = false;
            btnFilter1.Visible = true;
            label3.Text = "Date :";
            panel1.Size = new System.Drawing.Size(435, 210);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            btnFilter1.Visible = false;
            btnFilter2.Visible = true;
            label3.Text = "From :";
            label5.Visible = true;
            label5.Text = "TO :";
            dateTimePicker2.Visible = true;
            panel1.Size = new System.Drawing.Size(435, 250);
        }

        private void reportload()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportload2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%'", con);

                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadSales()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND D.billType = 'Sales'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadSales2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND D.billType = 'Sales'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadReturns()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND D.billType = 'Return'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadReturns2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND D.billType = 'Return'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadcash()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND M.paymentType= 'Cash'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadcash2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND M.paymentType= 'Cash'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadcard()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND M.paymentType= 'Card'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadcard2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND M.paymentType= 'Card'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadSalescard()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND M.paymentType= 'Card' AND D.billType = 'Sales'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadSalescard2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND M.paymentType= 'Card' AND D.billType = 'Sales'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadSalescash()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND M.paymentType= 'Cash' AND D.billType = 'Sales'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadSalescash2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND M.paymentType= 'Cash' AND D.billType = 'Sales'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadReturncash()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate = @date AND M.status LIKE '%sold%' AND M.paymentType= 'Cash' AND D.billType = 'Return'", con);

                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void reportloadReturncash2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT D.DetailID, D.MainID, D.qty, D.price, D.billType," +
                    " D.amount, M.billID, M.aDate, M.aTime, M.status, M.total, M.received, M.change, M.paymentType," +
                    " P.name AS productName, P.Type AS productCategory FROM  tblDetails D JOIN  " +
                    "tblMain M ON D.MainID = M.MainID JOIN  product P ON D.code = P.code  WHERE M.aDate BETWEEN @date1 AND @date2 AND M.status LIKE '%sold%' AND M.paymentType= 'Cash' AND D.billType = 'Return'", con);


                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Add a new row to the DataGridView
                    int rowIndex = gunaDataGridView1.Rows.Add();

                    // Populate each cell in the row
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvID"].Value = reader["DetailID"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPT"].Value = reader["paymentType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvBilltype"].Value = reader["billType"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvDate"].Value = reader["aDate"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvName"].Value = reader["productName"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvType"].Value = reader["productCategory"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvQty"].Value = reader["qty"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvPrice"].Value = reader["price"];
                    gunaDataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = reader["amount"];
                    gunaDataGridView1.Refresh();
                }
                reader.Close();

                SqlCommand cdm2 = new SqlCommand("", con);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnFilter1_Click(object sender, EventArgs e)
        {
            gunaDataGridView1.Rows.Clear();
            if(comboBox1.Text == "All" && comboBox2.Text == "All" && comboBox3.Text == "All")
            {
                reportload();
            }
            if (comboBox1.Text == "Sales" && comboBox2.Text == "All" && comboBox3.Text == "All")
            {
                reportloadSales();
            }
            if (comboBox1.Text == "Return" && comboBox2.Text == "All" && comboBox3.Text == "All")
            {
                reportloadReturns();
            }
            if (comboBox1.Text == "All" && comboBox2.Text == "All" && comboBox3.Text == "Cash")
            {
                reportloadcash();
            }
            if (comboBox1.Text == "All" && comboBox2.Text == "All" && comboBox3.Text == "Card")
            {
                reportloadcard();
            }
            if (comboBox1.Text == "Sales" && comboBox2.Text == "All" && comboBox3.Text == "Card")
            {
                reportloadSalescard();
            }
            if (comboBox1.Text == "Sales" && comboBox2.Text == "All" && comboBox3.Text == "Cash")
            {
                reportloadSalescash();
            }
            if (comboBox1.Text == "Return" && comboBox2.Text == "All" && comboBox3.Text == "Cash")
            {
                reportloadReturncash();
            }
            othercash();

        }

        private void btnFilter2_Click(object sender, EventArgs e)
        {
            
            gunaDataGridView1.Rows.Clear();

            if (comboBox1.Text == "All" && comboBox2.Text == "All" && comboBox3.Text == "All")
            {
                reportload2();
            }
            if (comboBox1.Text == "Sales" && comboBox2.Text == "All" && comboBox3.Text == "All")
            {
                reportloadSales2();
            }
            if (comboBox1.Text == "Return" && comboBox2.Text == "All" && comboBox3.Text == "All")
            {
                reportloadReturns2();
            }
            if (comboBox1.Text == "All" && comboBox2.Text == "All" && comboBox3.Text == "Cash")
            {
                reportloadcash2();
            }
            if (comboBox1.Text == "All" && comboBox2.Text == "All" && comboBox3.Text == "Card")
            {
                reportloadcard2();
            }
            if (comboBox1.Text == "Sales" && comboBox2.Text == "All" && comboBox3.Text == "Card")
            {
                reportloadSalescard2();
            }
            if (comboBox1.Text == "Sales" && comboBox2.Text == "All" && comboBox3.Text == "Cash")
            {
                reportloadSalescash2();
            }
            if (comboBox1.Text == "Return" && comboBox2.Text == "All" && comboBox3.Text == "Cash")
            {
                reportloadReturncash2();
            }

            
            othercashDaterange();
        }
    }
}
