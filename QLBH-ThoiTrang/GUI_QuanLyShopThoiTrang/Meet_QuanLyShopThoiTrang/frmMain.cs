using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meet_QuanLyShopThoiTrang
{
   
    public partial class frmMain : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public frmMain()
        {
            InitializeComponent();
            random = new Random();
        }
 
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
             index = random.Next(ThemeColor.ColorList.Count); 
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DissableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                           
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }
        private void DissableButton()
        {
            foreach(Control previosBtn in PanelMenu.Controls)
            {
                if (previosBtn.GetType() == typeof(Button))
                {
                    previosBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previosBtn.ForeColor = Color.Gainsboro;
                    previosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, Object btnSender,string ten)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelMain.Controls.Add(childForm);
            this.PanelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTiltle.Text = ten;

        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham(), sender,"SẢN PHẨM");
          
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien(), sender,"NHÂN VIÊN");
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang(), sender,"KHÁCH HÀNG");
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBanHang(), sender,"BÁN HÀNG");
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe(), sender,"HOÁ ĐƠN");
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThayDoiMatKhau(frmDangNhap.mail), sender,"ĐỔI MẬT KHẨU");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void ResetValue()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            if (int.Parse(frmDangNhap.vaitro) == 0)
            {
                btnSanPham.Visible = false;
                btnHoaDon.Visible = false;
                btnNhanVien.Visible = false;
            }
            else
            {
                btnSanPham.Visible = true;
                btnHoaDon.Visible = true;
                btnNhanVien.Visible = true;
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangNhap frmDN = new frmDangNhap();
            frmDN.Show();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Đăng Xuất Không ", "Thông Báo", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                this.Close();
            }

        }

        
    } 
}
