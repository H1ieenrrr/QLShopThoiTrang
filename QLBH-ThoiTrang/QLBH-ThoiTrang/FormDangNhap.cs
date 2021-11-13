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
namespace QLBH_ThoiTrang
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        public string vaitro { get; set; }
        public string matkhau { get; set; }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.EmailNV = txtEmail.Text;
            
            nv.MatKhau = busNhanVien.encryption(txtMatKhau.Text);
            if (busNhanVien.NhanVienDangNhap(nv))
            {
                FormMain.mail = nv.EmailNV;
                DataTable dt = busNhanVien.VaiTroNhanVien(nv.EmailNV);
                vaitro = dt.Rows[0][0].ToString();
                //MessageBox.Show("Đăng nhập thành công");
                FormMain.session = 1;
                this.Close();
            }
            else if(txtEmail.Text == "" || txtMatKhau.Text == "")
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
      

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();          
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
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
                    builder.Append(RandomNumber(999,1000));
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
            catch (Exception )
            {

                throw;
            }
        }

        private void chkghinhotk_CheckedChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtMatKhau.Text != "")
            {
                if (chkghinhotk.Checked == true)
                {
                    string user = txtEmail.Text;
                    string password = txtMatKhau.Text;
                    Properties.Settings.Default.User = user;
                    Properties.Settings.Default.PassWord = password;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtEmail.Text = Properties.Settings.Default.User;
            //txtMatKhau.Text = Properties.Settings.Default.PassWord;
            if (Properties.Settings.Default.User !="")
            {
                chkghinhotk.Checked = true;
            }
        }
    }
}
