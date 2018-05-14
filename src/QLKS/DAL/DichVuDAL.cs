using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QLKS.DAL
{
    class DichVuDAL
    {
        DataHelper _helper;
        public DichVuDAL()
        {
            _helper = new DataHelper();
        }
        public List<DichVu> GetAll()
        {
            List<DichVu> listdv = new List<DichVu>();
            string sql = "SELECT * FROM DICHVU";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listdv=_helper.MapReaderToList<DichVu>(dr);
            _helper.DisConnect();
            return listdv;
        }
        public DichVu GetDichVuByMaDV(int MaDV)
        {
            DichVu dv = new DichVu();
            string sql = "SELECT * FROM DICHVU WHERE MaDV=@MaDV";
            SqlParameter[] pr = {new SqlParameter("@MaDV", MaDV)};
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            dv = _helper.MapReaderToList<DichVu>(dr).FirstOrDefault();
            _helper.DisConnect();
            return dv;
        }

       
    }
}
