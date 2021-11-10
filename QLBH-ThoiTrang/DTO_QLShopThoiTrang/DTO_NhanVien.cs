using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLShopThoiTrang
{
    public class DTO_NhanVien
    {
        private string tenNhanVien;
        private string emailNV;
        private string diaChi;
        private string dienThoai;
        private int vaiTro;
        private int tinhTrang;
        private string matKhau;

        public string TenNhanVien
        {
            get
            {
                return tenNhanVien;
            }
            set
            {
                tenNhanVien = value;
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
        public int VaiTro
        {
            get
            {
                return vaiTro;
            }
            set
            {
                vaiTro = value;
            }
        }
        public int TinhTrang
        {
            get
            {
                return tinhTrang;
            }
            set
            {
                tinhTrang = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public DTO_NhanVien(string email, string tenNhanVien, string diaChi, string dienThoai, int vaiTro, int tinhTrang)
        {
            this.tenNhanVien = tenNhanVien;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.vaiTro = vaiTro;
            this.EmailNV = email;
            this.tinhTrang = tinhTrang;          
        }
        public DTO_NhanVien()
        {

        }
    }
}
