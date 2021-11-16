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
        protected SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BGDCBQC8\TANHIEN;Initial Catalog=QLShopBanHang;Integrated Security=True");

        //static string connstr = ConfigurationManager.ConnectionStrings["QLBH_ThoiTrang.Properties.Settings.QLBH"].ToString();
        //protected SqlConnection conn = new SqlConnection(connstr);
        //protected SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tan Hien\OneDrive\Documents\Game\QLBH - ThoiTrang\QLBH - ThoiTrang\QLShopBanHang.mdf;Integrated Security=True");
    }
}
