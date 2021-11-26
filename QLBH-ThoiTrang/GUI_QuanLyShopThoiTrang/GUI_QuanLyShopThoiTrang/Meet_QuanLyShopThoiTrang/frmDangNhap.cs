using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using DTO_QLShopThoiTrang;
using BUS_QLShopThoiTrang;

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static string vaitro { get; set; }
        public string matkhau { get; set; }
        public static int session = 0;
        public static int profile = 0;
        public static string mail;
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.EmailNV = txtEmail.Text;

            nv.MatKhau = busNhanVien.encryption(txtMatKhau.Text);
            if (busNhanVien.NhanVienDangNhap(nv))
            {
                mail = nv.EmailNV;
                DataTable dt = busNhanVien.VaiTroNhanVien(nv.EmailNV);
                vaitro = dt.Rows[0][0].ToString();
                session = 1;
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else if (txtEmail.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập emai hoặc mật khẩu!");
            }
            else
            {
                MessageBox.Show("Sai Email hoặc mật khẩu !!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
        }


        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";

        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email");
            }
            else
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RanDomString(4, true));
                    builder.Append(RandomNumber(999, 1000));
                    builder.Append(RanDomString(2, false));

                    string matkhaumoi = busNhanVien.encryption(builder.ToString());
                    busNhanVien.TaoMatKhauMoi(txtEmail.Text, matkhaumoi);
                    sendMail(txtEmail.Text, builder.ToString());
                }
            }
        }
        public string RanDomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random rd = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void sendMail(string email, string matkhau)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                //sender email address
                Msg.From = new MailAddress("meetclothingstore@gmail.com");
                //Recipient e-mail address
                Msg.To.Add(email);
                //Assign the subject  of out message
                Msg.Subject = "Bạn đã sử dụng tính năng quên mật khẩu";
                Msg.Body = "Chào anh/chị. Mật khẩu mới để truy cập phần mềm là: " + matkhau;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25))
                {
                    smtp.Credentials = new NetworkCredential("meetclothingstore@gmail.com", "meet2021");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                }
                MessageBox.Show("Một email phục hồi mật khẩu đã được gửi tới bạn");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
