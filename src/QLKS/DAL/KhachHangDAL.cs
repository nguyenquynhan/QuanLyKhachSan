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
        //Lay tat ca cac khach hang (Bao gom dang ton tai va da xoa)
        public List<KhachHang> GetAll()
        {
            List<KhachHang> listkh = new List<KhachHang>();
            string sql="SELECT * FROM KhachHang";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listkh = _helper.MapReaderToList<KhachHang>(dr);
            _helper.DisConnect();
            return listkh;
        }
        //Lay tat ca cac khach hang dang ton tai
        public List<KhachHang> GetAllExisting()
        {
            List<KhachHang> listkh = new List<KhachHang>();
            string sql = "SELECT * FROM KhachHang where DaXoa = 0";
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


        //Update DaXoa = 1 khi thuc hien xoa khach hang
        public bool UpdateXoaForQLKhachHang(KhachHang kh)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE KhachHang SET DaXoa = 1, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaKH = @MaKH";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaKH",kh.MaKH),
                    new SqlParameter("@NgaySua",kh.NgaySua),
                    new SqlParameter("@NguoiSua", kh.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 0 khi thuc hien them khach hang co tenNV va CMND da tung ton tai
        public bool UpdateForQLKhachHang(KhachHang kh)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE KhachHang SET DaXoa = 0,  NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi, GioiTinh = @GioiTinh, NgaySua = @NgaySua, NguoiSua = @NguoiSua Where TenKH = @TenKH and CMND = @CMND";
            pr = new SqlParameter[] {
                                new SqlParameter("@HoTen",kh.HoTen),
                                new SqlParameter("@CMND",kh.CMND),
                                new SqlParameter("@NgaySinh",kh.NgaySinh ),
                                new SqlParameter("@SDT", kh.SDT ),            
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
