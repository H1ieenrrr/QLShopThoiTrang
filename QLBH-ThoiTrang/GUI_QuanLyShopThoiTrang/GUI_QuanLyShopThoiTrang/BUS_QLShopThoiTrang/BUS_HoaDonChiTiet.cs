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
    public class BUS_HoaDonChiTiet
    {

        DAL_HoaDonChiTiet dal_hdct = new DAL_HoaDonChiTiet();
        public bool ThemHoaDonCT(DTO_HoaDonChiTiet hdct)
        {
            return dal_hdct.ThemHoaDonCT(hdct);
        }
        public DataTable DanhSachHoaDonCT(int mahd)
        {
            return dal_hdct.DanhSachHoaDonCT(mahd);
        }
    }
}
