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
using System.Data.SqlClient;

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        BUS_KhachHang bus_khachhang = new BUS_KhachHang();
        string email = frmDangNhap.mail;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadKH();
            dtNgaySinh.Value = DateTime.Now;

        }


        private void ResetValue()
        {
            txtTimKiem.Text = "Nhập SĐT Khách Hàng ";
            txtDienThoai.Text = null;
            txtTenKhachHang.Text = null;
            txtDiaChi.Text = null;

            rdNam.Checked = false;
            rdNu.Checked = false;
            txtDienThoai.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtDiaChi.Enabled = false;
            rdNam.Enabled = false;
            rdNu.Enabled = false;

            btThem.Enabled = true;
            btLuu.Enabled = false;
            btDong.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
        }
        private void LoadKH()
        {
            dgvKhachHang.DataSource = bus_khachhang.ListKH();
            dgvKhachHang.Columns[0].HeaderText = "Điện Thoại";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
            dgvKhachHang.Columns[4].HeaderText = "Ngày Sinh";

            dgvKhachHang.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtDienThoai.Text = null;
            txtTenKhachHang.Text = null;
            txtDiaChi.Text = null;

            txtDienThoai.Enabled = true;
            txtTenKhachHang.Enabled = true;
            txtDiaChi.Enabled = true;

            rdNam.Enabled = true;
            rdNu.Enabled = true;
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            rdNam.Checked = true;

            txtDienThoai.Focus();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string gioitinh = "Nam";
            if (rdNu.Checked == true)
                gioitinh = "Nữ";
            if (txtDienThoai.TextLength < 10)
            {
                MessageBox.Show("Số điện thoại k hợp lệ");
            }
            else if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (txtTenKhachHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhachHang.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else if (rdNam.Checked == false && rdNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtTenKhachHang.Text, txtDiaChi.Text, gioitinh, dtNgaySinh.Value, email);
                try
                {
                    if (bus_khachhang.ThemKH(kh))
                    {
                        MessageBox.Show("Thêm thành công");
                        ResetValue();
                        LoadKH();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, lỗi!");
                        LoadKH();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                    }
                }

            }
        }

        

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (txtTenKhachHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhachHang.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else if (rdNam.Checked == false && rdNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string gioitinh = "Nam";
                if (rdNu.Checked == true)
                    gioitinh = "Nữ";
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtTenKhachHang.Text, txtDiaChi.Text, gioitinh, dtNgaySinh.Value);

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

        private void btXoa_Click(object sender, EventArgs e)
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

        private void btTimKiem_Click(object sender, EventArgs e)
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

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 1)
            {
                txtDienThoai.Enabled = false;
                txtTenKhachHang.Enabled = true;
                txtDiaChi.Enabled = true;
                btThem.Enabled = true;
                btXoa.Enabled = true;
                btSua.Enabled = true;
                btLuu.Enabled = false;
                rdNam.Checked = true;
                rdNu.Enabled = true;
                rdNam.Enabled = true;
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
                txtTenKhachHang.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                if ((dgvKhachHang.CurrentRow.Cells["GioiTinh"].Value.ToString()) == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
