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
        //Lay tat ca nhung phong con ton tai
        public List<Phong> GetAlldgvPhong()
        {
            List<Phong> Listp = new List<Phong>();
            string sql = "SELECT PH.MaPH, PH.MaLoaiPH, LP.TenLoaiPH, PH.DangThue FROM Phong PH JOIN LoaiPhong LP ON PH.MaLoaiPH =LP.MaLoaiPH where PH.DaXoa = 0";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            Listp = _helper.MapReaderToList<Phong>(dr);
            _helper.DisConnect();
            return Listp;
        }

        //Lay tat ca cac phong (Da xoa va Chua Xoa)
        public List<Phong> GetAll()
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

        //Update Phong khi thuc hien thanh toan
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

        //Update Phong khi thuc hien xoa phong_
        public bool UpdateXoaForQLPhong(Phong PH)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE Phong SET DaXoa = 1, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaPH = @MaPH";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaPH",PH.MaPH),
                    new SqlParameter("@NgaySua",PH.NgaySua),
                    new SqlParameter("@NguoiSua", PH.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update Phong khi thuc hien them phong
        public bool UpdateForQLPhong(Phong PH)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE Phong SET DaXoa = 0, MaLoaiPH = @MaLoaiPH, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaPH = @MaPH and DaXoa = 1";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaPH",PH.MaPH),
                    new SqlParameter("@MaLoaiPH",PH.MaLoaiPH ),
                    new SqlParameter("@NgaySua",PH.NgaySua),
                    new SqlParameter("@NguoiSua", PH.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
        //public bool Delete(int MaPH)
        //{
        //    string sql = "delete Phong where MaPH = @MaPH";
        //    SqlParameter[] pr ={
        //                       new SqlParameter ("@MaPH", MaPH)
        //                       };
        //    return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        //}

        public bool Update(Phong ph)
        {
            string sql = "Update Phong set MaLoaiPH = @MaLoaiPH, NgaySua = @NgaySua, NguoiSua = @NguoiSua where MaPH=@MaPH";
            SqlParameter[] pr = {
                                new SqlParameter("@MaPH",ph.MaPH ),
                                new SqlParameter("@MaLoaiPH",ph.MaLoaiPH ),
                                new SqlParameter("@NgaySua", ph.NgaySua ),
                                new SqlParameter("@NguoiSua", ph.NguoiSua)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        public bool Create(Phong ph)
        {
            string sql = "Insert into Phong (MaPH, MaLoaiPH, NgayTao, NguoiTao, DaXoa) values (@MaPH, @MaLoaiPH, @NgayTao, @NguoiTao, @DaXoa)";
            SqlParameter[] pr = {
                                new SqlParameter("@MaPH",ph.MaPH ),
                                new SqlParameter("@MaLoaiPH",ph.MaLoaiPH ),
                                new SqlParameter("@NgayTao", ph.NgayTao ),
                                new SqlParameter("@NguoiTao", ph.NguoiTao),
                                new SqlParameter("@DaXoa", ph.DaXoa)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}
