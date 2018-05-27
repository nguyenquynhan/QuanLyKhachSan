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
    public class NhanVienDAL
    {
        DataHelper _helper;
        public NhanVienDAL()
        {
            _helper = new DataHelper();
        }

        //Lay tat ca nhung nhan vien (Bao gom dang ton tai va da xoa)
        public List<NhanVien> GetAll()
        {
            List<NhanVien> listct = new List<NhanVien>();
            string sql = "SELECT * FROM NhanVien ORDER BY NgayTao DESC";
            SqlDataReader dr = _helper.ExcuteDataReader(sql,null,CommandType.Text);
            listct = _helper.MapReaderToList<NhanVien>(dr);
            _helper.DisConnect();
            return listct;
        }

        //Lay tat ca nhung nhan vien dang ton tai
        public List<NhanVien> GetAllExisting()
        {
            List<NhanVien> listct = new List<NhanVien>();
            string sql = "SELECT * FROM NhanVien WHERE DaXoa = 0 ORDER BY NgayTao DESC";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listct = _helper.MapReaderToList<NhanVien>(dr);
            _helper.DisConnect();
            return listct;
        }

        //Lay nhan vien theo manv
        public NhanVien GetKhachHangByMaNV(int MaNV)
        {
            NhanVien kh = new NhanVien();
            string sql = "SELECT * FROM NhanVien where MaNV=@MANV";
            SqlParameter[] pr = {
                                new SqlParameter("@MaNV",MaNV )
                                };
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            kh = _helper.MapReaderToList<NhanVien>(dr).FirstOrDefault();
            _helper.DisConnect();
            return kh;
        }

        //Lay nhan vien theo ten nhan vien
        public List<NhanVien> GetKhachHangByTenNV(string TenNV)
        {
            List<NhanVien> listkhs = new List<NhanVien>();
            string sql = "SELECT * FROM NhanVien where HoTen like 'N%" + TenNV + "%'";
            SqlParameter[] pr = {
                                new SqlParameter("@TenNV", TenNV)
                                };
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            listkhs = _helper.MapReaderToList<NhanVien>(dr);
            _helper.DisConnect();
            return listkhs;
        }

        public bool Create(NhanVien nv)
        {
            string sql = "Insert into NhanVien(HoTen, NgaySinh, SDT, CMND, DiaChi, GioiTinh, Email, NgayLamViec, NgayTao, NguoiTao, DaXoa) values (@HoTen, @NgaySinh, @SDT, @CMND, @DiaChi, @GioiTinh, @Email, @NgayLamViec, @NgayTao, @NguoiTao, @DaXoa)";
            SqlParameter[] pr = {
                                new SqlParameter("@HoTen",nv.HoTen ),
                                new SqlParameter("@NgaySinh",nv.NgaySinh ),
                                new SqlParameter("@SDT", nv.SDT ),
                                new SqlParameter("@CMND", nv.CMND ),
                                new SqlParameter("@DiaChi",nv.DiaChi ),
                                new SqlParameter("@GioiTinh", nv.GioiTinh ),
                                new SqlParameter("@Email", nv.Email ),
                                new SqlParameter("@NgayLamViec", nv.NgayLamViec ),
                                new SqlParameter("@NgayTao", nv.NgayTao ),
                                new SqlParameter("@NguoiTao", nv.NguoiTao),
                                new SqlParameter("@DaXoa", nv.DaXoa)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        public bool Update(NhanVien nv)
        {
            string sql = "Update NhanVien set HoTen = @HoTen, NgaySinh = @NgaySinh, SDT = @SDT, CMND = @CMND, DiaChi = @DiaChi, GioiTinh = @GioiTinh, Email = @Email, NgayLamViec = @NgayLamViec, NgaySua = @NgaySua, NguoiSua = @NguoiSua where  MaNV = @MaNV";
            SqlParameter[] pr = {
                                new SqlParameter("@MaNV",nv.MaNV ),
                                new SqlParameter("@HoTen",nv.HoTen ),
                                new SqlParameter("@NgaySinh",nv.NgaySinh ),
                                new SqlParameter("@SDT", nv.SDT ),
                                new SqlParameter("@CMND", nv.CMND ),
                                new SqlParameter("@DiaChi",nv.DiaChi ),
                                new SqlParameter("@GioiTinh", nv.GioiTinh ),
                                new SqlParameter("@Email", nv.Email ),
                                new SqlParameter("@NgayLamViec", nv.NgayLamViec ),
                                new SqlParameter("@NgaySua", nv.NgaySua ),
                                new SqlParameter("@NguoiSua", nv.NguoiSua)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 1 khi thuc hien xoa nhan vien
        public bool UpdateXoaForQLNhanVien(NhanVien nv)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE NhanVien SET DaXoa = 1, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaNV = @MaNV";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaNV",nv.MaNV),
                    new SqlParameter("@NgaySua",nv.NgaySua),
                    new SqlParameter("@NguoiSua", nv.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 0 khi thuc hien them nhan vien co tenNV va CMND da tung ton tai
        public bool UpdateForQLNhanVien(NhanVien nv)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE NhanVien SET DaXoa = 0, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi, GioiTinh = @GioiTinh, Email = @Email, NgayLamViec = @NgayLamViec, NgaySua = @NgaySua, NguoiSua = @NguoiSua where  HoTen = @HoTen and CMND = @CMND";
            pr = new SqlParameter[] {
                                new SqlParameter("@MaNV",nv.MaNV ),
                                new SqlParameter("@HoTen",nv.HoTen ),
                                new SqlParameter("@NgaySinh",nv.NgaySinh ),
                                new SqlParameter("@SDT", nv.SDT ),
                                new SqlParameter("@CMND", nv.CMND ),
                                new SqlParameter("@DiaChi",nv.DiaChi ),
                                new SqlParameter("@GioiTinh", nv.GioiTinh ),
                                new SqlParameter("@Email", nv.Email ),
                                new SqlParameter("@NgayLamViec", nv.NgayLamViec ),
                                new SqlParameter("@NgaySua", nv.NgaySua ),
                                new SqlParameter("@NguoiSua", nv.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
        public bool Delete(int MaNV)
        {
            string sql = "delete NhanVien where MaNV = @MaNV";
            SqlParameter[] pr ={
                               new SqlParameter ("@MaNV", MaNV)
                               };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}