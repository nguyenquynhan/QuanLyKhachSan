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
    public class NguoiDungDAL
    {
        DataHelper _helper;
        public NguoiDungDAL()
        {
            _helper = new DataHelper();
        }
        //Lay tat ca nhung nguoi dung (Bao gom dang ton tai va da xoa)
        public List<NguoiDung> GetAll()
        {
            List<NguoiDung> listct = new List<NguoiDung>();
            string sql = "SELECT nd.*, nv.HoTen FROM NguoiDung nd JOIN NhanVien nv ON nd.MaNV = nv.MaNV ORDER BY nd.NgayTao DESC";
            SqlDataReader dr = _helper.ExcuteDataReader(sql,null,CommandType.Text);
            listct = _helper.MapReaderToList<NguoiDung>(dr);
            _helper.DisConnect();
            return listct;
        }

        //Lay tat ca nhung nguoi dung dang ton tai
        public List<NguoiDung> GetAllExisting()
        {
            List<NguoiDung> listct = new List<NguoiDung>();
            string sql = "SELECT nd.*, nv.HoTen FROM NguoiDung nd JOIN NhanVien nv ON nd.MaNV = nv.MaNV where nd.DaXoa = 0 ORDER BY nd.NgayTao DESC ";
            SqlDataReader dr = _helper.ExcuteDataReader(sql, null, CommandType.Text);
            listct = _helper.MapReaderToList<NguoiDung>(dr);
            _helper.DisConnect();
            return listct;
        }

        public bool Create(NguoiDung ND)
        {
            
            ND.Password = SecurityHelper.Encrypt(ND.Password);
            string sql = "INSERT INTO NguoiDung(MaNV, UserName, Password, IsAdmin, DaXoa) VALUES(@MaNV, @UserName, @Password, @IsAdmin, @DaXoa)";
            SqlParameter[] pr ={
                              new SqlParameter("@MaNV",ND.MaNV),
                              new SqlParameter("@UserName",ND.UserName),
                              new SqlParameter("@Password", ND.Password),
                              new SqlParameter("@IsAdmin",ND.IsAdmin),
                              new SqlParameter("@DaXoa",ND.DaXoa)
                              };
           return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);//excutenonquery thực thi , trả về true or false( thêm xóa xửa)
        }

        public bool Delete(int ID)
        {
            string sql = "delete NguoiDung where MaND=@MaND";
            SqlParameter[] pr ={
                               new SqlParameter ("@MaND", ID)
                               };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        public NguoiDung GetbyID(int ID)
        {
            NguoiDung ND = new NguoiDung();
            string sql = "SELECT nd.*, nv.HoTen FROM NguoiDung nd JOIN NhanVien nv nd.MaNV = nv.MaNV where MaNV=@MaNV";
            SqlParameter[] pr ={
                              new SqlParameter("@MaNV",ID)
                              };
            SqlDataReader dr= _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            ND = _helper.MapReaderToList<NguoiDung>(dr).FirstOrDefault();
            _helper.DisConnect();
            return ND;
        }

        public NguoiDung DangNhap(string userName, string password)
        {
            password = SecurityHelper.Encrypt(password);            
            string sql = "SELECT * FROM NguoiDung where UserName=@UserName AND Password=@Password";
            SqlParameter[] pr ={
                              new SqlParameter("@UserName", userName),
                              new SqlParameter("@Password", password)
                              };
            SqlDataReader dr = _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            NguoiDung ND = _helper.MapReaderToList<NguoiDung>(dr).FirstOrDefault();
            _helper.DisConnect();
            return ND;
        }

        public bool Update(NguoiDung ND)
        {
            string sql = string.Empty;
            SqlParameter[] pr = new SqlParameter[] { };
            if (ND.Password.Length == 0) //nếu không sửa pass
            {
                sql = "UPDATE NguoiDung SET MaNV=@MaNV, UserName=@UserName, IsAdmin=@IsAdmin WHERE MaND=@MaND";
                pr = new SqlParameter[] {
                              new SqlParameter("@UserName",ND.UserName),
                              new SqlParameter("@MaNV",ND.MaNV),
                              new SqlParameter("@IsAdmin",ND.IsAdmin),
                              new SqlParameter("@MaND",ND.MaND)
                              };
            }
            else
            {
                sql = "UPDATE NguoiDung SET MaNV=@MaNV, UserName=@UserName, Password=@Password, IsAdmin=@IsAdmin WHERE MaND=@MaND";
                pr = new SqlParameter[] {
                              new SqlParameter("@UserName",ND.UserName),
                              new SqlParameter("@Password", SecurityHelper.Encrypt(ND.Password)),
                              new SqlParameter("@MaNV",ND.MaNV),
                              new SqlParameter("@IsAdmin",ND.IsAdmin),
                              new SqlParameter("@MaND",ND.MaND)
                              };
            }
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 1 khi thuc hien xoa nguoi dung
        public bool UpdateXoaForQLNguoiDung(NguoiDung nd)
        {
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE NguoiDung SET DaXoa = 1, NgaySua=@NgaySua, NguoiSua=@NguoiSua Where MaND = @MaND";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaND",nd.MaND),
                    new SqlParameter("@NgaySua",nd.NgaySua),
                    new SqlParameter("@NguoiSua", nd.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }

        //Update DaXoa = 0 khi thuc hien them nguoi dung da tung ton tai
        public bool UpdateForQLNguoiDung(NguoiDung nd)
        {
            nd.Password = SecurityHelper.Encrypt(nd.Password);
            SqlParameter[] pr = new SqlParameter[] { };
            string sql = "UPDATE NguoiDung SET DaXoa = 0, UserName = @UserName, Password = @Password, NgaySua = @NgaySua, NguoiSua = @NguoiSua Where MaNV = @MaNV";
            pr = new SqlParameter[] {
                    new SqlParameter("@MaNV",nd.MaNV),
                    new SqlParameter("@UserName",nd.UserName),
                    new SqlParameter("@Password",nd.Password),
                    new SqlParameter("@NgaySua",nd.NgaySua),
                    new SqlParameter("@NguoiSua", nd.NguoiSua)
            };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}