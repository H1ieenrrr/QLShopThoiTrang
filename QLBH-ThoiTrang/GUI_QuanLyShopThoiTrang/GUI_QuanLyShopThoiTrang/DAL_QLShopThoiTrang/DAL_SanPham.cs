using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLShopThoiTrang;
namespace DAL_QLShopThoiTrang
{
    public class DAL_SanPham: DbConnect
    {
        public DataTable getHang()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachSP";
                cmd.Connection = conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertSanPham(DTO_SanPham sp)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemSP";
                cmd.Parameters.AddWithValue("TenSP", sp.tenSP);
                cmd.Parameters.AddWithValue("GiaSP", sp.giaSP);
                cmd.Parameters.AddWithValue("Size", sp.size);
                cmd.Parameters.AddWithValue("NgayNhap", sp.ngayNhap);
                cmd.Parameters.AddWithValue("SoLuong", sp.soLuong);
                cmd.Parameters.AddWithValue("HinhAnh", sp.hinhAnh);
                cmd.Parameters.AddWithValue("MoTa", sp.moTa);
                cmd.Parameters.AddWithValue("Email", sp.EmailNV);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool UpdateSanPham(DTO_SanPham sp)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaSP";
                cmd.Parameters.AddWithValue("MaSP", sp.maSP);
                cmd.Parameters.AddWithValue("TenSP", sp.tenSP);
                cmd.Parameters.AddWithValue("GiaSP", sp.giaSP);
                cmd.Parameters.AddWithValue("Size", sp.size);
                cmd.Parameters.AddWithValue("NgayNhap", sp.ngayNhap);
                cmd.Parameters.AddWithValue("SoLuong", sp.soLuong);
                cmd.Parameters.AddWithValue("HinhAnh", sp.hinhAnh);
                cmd.Parameters.AddWithValue("MoTa", sp.moTa);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;

        }

        public bool DeleteSanPham(string MaSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaSP";
                cmd.Parameters.AddWithValue("MaSP", MaSP);
                cmd.Connection = conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public DataTable SearchSanPham(string TenSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemSP";
                cmd.Parameters.AddWithValue("TenSP", TenSP);
                cmd.Connection = conn;
                DataTable dtaSP = new DataTable();
                dtaSP.Load(cmd.ExecuteReader());
                return dtaSP;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
