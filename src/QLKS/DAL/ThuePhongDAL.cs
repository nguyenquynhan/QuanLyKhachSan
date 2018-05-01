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
    class ThuePhongDAL
    {
        DataHelper _helper;
        public ThuePhongDAL()
        {
            _helper = new DataHelper();
        }

        public bool Create(ThuePhong TP)
        {

            string sql = "INSERT INTO ThuePhong(MaKH, MaPH, NgayNhanPH, SoLuongNguoi) VALUES(@MaKH, @MaPH, @NgayNhanPH, @SoLuongNguoi)";
            SqlParameter[] pr ={
                              new SqlParameter("@MaKH",TP.MaKH),
                              new SqlParameter("@MaPH",TP.MaPH),
                              new SqlParameter("@NgayNhanPH", TP.NgayNhanPH),
                              new SqlParameter("@SoLuongNguoi",TP.SoLuongNguoi)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);//excutenonquery thực thi , trả về true or false( thêm xóa xửa)
        }

    }
}
