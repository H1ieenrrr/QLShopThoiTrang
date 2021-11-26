using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QLShopThoiTrang
{
    public class DTO_HoaDonChiTiet
    {
        private int maHD;
        private int maSP;
        private int soLuong;
        private decimal donGia;
        private DateTime ngayLap;

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
        public int MaSP
        {
            get
            {
                return maSP;
            }
            set
            {
                maSP = value;
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
        public DateTime NgayLap
        {
            get
            {
                return ngayLap;
            }
            set
            {
                ngayLap = value;
            }
        }
        public decimal DonGia
        {
            get
            {
                return donGia;
            }
            set
            {
                donGia = value;
            }
        }
        public DTO_HoaDonChiTiet(int MaSP, decimal DonGia, int SoLuong, DateTime NgayLap)
        {
            this.maSP = MaSP;
            this.donGia = DonGia;
            this.soLuong = SoLuong;
            this.ngayLap = NgayLap;
        }
    }
}
