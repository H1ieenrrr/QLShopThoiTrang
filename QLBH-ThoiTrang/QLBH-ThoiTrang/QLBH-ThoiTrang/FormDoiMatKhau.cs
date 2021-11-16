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
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace QLBH_ThoiTrang
{
    public partial class FormDoiMatKhau : Form
    {
        string stremail;
        BUS_NhanVien busNhanVien = new BUS_QLShopThoiTrang.BUS_NhanVien();

        public FormDoiMatKhau(string email)
        {
            InitializeComponent();
            stremail = email;
            txtEmail.Text = stremail;
            txtEmail.Enabled = false;
        }


        public void sendMail(string email, string matkhau)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("meetclothingstore@gmail.com");
                Msg.To.Add(email);
                Msg.Subject = "Bạn đã sử dụng tính năng Đổi Mật Khẩu";
                Msg.Body = "Chào Anh/Chị. Mật khẩu mới để truy cập phần mềm là: " + matkhau;
                using(SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25))
                {
                    smtp.Credentials = new NetworkCredential("meetclothingstore@gmail.com", "meet2021");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                }
                MessageBox.Show("Một email đổi mật khẩu đã được gửi đến bạn ");
            }
            catch(Exception )
            {
                throw;
            }
        }
        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtMatKhauCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Mật Khẩu Cũ ","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            else if (txtMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Mật Khẩu Mới ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else if (txtNhapLaiMK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Lại Mật Khẩu Mới ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhapLaiMK.Focus();
                return;
            }
            else if (txtNhapLaiMK.Text.Trim() != txtMatKhauMoi.Text.Trim())
            {
                MessageBox.Show("Mật Khẩu Không Trùng Khớp  ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn Có Chắc Muốn Đổi Mật Khẩu ","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    string MatKhauMoi = busNhanVien.encryption(txtMatKhauMoi.Text);
                    string MatKhauCu = busNhanVien.encryption(txtMatKhauCu.Text);
                    if (busNhanVien.DoiMatKhau(txtEmail.Text, MatKhauCu, MatKhauMoi))
                    {
                        FormMain.profile = 1;
                        FormMain.session = 0;
                        sendMail(stremail, txtNhapLaiMK.Text);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công, Bạn Cần Đăng Nhập Lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Cũ Không Đúng, Đổi Mật Khẩu Thất Bại");
                        txtMatKhauCu.Text = null;
                        txtMatKhauMoi.Text = null;
                        txtNhapLaiMK.Text = null;
                    }
                }
                else
                {
                    txtMatKhauCu.Text = null;
                    txtMatKhauMoi.Text = null;
                    txtNhapLaiMK.Text = null;
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
