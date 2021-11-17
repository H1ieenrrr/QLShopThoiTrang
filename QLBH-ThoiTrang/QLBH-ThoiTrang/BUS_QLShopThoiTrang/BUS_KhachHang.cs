using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLShopThoiTrang;
using DTO_QLShopThoiTrang;

namespace BUS_QLShopThoiTrang
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_khachhang = new DAL_KhachHang();
        public DataTable ListKH()
        {
            return dal_khachhang.ListKH();
        }
        public bool ThemKH(DTO_KhachHang kh)
        {
            return dal_khachhang.ThemKH(kh);
        }
        public bool SuaKH(DTO_KhachHang kh)
        {
            return dal_khachhang.SuaKH(kh);
        }
        public bool XoaKH(string dienthoai)
        {
            return dal_khachhang.XoaKH(dienthoai);
        }

        public DataTable TimKiemKhachHang(string DienThoai)
        {
            return dal_khachhang.TimKiemKhachHang(DienThoai);
        }
        public bool KiemTraSDT(string dienthoai)
        {
            return dal_khachhang.KiemTraSDT(dienthoai);
        }
    }
}
