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
            string sql = "SELECT * FROM CHITIETTIENTHUEPHONG";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listtp=_helper.MapReaderToList<ChiTietTienThuePhong>(dr);
            _helper.DisConnect();
            return listtp;
        }

        public bool Create(ChiTietTienThuePhong ctttp)
        {

            string sql = "INSERT INTO ChiTietTienThuePhong(MaTP, LoaiTienPhong, Gia, SoLuong, ThanhTien, NgayTao, NguoiTao) VALUES(@MaTP, @LoaiTienPhong, @Gia, @SoLuong, @ThanhTien, @NgayTao, @NguoiTao)";
            SqlParameter[] pr ={
                              new SqlParameter("@MaTP",ctttp.MaTP),
                              new SqlParameter("@LoaiTienPhong",ctttp.LoaiTienPhong),
                              new SqlParameter("@Gia", ctttp.Gia),
                              new SqlParameter("@SoLuong",ctttp.SoLuong),
                              new SqlParameter("@ThanhTien",ctttp.ThanhTien),
                              new SqlParameter("@NgayTao",ctttp.NgayTao),
                              new SqlParameter("@NguoiTao",ctttp.NguoiTao),
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);//excutenonquery thực thi , trả về true or false( thêm xóa xửa)
        }
        
    }
}
