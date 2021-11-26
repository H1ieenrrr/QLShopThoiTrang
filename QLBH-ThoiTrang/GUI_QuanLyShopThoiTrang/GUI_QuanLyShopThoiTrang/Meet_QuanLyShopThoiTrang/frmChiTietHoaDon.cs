using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLShopThoiTrang;
using BUS_QLShopThoiTrang;

namespace Meet_QuanLyShopThoiTrang
{
    public partial class frmChiTietHoaDon : Form
    {
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        BUS_HoaDonChiTiet bus_hoadonchitiet = new BUS_HoaDonChiTiet();
        private void DSHoaDonChiTiet()
        {
            dgvHoaDonCT.DataSource = bus_hoadonchitiet.DanhSachHoaDonCT(int.Parse(lbCTHD.Text));
            dgvHoaDonCT.Columns[0].HeaderText = "Mã Hoá Đơn";
            dgvHoaDonCT.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvHoaDonCT.Columns[2].HeaderText = "Số Lượng";
            dgvHoaDonCT.Columns[3].HeaderText = "Đơn Giá";
            dgvHoaDonCT.Columns[4].HeaderText = "Tổng Tiền";

        }

        private void frmChiTietHoaDon_Load(object sender, System.EventArgs e)
        {
            DSHoaDonChiTiet();
        }
    }
}
