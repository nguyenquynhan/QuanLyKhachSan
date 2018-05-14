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
    
    class LoaiPhongDAL
    {
        DataHelper _helper;
        public LoaiPhongDAL()
        {
            _helper = new DataHelper();
        }
        public LoaiPhong GetByMaLoaiPH(int MaLoaiPH)
        {
            LoaiPhong lp = new LoaiPhong();
            string sql = " SELECT * FROM lOAIPHONG LP WHERE LP.MALOAIPH=@MaLoaiPH";
            SqlParameter[] pr ={
                                  new SqlParameter("@MaLoaiPH",MaLoaiPH)
                              };
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
           lp = _helper.MapReaderToList<LoaiPhong>(dr).FirstOrDefault();
            return lp;
        }

        
    }
}
