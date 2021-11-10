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
        BUS_NhanVien bus_nhanvien = new BUS_NhanVien();
        private void load()
        {
            cbtenSanPham.Text = bus_nhanvien.LoadDanhMuc().ToString();
        }
        private void FormQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
