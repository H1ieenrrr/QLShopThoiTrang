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
    public class DAL_HoaDonChiTiet: DbConnect
    {
        public bool ThemHoaDonCT(DTO_HoaDonChiTiet hdct)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HDCT_ThemHDCT";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("masp", hdct.MaSP);
                cmd.Parameters.AddWithValue("dongia", hdct.DonGia);
                cmd.Parameters.AddWithValue("soluong", hdct.SoLuong);
                cmd.Parameters.AddWithValue("ngaylap", hdct.NgayLap);
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
        public DataTable DanhSachHoaDonCT(int mahd)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HDCT_DanhSachHDCT";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("mahd", mahd);
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
    }
}
