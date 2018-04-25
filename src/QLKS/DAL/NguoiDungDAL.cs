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

        public List<NguoiDung> GetAll()
        {
            List<NguoiDung> listct = new List<NguoiDung>();
            string sql = "SELECT * FROM NguoiDung ORDER BY NgayTao DESC";
            SqlDataReader dr = _helper.ExcuteDataReader(sql,null,CommandType.Text);
            listct = _helper.MapReaderToList<NguoiDung>(dr);
            _helper.DisConnect();
            return listct;
        }
        public bool Create(NguoiDung ND)
        {
            
            ND.Password = SecurityHelper.Encrypt(ND.Password);
            string sql = "INSERT INTO NguoiDung(MaNV, UserName, Password) VALUES(@MaNV, @UserName, @Password)";
            SqlParameter[] pr ={
                              new SqlParameter("@MaNV",ND.MaNV),
                              new SqlParameter("@UserName",ND.UserName),
                              new SqlParameter("@Password", ND.Password)
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
            string sql = "SELECT * FROM NguoiDung where MaND=@MaND";
            SqlParameter[] pr ={
                              new SqlParameter("@MaND",ID)
                              };
            SqlDataReader dr= _helper.ExcuteDataReader(sql, pr, CommandType.Text);
            ND = _helper.MapReaderToList<NguoiDung>(dr).FirstOrDefault();
            _helper.DisConnect();
            return ND;
        }

        public bool DangNhap(string userName, string password)
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

            return ND != null;
        }

        public bool Update(NguoiDung ND)
        {
            string sql = "UPDATE NguoiDung SET MaNV=@MaNV, UserName=@UserName, Password=@Password WHERE MaND=@MaND";
            SqlParameter[] pr ={
                              new SqlParameter("@UserName",ND.UserName),
                              new SqlParameter("@Password",ND.Password),
                              new SqlParameter("@MaNV",ND.MaNV)
                              };
            return _helper.ExcuteNonQuery(sql, pr, CommandType.Text);
        }
    }
}