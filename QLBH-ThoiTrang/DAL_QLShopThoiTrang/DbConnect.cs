using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL_QLShopThoiTrang
{
    public class DbConnect
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BGDCBQC8\TANHIEN;Initial Catalog=QLShopBanHang;Integrated Security=True");
    }
}
