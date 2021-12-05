using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QLShopThoiTrang
{
    public class DTO_SanPham
    {       
            private int MaSP;
            private string TenSP;
            private float GiaSP;
            private DateTime NgayNhap;
            private string Size;
            private int SoLuong;
            private string HinhAnh;
            private string MoTa;
            private string MaNV;
            private string Email;

            public int maSP
            {
                get
                {
                    return MaSP;
                }
                set
                {
                    MaSP = value;
                }
            }

            public string tenSP
            {
                get
                {
                    return TenSP;
                }
                set
                {
                    TenSP = value;
                }
            }
            public float giaSP
            {
                get
                {
                    return GiaSP;
                }
                set
                {
                    GiaSP = value;
                }
            }
            public DateTime ngayNhap
            {
                get
                {
                    return NgayNhap;
                }
                set
                {
                    NgayNhap = value;
                }
            }
            public int soLuong
            {
                get
                {
                    return SoLuong;
                }
                set
                {
                    SoLuong = value;
                }
            }
            public string size
            {
                get
                {
                    return Size;
                }
                set
                {
                    Size = value;
                }
            }
            public string hinhAnh
            {
                get
                {
                    return HinhAnh;
                }
                set
                {
                    HinhAnh = value;
                }
            }
            public string moTa
            {
                get
                {
                    return MoTa;
                }
                set
                {
                    MoTa = value;
                }
            }
            public string maNV
            {
                get
                {
                    return MaNV;
                }
                set
                {
                    MaNV = value;
                }
            }
            public string EmailNV
            {
                get
                {
                    return Email;
                }
                set
                {
                    Email = value;
                }
            }
        public DTO_SanPham(string TenSP, float GiaSP, string Size, DateTime NgayNhap, int SoLuong, string HinhAnh, string MoTa, string Email)
        {

            this.TenSP = TenSP;
            this.GiaSP = GiaSP;
            this.Size = Size;
            this.NgayNhap = NgayNhap;
            this.SoLuong = SoLuong;
            this.HinhAnh = HinhAnh;
            this.MoTa = MoTa;
            this.Email = Email;
        }


        public DTO_SanPham(int MaSP, string TenSP, float GiaSP, string Size, DateTime NgayNhap, int SoLuong, string HinhAnh, string MoTa)
            {
                this.MaSP = MaSP;
                this.TenSP = TenSP;
                this.GiaSP = GiaSP;
                this.Size = Size;
                this.NgayNhap = NgayNhap;
                this.SoLuong = SoLuong;
                this.HinhAnh = HinhAnh;
                this.MoTa = MoTa;
            }
          
            public DTO_SanPham()
            {
            }
    }
}
