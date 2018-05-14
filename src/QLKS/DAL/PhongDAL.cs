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
            string sql = "SELECT PH.MaPH, PH.MaLoaiPH, LP.TenLoaiPH, PH.DangThue FROM Phong PH JOIN LoaiPhong LP ON PH.MaLoaiPH =LP.MaLoaiPH";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            Listp = _helper.MapReaderToList<Phong>(dr);
            _helper.DisConnect();
            return Listp;
        }
        public bool UpdateDangThue(int MaPH)
        {
            string sql = "UPDATE Phong SET DangThue=1 where MaPH=@MaPH";
            SqlParameter[] pr = { new SqlParameter ("@MaPH",MaPH)};
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        public bool UpdatePhong(Phong PH)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE Phong SET DangThue = 0, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaPH = @MaPH";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaPH",PH.MaPH),
                    new SqlParameter("@NgaySua",PH.NgaySua),
                    new SqlParameter("@NguoiSua", PH.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }


    }
}
