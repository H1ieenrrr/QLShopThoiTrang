using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmInHoaDon : Form
    {
        public string date, tenKH, thuNgan, tongHD, thue, tongThanhToan;
        public DataTable dt = new DataTable();
                
        private void pbThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmInHoaDon()
        {
            InitializeComponent();
            date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagarea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagarea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
            Print(this.panelPrint);
        }


        private void pbPrint_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pbPrint, "Print");
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            dgvSP.DataSource = dt;
            lblNgay.Text = date;
            lblTenKH.Text = tenKH;
            lblThuNgan.Text = thuNgan;
            lblTongHD.Text = tongHD;
            lblThue.Text = thue;
            lblTongThanhToan.Text = tongThanhToan;
            dgvSP.Enabled = false;
        }
        public void Print(Panel pn1)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = pn1;
            getprintarea(pn1);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        private Bitmap memoryimg;
        
        private void getprintarea(Panel pn1)
        {
            memoryimg = new Bitmap(pn1.Width, pn1.Height);
            pn1.DrawToBitmap(memoryimg, new Rectangle(0, 0, pn1.Width, pn1.Height));
        }
    }
}
