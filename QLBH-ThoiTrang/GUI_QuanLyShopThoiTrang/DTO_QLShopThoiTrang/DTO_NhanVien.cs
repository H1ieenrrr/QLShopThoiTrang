using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QLShopThoiTrang
{
    public class DTO_NhanVien
    {

        private string TenNV;
        private string Email;
        private string DiaChi;
        private string DienThoai;
        private int VaiTro;
        private string matKhau;
        private string HinhAnh;


        public string TenNhanVien
        {
            get
            {
                return TenNV;
            }
            set
            {
                TenNV = value;
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
        public string diaChi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                DiaChi = value;
            }
        }
        public string dienThoai
        {
            get
            {
                return DienThoai;
            }
            set
            {
                DienThoai = value;
            }
        }
        public int vaiTro
        {
            get
            {
                return VaiTro;
            }
            set
            {
                VaiTro = value;
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

        public DTO_NhanVien(string Email, string TenNV, string DiaChi, string DienThoai, string HinhAnh, int VaiTro)
        {
            this.Email = Email;
            this.TenNV = TenNV;
            this.DiaChi = DiaChi;
            this.DienThoai = DienThoai;
            this.HinhAnh = HinhAnh;
            this.VaiTro = VaiTro;
        }
        public DTO_NhanVien()
        {

        }
    }
}
