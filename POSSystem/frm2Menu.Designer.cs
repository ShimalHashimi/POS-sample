namespace POSSystem
{
    partial class frm2Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2Menu));
            this.productTransition = new System.Windows.Forms.Timer(this.components);
            this.btnLogout = new Guna.UI.WinForms.GunaButton();
            this.btnReport = new Guna.UI.WinForms.GunaButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCash = new Guna.UI.WinForms.GunaTileButton();
            this.btnCal = new Guna.UI.WinForms.GunaTileButton();
            this.btnKeyboard = new Guna.UI.WinForms.GunaTileButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.btnBilling = new Guna.UI.WinForms.GunaButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.btnDash = new Guna.UI.WinForms.GunaButton();
            this.btnStaff = new Guna.UI.WinForms.GunaButton();
            this.btnPurchesing = new Guna.UI.WinForms.GunaButton();
            this.btnBarcode = new Guna.UI.WinForms.GunaTileButton();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // productTransition
            // 
            this.productTransition.Interval = 10;
            // 
            // btnLogout
            // 
            this.btnLogout.AnimationHoverSpeed = 0.07F;
            this.btnLogout.AnimationSpeed = 0.03F;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnLogout.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogout.Location = new System.Drawing.Point(14, 399);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnLogout.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogout.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogout.OnHoverImage = null;
            this.btnLogout.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogout.Radius = 15;
            this.btnLogout.Size = new System.Drawing.Size(289, 48);
            this.btnLogout.TabIndex = 49;
            this.btnLogout.Text = "  LogOut";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // btnReport
            // 
            this.btnReport.AnimationHoverSpeed = 0.07F;
            this.btnReport.AnimationSpeed = 0.03F;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnReport.BorderColor = System.Drawing.Color.Black;
            this.btnReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReport.FocusedColor = System.Drawing.Color.Empty;
            this.btnReport.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReport.Location = new System.Drawing.Point(14, 347);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnReport.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnReport.OnHoverForeColor = System.Drawing.Color.White;
            this.btnReport.OnHoverImage = null;
            this.btnReport.OnPressedColor = System.Drawing.Color.Black;
            this.btnReport.Radius = 15;
            this.btnReport.Size = new System.Drawing.Size(289, 48);
            this.btnReport.TabIndex = 48;
            this.btnReport.Text = "  Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnBarcode);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnCash);
            this.panel3.Controls.Add(this.btnCal);
            this.panel3.Controls.Add(this.btnKeyboard);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(291, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1096, 91);
            this.panel3.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 32F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 61);
            this.label1.TabIndex = 126;
            this.label1.Text = "Rich Shoe Palace";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCash
            // 
            this.btnCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCash.AnimationHoverSpeed = 0.07F;
            this.btnCash.AnimationSpeed = 0.03F;
            this.btnCash.BackColor = System.Drawing.Color.Transparent;
            this.btnCash.BaseColor = System.Drawing.SystemColors.Control;
            this.btnCash.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCash.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCash.FocusedColor = System.Drawing.Color.Empty;
            this.btnCash.Font = new System.Drawing.Font("Arial", 11F);
            this.btnCash.ForeColor = System.Drawing.Color.Black;
            this.btnCash.Image = ((System.Drawing.Image)(resources.GetObject("btnCash.Image")));
            this.btnCash.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCash.Location = new System.Drawing.Point(492, 4);
            this.btnCash.Margin = new System.Windows.Forms.Padding(4);
            this.btnCash.Name = "btnCash";
            this.btnCash.OnHoverBaseColor = System.Drawing.SystemColors.ControlLight;
            this.btnCash.OnHoverBorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCash.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnCash.OnHoverImage = null;
            this.btnCash.OnPressedColor = System.Drawing.Color.Black;
            this.btnCash.Radius = 15;
            this.btnCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCash.Size = new System.Drawing.Size(134, 78);
            this.btnCash.TabIndex = 125;
            this.btnCash.Text = "Other Cash";
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCal
            // 
            this.btnCal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCal.AnimationHoverSpeed = 0.07F;
            this.btnCal.AnimationSpeed = 0.03F;
            this.btnCal.BackColor = System.Drawing.Color.Transparent;
            this.btnCal.BaseColor = System.Drawing.SystemColors.Control;
            this.btnCal.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCal.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCal.FocusedColor = System.Drawing.Color.Empty;
            this.btnCal.Font = new System.Drawing.Font("Arial", 11F);
            this.btnCal.ForeColor = System.Drawing.Color.Black;
            this.btnCal.Image = ((System.Drawing.Image)(resources.GetObject("btnCal.Image")));
            this.btnCal.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCal.Location = new System.Drawing.Point(891, 4);
            this.btnCal.Margin = new System.Windows.Forms.Padding(4);
            this.btnCal.Name = "btnCal";
            this.btnCal.OnHoverBaseColor = System.Drawing.SystemColors.ControlLight;
            this.btnCal.OnHoverBorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCal.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnCal.OnHoverImage = null;
            this.btnCal.OnPressedColor = System.Drawing.Color.Black;
            this.btnCal.Radius = 15;
            this.btnCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCal.Size = new System.Drawing.Size(114, 78);
            this.btnCal.TabIndex = 123;
            this.btnCal.Text = "Calculator";
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeyboard.AnimationHoverSpeed = 0.07F;
            this.btnKeyboard.AnimationSpeed = 0.03F;
            this.btnKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.btnKeyboard.BaseColor = System.Drawing.SystemColors.Control;
            this.btnKeyboard.BorderColor = System.Drawing.SystemColors.Control;
            this.btnKeyboard.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnKeyboard.FocusedColor = System.Drawing.Color.Empty;
            this.btnKeyboard.Font = new System.Drawing.Font("Arial", 11F);
            this.btnKeyboard.ForeColor = System.Drawing.Color.Black;
            this.btnKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.Image")));
            this.btnKeyboard.ImageSize = new System.Drawing.Size(40, 40);
            this.btnKeyboard.Location = new System.Drawing.Point(769, 4);
            this.btnKeyboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.OnHoverBaseColor = System.Drawing.SystemColors.ControlLight;
            this.btnKeyboard.OnHoverBorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnKeyboard.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnKeyboard.OnHoverImage = null;
            this.btnKeyboard.OnPressedColor = System.Drawing.Color.Black;
            this.btnKeyboard.Radius = 15;
            this.btnKeyboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnKeyboard.Size = new System.Drawing.Size(114, 78);
            this.btnKeyboard.TabIndex = 122;
            this.btnKeyboard.Text = "Keyboard";
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panel2.Controls.Add(this.btnPurchesing);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.gunaPictureBox1);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnBilling);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 762);
            this.panel2.TabIndex = 7;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(291, 241);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // btnBilling
            // 
            this.btnBilling.AnimationHoverSpeed = 0.07F;
            this.btnBilling.AnimationSpeed = 0.03F;
            this.btnBilling.BackColor = System.Drawing.Color.Transparent;
            this.btnBilling.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnBilling.BorderColor = System.Drawing.Color.Black;
            this.btnBilling.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBilling.FocusedColor = System.Drawing.Color.Empty;
            this.btnBilling.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Image = ((System.Drawing.Image)(resources.GetObject("btnBilling.Image")));
            this.btnBilling.ImageSize = new System.Drawing.Size(40, 40);
            this.btnBilling.Location = new System.Drawing.Point(14, 249);
            this.btnBilling.Margin = new System.Windows.Forms.Padding(0);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnBilling.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBilling.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBilling.OnHoverImage = null;
            this.btnBilling.OnPressedColor = System.Drawing.Color.Black;
            this.btnBilling.Radius = 15;
            this.btnBilling.Size = new System.Drawing.Size(289, 48);
            this.btnBilling.TabIndex = 47;
            this.btnBilling.Text = " Billing";
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.gunaButton1);
            this.panel6.Controls.Add(this.btnDash);
            this.panel6.Controls.Add(this.btnStaff);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(291, 91);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1096, 671);
            this.panel6.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "sssss";
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaButton1.Image")));
            this.gunaButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.gunaButton1.Location = new System.Drawing.Point(717, 453);
            this.gunaButton1.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Size = new System.Drawing.Size(297, 62);
            this.gunaButton1.TabIndex = 47;
            this.gunaButton1.Text = "Code-Text";
            // 
            // btnDash
            // 
            this.btnDash.AnimationHoverSpeed = 0.07F;
            this.btnDash.AnimationSpeed = 0.03F;
            this.btnDash.BackColor = System.Drawing.Color.Transparent;
            this.btnDash.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(100)))));
            this.btnDash.BorderColor = System.Drawing.Color.Black;
            this.btnDash.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDash.FocusedColor = System.Drawing.Color.Empty;
            this.btnDash.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDash.ForeColor = System.Drawing.Color.White;
            this.btnDash.Image = ((System.Drawing.Image)(resources.GetObject("btnDash.Image")));
            this.btnDash.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDash.Location = new System.Drawing.Point(717, 371);
            this.btnDash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDash.Name = "btnDash";
            this.btnDash.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnDash.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDash.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDash.OnHoverImage = null;
            this.btnDash.OnPressedColor = System.Drawing.Color.Black;
            this.btnDash.Radius = 15;
            this.btnDash.Size = new System.Drawing.Size(286, 62);
            this.btnDash.TabIndex = 42;
            this.btnDash.Text = " Dashboard";
            // 
            // btnStaff
            // 
            this.btnStaff.AnimationHoverSpeed = 0.07F;
            this.btnStaff.AnimationSpeed = 0.03F;
            this.btnStaff.BackColor = System.Drawing.Color.Transparent;
            this.btnStaff.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnStaff.BorderColor = System.Drawing.Color.Black;
            this.btnStaff.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStaff.FocusedColor = System.Drawing.Color.Empty;
            this.btnStaff.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageSize = new System.Drawing.Size(30, 30);
            this.btnStaff.Location = new System.Drawing.Point(717, 305);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnStaff.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStaff.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStaff.OnHoverImage = null;
            this.btnStaff.OnPressedColor = System.Drawing.Color.Black;
            this.btnStaff.Radius = 15;
            this.btnStaff.Size = new System.Drawing.Size(286, 62);
            this.btnStaff.TabIndex = 46;
            this.btnStaff.Text = "Staff";
            // 
            // btnPurchesing
            // 
            this.btnPurchesing.AnimationHoverSpeed = 0.07F;
            this.btnPurchesing.AnimationSpeed = 0.03F;
            this.btnPurchesing.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchesing.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnPurchesing.BorderColor = System.Drawing.Color.Black;
            this.btnPurchesing.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPurchesing.FocusedColor = System.Drawing.Color.Empty;
            this.btnPurchesing.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnPurchesing.ForeColor = System.Drawing.Color.White;
            this.btnPurchesing.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchesing.Image")));
            this.btnPurchesing.ImageSize = new System.Drawing.Size(40, 40);
            this.btnPurchesing.Location = new System.Drawing.Point(14, 297);
            this.btnPurchesing.Margin = new System.Windows.Forms.Padding(0);
            this.btnPurchesing.Name = "btnPurchesing";
            this.btnPurchesing.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnPurchesing.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPurchesing.OnHoverForeColor = System.Drawing.Color.White;
            this.btnPurchesing.OnHoverImage = null;
            this.btnPurchesing.OnPressedColor = System.Drawing.Color.Black;
            this.btnPurchesing.Radius = 10;
            this.btnPurchesing.Size = new System.Drawing.Size(316, 48);
            this.btnPurchesing.TabIndex = 56;
            this.btnPurchesing.Text = "Purchesing";
            this.btnPurchesing.Click += new System.EventHandler(this.btnPurchesing_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarcode.AnimationHoverSpeed = 0.07F;
            this.btnBarcode.AnimationSpeed = 0.03F;
            this.btnBarcode.BackColor = System.Drawing.Color.Transparent;
            this.btnBarcode.BaseColor = System.Drawing.SystemColors.Control;
            this.btnBarcode.BorderColor = System.Drawing.SystemColors.Control;
            this.btnBarcode.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBarcode.FocusedColor = System.Drawing.Color.Empty;
            this.btnBarcode.Font = new System.Drawing.Font("Arial", 11F);
            this.btnBarcode.ForeColor = System.Drawing.Color.Black;
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.ImageSize = new System.Drawing.Size(40, 40);
            this.btnBarcode.Location = new System.Drawing.Point(627, 4);
            this.btnBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.OnHoverBaseColor = System.Drawing.SystemColors.ControlLight;
            this.btnBarcode.OnHoverBorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnBarcode.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnBarcode.OnHoverImage = null;
            this.btnBarcode.OnPressedColor = System.Drawing.Color.Black;
            this.btnBarcode.Radius = 15;
            this.btnBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBarcode.Size = new System.Drawing.Size(134, 78);
            this.btnBarcode.TabIndex = 129;
            this.btnBarcode.Text = " Barcode";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // frm2Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 762);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "frm2Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm2Menu_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer productTransition;
        private Guna.UI.WinForms.GunaButton btnLogout;
        private Guna.UI.WinForms.GunaButton btnReport;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI.WinForms.GunaTileButton btnCash;
        private Guna.UI.WinForms.GunaTileButton btnCal;
        private Guna.UI.WinForms.GunaTileButton btnKeyboard;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaButton btnBilling;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaButton btnDash;
        private Guna.UI.WinForms.GunaButton btnStaff;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton btnPurchesing;
        private Guna.UI.WinForms.GunaTileButton btnBarcode;
    }
}