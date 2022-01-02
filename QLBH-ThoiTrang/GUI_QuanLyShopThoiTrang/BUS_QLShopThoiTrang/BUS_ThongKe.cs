using DAL_QLShopThoiTrang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLShopThoiTrang;

namespace BUS_QLShopThoiTrang
{
    public class BUS_ThongKe
    {
        DAL_ThongKe dal_thongke = new DAL_ThongKe();
        public DataTable DanhSachHoaDon()
        {
            return dal_thongke.DanhSachHoaDon();
        }
        public DataTable TimHoaDon(DateTime ngaybatdau, DateTime ngayketthuc, string tennv)
        {
            return dal_thongke.TimHoaDon(ngaybatdau, ngayketthuc , tennv);
        }
        public DataTable TimHDTheoTenNV(string tennv)
        {
            return dal_thongke.TimHDTheoTenNV(tennv);
        }
        public DataTable ThongKeTongHop(DateTime tungay, DateTime denngay)
        {
            return dal_thongke.ThongKeTongHop(tungay,denngay);
        }

        public DataTable ThongKeKhachHang()
        {
            return dal_thongke.ThongKeKhachHang();
        }
        public DataTable ThongKeKhachHangTheoThang()
        {
            return dal_thongke.ThongKeKhachHangTheoThang();
        }
        public DataTable ThongKeKhachHangTheoNam()
        {
            return dal_thongke.ThongKeKhachHangTheoNam();
        }
        public bool XoaHD(string mahd)
        {
            return dal_thongke.XoaHD(mahd);
        }

    }
}
