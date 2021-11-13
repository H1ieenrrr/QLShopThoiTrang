
namespace QLBH_ThoiTrang
{
    partial class FormTaoHoaDon
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
            this.label6 = new System.Windows.Forms.Label();
            this.panelTaoHoaDon = new System.Windows.Forms.Panel();
            this.cbtenSanPham = new System.Windows.Forms.ComboBox();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeHoaDon = new System.Windows.Forms.DateTimePicker();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtNhanVienNhap = new System.Windows.Forms.TextBox();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvTaoHoaDon = new System.Windows.Forms.DataGridView();
            this.panelTaoHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaoHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(445, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 44);
            this.label6.TabIndex = 24;
            this.label6.Text = "Tạo Hóa Đơn";
            // 
            // panelTaoHoaDon
            // 
            this.panelTaoHoaDon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTaoHoaDon.Controls.Add(this.cbtenSanPham);
            this.panelTaoHoaDon.Controls.Add(this.txtTenNhanVien);
            this.panelTaoHoaDon.Controls.Add(this.label2);
            this.panelTaoHoaDon.Controls.Add(this.dateTimeHoaDon);
            this.panelTaoHoaDon.Controls.Add(this.txtDonGia);
            this.panelTaoHoaDon.Controls.Add(this.txtSoLuong);
            this.panelTaoHoaDon.Controls.Add(this.txtNhanVienNhap);
            this.panelTaoHoaDon.Controls.Add(this.txtMaHoaDon);
            this.panelTaoHoaDon.Controls.Add(this.label8);
            this.panelTaoHoaDon.Controls.Add(this.label7);
            this.panelTaoHoaDon.Controls.Add(this.label5);
            this.panelTaoHoaDon.Controls.Add(this.label1);
            this.panelTaoHoaDon.Controls.Add(this.label4);
            this.panelTaoHoaDon.Controls.Add(this.label3);
            this.panelTaoHoaDon.Controls.Add(this.label10);
            this.panelTaoHoaDon.Controls.Add(this.label9);
            this.panelTaoHoaDon.Controls.Add(this.btnDong);
            this.panelTaoHoaDon.Controls.Add(this.btnLuu);
            this.panelTaoHoaDon.Controls.Add(this.btnThem);
            this.panelTaoHoaDon.Controls.Add(this.dgvTaoHoaDon);
            this.panelTaoHoaDon.Location = new System.Drawing.Point(12, 48);
            this.panelTaoHoaDon.Name = "panelTaoHoaDon";
            this.panelTaoHoaDon.Size = new System.Drawing.Size(1239, 665);
            this.panelTaoHoaDon.TabIndex = 23;
            // 
            // cbtenSanPham
            // 
            this.cbtenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtenSanPham.FormattingEnabled = true;
            this.cbtenSanPham.Location = new System.Drawing.Point(843, 41);
            this.cbtenSanPham.Name = "cbtenSanPham";
            this.cbtenSanPham.Size = new System.Drawing.Size(308, 37);
            this.cbtenSanPham.TabIndex = 105;
            this.cbtenSanPham.Text = "Danh Mục";
            this.cbtenSanPham.SelectedIndexChanged += new System.EventHandler(this.cbtenSanPham_SelectedIndexChanged);
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhanVien.Location = new System.Drawing.Point(226, 227);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(301, 34);
            this.txtTenNhanVien.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(22, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 29);
            this.label2.TabIndex = 103;
            this.label2.Text = "Tên Khách Hàng:";
            // 
            // dateTimeHoaDon
            // 
            this.dateTimeHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeHoaDon.Location = new System.Drawing.Point(843, 106);
            this.dateTimeHoaDon.Name = "dateTimeHoaDon";
            this.dateTimeHoaDon.Size = new System.Drawing.Size(308, 34);
            this.dateTimeHoaDon.TabIndex = 102;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(843, 168);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(308, 34);
            this.txtDonGia.TabIndex = 101;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(226, 108);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(301, 34);
            this.txtSoLuong.TabIndex = 99;
            // 
            // txtNhanVienNhap
            // 
            this.txtNhanVienNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVienNhap.Location = new System.Drawing.Point(226, 173);
            this.txtNhanVienNhap.Name = "txtNhanVienNhap";
            this.txtNhanVienNhap.Size = new System.Drawing.Size(301, 34);
            this.txtNhanVienNhap.TabIndex = 98;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(226, 47);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(301, 34);
            this.txtMaHoaDon.TabIndex = 97;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(581, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 29);
            this.label8.TabIndex = 96;
            this.label8.Text = "Đơn Giá:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(581, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 29);
            this.label7.TabIndex = 95;
            this.label7.Text = "Ngày Lập Hóa Đơn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(581, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 29);
            this.label5.TabIndex = 94;
            this.label5.Text = "Tên Sản Phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(22, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 93;
            this.label1.Text = "Nhân Viên Nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(22, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 29);
            this.label4.TabIndex = 92;
            this.label4.Text = "Số Lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(22, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 91;
            this.label3.Text = "Mã Hóa Đơn:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(9, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(229, 29);
            this.label10.TabIndex = 89;
            this.label10.Text = "Danh Sách Hóa Đơn";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(9, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 29);
            this.label9.TabIndex = 87;
            this.label9.Text = "Thông Tin Hóa Đơn";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.LightCoral;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(683, 290);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(119, 41);
            this.btnDong.TabIndex = 71;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(535, 290);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(111, 41);
            this.btnLuu.TabIndex = 68;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnThem.Location = new System.Drawing.Point(383, 290);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(117, 41);
            this.btnThem.TabIndex = 65;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // dgvTaoHoaDon
            // 
            this.dgvTaoHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaoHoaDon.Location = new System.Drawing.Point(14, 381);
            this.dgvTaoHoaDon.Name = "dgvTaoHoaDon";
            this.dgvTaoHoaDon.RowHeadersWidth = 51;
            this.dgvTaoHoaDon.RowTemplate.Height = 24;
            this.dgvTaoHoaDon.Size = new System.Drawing.Size(1206, 268);
            this.dgvTaoHoaDon.TabIndex = 15;
            // 
            // FormTaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 725);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelTaoHoaDon);
            this.Name = "FormTaoHoaDon";
            this.Text = "FormTaoHoaDon";
            this.panelTaoHoaDon.ResumeLayout(false);
            this.panelTaoHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaoHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelTaoHoaDon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvTaoHoaDon;
        private System.Windows.Forms.DateTimePicker dateTimeHoaDon;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtNhanVienNhap;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbtenSanPham;
    }
}