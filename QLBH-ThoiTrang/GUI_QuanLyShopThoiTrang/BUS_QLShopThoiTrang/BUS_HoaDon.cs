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
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_hoadon = new DAL_HoaDon();
        public DataTable HienThiDanhSachSP()
        {
            return dal_hoadon.HienThiDanhSachSP();
        }
        public DataTable HienThiTenNV(string email)
        {
            return dal_hoadon.HienThiTenNV(email);
        }
        public DataTable HienThiThongTinKH(string dienthoai)
        {
            return dal_hoadon.HienThiThongTinKH(dienthoai);
        }
        public DataTable HienThiTenSP()
        {
            return dal_hoadon.HienThiTenSP();
        }
        public DataTable HienThiGiaSP(string tensp)
        {
            return dal_hoadon.HienThiGiaSP(tensp);
        }
        public bool ThemHoaDon(DTO_HoaDon hd)
        {
            return dal_hoadon.ThemHoaDon(hd);
        }
        public bool KiemTraHang(string TenSP, float SoLuong, float SoLuongDat)
        {
            return dal_hoadon.KiemTraHang(TenSP, SoLuong, SoLuongDat);
        }
      

    }
}
