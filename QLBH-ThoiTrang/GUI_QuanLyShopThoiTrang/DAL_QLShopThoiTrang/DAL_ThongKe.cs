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
    public class DAL_ThongKe: DbConnect
    {
        public DataTable TimHoaDon(DateTime ngaybatdau, DateTime ngayketthuc , string tennv)
        {
            try
            {
                string sql = "Select HoaDon.MaHD,HoaDon.NgayLapHD,NhanVien.TenNV,KhachHang.TenKH," +
                    "HoaDon.TongTien,HoaDon.Thue,HoaDon.TongThanhToan from HoaDon,NhanVien,KhachHang " +
                    "Where HoaDon.MaNV = NhanVien.MaNV and HoaDon.DienThoai = KhachHang.DienThoai " +
                    " AND(Cast(NgayLapHD as date) between @ngaybatdau and @ngayketthuc  AND TenNV like '%' + @tennv + '%')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("ngayketthuc", ngayketthuc);
                cmd.Parameters.AddWithValue("tennv", tennv);
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
        public DataTable DanhSachHoaDon()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDon";
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

        public DataTable ThongKeTongHop(DateTime tungay , DateTime denngay)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeTongHop";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("TuNgay", tungay);
                cmd.Parameters.AddWithValue("DenNgay", denngay);
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
        public DataTable TimHDTheoTenNV(string tennv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HD_TimHDTheoTenNV";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("tennv", tennv);
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

        public DataTable ThongKeKhachHang()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeKhachHang";
                cmd.Connection = conn;
                DataTable dta = new DataTable();
                dta.Load(cmd.ExecuteReader());
                return dta;
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
        public DataTable ThongKeKhachHangTheoThang()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeKhachHangTheoThang";
                cmd.Connection = conn;
                DataTable dta = new DataTable();
                dta.Load(cmd.ExecuteReader());
                return dta;
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
        public DataTable ThongKeKhachHangTheoNam()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeKhachHangTheoNam";
                cmd.Connection = conn;
                DataTable dta = new DataTable();
                dta.Load(cmd.ExecuteReader());
                return dta;
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

        
    }
}
