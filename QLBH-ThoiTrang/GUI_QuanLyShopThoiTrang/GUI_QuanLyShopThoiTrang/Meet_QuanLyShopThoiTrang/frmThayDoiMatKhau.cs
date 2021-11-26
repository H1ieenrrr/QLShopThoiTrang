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

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmThayDoiMatKhau : Form
    {
        public frmThayDoiMatKhau(string email)
        {
            InitializeComponent();
            stremail = email;
            txtEmail.Text = stremail;
            txtEmail.Enabled = false;
        }
        string stremail;
        BUS_NhanVien busNhanVien = new BUS_QLShopThoiTrang.BUS_NhanVien();
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Mật Khẩu Cũ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            else if (txtMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Mật Khẩu Mới ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else if (txtMatKhauMoi2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Nhập Lại Mật Khẩu Mới ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi2.Focus();
                return;
            }
            else if (txtMatKhauMoi2.Text.Trim() != txtMatKhauMoi.Text.Trim())
            {
                MessageBox.Show("Mật Khẩu Không Trùng Khớp  ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn Có Chắc Muốn Đổi Mật Khẩu ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string MatKhauMoi = busNhanVien.encryption(txtMatKhauMoi.Text);
                    string MatKhauCu = busNhanVien.encryption(txtMatKhauCu.Text);
                    if (busNhanVien.DoiMatKhau(txtEmail.Text, MatKhauCu, MatKhauMoi))
                    {
                        frmDangNhap.profile = 1;
                        frmDangNhap.session = 0;
                        sendMail(stremail, txtMatKhauMoi2.Text);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công, Bạn Cần Đăng Nhập Lại");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Cũ Không Đúng, Đổi Mật Khẩu Thất Bại");
                        txtMatKhauCu.Text = null;
                        txtMatKhauMoi.Text = null;
                        txtMatKhauMoi2.Text = null;
                    }
                }
                else
                {
                    txtMatKhauCu.Text = null;
                    txtMatKhauMoi.Text = null;
                    txtMatKhauMoi2.Text = null;
                }
            }
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
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25))
                {
                    smtp.Credentials = new NetworkCredential("meetclothingstore@gmail.com", "meet2021");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                }
                MessageBox.Show("Một email đổi mật khẩu đã được gửi đến bạn ");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
