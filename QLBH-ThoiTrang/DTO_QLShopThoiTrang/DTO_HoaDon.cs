using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLShopThoiTrang
{
    public class DTO_HoaDon
    {

        private int maHD;
        private int soLuong;
        private string tenNV;
        private string tenKH;
        private string tenSP;
        private DateTime ngayLapHD;
        private float tongtien;
        private string emailNV;

        public int MaHD
        {
            get
            {
                return maHD;
            }
            set
            {
                maHD = value;
            }
        }
        public int SoLuong
        {
            get
            {
                return soLuong;
            }
            set
            {
                soLuong = value;
            }
        }
        public string TenNV
        {
            get
            {
                return tenNV;
            }
            set
            {
                tenNV = value;
            }
        }
        public string TenKH
        {
            get
            {
                return tenKH;
            }
            set
            {
                tenKH = value;
            }
        }
        public string TenSP
        {
            get
            {
                return tenSP;
            }
            set
            {
                tenSP = value;
            }
        }
        public DateTime NgayLapHD
        {
            get
            {
                return ngayLapHD;
            }
            set
            {
                ngayLapHD = value;
            }
        }
        public float TongTien
        {
            get
            {
                return tongtien;
            }
            set
            {
                tongtien = value;
            }
        }
        public string EmailNV
        {
            get
            {
                return emailNV;
            }
            set
            {
                emailNV = value;
            }
        }
        public DTO_HoaDon(int maHD, int soLuong, string tenNV, string tenKH,
          string tenSP, DateTime ngayLapHD, float tongTien)
        {
            this.maHD = maHD;
            this.soLuong = soLuong;
            this.tenNV = tenNV;
            this.tenKH = tenKH;
            this.tenSP = tenSP;
            this.ngayLapHD = ngayLapHD;
            this.tongtien = tongTien;
        }
        public DTO_HoaDon(int soLuong, string tenNV, string tenKH,
            string tenSP, DateTime ngayLapHD, float tongTien, string emailNV)
        {
            this.soLuong = soLuong;
            this.tenNV = tenNV;
            this.tenKH = tenKH;
            this.tenSP = tenSP;
            this.ngayLapHD = ngayLapHD;
            this.tongtien = tongTien;
            this.emailNV = emailNV;
        }
        public DTO_HoaDon()
        {

        }
    }
}
