using DAL_QLShopThoiTrang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLShopThoiTrang
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_hoadon = new DAL_HoaDon();
        public DataTable HienThiDanhSachSP()
        {
            return dal_hoadon.HienThiDanhSachSP();
        }
    }
}
