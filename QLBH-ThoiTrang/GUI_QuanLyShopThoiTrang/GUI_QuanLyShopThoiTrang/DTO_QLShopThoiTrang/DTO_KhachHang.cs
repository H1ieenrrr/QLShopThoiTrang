using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QLShopThoiTrang
{
    public class DTO_KhachHang
    {
        private string dienThoai;
        private string tenKH;
        private string diaChi;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string emailNV;
        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }
            set
            {
                ngaySinh = value;
            }
        }
        public string DienThoai
        {
            get
            {
                return dienThoai;
            }
            set
            {
                dienThoai = value;
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
        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }
            set
            {
                gioiTinh = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return diaChi;
            }
            set
            {
                diaChi = value;
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
        public DTO_KhachHang(string dienthoai, string tenkh, string diachi, string gioitinh, DateTime NgaySinh, string email)
        {
            this.dienThoai = dienthoai;
            this.tenKH = tenkh;
            this.diaChi = diachi;
            this.gioiTinh = gioitinh;
            this.ngaySinh = NgaySinh;
            this.emailNV = email;
        }
        public DTO_KhachHang(string dienthoai, string tenkh, string diachi, string gioitinh, DateTime NgaySinh)
        {
            this.dienThoai = dienthoai;
            this.tenKH = tenkh;
            this.diaChi = diachi;
            this.gioiTinh = gioitinh;
            this.ngaySinh = NgaySinh;
        }
        public DTO_KhachHang()
        {

        }
    }
}
