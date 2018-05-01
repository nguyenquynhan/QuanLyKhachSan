using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace QLKS.DAL
{
    class KhachHangDAL
    {
        DataHelper _helper;
        public KhachHangDAL()
        {
            _helper = new  DataHelper();
        }

        public List<KhachHang> GetAll()
        {
            List<KhachHang> listkh = new List<KhachHang>();
            string sql="SELECT * FROM KhachHang";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listkh = _helper.MapReaderToList<KhachHang>(dr);
            _helper.DisConnect();
            return listkh;
        }
        public List<KhachHang> GetTen()
        {
            List<KhachHang> tenKH = new List<KhachHang>();
            string sql = "SELECT HoTen From KhachHang";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            tenKH =_helper.MapReaderToList<KhachHang>(dr);
            _helper.DisConnect();
            return tenKH;
        }

    }
}
