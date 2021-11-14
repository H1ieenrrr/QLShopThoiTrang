using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLShopThoiTrang;
using DTO_QLShopThoiTrang;

namespace QLBH_ThoiTrang
{
    public partial class FormQuanLyNhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_QLShopThoiTrang.BUS_NhanVien();
        string checkUrlImage; // kiểm tra hình khi cập nhật
        string fileName; // ten file
        string fileSavePath; // url store images
        string fileAddress; // url load images
        public FormQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void FormQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadGridView();
            ResetValue();
        }

        private void LoadGridView()
        {
            dgvNhanVien.DataSource = busNhanVien.DanhSachNV();
            dgvNhanVien.Columns[0].HeaderText = "Email";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên   ";
            dgvNhanVien.Columns[2].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns[3].HeaderText = "Điện Thoại ";
            dgvNhanVien.Columns[4].HeaderText = "Hình Ảnh";
            dgvNhanVien.Columns[5].HeaderText = "Vai Trò";

        }
        private void ResetValue()
        {
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtTenNhanVien.Text = null;
            txtHinh.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtHinh.Enabled = false;
            rbNhanVien.Enabled = false;
            rbChuCuaHang.Enabled = false;
            txtDienThoai.Enabled = false;

            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnDong.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = false;
            btnMoHinh.Enabled = false;
           
        }

        private void btnMoHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn Ảnh Minh Họa Cho Sản Phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbHinhNV.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                fileSavePath = saveDirectory + "\\ImagesNV\\" + fileName;
                txtHinh.Text = "\\ImagesNV\\" + fileName;
            }
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            if (dgvNhanVien.Rows.Count > 1)
            {
                btnMoHinh.Enabled = true;
                btnLuu.Enabled = false;
                txtEmail.Enabled = true;
                txtTenNhanVien.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtTimKiem.Enabled = true;
                rbChuCuaHang.Enabled = true;
                rbNhanVien.Enabled = true;
                txtEmail.Focus();

                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells["DienThoai"].Value.ToString();
                txtHinh.Text = dgvNhanVien.CurrentRow.Cells["HinhAnh"].Value.ToString();
                if (int.Parse(dgvNhanVien.CurrentRow.Cells["VaiTro"].Value.ToString()) == 1)
                    rbChuCuaHang.Checked = true;
                else
                    rbNhanVien.Checked = true;

                checkUrlImage = txtHinh.Text;
                pbHinhNV.Image = Image.FromFile(saveDirectory + dgvNhanVien.CurrentRow.Cells["HinhAnh"].Value.ToString());

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtTenNhanVien.Text = null;
            txtHinh.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtHinh.Enabled = false;
            txtDienThoai.Enabled = true;
            rbNhanVien.Enabled = true;
            rbChuCuaHang.Enabled = true;
            rbNhanVien.Checked = true;
            rbChuCuaHang.Checked = false;

            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnDong.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = false;
            btnMoHinh.Enabled = true;
            pbHinhNV.Image = null;

            txtEmail.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string email;
            int role = 0;
            if (rbChuCuaHang.Checked)
                role = 1;
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Email ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!IsValid(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn Phải Nhập Đúng Định Dạng Email ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Tên ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            else if (txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Số Điện Thoại ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMoHinh.Focus();
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Địa Chỉ ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            else if (rbChuCuaHang.Checked == false && rbNhanVien.Checked == false)     // kiem tra phai check tinh trang
            {
                MessageBox.Show("Bạn Phải Chọn Vai Trò Nhân Viên ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNhanVien.Text, txtDiaChi.Text, txtDienThoai.Text, "\\ImagesSP\\" + fileName, role);
                if (busNhanVien.InsertNhanVien(nv))
                {
                    MessageBox.Show("Thêm Nhân Viên Thành Công");
                    File.Copy(fileAddress, fileSavePath, true);
                    ResetValue();
                    LoadGridView();
                    email = txtEmail.Text;
                    SendMail(nv.EmailNV);
                }
                else
                {
                    MessageBox.Show("Thêm Nhân Viên Thất Bại");
                }
            }

        }
        public void SendMail(string Email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);

                NetworkCredential cred = new NetworkCredential("meetclothingstore@gmail.com", "meet2021");

                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress("meetclothingstore@gmail.com");

                Msg.To.Add(Email);

                Msg.Subject = "Chào Mừng Thành Viên Mới";

                Msg.Body = "Chào anh/chị . Mật khẩu truy cập phần mềm là abc123 , anh/chị vui lòng đăng nhập vào phần mềm và đổi mật khẩu  ";

                client.Credentials = cred;

                client.EnableSsl = true;
                client.Send(Msg);

                MessageBox.Show("Your Mail is Sended");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValid(string EmailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(EmailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int role = 0;
            if (rbChuCuaHang.Checked)
                role = 1;
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Email ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!IsValid(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn Phải Nhập Đúng Định Dạng Email ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Tên ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            else if (txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Số Điện Thoại ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMoHinh.Focus();
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Địa Chỉ ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNhanVien.Text, txtDiaChi.Text, txtDienThoai.Text, "\\ImagesSP\\" + fileName, role);
                if (MessageBox.Show("Bạn Có Chắc Muốn Chỉnh Sửa ", "ConFirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNhanVien.UpdateNV(nv))
                    {
                        if (txtHinh.Text != checkUrlImage)
                            File.Copy(fileAddress, fileSavePath, true);
                        MessageBox.Show("Sửa Nhân Viên Thành Công");
                        ResetValue();
                        LoadGridView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Nhân Viên Không Thành Công");
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
            string Email = txtEmail.Text;
            if (MessageBox.Show("Bạn Có Chắc Muốn Xóa Dữ Liệu ", "ConFirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busNhanVien.DeleteNV(Email))
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
            string TenNV = txtTimKiem.Text;
            DataTable dsNV = busNhanVien.SearchNV(TenNV);
            if (dsNV.Rows.Count > 0)
            {
                dgvNhanVien.DataSource = dsNV;
                dgvNhanVien.Columns[0].HeaderText = "Email";
                dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên   ";
                dgvNhanVien.Columns[2].HeaderText = "Địa Chỉ";
                dgvNhanVien.Columns[3].HeaderText = "Điện Thoại ";
                dgvNhanVien.Columns[4].HeaderText = "Hình Ảnh";
                dgvNhanVien.Columns[5].HeaderText = "Vai Trò";
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            txtTimKiem.BackColor = Color.LightGray;
            ResetValue();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }
    }
}
