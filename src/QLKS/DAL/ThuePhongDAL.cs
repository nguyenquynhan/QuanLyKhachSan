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

        public ThuePhong Create(ThuePhong TP)
        {

            string sql = "INSERT INTO ThuePhong(MaKH, MaPH, NgayNhanPH, SoLuongNguoi, NguoiTao) output INSERTED.MaTP VALUES(@MaKH, @MaPH, @NgayNhanPH, @SoLuongNguoi, @NguoiTao)";
            SqlParameter[] pr ={
                              new SqlParameter("@MaKH",TP.MaKH),
                              new SqlParameter("@MaPH",TP.MaPH),
                              new SqlParameter("@NgayNhanPH", TP.NgayNhanPH),
                              new SqlParameter("@SoLuongNguoi",TP.SoLuongNguoi),
                              new SqlParameter("@NguoiTao",TP.NguoiTao),
                              };
            var maTP = _helper.ExecuteScalar(sql, pr, CommandType.Text);//excutenonquery thực thi , trả về true or false( thêm xóa xửa)

            if (maTP != null)
            {
                TP.MaTP = (int)maTP;
                return TP;
            }

            return null;          
        }
        public ThuePhong GetThuePhongByMaPH(int MaPH)
        {
            ThuePhong Listtp = new ThuePhong();
            string sql = "SELECT TP.*,KH.HoTen as TenKH from ThuePhong TP, KhachHang KH where MaPH=@SoPhong and  KH.MaKH =TP.MaKH and NgayTraPH is null";
            SqlParameter[] pr ={new SqlParameter("@SoPhong",MaPH)};
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            Listtp = _helper.MapReaderToList<ThuePhong>(dr).FirstOrDefault();
            _helper.DisConnect();
            return Listtp;
        }

        public bool UpdateThuePhong(ThuePhong TP)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE ThuePhong SET TongTien=@TongTien, NgayTraPH=@NgayTraPH, NguoiTao=@NguoiTao, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaTP = @MaTP";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaTP",TP.MaTP),
                    new SqlParameter("@TongTien",TP.TongTien),
                    new SqlParameter("@NgayTraPH",TP.NgayTraPH),
                    new SqlParameter("@NguoiTao", TP.NguoiTao),
                    new SqlParameter("@NgaySua",TP.NgaySua),
                    new SqlParameter("@NguoiSua", TP.NguoiSua),
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

    }
}
