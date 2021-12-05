
namespace Meet_QuanLyShopThoiTrang
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.dtNgayBatDau = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dtNgayKetThuc = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btExcel = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnThongKeTongHop = new Guna.UI2.WinForms.Guna2Button();
            this.btXuatThongKePDF = new Guna.UI2.WinForms.Guna2Button();
            this.btXuatThongKeExcel = new Guna.UI2.WinForms.Guna2Button();
            this.dgvThongKe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(38, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 29);
            this.label3.TabIndex = 149;
            this.label3.Text = "Ngày bắt đầu:";
            // 
            // dtNgayBatDau
            // 
            this.dtNgayBatDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtNgayBatDau.BackColor = System.Drawing.Color.Transparent;
            this.dtNgayBatDau.BaseColor = System.Drawing.Color.White;
            this.dtNgayBatDau.BorderColor = System.Drawing.Color.Silver;
            this.dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtNgayBatDau.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtNgayBatDau.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dtNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayBatDau.Location = new System.Drawing.Point(218, 66);
            this.dtNgayBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNgayBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNgayBatDau.Name = "dtNgayBatDau";
            this.dtNgayBatDau.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtNgayBatDau.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayBatDau.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayBatDau.OnPressedColor = System.Drawing.Color.Black;
            this.dtNgayBatDau.Size = new System.Drawing.Size(166, 36);
            this.dtNgayBatDau.TabIndex = 164;
            this.dtNgayBatDau.Text = "24/11/2021";
            this.dtNgayBatDau.Value = new System.DateTime(2021, 11, 24, 22, 3, 45, 353);
            // 
            // dtNgayKetThuc
            // 
            this.dtNgayKetThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtNgayKetThuc.BackColor = System.Drawing.Color.Transparent;
            this.dtNgayKetThuc.BaseColor = System.Drawing.Color.White;
            this.dtNgayKetThuc.BorderColor = System.Drawing.Color.Silver;
            this.dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtNgayKetThuc.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtNgayKetThuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayKetThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dtNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayKetThuc.Location = new System.Drawing.Point(527, 64);
            this.dtNgayKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNgayKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNgayKetThuc.Name = "dtNgayKetThuc";
            this.dtNgayKetThuc.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtNgayKetThuc.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayKetThuc.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayKetThuc.OnPressedColor = System.Drawing.Color.Black;
            this.dtNgayKetThuc.Size = new System.Drawing.Size(168, 36);
            this.dtNgayKetThuc.TabIndex = 166;
            this.dtNgayKetThuc.Text = "24/11/2021";
            this.dtNgayKetThuc.Value = new System.DateTime(2021, 11, 24, 22, 3, 45, 353);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(403, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 165;
            this.label1.Text = "Đến ngày:";
            // 
            // btTimKiem
            // 
            this.btTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btTimKiem.BorderRadius = 15;
            this.btTimKiem.CheckedState.Parent = this.btTimKiem;
            this.btTimKiem.CustomImages.Parent = this.btTimKiem;
            this.btTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btTimKiem.DisabledState.Parent = this.btTimKiem;
            this.btTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.ForeColor = System.Drawing.Color.White;
            this.btTimKiem.HoverState.Parent = this.btTimKiem;
            this.btTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btTimKiem.Image")));
            this.btTimKiem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btTimKiem.ImageSize = new System.Drawing.Size(35, 35);
            this.btTimKiem.Location = new System.Drawing.Point(721, 53);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.ShadowDecoration.Parent = this.btTimKiem;
            this.btTimKiem.Size = new System.Drawing.Size(254, 45);
            this.btTimKiem.TabIndex = 167;
            this.btTimKiem.Text = "Thống Kê Chi Tiết";
            this.btTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimKiem.BorderRadius = 15;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.Parent = this.txtTimKiem;
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.FocusedState.Parent = this.txtTimKiem;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.HoverState.Parent = this.txtTimKiem;
            this.txtTimKiem.Location = new System.Drawing.Point(148, 117);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.ShadowDecoration.Parent = this.txtTimKiem;
            this.txtTimKiem.Size = new System.Drawing.Size(236, 40);
            this.txtTimKiem.TabIndex = 168;
            this.txtTimKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.BorderRadius = 15;
            this.btExcel.CheckedState.Parent = this.btExcel;
            this.btExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcel.CustomImages.Parent = this.btExcel;
            this.btExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btExcel.DisabledState.Parent = this.btExcel;
            this.btExcel.FillColor = System.Drawing.Color.Transparent;
            this.btExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcel.ForeColor = System.Drawing.Color.White;
            this.btExcel.HoverState.Parent = this.btExcel;
            this.btExcel.Image = ((System.Drawing.Image)(resources.GetObject("btExcel.Image")));
            this.btExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btExcel.ImageSize = new System.Drawing.Size(35, 35);
            this.btExcel.Location = new System.Drawing.Point(1123, 87);
            this.btExcel.Name = "btExcel";
            this.btExcel.ShadowDecoration.Parent = this.btExcel;
            this.btExcel.Size = new System.Drawing.Size(54, 45);
            this.btExcel.TabIndex = 170;
            this.btExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(245, 614);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 38);
            this.label2.TabIndex = 171;
            this.label2.Text = "TỔNG DOANH THU:";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTongDoanhThu.BorderRadius = 15;
            this.txtTongDoanhThu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongDoanhThu.DefaultText = "1000000";
            this.txtTongDoanhThu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTongDoanhThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTongDoanhThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongDoanhThu.DisabledState.Parent = this.txtTongDoanhThu;
            this.txtTongDoanhThu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongDoanhThu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongDoanhThu.FocusedState.Parent = this.txtTongDoanhThu;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongDoanhThu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongDoanhThu.HoverState.Parent = this.txtTongDoanhThu;
            this.txtTongDoanhThu.Location = new System.Drawing.Point(584, 607);
            this.txtTongDoanhThu.Margin = new System.Windows.Forms.Padding(8);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.PasswordChar = '\0';
            this.txtTongDoanhThu.PlaceholderText = "";
            this.txtTongDoanhThu.SelectedText = "";
            this.txtTongDoanhThu.SelectionStart = 7;
            this.txtTongDoanhThu.ShadowDecoration.Parent = this.txtTongDoanhThu;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(289, 51);
            this.txtTongDoanhThu.TabIndex = 172;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(776, 614);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 38);
            this.label4.TabIndex = 173;
            this.label4.Text = "VNĐ";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.btnThongKeTongHop);
            this.guna2GroupBox1.Controls.Add(this.dtNgayKetThuc);
            this.guna2GroupBox1.Controls.Add(this.dtNgayBatDau);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.btXuatThongKePDF);
            this.guna2GroupBox1.Controls.Add(this.btTimKiem);
            this.guna2GroupBox1.Controls.Add(this.txtTimKiem);
            this.guna2GroupBox1.Controls.Add(this.btXuatThongKeExcel);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(1200, 174);
            this.guna2GroupBox1.TabIndex = 174;
            this.guna2GroupBox1.Text = "Tìm Kiếm Hoá Đơn";
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // btnThongKeTongHop
            // 
            this.btnThongKeTongHop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThongKeTongHop.BorderRadius = 15;
            this.btnThongKeTongHop.CheckedState.Parent = this.btnThongKeTongHop;
            this.btnThongKeTongHop.CustomImages.Parent = this.btnThongKeTongHop;
            this.btnThongKeTongHop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTongHop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTongHop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKeTongHop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKeTongHop.DisabledState.Parent = this.btnThongKeTongHop;
            this.btnThongKeTongHop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeTongHop.ForeColor = System.Drawing.Color.White;
            this.btnThongKeTongHop.HoverState.Parent = this.btnThongKeTongHop;
            this.btnThongKeTongHop.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKeTongHop.Image")));
            this.btnThongKeTongHop.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKeTongHop.ImageSize = new System.Drawing.Size(35, 35);
            this.btnThongKeTongHop.Location = new System.Drawing.Point(721, 112);
            this.btnThongKeTongHop.Name = "btnThongKeTongHop";
            this.btnThongKeTongHop.ShadowDecoration.Parent = this.btnThongKeTongHop;
            this.btnThongKeTongHop.Size = new System.Drawing.Size(254, 45);
            this.btnThongKeTongHop.TabIndex = 169;
            this.btnThongKeTongHop.Text = "Thống Kê Tổng Hợp";
            this.btnThongKeTongHop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKeTongHop.Click += new System.EventHandler(this.btnThongKeTongHop_Click);
            // 
            // btXuatThongKePDF
            // 
            this.btXuatThongKePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btXuatThongKePDF.CheckedState.Parent = this.btXuatThongKePDF;
            this.btXuatThongKePDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btXuatThongKePDF.CustomImages.Parent = this.btXuatThongKePDF;
            this.btXuatThongKePDF.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXuatThongKePDF.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXuatThongKePDF.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXuatThongKePDF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXuatThongKePDF.DisabledState.Parent = this.btXuatThongKePDF;
            this.btXuatThongKePDF.FillColor = System.Drawing.Color.Transparent;
            this.btXuatThongKePDF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btXuatThongKePDF.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btXuatThongKePDF.HoverState.Parent = this.btXuatThongKePDF;
            this.btXuatThongKePDF.Image = ((System.Drawing.Image)(resources.GetObject("btXuatThongKePDF.Image")));
            this.btXuatThongKePDF.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btXuatThongKePDF.ImageSize = new System.Drawing.Size(35, 35);
            this.btXuatThongKePDF.Location = new System.Drawing.Point(1082, 42);
            this.btXuatThongKePDF.Name = "btXuatThongKePDF";
            this.btXuatThongKePDF.ShadowDecoration.Parent = this.btXuatThongKePDF;
            this.btXuatThongKePDF.Size = new System.Drawing.Size(115, 67);
            this.btXuatThongKePDF.TabIndex = 175;
            this.btXuatThongKePDF.Text = "PDF";
            this.btXuatThongKePDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btXuatThongKePDF.Click += new System.EventHandler(this.btXuatThongKePDF_Click);
            // 
            // btXuatThongKeExcel
            // 
            this.btXuatThongKeExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btXuatThongKeExcel.CheckedState.Parent = this.btXuatThongKeExcel;
            this.btXuatThongKeExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btXuatThongKeExcel.CustomImages.Parent = this.btXuatThongKeExcel;
            this.btXuatThongKeExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btXuatThongKeExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btXuatThongKeExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btXuatThongKeExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btXuatThongKeExcel.DisabledState.Parent = this.btXuatThongKeExcel;
            this.btXuatThongKeExcel.FillColor = System.Drawing.Color.Transparent;
            this.btXuatThongKeExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btXuatThongKeExcel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btXuatThongKeExcel.HoverState.Parent = this.btXuatThongKeExcel;
            this.btXuatThongKeExcel.Image = ((System.Drawing.Image)(resources.GetObject("btXuatThongKeExcel.Image")));
            this.btXuatThongKeExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btXuatThongKeExcel.ImageSize = new System.Drawing.Size(35, 35);
            this.btXuatThongKeExcel.Location = new System.Drawing.Point(1082, 115);
            this.btXuatThongKeExcel.Name = "btXuatThongKeExcel";
            this.btXuatThongKeExcel.ShadowDecoration.Parent = this.btXuatThongKeExcel;
            this.btXuatThongKeExcel.Size = new System.Drawing.Size(115, 59);
            this.btXuatThongKeExcel.TabIndex = 170;
            this.btXuatThongKeExcel.Text = "Excel";
            this.btXuatThongKeExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btXuatThongKeExcel.Click += new System.EventHandler(this.btXuatThongKe_Click_1);
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongKe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvThongKe.ColumnHeadersHeight = 27;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvThongKe.EnableHeadersVisualStyles = false;
            this.dgvThongKe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKe.Location = new System.Drawing.Point(12, 180);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(1188, 403);
            this.dgvThongKe.TabIndex = 170;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThongKe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThongKe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThongKe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKe.ThemeStyle.HeaderStyle.Height = 27;
            this.dgvThongKe.ThemeStyle.ReadOnly = false;
            this.dgvThongKe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThongKe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongKe.ThemeStyle.RowsStyle.Height = 24;
            this.dgvThongKe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongKe.DoubleClick += new System.EventHandler(this.dgvThongKe_DoubleClick);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btExcel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaDateTimePicker dtNgayBatDau;
        private Guna.UI.WinForms.GunaDateTimePicker dtNgayKetThuc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btExcel;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btXuatThongKeExcel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongKe;
        private Guna.UI2.WinForms.Guna2Button btXuatThongKePDF;
        private Guna.UI2.WinForms.Guna2Button btnThongKeTongHop;
    }
}