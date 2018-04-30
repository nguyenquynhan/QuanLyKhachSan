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
    public class NhanVienDAL
    {
        DataHelper _helper;
        public NhanVienDAL()
        {
            _helper = new DataHelper();
        }

        public List<NhanVien> GetAll()
        {
            List<NhanVien> listct = new List<NhanVien>();
            string sql = "SELECT * FROM NhanVien ORDER BY NgayTao DESC";
            SqlDataReader dr = _helper.ExcuteDataReader(sql,null,CommandType.Text);
            listct = _helper.MapReaderToList<NhanVien>(dr);
            _helper.DisConnect();
            return listct;
        }        
    }
}