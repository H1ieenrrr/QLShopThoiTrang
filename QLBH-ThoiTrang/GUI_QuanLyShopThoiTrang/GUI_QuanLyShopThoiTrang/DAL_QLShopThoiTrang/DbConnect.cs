using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL_QLShopThoiTrang
{
    public class DbConnect
    {
        //protected SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BGDCBQC8\TANHIEN;Initial Catalog=QLShopBanHang;Integrated Security=True");

        //protected SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tan Hien\OneDrive\Documents\Kỳ_4\Dự Án 1\QLBH - ThoiTrang\QLShopThoiTrang\QLBH - ThoiTrang\GUI_QuanLyShopThoiTrang\GUI_QuanLyShopThoiTrang\Meet_QuanLyShopThoiTrang\QLShopBanHang.mdf;Integrated Security=True");


        static string connstr = ConfigurationManager.ConnectionStrings["Meet_QuanLyShopThoiTrang.Properties.Settings.QLBH"].ToString();
        protected SqlConnection conn = new SqlConnection(connstr);
    }
}
