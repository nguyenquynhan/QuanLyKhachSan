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

        public List<LoaiPhong> GetAll()
        {

            List<LoaiPhong> listlp = new List<LoaiPhong>();
            string sql = " SELECT * FROM lOAIPHONG ";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listlp = _helper.MapReaderToList<LoaiPhong>(dr);
            return listlp;
        }

        //Lay nhung phong con ton tai
        public List<LoaiPhong> GetAllForLoaiPhong()
        {

            List<LoaiPhong> listlp = new List<LoaiPhong>();
            string sql = " SELECT * FROM lOAIPHONG where DaXoa = 0";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listlp = _helper.MapReaderToList<LoaiPhong>(dr);
            return listlp;
        }

        //Update DaXoa = 1 khi thuc hien xoa dich vu
        public bool UpdateXoaForQLLoaiPhong(LoaiPhong LPH)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE LoaiPhong SET DaXoa = 1, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaLoaiPH = @MaLoaiPH";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaLoaiPH",LPH.MaLoaiPH),
                    new SqlParameter("@NgaySua",LPH.NgaySua),
                    new SqlParameter("@NguoiSua", LPH.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update khi them loai phong , neu loai phong trung thi update Daxoa = 0
        public bool UpdateForQLPhong(LoaiPhong LPH)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE LoaiPhong SET DaXoa = 0, TenLoaiPH = @TenLoaiPH, GiaGioDau = @GiaGioDau, GiaGioHai = @GiaGioHai, GiaGioTiepTheo = @GiaGioTiepTheo, GiaTheoNgay = @GiaTheoNgay, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaLoaiPH = @MaLoaiPH";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaLoaiPH",LPH.MaLoaiPH ),
                    new SqlParameter("@TenLoaiPH",LPH.TenLoaiPH ),
                    new SqlParameter("@GiaGioDau",LPH.GiaGioDau),
                    new SqlParameter("@GiaGioHai",LPH.GiaGioHai),
                    new SqlParameter("@GiaGioTiepTheo",LPH.GiaGioTiepTheo),
                    new SqlParameter("@GiaTheoNgay",LPH.GiaTheoNgay),
                    new SqlParameter("@NgaySua",LPH.NgaySua),
                    new SqlParameter("@NguoiSua", LPH.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Create loai phong
        public bool Create(LoaiPhong lph)
        {
            string sql = "Insert into LoaiPhong (TenLoaiPH, GiaGioDau, GiaGioHai, GiaGioTiepTheo, GiaTheoNgay, NgayTao, NguoiTao, DaXoa) values (@TenLoaiPH, @GiaGioDau, @GiaGioHai, @GiaGioTiepTheo, @GiaTheoNgay, @NgayTao, @NguoiTao, @DaXoa)";
            SqlParameter[] pr = {
                              
                                new SqlParameter("@TenLoaiPH",lph.TenLoaiPH ),
                                new SqlParameter("@GiaGioDau",lph.GiaGioDau),
                                new SqlParameter("@GiaGioHai",lph.GiaGioHai),
                                new SqlParameter("@GiaGioTiepTheo",lph.GiaGioTiepTheo),
                                new SqlParameter("@GiaTheoNgay",lph.GiaTheoNgay),
                                new SqlParameter("@NgayTao", lph.NgayTao ),
                                new SqlParameter("@NguoiTao", lph.NguoiTao),
                                new SqlParameter("@DaXoa", lph.DaXoa)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update khi sua loai phong
        public bool Update(LoaiPhong lph)
        {
            string sql = "Update LoaiPhong set TenLoaiPH = @TenLoaiPH, GiaGioDau = @GiaGioDau, GiaGioHai = @GiaGioHai, GiaGioTiepTheo = @GiaGioTiepTheo, GiaTheoNgay = @GiaTheoNgay, NgaySua=@NgaySua, NguoiSua=@NguoiSua where  MaLoaiPH = @MaLoaiPH";
            SqlParameter[] pr = {
                                new SqlParameter("@MaLoaiPH",lph.MaLoaiPH ),
                                new SqlParameter("@TenLoaiPH",lph.TenLoaiPH ),
                                new SqlParameter("@GiaGioDau",lph.GiaGioDau),
                                new SqlParameter("@GiaGioHai",lph.GiaGioHai),
                                new SqlParameter("@GiaGioTiepTheo",lph.GiaGioTiepTheo),
                                new SqlParameter("@GiaTheoNgay",lph.GiaTheoNgay),
                                new SqlParameter("@NgaySua", lph.NgaySua ),
                                new SqlParameter("@NguoiSua", lph.NguoiSua)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}
