using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL_QLShopThoiTrang;
using DTO_QLShopThoiTrang;
using System.Security.Cryptography;
using System.Data;

namespace BUS_QLShopThoiTrang
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nhanvien = new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
           return dal_nhanvien.NhanVienDangNhap(nv);
        }
        public DataTable VaiTroNhanVien(string email)
        {
            return dal_nhanvien.VaiTroNhanVien(email);
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            return dal_nhanvien.NhanVienQuenMatKhau(email);
        }
        public bool TaoMatKhauMoi(string email, string matkhau)
        {
            return dal_nhanvien.TaoMatKhau(email, matkhau);
        }
        public DataTable LoadDanhMuc()
        {
            return dal_nhanvien.LoadDanhMuc();
        }
        public string encryption(string matkhau)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(matkhau));
            StringBuilder encryptdata = new StringBuilder();

            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public bool DoiMatKhau(string Email, string MatKhauCu, string MatKhauMoi)
        {
            return dal_nhanvien.DoiMatKhau(Email, MatKhauCu, MatKhauMoi);
        }

        public DataTable DanhSachNV()
        {
            return dal_nhanvien.DanhSachNV();
        }

        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            return dal_nhanvien.InsertNhanVien(nv);
        }
    }
}
