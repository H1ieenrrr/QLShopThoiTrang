using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_QLShopThoiTrang;

namespace DAL_QLShopThoiTrang
{
    public class DAL_NhanVien: DbConnect
    {
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("email", nv.EmailNV);
                cmd.Parameters.AddWithValue("matkhau", nv.MatKhau);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataTable VaiTroNhanVien(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayVaiTroNV";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool TaoMatKhau(string email, string matkhau)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TaoMatKhauMoi";
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", matkhau);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataTable LoadDanhMuc()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhMucSanPham";
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DoiMatKhau(string Email, string MatKhauCu, string MatKhauMoi)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoiMatKhau";
                cmd.Parameters.AddWithValue("Email",Email);
                cmd.Parameters.AddWithValue("@opwd", MatKhauCu);
                cmd.Parameters.AddWithValue("@npwd", MatKhauMoi);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;           
            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool KiemTraEmail(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NV_KiemTraKhoaChinh";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool KiemTraAdmin()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NV_KiemTraAdmin";
                cmd.Connection = conn;
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataTable DanhSachNV()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNV";
                cmd.Connection = conn;
                DataTable dtaNV = new DataTable();
                dtaNV.Load(cmd.ExecuteReader());
                return dtaNV;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemNV";
                cmd.Parameters.AddWithValue("Email", nv.EmailNV);
                cmd.Parameters.AddWithValue("TenNV", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("DiaChi", nv.diaChi);
                cmd.Parameters.AddWithValue("DienThoai", nv.dienThoai);
                cmd.Parameters.AddWithValue("HinhAnh", nv.hinhAnh);
                cmd.Parameters.AddWithValue("VaiTro", nv.vaiTro);               
                if (cmd.ExecuteNonQuery() > 0)               
                    return true;               
            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool UpdateNV(DTO_NhanVien nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaNV";
                cmd.Parameters.AddWithValue("Email", nv.EmailNV);
                cmd.Parameters.AddWithValue("TenNV", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("DiaChi", nv.diaChi);
                cmd.Parameters.AddWithValue("DienThoai", nv.dienThoai);
                cmd.Parameters.AddWithValue("HinhAnh", nv.hinhAnh);
                cmd.Parameters.AddWithValue("VaiTro", nv.vaiTro);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool DeleteNV(string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaNV";
                cmd.Parameters.AddWithValue("Email",Email);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public DataTable SearchNV(string TenNV)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemNV";
                cmd.Parameters.AddWithValue("TenNV",TenNV);
                DataTable dtaNV = new DataTable();
                dtaNV.Load(cmd.ExecuteReader());
                return dtaNV;
            }
            finally
            {
                conn.Close();
            }
        }
        
    }
}
