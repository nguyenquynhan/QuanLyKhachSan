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

            string sql = "INSERT INTO ThuePhong(MaKH, MaPH, NgayNhanPH, SoLuongNguoi, NguoiTao, NgayTao) output INSERTED.MaTP VALUES(@MaKH, @MaPH, @NgayNhanPH, @SoLuongNguoi, @NguoiTao, @NgayTao)";
            SqlParameter[] pr ={
                              new SqlParameter("@MaKH",TP.MaKH),
                              new SqlParameter("@MaPH",TP.MaPH),
                              new SqlParameter("@NgayNhanPH", TP.NgayNhanPH),
                              new SqlParameter("@SoLuongNguoi",TP.SoLuongNguoi),
                              new SqlParameter("@NguoiTao",TP.NguoiTao),
                              new SqlParameter("@NgayTao",TP.NgayTao)
                              };
            var maTP =  _helper.ExecuteScalar(sql, pr, CommandType.Text);

            if (maTP != null)
            {
                TP.MaTP = (int)maTP;
                return TP;
            }

            return null;          
        }
        public List<ThuePhong> GetAll()
        {
            List<ThuePhong> Listtp = new List<ThuePhong>();
            string sql = "SELECT * from ThuePhong";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            Listtp = _helper.MapReaderToList<ThuePhong>(dr);
            _helper.DisConnect();
            return Listtp;
        }
        public ThuePhong GetThuePhongByMaPH(int MaPH)
        {
            ThuePhong Listtp = new ThuePhong();
            string sql = "SELECT TP.*,KH.HoTen from ThuePhong TP, KhachHang KH where MaPH=@SoPhong and  KH.MaKH =TP.MaKH and NgayTraPH is null";
            SqlParameter[] pr ={new SqlParameter("@SoPhong",MaPH)};
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            Listtp = _helper.MapReaderToList<ThuePhong>(dr).FirstOrDefault();
            _helper.DisConnect();
            return Listtp;
        }

       
        //Lay danh sach thue phong
        public List<ThuePhong> GetHoaDonThuePhong()
        {
            List<ThuePhong> Listtp = new List<ThuePhong>();
            string sql = @"select MaTP, SoLuongNguoi, TP.MaPH, LP.TenLoaiPH, KH.HoTen, NgayNhanPH, NgayTraPH, TongTienDV, TongTienPH, TongTien 
                          from ThuePhong TP, LoaiPhong LP, Phong PH, KhachHang KH 
                          where TP.MaPH = PH.MaPH and TP.MaKH = KH.MaKH and PH.MaLoaiPH = LP.MaLoaiPH 
	                      and TP.NgayTraPH is not null order by NgayTraPH desc";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            Listtp = _helper.MapReaderToList<ThuePhong>(dr);
            _helper.DisConnect();
            return Listtp;
        }

        //Update Thue Phong
        public bool UpdateThuePhong(ThuePhong TP)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE ThuePhong SET TongTien=@TongTien, TongTienPH = @TongTienPH, TongTienDV = @TongTienDV, NgayTraPH=@NgayTraPH, NguoiTao=@NguoiTao, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaTP = @MaTP";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaTP",TP.MaTP),
                    new SqlParameter("@TongTien",TP.TongTien),
                     new SqlParameter("@TongTienPH",TP.TongTienPH),
                      new SqlParameter("@TongTienDV",TP.TongTienDV),
                    new SqlParameter("@NgayTraPH",TP.NgayTraPH),
                    new SqlParameter("@NguoiTao", TP.NguoiTao),
                    new SqlParameter("@NgaySua",TP.NgaySua),
                    new SqlParameter("@NguoiSua", TP.NguoiSua),
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
        public bool Delete(int MaPH)
        {
            string sql = "delete ThuePhong where MaPH = @MaPH";
            SqlParameter[] pr ={
                               new SqlParameter ("@MaPH", MaPH)
                               };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update IsNgay = 1
        public bool UpdateIsNgay1(ThuePhong TP)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE ThuePhong SET IsNgay = 1 Where MaTP = @MaTP";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaTP",TP.MaTP),
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
        //Update IsNgay = 0
        public bool UpdateIsNgay0(ThuePhong TP)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE ThuePhong SET IsNgay = 0 Where MaTP = @MaTP";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaTP",TP.MaTP),
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}
