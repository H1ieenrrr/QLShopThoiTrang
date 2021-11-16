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
using System.IO;

namespace QLBH_ThoiTrang
{
    public partial class FormQuanLySanPham : Form
    {
        BUS_SanPham busSanPham = new BUS_QLShopThoiTrang.BUS_SanPham();
        string stremail = FormMain.mail; // Nhận email từ frmMain
        string checkUrlImage; // kiểm tra hình khi cập nhật
        string fileName; // ten file
        string fileSavePath; // url store images
        string fileAddress; // url load images
        public FormQuanLySanPham()
        {
            InitializeComponent();
        }

        private void FormQuanLySanPham_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
        }
        private void ResetValue()
        {
            txtTimKiem.Text = "Nhập Tên Sản Phẩm ";
            txtMaSanPham.Text = null;
            txtTenSanPham.Text = null;
            txtGiaSanPham.Text = null;
            txtMoToSanPham.Text = null;
            txtSize.Text = null;
            txtHinh.Text = null;
            dateTimeNgayNhap.Enabled = false;
            txtSoLuong.Text = null;

            txtMaSanPham.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtGiaSanPham.Enabled = false;
            txtMoToSanPham.Enabled = false;
            txtSize.Enabled = false;
            txtHinh.Enabled = false;
            txtSoLuong.Enabled = false;

            btnDong.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnChonHinh.Enabled = false;

            pbHinhSP.Image = default;
        }

        private void LoadGridView()
        {
            dgvSanPham.DataSource = busSanPham.getHang();
            dgvSanPham.Columns[0].HeaderText = "Mã SP";
            dgvSanPham.Columns[1].HeaderText = "Tên SP";
            dgvSanPham.Columns[2].HeaderText = "Giá SP";
            dgvSanPham.Columns[3].HeaderText = "Size";
            dgvSanPham.Columns[4].HeaderText = "Ngày Nhập";
            dgvSanPham.Columns[5].HeaderText = "Số Lượng";
            dgvSanPham.Columns[6].HeaderText = "Hình Ảnh";
            dgvSanPham.Columns[7].HeaderText = "Mô Tả";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Text = null;
            txtTenSanPham.Text = null;
            txtGiaSanPham.Text = null;
            txtMoToSanPham.Text = null;
            txtSize.Text = null;
            txtHinh.Text = null;
            dateTimeNgayNhap.Enabled = true;
            txtSoLuong.Text = null;

            txtTenSanPham.Enabled = true;
            txtGiaSanPham.Enabled = true;
            txtMoToSanPham.Enabled = true;
            txtSize.Enabled = true;
            txtSoLuong.Enabled = true;
            pbHinhSP.Image = null;

            btnDong.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChonHinh.Enabled = true;

            txtTenSanPham.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(), out intSoLuong);
            float floatGiaSP;
            bool isFloatGiaSP = float.TryParse(txtGiaSanPham.Text.Trim().ToString(), out floatGiaSP);

            if (txtTenSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Tên Hàng ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.Focus();
                return;
            }
            else if (!isFloatGiaSP || float.Parse(txtGiaSanPham.Text) < 0)
            {
                MessageBox.Show("Bạn Phải Nhập Giá SP Nhập Vào ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaSanPham.Focus();
                return;
            }
            else if (txtSize.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Size ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSize.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnChonHinh.Focus();
                return;
            }
            else if (dateTimeNgayNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn Ngày ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimeNgayNhap.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Bạn Phải Nhập Số Lượng ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            else
            {
                DTO_SanPham sp = new DTO_SanPham(txtTenSanPham.Text, float.Parse(txtGiaSanPham.Text), txtSize.Text, dateTimeNgayNhap.Value,
                                                int.Parse(txtSoLuong.Text),"\\ImagesSP\\" + fileName, txtMoToSanPham.Text, stremail);
                if (busSanPham.InsertSanPham(sp))
                {
                    MessageBox.Show("Thêm Sản Phẩm Thành Công");
                    File.Copy(fileAddress, fileSavePath, true);
                    ResetValue();
                    LoadGridView();
                }
                else
                {
                    MessageBox.Show("Thêm Sản Phẩm Không Thành Công");
                }
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn Ảnh Minh Họa Cho Sản Phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbHinhSP.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                fileSavePath = saveDirectory + "\\ImagesSP\\" + fileName;
                txtHinh.Text = "\\ImagesSP\\" + fileName;
            }
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            if (dgvSanPham.Rows.Count > 1)
            {
                btnChonHinh.Enabled = true;
                btnLuu.Enabled = false;
                txtTenSanPham.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaSanPham.Enabled = true;
                txtSize.Enabled = true;
                txtMoToSanPham.Enabled = true;
                txtTenSanPham.Focus();
                dateTimeNgayNhap.Enabled = true;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;                                           

                txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
                txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtGiaSanPham.Text = dgvSanPham.CurrentRow.Cells["GiaSP"].Value.ToString();
                txtSize.Text = dgvSanPham.CurrentRow.Cells["Size"].Value.ToString();
                txtHinh.Text = dgvSanPham.CurrentRow.Cells["HinhAnh"].Value.ToString();
                dateTimeNgayNhap.Text = dgvSanPham.CurrentRow.Cells["NgayNhap"].Value.ToString();
                txtMoToSanPham.Text = dgvSanPham.CurrentRow.Cells["MoTa"].Value.ToString();

                checkUrlImage = txtHinh.Text;
                pbHinhSP.Image = Image.FromFile(saveDirectory + dgvSanPham.CurrentRow.Cells["HinhAnh"].Value.ToString());

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(), out intSoLuong);
            float floatGiaSP;
            bool isFloatGiaSP = float.TryParse(txtGiaSanPham.Text.Trim().ToString(), out floatGiaSP);

            if (txtTenSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Tên Hàng ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.Focus();
                return;
            }
            else if (!isFloatGiaSP || float.Parse(txtGiaSanPham.Text) < 0)
            {
                MessageBox.Show("Bạn Phải Nhập Giá SP Nhập Vào ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaSanPham.Focus();
                return;
            }
            else if (txtSize.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Size ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSize.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnChonHinh.Focus();
                return;
            }
            else if (dateTimeNgayNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn Ngày ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimeNgayNhap.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Bạn Phải Nhập Số Lượng ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            else
            {
                DTO_SanPham sp = new DTO_SanPham(int.Parse(txtMaSanPham.Text), txtTenSanPham.Text, float.Parse(txtGiaSanPham.Text), txtSize.Text, 
                                           dateTimeNgayNhap.Value, int.Parse(txtSoLuong.Text), txtHinh.Text, txtMoToSanPham.Text);

                if(MessageBox.Show("Bạn Có Chắc Muốn Sửa Sản Phẩm", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busSanPham.UpdateSanPham(sp))
                    {
                        if (txtHinh.Text != checkUrlImage)
                            File.Copy(fileAddress, fileSavePath, true);
                        MessageBox.Show("Sửa Sản Phẩm Thành Công");
                        ResetValue();
                        LoadGridView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Sản Phẩm Không Thành Công");
                    }
                }
                else
                {
                    ResetValue();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSanPham.Text;
            if (MessageBox.Show("Bạn Có Chắc Muốn Xóa Dữ Liệu ", "ConFirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busSanPham.DeleteSanPham(MaSP))
                {
                    MessageBox.Show("Xóa Dữ Liệu Thành Công");
                    ResetValue();
                    LoadGridView();
                }
                else
                {
                    MessageBox.Show("Xóa Không Thành Công");
                }
            }
            else
            {
                ResetValue();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenSP = txtTimKiem.Text;
            DataTable dtaSP = busSanPham.SearchSanPham(TenSP);
            if (dtaSP.Rows.Count > 0)
            {
                dgvSanPham.DataSource = dtaSP;
                dgvSanPham.Columns[0].HeaderText = "Mã SP";
                dgvSanPham.Columns[1].HeaderText = "Tên SP";
                dgvSanPham.Columns[2].HeaderText = "Giá SP";
                dgvSanPham.Columns[3].HeaderText = "Size";
                dgvSanPham.Columns[4].HeaderText = "Ngày Nhập";
                dgvSanPham.Columns[5].HeaderText = "Số Lượng";
                dgvSanPham.Columns[6].HeaderText = "Hình Ảnh";
                dgvSanPham.Columns[7].HeaderText = "Mô Tả";
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Tên Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.BackColor = Color.LightGray;
            ResetValue();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
