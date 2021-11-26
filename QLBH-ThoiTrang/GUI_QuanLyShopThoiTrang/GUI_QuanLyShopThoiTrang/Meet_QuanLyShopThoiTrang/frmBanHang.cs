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

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }
        BUS_HoaDon bus_hoadon = new BUS_HoaDon();
        BUS_HoaDonChiTiet bus_hoadonct = new BUS_HoaDonChiTiet();
        DataTable dtDSCT = new DataTable();
        int vitriclick = 0;

        private void LoadTenSP()
        {
            cbTenSP.DataSource = bus_hoadon.HienThiTenSP();
            cbTenSP.DisplayMember = "TenSP";
        }
        private void ResetValue()
        {
            txtTongHD.Text = null;
            txtTongThanhToan.Text = null;
            cbThue.Text = "10";
            txtTongHD.Enabled = false;
            txtTongThanhToan.Enabled = false;
            dtDSCT.Rows.Clear();
            txtMaSP.Enabled = false;
            txtMaSP.Text = null;
            cbTenNV.DataSource = bus_hoadon.HienThiTenNV(frmDangNhap.mail);
            cbTenNV.DisplayMember = "TenNV";
            txtDonGia.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTenKH.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;
            dgvCTHD.Text = null;
            txtDonGia.Text = null;
            txtSoLuong.Text = null;
            dgvCTHD.Text = null;
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            dtDSCT.Rows.Clear();
            dtDSCT.Columns.Add("Mã sản phẩm");
            dtDSCT.Columns.Add("Tên sản phẩm");
            dtDSCT.Columns.Add("Đơn giá");
            dtDSCT.Columns.Add("Số lượng");
            dtDSCT.Columns.Add("Thành tiền");
            ResetValue();
            LoadTenSP();
        }

        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = bus_hoadon.HienThiGiaSP(cbTenSP.Text);
            dt.Columns[0].ColumnName = "MaSP";
            dt.Columns[1].ColumnName = "GiaSP";
            foreach (DataRow R in dt.Rows)
            {
                txtMaSP.Text = R["MaSP"].ToString();
                txtDonGia.Text = R["GiaSP"].ToString();
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_hoadon.HienThiThongTinKH(txtDienThoai.Text);
            dt.Columns[0].ColumnName = "TenKH";
            dt.Columns[1].ColumnName = "DiaChi";
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại");
            }
            else if (dt.Rows.Count > 0)
            {
                foreach (DataRow R in dt.Rows)
                {
                    txtTenKH.Text = R["TenKH"].ToString();
                    txtDiaChi.Text = R["DiaChi"].ToString();
                }
            }
            else
            {
                string messenger = "Không tìm thấy khách hàng\n Bạn có muốn thêm khách hàng không?";
                if (MessageBox.Show(messenger, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmKhachHang kh = new frmKhachHang();
                    kh.ShowDialog();
                }
                else
                {
                    txtDienThoai.Focus();
                }
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            float floatGiaSP;
            bool isFloatGiaSP = float.TryParse(txtSoLuong.Text.Trim().ToString(), out floatGiaSP);
            if (txtMaSP.Text == "" || cbTenSP.Text == "")
            {
                MessageBox.Show("Chưa chọn sp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!isFloatGiaSP || float.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Chưa nhập số lượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!CheckTrungSanPham(txtMaSP.Text))
                {
                    DataRow row = dtDSCT.NewRow();
                    row[0] = txtMaSP.Text;
                    row[1] = cbTenSP.Text;
                    row[2] = txtDonGia.Text;
                    row[3] = txtSoLuong.Text;
                    row[4] = (Convert.ToDecimal(txtDonGia.Text) * Convert.ToDecimal(txtSoLuong.Text)).ToString();
                    dtDSCT.Rows.Add(row);
                }
                else
                {
                    capnhatSL(txtMaSP.Text, int.Parse(txtSoLuong.Text.ToString()));
                }
                dgvCTHD.DataSource = dtDSCT;
                txtTongHD.Text = "0";
                //kiểm tra nếu cột kh có giá trị thì tổng tiền trở về 0                           
                for (int i = 0; i < dtDSCT.Rows.Count; i++)
                {
                    txtTongHD.Text = Convert.ToString(float.Parse(txtTongHD.Text) + float.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString()));

                }
                txtTongThanhToan.Text = Convert.ToString(float.Parse(txtTongHD.Text) +
                       (float.Parse(txtTongHD.Text) * int.Parse(cbThue.Text) / 100));
            }
        }
        private bool CheckTrungSanPham(string maSP)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][0].ToString() == maSP)
                    return true;
            return false;
        }
        private void capnhatSL(string MaSP, int SL)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
            {
                if (dtDSCT.Rows[i][0].ToString() == MaSP)
                {
                    int SoLuong = int.Parse(dtDSCT.Rows[i][3].ToString()) + SL;
                    dtDSCT.Rows[i][3] = SoLuong;
                    float DonGia = float.Parse(dtDSCT.Rows[i][2].ToString());
                    dtDSCT.Rows[i][4] = (DonGia * SoLuong).ToString();
                    break;
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (vitriclick < dtDSCT.Rows.Count)
                dtDSCT.Rows.RemoveAt(vitriclick);
        }

     
        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienThoai.Focus();
            }
            else if (dgvCTHD.RowCount < 2)
            {
                MessageBox.Show("Chưa chọn sản phẩm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTenSP.Focus();
            }
            else if (cbThue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa chọn thuế VAT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn thanh toán hoá đơn này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DTO_HoaDon hd = new DTO_HoaDon(dtNgayTao.Value, int.Parse(cbThue.Text), decimal.Parse(txtTongHD.Text), decimal.Parse(txtTongThanhToan.Text), txtDienThoai.Text, frmDangNhap.mail);
                    if (bus_hoadon.ThemHoaDon(hd))
                    {
                        for (int i = 0; i < dgvCTHD.Rows.Count; i++)
                        {
                            DTO_HoaDonChiTiet hdct = new DTO_HoaDonChiTiet(
                              Convert.ToInt32(dgvCTHD.Rows[i].Cells[0].Value), Convert.ToDecimal(dgvCTHD.Rows[i].Cells[2].Value),
                             Convert.ToInt32(dgvCTHD.Rows[i].Cells[3].Value), dtNgayTao.Value);
                            bus_hoadonct.ThemHoaDonCT(hdct);
                        }
                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValue();
                    }
                }
            }
        }

        private void cbThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTongHD.Text != "")
                txtTongThanhToan.Text = Convert.ToString(float.Parse(txtTongHD.Text) +
                 (float.Parse(txtTongHD.Text) * int.Parse(cbThue.Text) / 100));
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vitriclick = e.RowIndex;
        }
    }
}
