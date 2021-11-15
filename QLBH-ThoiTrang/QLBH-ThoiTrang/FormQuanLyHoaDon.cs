using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLShopThoiTrang;
using BUS_QLShopThoiTrang;

namespace QLBH_ThoiTrang
{
    public partial class FormQuanLyHoaDon : Form
    {
        public FormQuanLyHoaDon()
        {
            InitializeComponent();
        }
        BUS_HoaDon bus_hoadon = new BUS_HoaDon();
        private void LoadDanhSachSP()
        {
            dtgDanhSachSP.DataSource = bus_hoadon.HienThiDanhSachSP();
            dtgDanhSachSP.Columns[0].HeaderText = "Mã SP";
            dtgDanhSachSP.Columns[1].HeaderText = "Tên SP";
            dtgDanhSachSP.Columns[2].HeaderText = "Đơn Giá";
            dtgDanhSachSP.Columns[3].HeaderText = "Số Lượng";
        }
        private void ResetValue()
        {
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
        }
        private void FormQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadDanhSachSP();
            ResetValue();
        }

        private void dtgDanhSachSP_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachSP.Rows.Count > 0)
            {
                txtMaSP.Text = dtgDanhSachSP.CurrentRow.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dtgDanhSachSP.CurrentRow.Cells["TenSP"].Value.ToString();
                txtDonGia.Text = dtgDanhSachSP.CurrentRow.Cells["GiaSP"].Value.ToString();
                txtSoLuong.Text = dtgDanhSachSP.CurrentRow.Cells["SoLuong"].Value.ToString();
            }
        }
    }
}
