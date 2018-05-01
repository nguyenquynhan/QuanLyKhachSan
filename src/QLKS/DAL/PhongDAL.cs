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
    class PhongDAL
    {
        DataHelper _helper;
        public PhongDAL()
        {
            _helper=new DataHelper();
        }
        public List<Phong> GetAlldgvPhong()
        {
            List<Phong> Listp = new List<Phong>();
            string sql = "SELECT PH.MaPH, PH.MaLoaiPH, LP.TenLoaiPH FROM Phong PH JOIN LoaiPhong LP ON PH.MaLoaiPH =LP.MaLoaiPH";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            Listp = _helper.MapReaderToList<Phong>(dr);
            _helper.DisConnect();
            return Listp;
        }

    }
}
