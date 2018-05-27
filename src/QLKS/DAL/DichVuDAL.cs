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
        //Lay tat cac ca dich vu (Bao gom dang ton tai va da xoa)
        public List<DichVu> GetAll()
        {
            List<DichVu> listdv = new List<DichVu>();
            string sql = "SELECT * FROM DICHVU";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listdv=_helper.MapReaderToList<DichVu>(dr);
            _helper.DisConnect();
            return listdv;
        }
        //Lay tat ca nhung dang ton tai
        public List<DichVu> GetAllEXISTING()
        {
            List<DichVu> listdv = new List<DichVu>();
            string sql = "SELECT * FROM DICHVU where DaXoa = 0";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listdv = _helper.MapReaderToList<DichVu>(dr);
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

        //Create dich vu
        public bool Create(DichVu dv)
        {
            string sql = "Insert into DichVu(TenDV, Gia, NgayTao, NguoiTao, DaXoa) values (@TenDV, @Gia, @NgayTao, @NguoiTao, @DaXoa)";
            SqlParameter[] pr = {
                                new SqlParameter("@TenDV",dv.TenDV ),
                                new SqlParameter("@Gia", dv.Gia ),
                                new SqlParameter("@NgayTao", dv.NgayTao ),
                                new SqlParameter("@NguoiTao", dv.NguoiTao ),
                                new SqlParameter("@DaXoa", dv.DaXoa ),
                               
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
        //Update dịch vụ
        public bool Update(DichVu dv)
        {
            string sql = "Update  DichVu set TenDV = @TenDV, Gia = @Gia, NgaySua = @NgaySua, NguoiSua = @NguoiSua where MaDV = @MaDV";
            SqlParameter[] pr = {
                                new SqlParameter("@MaDV",dv.MaDV ),
                                new SqlParameter("@TenDV",dv.TenDV ),
                                new SqlParameter("@Gia", dv.Gia ),
                                new SqlParameter("@NgaySua", dv.NgaySua ),
                                new SqlParameter("@NguoiSua", dv.NguoiSua ),
                               
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 1 khi thuc hien xoa dich vu
        public bool UpdateXoaForQLDichVu(DichVu dv)
        {
            string sql = "Update  DichVu set DaXoa = 1, NgaySua = @NgaySua, NguoiSua = @NguoiSua where MaDV = @MaDV";
            SqlParameter[] pr = {
                                new SqlParameter("@MaDV",dv.MaDV ),
                                new SqlParameter("@NgaySua", dv.NgaySua ),
                                new SqlParameter("@NguoiSua", dv.NguoiSua ),
                               
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 0 khi thuc hien them dich vu nhung da tung ton tai
        public bool UpdateForQLDichVu(DichVu dv)
        {
            string sql = "Update  DichVu set DaXoa = 0,Gia = @Gia, NgaySua = @NgaySua, NguoiSua = @NguoiSua where TenDV = @TenDV and DaXoa = 1";
            SqlParameter[] pr = {
                                new SqlParameter("@TenDV",dv.TenDV ),
                                new SqlParameter("@Gia",dv.Gia ),
                                new SqlParameter("@NgaySua", dv.NgaySua ),
                                new SqlParameter("@NguoiSua", dv.NguoiSua ),
                               
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Xoa dich vu
        //public bool Delete(int MaDV)
        //{
        //    string sql = "delete DichVu where MaDV=@MaDV";
        //    SqlParameter[] pr ={
        //                       new SqlParameter ("@MaDV", MaDV)
        //                       };
        //    return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        //}
       
    }
}
