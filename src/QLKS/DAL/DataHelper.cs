using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
/// <summary>
/// Summary description for DBHelp
/// </summary>
namespace QLKS.DAL
{
    public class DataHelper
    {
        #region Property
        //=====================Property===============================
        private SqlCommand cm;
        private SqlConnection cn;       
        public static string error = "";
        //===================End Property===============================
        #endregion
        
        //===============================Funtion Basic===========================================
        public DataHelper()
        {
            string strCn = ConfigurationManager.ConnectionStrings["QLKSConnectionString"].ConnectionString;
            cn = new SqlConnection(strCn);            
        }

        public void Connect()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();    
        }
        public void DisConnect()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        public bool ExcuteNonQuery(string sql,SqlParameter[] prs, CommandType cmType)
        {
            try
            {
                Connect();
                cm = new SqlCommand(sql, cn);
                if (prs != null)
                    cm.Parameters.AddRange(prs);
                cm.ExecuteNonQuery();
                DisConnect();

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }            
        }

        public SqlDataReader ExcuteDataReader(string sql, SqlParameter[] prs, CommandType cmType)
        {
            try
            {
                Connect();
                cm = new SqlCommand(sql, cn);
                if(prs != null)
                    cm.Parameters.AddRange(prs);
                SqlDataReader dr = cm.ExecuteReader();
                return dr; ;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
        public DataTable ExcuteDataTable(string sql, SqlParameter[] prs, CommandType cmType)
        {
            try
            {
                Connect();
                cm = new SqlCommand(sql, cn);
                if (prs != null)
                    cm.Parameters.AddRange(prs);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);
                return dt ;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        public List<T> MapReaderToList<T>(SqlDataReader r) where T : new()
        {
            List<T> res = new List<T>();
            if(r != null){
                while (r.Read())
                {
                    T t = new T();

                    for (int inc = 0; inc < r.FieldCount; inc++)
                    {
                        Type type = t.GetType();
                        PropertyInfo prop = type.GetProperty(r.GetName(inc));
                        var value = r.GetValue(inc);
                        if (value != DBNull.Value)
                        {
                            prop.SetValue(t, value, null);
                        }
                    }

                    res.Add(t);
                }
                r.Close();
            }
            return res;

        }
    }

    
}