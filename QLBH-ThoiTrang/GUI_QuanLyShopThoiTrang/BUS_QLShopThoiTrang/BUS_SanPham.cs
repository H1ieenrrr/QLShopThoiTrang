using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLShopThoiTrang;
using DAL_QLShopThoiTrang;
using System.Data;

namespace BUS_QLShopThoiTrang
{
    public class BUS_SanPham
    {
        DAL_SanPham dalSanPham = new DAL_SanPham();
        public DataTable getHang()
        {
            return dalSanPham.getHang();
        }
        public bool InsertSanPham(DTO_SanPham sp)
        {
            return dalSanPham.InsertSanPham(sp);
        }

        public bool UpdateSanPham(DTO_SanPham sp)
        {
            return dalSanPham.UpdateSanPham(sp);
        }

        public bool DeleteSanPham(string MaSP)
        {
            return dalSanPham.DeleteSanPham(MaSP);
        }
        public DataTable SearchSanPham(string TenSP)
        {
            return dalSanPham.SearchSanPham(TenSP);
        }

    }
}
