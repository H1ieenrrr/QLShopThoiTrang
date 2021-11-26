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

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();         
        }
        BUS_SanPham busSanPham = new BUS_QLShopThoiTrang.BUS_SanPham();
        string stremail = frmDangNhap.mail; // Nhận email từ frmMain
        string checkUrlImage; // kiểm tra hình khi cập nhật
        string fileName; // ten file
        string fileSavePath; // url store images
        string fileAddress; // url load images
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
        private void ResetValue()
        {
            txtTimKiem.Text = "Nhập tên sản phẩm";
            txtMaSanPham.Text = null;
            txtTenSanPham.Text = null;
            txtGiaSanPham.Text = null;
            txtMoTa.Text = null;
            txtSize.Text = null;
            txtHinhAnh.Text = null;
            dtNgayNhap.Enabled = false;
            txtSoLuong.Text = null;

            txtMaSanPham.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtGiaSanPham.Enabled = false;
            txtMoTa.Enabled = false;
            txtSize.Enabled = false;
            txtHinhAnh.Enabled = false;
            txtSoLuong.Enabled = false;

            btDong.Enabled = true;
            btLuu.Enabled = false;
            btSua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = false;
            btChonHinh.Enabled = false;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Text = null;
            txtTenSanPham.Text = null;
            txtGiaSanPham.Text = null;
            txtMoTa.Text = null;
            txtSize.Text = null;
            txtHinhAnh.Text = null;
            dtNgayNhap.Enabled = true;
            txtSoLuong.Text = null;

            txtTenSanPham.Enabled = true;
            txtGiaSanPham.Enabled = true;
            txtMoTa.Enabled = true;
            txtSize.Enabled = true;
            txtSoLuong.Enabled = true;
            picHinhSP.Image = null;

            btDong.Enabled = true;       
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btThem.Enabled = false;
            btXoa.Enabled = false;
            btChonHinh.Enabled = true;

            txtTenSanPham.Focus();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(), out intSoLuong);
            float floatGiaSP;
            bool isFloatGiaSP = float.TryParse(txtGiaSanPham.Text.Trim().ToString(), out floatGiaSP);
            try
            {
                if (txtTenSanPham.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn Phải Nhập Tên Hàng ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenSanPham.Focus();
                    return;
                }
                else if (!isFloatGiaSP || float.Parse(txtGiaSanPham.Text) < 0)
                {
                    MessageBox.Show("Bạn Phải Nhập Giá SP", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGiaSanPham.Focus();
                    return;
                }
                else if (txtSize.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn Phải Nhập Size ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSize.Focus();
                    return;
                }
                else if (txtHinhAnh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btChonHinh.Focus();
                    return;
                }
                else if (dtNgayNhap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn Phải Chọn Ngày ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtNgayNhap.Focus();
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
                    DTO_SanPham sp = new DTO_SanPham(txtTenSanPham.Text, float.Parse(txtGiaSanPham.Text), txtSize.Text, dtNgayNhap.Value,
                                                     int.Parse(txtSoLuong.Text), "\\ImagesSP\\" + fileName, txtMoTa.Text, stremail);
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
            catch (Exception)
            {
     
            }        
        }

        private void btSua_Click(object sender, EventArgs e)
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
            else if (txtHinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btChonHinh.Focus();
                return;
            }
            else if (dtNgayNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn Ngày ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtNgayNhap.Focus();
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
                                           dtNgayNhap.Value, int.Parse(txtSoLuong.Text), "\\ImagesSP\\" + fileName, txtMoTa.Text);

                if (MessageBox.Show("Bạn Có Chắc Muốn Sửa Sản Phẩm", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busSanPham.UpdateSanPham(sp))
                    {
                        if (txtHinhAnh.Text != checkUrlImage)
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

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            if (dgvSanPham.Rows.Count > 1)
            {
                btChonHinh.Enabled = true;
                btLuu.Enabled = false;
                txtTenSanPham.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaSanPham.Enabled = true;
                txtSize.Enabled = true;
                txtMoTa.Enabled = true;
                txtTenSanPham.Focus();
                dtNgayNhap.Enabled = true;

                btSua.Enabled = true;
                btXoa.Enabled = true;

                txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
                txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtGiaSanPham.Text = dgvSanPham.CurrentRow.Cells["GiaSP"].Value.ToString();
                txtSize.Text = dgvSanPham.CurrentRow.Cells["Size"].Value.ToString();
                txtHinhAnh.Text = dgvSanPham.CurrentRow.Cells["HinhAnh"].Value.ToString();
                dtNgayNhap.Text = dgvSanPham.CurrentRow.Cells["NgayNhap"].Value.ToString();
                txtMoTa.Text = dgvSanPham.CurrentRow.Cells["MoTa"].Value.ToString();

                checkUrlImage = txtHinhAnh.Text;
                try
                {
                    picHinhSP.Image = Image.FromFile(saveDirectory + dgvSanPham.CurrentRow.Cells["HinhAnh"].Value.ToString());
                }
                catch (Exception)
                {


                }

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
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

        private void btTimKiem_Click(object sender, EventArgs e)
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

        private void btChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn Ảnh Minh Họa Cho Sản Phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                picHinhSP.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                fileSavePath = saveDirectory + "\\ImagesSP\\" + fileName;
                txtHinhAnh.Text = "\\ImagesSP\\" + fileName;
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadGridView();
            ResetValue();
        }
    }
}
