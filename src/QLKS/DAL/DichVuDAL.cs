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

        //Create dich vu
        public bool Create(DichVu dv)
        {
            string sql = "Insert into DichVu(TenDV, Gia, NgayTao, NguoiTao) values (@TenDV, @Gia, @NgayTao, @NguoiTao)";
            SqlParameter[] pr = {
                                new SqlParameter("@TenDV",dv.TenDV ),
                                new SqlParameter("@Gia", dv.Gia ),
                                new SqlParameter("@NgayTao", dv.NgayTao ),
                                new SqlParameter("@NguoiTao", dv.NguoiTao )
                               
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

        public bool Delete(int MaDV)
        {
            string sql = "delete DichVu where MaDV=@MaDV";
            SqlParameter[] pr ={
                               new SqlParameter ("@MaDV", MaDV)
                               };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
       
    }
}
