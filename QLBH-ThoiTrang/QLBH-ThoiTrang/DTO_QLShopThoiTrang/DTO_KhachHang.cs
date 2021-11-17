using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLShopThoiTrang
{
    public class DTO_KhachHang
    {
        private string dienThoai;
        private string tenKH;
        private string diaChi;
        private string gioiTinh;
        private DateTime ngaysinh;
        private string emailNV;
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
        public DateTime NgaySinh
        {
            get
            {
                return ngaysinh;
            }
            set
            {
                ngaysinh = value;
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
        public DTO_KhachHang(string dienthoai, string tenkh, string diachi, string gioitinh,DateTime ngaysinh, string email)
        {
            this.dienThoai = dienthoai;
            this.tenKH = tenkh;
            this.diaChi = diachi;
            this.gioiTinh = gioitinh;
            this.emailNV = email;
            this.ngaysinh = ngaysinh;
        }
        public DTO_KhachHang(string dienthoai, string tenkh, string diachi, string gioitinh, DateTime ngaysinh)
        {
            this.dienThoai = dienthoai;
            this.tenKH = tenkh;
            this.diaChi = diachi;
            this.gioiTinh = gioitinh;
            this.ngaysinh = ngaysinh;
        }
        public DTO_KhachHang()
        {

        }
    }
}
