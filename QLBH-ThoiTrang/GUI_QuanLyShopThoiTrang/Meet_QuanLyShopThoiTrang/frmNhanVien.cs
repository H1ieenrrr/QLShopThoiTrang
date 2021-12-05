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

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmNhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_QLShopThoiTrang.BUS_NhanVien();
        string checkUrlImage; // kiểm tra hình khi cập nhật
        string fileName; // ten file
        string fileSavePath; // url store images
        string fileAddress; // url load images
        string checkemail = frmDangNhap.mail;
        string saveDirectory = Application.StartupPath + "\\ImagesNV\\";


        public frmNhanVien()
        {
            InitializeComponent();
           
        }
        

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDSNhanVien();
            ResetValue();
        }

        private void ResetValue()
        {
            txtTimKiem.Text = "Nhập tên nhân viên";
            picHinhNV.Image = default;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtTimKiem.Text = null;
            txtHinhAnh.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtTimKiem.Enabled = false;
            txtHinhAnh.Enabled = false;
            rdNhanVien.Enabled = false;
            rdQuanLy.Enabled = false;
            txtDienThoai.Enabled = false;
            txtTenNV.Enabled = false;

            btThem.Enabled = true;
            btLuu.Enabled = false;
            btSua.Enabled = false;
            btDong.Enabled = true;
            btTimKiem.Enabled = true;
            btXoa.Enabled = false;
            btChonHinh.Enabled = false;
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
        private void LoadDSNhanVien()
        {
                dgvNhanVien.DataSource = busNhanVien.DanhSachNV();
                dgvNhanVien.Columns[0].HeaderText = "Email";
                dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên   ";
                dgvNhanVien.Columns[2].HeaderText = "Địa Chỉ";
                dgvNhanVien.Columns[3].HeaderText = "Điện Thoại ";
                dgvNhanVien.Columns[4].HeaderText = "Hình Ảnh";
                dgvNhanVien.Columns[5].HeaderText = "Vai Trò";
           
           
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtTimKiem.Text = null;
            txtHinhAnh.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtTimKiem.Enabled = true;
            txtHinhAnh.Enabled = false;
            txtDienThoai.Enabled = true;
            rdNhanVien.Enabled = true;
            rdQuanLy.Enabled = true;
            rdNhanVien.Checked = true;
            txtTenNV.Enabled = true;
            rdQuanLy.Checked = false;

            btThem.Enabled = false;
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btDong.Enabled = true;
            btTimKiem.Enabled = true;
            btXoa.Enabled = false;
            btChonHinh.Enabled = true;
            picHinhNV.Image = null;

            txtEmail.Focus();
        }

      
        private void btChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn Ảnh Minh Họa Cho Sản Phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                picHinhNV.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                
                fileSavePath = saveDirectory +  fileName;
                txtHinhAnh.Text =  fileName;
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int IntDienThoai;
                bool isIntDieNThoai = int.TryParse(txtDienThoai.Text.Trim().ToString(), out IntDienThoai);
                string email;
                int role = 0;
                if (rdQuanLy.Checked)
                    role = 1;
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
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
                if (string.IsNullOrEmpty(txtTenNV.Text.Trim()))
                {
                    MessageBox.Show("Bạn Phải Nhập Tên ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNV.Focus();
                    return;
                }
                else if (!isIntDieNThoai || string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
                {
                    MessageBox.Show("Bạn Phải Nhập Số Điện Thoại ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDienThoai.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtHinhAnh.Text.Trim()))
                {
                    MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btChonHinh.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
                {
                    MessageBox.Show("Bạn Phải Nhập Địa Chỉ ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiaChi.Focus();
                    return;
                }
                else if (rdQuanLy.Checked == false && rdNhanVien.Checked == false)     // kiem tra phai check tinh trang
                {
                    MessageBox.Show("Bạn Phải Chọn Vai Trò Nhân Viên ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNV.Focus();
                    return;
                }
                else if (busNhanVien.KiemTraKhoaChinh(txtEmail.Text))
                {
                    MessageBox.Show("Email đã tồn tại!");
                }
                else
                {
                    DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, txtDienThoai.Text,  fileName, role);
                    if (busNhanVien.InsertNhanVien(nv))
                    {
                        MessageBox.Show("Thêm Nhân Viên Thành Công");
                        if (txtHinhAnh.Text != checkUrlImage)
                            File.Copy(fileAddress, fileSavePath, true);
                        ResetValue();
                        LoadDSNhanVien();
                        email = txtEmail.Text;
                        SendMail(nv.EmailNV);
                    }
                    else
                    {
                        MessageBox.Show("Thêm Nhân Viên Thất Bại");
                    }
                }
            }
            catch (Exception)
            {              
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int role = 0;
            if (rdQuanLy.Checked)
                role = 1;
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
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
            if (string.IsNullOrEmpty(txtTenNV.Text.Trim()))
            {
                MessageBox.Show("Bạn Phải Nhập Tên ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Bạn Phải Nhập Số Điện Thoại ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtHinhAnh.Text.Trim()))
            {
                MessageBox.Show("Bạn Phải UpLoad Hình ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btChonHinh.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Bạn Phải Nhập Địa Chỉ ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, txtDienThoai.Text, txtHinhAnh.Text, role);
                if (MessageBox.Show("Bạn Có Chắc Muốn Chỉnh Sửa ", "ConFirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNhanVien.UpdateNV(nv))
                    {
                        MessageBox.Show("Sửa Nhân Viên Thành Công");
                        if (!string.IsNullOrEmpty(fileAddress) && txtHinhAnh.Text != checkUrlImage)
                        {
                            File.Copy(fileAddress, fileSavePath, true);
                        }
                        ResetValue();
                        LoadDSNhanVien();
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

        private void btXoa_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            if (MessageBox.Show("Bạn Có Chắc Muốn Xóa Dữ Liệu ", "ConFirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Email == frmDangNhap.mail || busNhanVien.NV_KiemTraAdmin())
                {
                    MessageBox.Show("Không thể xoá tài khoản này");
                }
                else if (busNhanVien.DeleteNV(Email))
                {
                    MessageBox.Show("Xóa Dữ Liệu Thành Công");
                    ResetValue();
                    LoadDSNhanVien();
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
            ResetValue();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 1)
            {
                try
                {
                    txtEmail.Enabled = false;
                    btChonHinh.Enabled = true;
                    btLuu.Enabled = false;
                    txtTenNV.Enabled = true;
                    txtDiaChi.Enabled = true;
                    txtDienThoai.Enabled = true;
                    txtTimKiem.Enabled = true;
                    rdQuanLy.Enabled = true;
                    rdNhanVien.Enabled = true;
                    txtEmail.Focus();
                    btSua.Enabled = true;
                    btXoa.Enabled = true;

                    txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value?.ToString();
                    txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value?.ToString();
                    txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value?.ToString();
                    txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells["DienThoai"].Value?.ToString();
                    string hinh = txtHinhAnh.Text = dgvNhanVien.CurrentRow.Cells["HinhAnh"].Value?.ToString();
                    if (int.Parse(dgvNhanVien.CurrentRow.Cells["VaiTro"].Value?.ToString()) == 1)
                        rdQuanLy.Checked = true;
                    else
                        rdNhanVien.Checked = true;

                    checkUrlImage = txtHinhAnh.Text;


                    picHinhNV.Image = Image.FromFile(saveDirectory + hinh);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Không tìm thấy hình của nhân viên, vui lòng cập nhật lại!");
                    //}
                    //checkUrlImage = txtHinh.Text;
                    //pbHinhNV.Image = Image.FromFile(saveDirectory + dgvNhanVien.CurrentRow.Cells["HinhAnh"].Value.ToString());

                }
            }
        }
    }
}
