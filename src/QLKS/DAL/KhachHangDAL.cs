using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace QLKS.DAL
{
    class KhachHangDAL
    {
        DataHelper _helper;
        public KhachHangDAL()
        {
            _helper = new  DataHelper();
        }
        //Lay tat ca cac khach hang
        public List<KhachHang> GetAll()
        {
            List<KhachHang> listkh = new List<KhachHang>();
            string sql="SELECT * FROM KhachHang";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listkh = _helper.MapReaderToList<KhachHang>(dr);
            _helper.DisConnect();
            return listkh;
        }
        //Lay khach hang theo makh
        public KhachHang GetKhachHangByMaKH(int MaKH)
        {
            KhachHang kh = new KhachHang();
            string sql = "SELECT * FROM KhachHang where MaKH=@MaKH";
            SqlParameter[] pr = {
                                new SqlParameter("@MaKH",MaKH )
                                };
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            kh = _helper.MapReaderToList<KhachHang>(dr).FirstOrDefault();
            _helper.DisConnect();
            return kh;
        }

        //Lay khach hang theo ten khach hang
        public List<KhachHang> GetKhachHangByTenKH(string TenKH)
        {
            List<KhachHang> listkhs = new List<KhachHang>();
            string sql = "SELECT * FROM KhachHang where HoTen like 'N%"+ @TenKH +"%'";
            SqlParameter[] pr = {
                                new SqlParameter("@TenKH", TenKH)
                                };
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            listkhs = _helper.MapReaderToList<KhachHang>(dr);
            _helper.DisConnect();
            return listkhs;
        }
        //lay khach hang vo datatable
        public DataTable LayDL()
        {
            DataTable table = new DataTable();
            string sql = "SELECT * FROM KhachHang ";
            table = _helper.ExcuteDataTable(sql, null, CommandType.Text);
            _helper.DisConnect();
            return table;
        }
        //Create khach hang
        public bool Create(KhachHang kh)
        {
            string sql = "Insert into KhachHang(HoTen, NgaySinh, SDT, CMND, DiaChi, GioiTinh, NgayTao, NguoiTao) values (@HoTen, @NgaySinh, @SDT, @CMND, @DiaChi, @GioiTinh, @NgayTao, @NguoiTao)";
            SqlParameter[] pr = {
                                new SqlParameter("@HoTen",kh.HoTen ),
                                new SqlParameter("@NgaySinh",kh.NgaySinh ),
                                new SqlParameter("@SDT", kh.SDT ),
                                new SqlParameter("@CMND", kh.CMND ),
                                new SqlParameter("@DiaChi",kh.DiaChi ),
                                new SqlParameter("@GioiTinh", kh.GioiTinh ),
                                new SqlParameter("@NgayTao", kh.NgayTao ),
                                new SqlParameter("@NguoiTao", kh.NguoiTao)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
        //Update khach hang
        public bool Update(KhachHang kh)
        {
            string sql = "Update KhachHang set HoTen = @HoTen, NgaySinh = @NgaySinh, SDT = @SDT, CMND = @CMND, DiaChi = @DiaChi, GioiTinh = @GioiTinh, NgaySua = @NgaySua, NguoiSua = @NguoiSua where MaKH=@MaKH";
            SqlParameter[] pr = {
                                new SqlParameter("@MaKH",kh.MaKH ),
                                new SqlParameter("@HoTen",kh.HoTen ),
                                new SqlParameter("@NgaySinh",kh.NgaySinh ),
                                new SqlParameter("@SDT", kh.SDT ),
                                new SqlParameter("@CMND", kh.CMND ),
                                new SqlParameter("@DiaChi",kh.DiaChi ),
                                new SqlParameter("@GioiTinh", kh.GioiTinh ),
                                new SqlParameter("@NgaySua", kh.NgaySua ),
                                new SqlParameter("@NguoiSua", kh.NguoiSua)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        public bool Delete(int MaKH)
        {
            string sql = "delete KhachHang where MaKH=@MaKH";
            SqlParameter[] pr ={
                               new SqlParameter ("@MaKH", MaKH)
                               };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}
