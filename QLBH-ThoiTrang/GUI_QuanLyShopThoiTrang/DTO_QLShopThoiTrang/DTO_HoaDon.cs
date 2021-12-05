using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QLShopThoiTrang
{
    public class DTO_HoaDon
    {
        private DateTime ngayLapHD;
        private decimal tongTien;
        private int thue;
        private decimal tongThanhToan;
        private string dienThoaiKH;
        private string emailNV;
        public decimal TongThanhToan
        {
            get
            {
                return tongThanhToan;
            }
            set
            {
                tongThanhToan = value;
            }
        }
        public int Thue
        {
            get
            {
                return thue;
            }
            set
            {
                thue = value;
            }
        }
        public string DienThoaiKH
        {
            get
            {
                return dienThoaiKH;
            }
            set
            {
                dienThoaiKH = value;
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
        public decimal TongTien
        {
            get
            {
                return tongTien;
            }
            set
            {
                tongTien = value;
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
        public DTO_HoaDon(DateTime ngayLapHD, int thue, decimal tongTien, decimal tongThanhToan, string dienThoaiKH, string emailNV)
        {
            this.ngayLapHD = ngayLapHD;
            this.thue = thue;
            this.tongTien = tongTien;
            this.tongThanhToan = tongThanhToan;
            this.dienThoaiKH = dienThoaiKH;
            this.emailNV = emailNV;
        }
        public DTO_HoaDon()
        {

        }
    }
}
