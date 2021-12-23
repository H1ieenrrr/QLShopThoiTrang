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
    public class DAL_HoaDon: DbConnect
    {
        public DataTable HienThiDanhSachSP()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HienThiDanhSachSP";
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
        public DataTable HienThiTenNV(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HienThiTenNV";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("email", email);
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
        public DataTable HienThiThongTinKH(string dienthoai)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HienThiThongTinKH";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("dienthoai", dienthoai);
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
        public DataTable HienThiTenSP()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HoaDon_LoadTenSP";
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
        public DataTable HienThiGiaSP(string tenSP)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HoaDon_GiaSP";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("TenSP", tenSP);
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
        public bool ThemHoaDon(DTO_HoaDon hd)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HD_ThemHoaDon";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("ngaylaphd", hd.NgayLapHD);
                cmd.Parameters.AddWithValue("thue", hd.Thue);
                cmd.Parameters.AddWithValue("tongtien", hd.TongTien);
                cmd.Parameters.AddWithValue("tongthanhtoan", hd.TongThanhToan);
                cmd.Parameters.AddWithValue("dienthoai", hd.DienThoaiKH);
                cmd.Parameters.AddWithValue("email", hd.EmailNV);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Lỗi",ex);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool KiemTraHang(string TenSP, float SoLuong, float SoLuongDat)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraHang";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("TenSP",TenSP);
                cmd.Parameters.AddWithValue("SoLuong", SoLuong);
                cmd.Parameters.AddWithValue("SoLuongdat", SoLuongDat);
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
    }
}
