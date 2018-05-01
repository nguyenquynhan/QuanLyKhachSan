using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QLKS.DTO;
using System.Configuration;
namespace QLKS.DAL
{
    class ChiTietTienThuePhongDAL
    {
        DataHelper _helper;
        public ChiTietTienThuePhongDAL()
        {
            _helper = new DataHelper();
        }
        public List<ChiTietTienThuePhong> GetAll()
        {
            List<ChiTietTienThuePhong> listtp = new List<ChiTietTienThuePhong>();
            string sql = "";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listtp=_helper.MapReaderToList<ChiTietTienThuePhong>(dr);
            _helper.DisConnect();
            return listtp;
        }
    }
}
