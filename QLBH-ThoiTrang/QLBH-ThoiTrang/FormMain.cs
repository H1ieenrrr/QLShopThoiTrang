using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_ThoiTrang
{
    public partial class FormMain : Form
    {
        public static int session = 0;
        public static int profile = 0;
        public static string mail;
        FormDangNhap dn = new FormDangNhap();
        FormQuanLyHoaDon qlhd = new FormQuanLyHoaDon();
        FormQuanLyNhanVien qlnv = new FormQuanLyNhanVien();
        FormTaoHoaDon thd = new FormTaoHoaDon();
        FormDoiMatKhau doimatkhau;
        FormThongKe thongke = new FormThongKe();
        public FormMain()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panelHeThong.Visible = false;
            panelNhanVien.Visible = false;
            panelQuanLy.Visible = false;
            panelThongKê.Visible = false;           
        }
        //hide submenu
        private void hidesubMenu()
        {                  
            if (panelHeThong.Visible == true)
                panelHeThong.Visible = false;
            if (panelNhanVien.Visible == true)
                panelNhanVien.Visible = false;
            if (panelQuanLy.Visible == true)
                panelQuanLy.Visible = false;
            if (panelThongKê.Visible == true)
                panelThongKê.Visible = false;
        }
        private void ResetValue()
        {
          //  openChildForm(new FormTrangChu());
            if (session == 1)
            {
                btnDangNhap.Enabled = false;
                btnDangXuat.Enabled = true;
                btnHeThong.Visible = true;               
                btnNhanVien.Visible = true;
                btnHeThong.Visible = true;              
                if (int.Parse(dn.vaitro) == 0)
                {
                    btnThongKe.Visible = false;
                    btnQuanLy.Visible = false;
                }
                else
                {
                    btnThongKe.Visible = true;
                    btnQuanLy.Visible = true;
                }
            }
            else
            {
                btnDangNhap.Enabled = true;
                btnHeThong.Visible = false;
                btnNhanVien.Visible = false;
                btnHeThong.Visible = false;
                btnThongKe.Visible = false;
                btnQuanLy.Visible = false;
                btnDangXuat.Enabled = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidesubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #region showsubmenu
        private void btnHeThong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHeThong);
        }
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQuanLy);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhanVien);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongKê);
        }
        #endregion
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)            
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.BringToFront();
            childForm.Show();
        }
        #region MoFileTungButton
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            openChildForm(dn = new FormDangNhap());
            dn.FormClosed += new FormClosedEventHandler(FormDangNhap_Closed);
            hidesubMenu();
        }
        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new FormQuanLyHoaDon());
            hidesubMenu();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTrangChu());
            hidesubMenu();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            openChildForm(doimatkhau = new FormDoiMatKhau(FormMain.mail));
            hidesubMenu();

            doimatkhau.FormClosed += new FormClosedEventHandler(FormDoiMatKhau_Closed);
        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new FormQuanLySanPham());
            hidesubMenu();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FormQuanLyNhanVien());
            hidesubMenu();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new FormQuanLyKhachHang());
            hidesubMenu();
        }
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTaoHoaDon());
            hidesubMenu();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            openChildForm(new FormThongKe());
            hidesubMenu();
        }

        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {;
            ResetValue();
            if(profile == 1)
            {
                profile = 0;
            }
        }

        private void FormDangNhap_Closed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            ResetValue();            
        }

        private void FormDoiMatKhau_Closed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            ResetValue();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn Có Muốn Đăng Xuất Không ","Thông Báo",MessageBoxButtons.YesNo)!= DialogResult.No)
            {
                session = 0;
                this.Refresh();
                ResetValue();
                openChildForm(new FormTrangChu());
            }
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
