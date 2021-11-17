using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLShopThoiTrang;
using DTO_QLShopThoiTrang;
namespace QLBH_ThoiTrang
{
    public partial class FormQuanLyKhachHang : Form
    {
        BUS_KhachHang bus_khachhang = new BUS_KhachHang();
        string email = FormMain.mail;
        public FormQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadKH();
        }

        private void ResetValue()
        {
            txtTimKiem.Text = "Nhập SĐT Khách Hàng ";
            txtDienThoai.Text = null;
            txtTenKH.Text = null;
            txtDiaChi.Text = null;

            rbNam.Checked = false;
            rbNu.Checked = false;
            txtDienThoai.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            rbNam.Enabled = false;
            rbNu.Enabled = false;
            dateTimeNgaySinh.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnDong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void LoadKH()
        {
            dgvKhachHang.DataSource = bus_khachhang.ListKH();
            dgvKhachHang.Columns[0].HeaderText = "Điện Thoại";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDienThoai.Text = null;
            txtTenKH.Text = null;
            txtDiaChi.Text = null;

            txtDienThoai.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;

            rbNam.Enabled = true;
            rbNu.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            rbNam.Checked = true;
            
            txtDienThoai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gioitinh = "Nam";
            if (rbNu.Checked == true)
                gioitinh = "Nữ";

            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            if (bus_khachhang.KiemTraSDT(txtDienThoai.Text))
            {
                MessageBox.Show("Số Điện Thoại Đã Được Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else if (dateTimeNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn Ngày ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimeNgaySinh.Focus();
                return;
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtTenKH.Text, txtDiaChi.Text, gioitinh, dateTimeNgaySinh.Value, email);
                if (bus_khachhang.ThemKH(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValue();
                    LoadKH();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, lỗi!");
                    ResetValue();
                    LoadKH();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadKH();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 1)
            {
                txtDienThoai.Enabled = false;
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                rbNam.Checked = true;

                dateTimeNgaySinh.Enabled = true;
                rbNam.Enabled = true;
                rbNu.Enabled = true;
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                dateTimeNgaySinh.Text = dgvKhachHang.CurrentRow.Cells["NgaySinh"].Value.ToString();
                if ((dgvKhachHang.CurrentRow.Cells["GioiTinh"].Value.ToString()) == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else if (dateTimeNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn Ngày ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimeNgaySinh.Focus();
                return;
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string gioitinh = "Nam";
                if (rbNu.Checked == true)
                    gioitinh = "Nữ";
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtTenKH.Text, txtDiaChi.Text, gioitinh,dateTimeNgaySinh.Value);

                if (MessageBox.Show("Bạn có muốn chỉnh sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bus_khachhang.SuaKH(kh))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadKH();
                        ResetValue();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại! Lỗi");
                        LoadKH();
                    }
                }
                else
                {
                    LoadKH();
                    ResetValue();
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá khách hàng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bus_khachhang.XoaKH(txtDienThoai.Text))
                {
                    MessageBox.Show("Xoá thành công");
                    LoadKH();
                    ResetValue();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại! Lỗi kết nối");
                    LoadKH();
                }
            }
            else
            {
                LoadKH();
                ResetValue();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_khachhang.TimKiemKhachHang(txtTimKiem.Text);
            if (dt.Rows.Count > 0)
            {
                dgvKhachHang.DataSource = bus_khachhang.TimKiemKhachHang(txtTimKiem.Text);
                dgvKhachHang.Columns[0].HeaderText = "Điện Thoại";
                dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
                dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
                dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
            }
            else
            {
                MessageBox.Show("Không tìm thấy số điện thoại");
                txtTimKiem.Focus();
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
        }
    }
}
