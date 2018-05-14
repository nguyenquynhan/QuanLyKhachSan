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
    class ChiTietDichVuThuePhongDAL
    {
        DataHelper _helper;
        public ChiTietDichVuThuePhongDAL()
        {
            _helper = new DataHelper();
        }
         public List<ChiTietDichVuThuePhong> GetAll()
        {
            List<ChiTietDichVuThuePhong> listChiTietDVTP = new List<ChiTietDichVuThuePhong>();
            string sql = "SELECT TP.MaTP, DV.TenDV,CTDV.* FROM DichVu DV, ChiTietDichVuThuePhong CTDV, ThuePhong TP WHERE DV.MaDV=CTDV.MaDV And CTDV.MaTP=TP.MaTP";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listChiTietDVTP = _helper.MapReaderToList<ChiTietDichVuThuePhong>(dr);
            return listChiTietDVTP;
        }
         public bool Create(ChiTietDichVuThuePhong CTDVTP)
         {

             string sql = "INSERT INTO ChiTietDichVuThuePhong(MaTP, MaDV, Gia, SoLuong, ThanhTien, NgayTao, NguoiTao) VALUES(@MaTP, @MaDV, @Gia, @SoLuong, @ThanhTien, @NgayTao, @NguoiTao)";
             SqlParameter[] pr ={
                              new SqlParameter("@MaTP",CTDVTP.MaTP),
                              new SqlParameter("@MaDV",CTDVTP.MaDV),
                              new SqlParameter("@Gia",CTDVTP.Gia),
                              new SqlParameter("@SoLuong", CTDVTP.SoLuong),
                              new SqlParameter("@ThanhTien", CTDVTP.ThanhTien),
                              new SqlParameter("@NgayTao", CTDVTP.NgayTao),
                              new SqlParameter("@NguoiTao", CTDVTP.NguoiTao)
                              };
             return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);//excutenonquery thực thi , trả về true or false( thêm xóa xửa)
         }

         public List<ChiTietDichVuThuePhong> GetByMaTP(int MaTP)
         {
             List<ChiTietDichVuThuePhong> listChiTietDVTP = new List<ChiTietDichVuThuePhong>();
             string sql = "SELECT DV.TenDV,CTDV.* FROM DichVu DV, ChiTietDichVuThuePhong CTDV, ThuePhong TP WHERE DV.MaDV=CTDV.MaDV And CTDV.MaTP=TP.MaTP And CTDV.MaTP=@MaTP";
             SqlParameter[] pr ={
                                   new SqlParameter("@MaTP",MaTP)
                               };
             SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
             listChiTietDVTP = _helper.MapReaderToList<ChiTietDichVuThuePhong>(dr);
             return listChiTietDVTP;
         }
         public bool Delete(int MaCTDV)
         {
             string sql = "delete from ChiTietDichVuThuePhong where MaCTDVTP=@MaCTDV";
             SqlParameter[] pr ={
                               new SqlParameter ("@MaCTDV", MaCTDV)
                               };
             return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
         }
    }
}
