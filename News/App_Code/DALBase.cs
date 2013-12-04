using System;
using System.IO;
using System.Diagnostics;
using System.Text;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NEWS.DAL
{
    public class DALBase
    {

        public DALBase()
        {
            
        }

        private static string GetConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }

        private static SqlConnection GetConnetion()
        {
            return new SqlConnection(GetConnectionString);
        }

        public static void BeginTransaction()
        {
            SqlConnection sqlConnection = GetConnetion();
            sqlConnection.BeginTransaction();
        }

        public object ExecuteScalar(string sql, SqlParameter[] sqlParams)
        {
            object result = null;
            try
            {
                SqlConnection conn = GetConnetion();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(sqlParams);
                try
                {
                    result = cmd.ExecuteScalar();
                    return result;
                }
                finally
                {
                    conn.Close();
                }
            }
            catch(Exception ex)
            {                
                throw ex;
            }           
        }

        public object ExecuteScalar(string sql, List<SqlParameter> p)
        {
            return ExecuteScalar(sql, p.ToArray());
        }

        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, new SqlParameter[0]);
        }
        
        public DataTable GetDataTable(SqlCommand cmd)
        {
            DataTable data = new DataTable();
            try
            {
                SqlConnection conn = GetConnetion();
                conn.Open();
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                try
                {
                    da.Fill(data);
                    return data;
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        public DataTable GetDataTable(string sql, SqlParameter[] sqlParams)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddRange(sqlParams);
            
            return GetDataTable(cmd);
        }
       
        public DataTable GetDataTable(string sql)
        {
            return GetDataTable(sql, new SqlParameter[0]);
        }

        public DataTable GetDataTable(string sql, List<SqlParameter> sqlParams)
        {
            return GetDataTable(sql, sqlParams.ToArray());
        }

        public void ExecuteNoneQuery(string sql)
        {
            ExecuteNoneQuery(sql, new SqlParameter[0]);
        }

        public void ExecuteNoneQuery(string sql, SqlParameter[] sqlParams)
        {
            ExecuteNoneQuery(sql, sqlParams, CommandType.Text);
        }

        public void ExecuteNoneQuery(string sql, List<SqlParameter> sqlParams)
        {
            ExecuteNoneQuery(sql, sqlParams.ToArray(), CommandType.Text);
        }

        public void ExecuteNoneQuery(string sql, SqlParameter[] sqlParams, CommandType commandType)
        {
            try
            {
                SqlConnection conn = GetConnetion();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParams);
                cmd.CommandType = commandType;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ExecuteNoneQuery(string sql, SqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameterCollection ExecuteStoredProcedure(string sql, SqlParameter[] sqlParams)
        {
            SqlParameterCollection result = null;
            try
            {
                SqlConnection conn = GetConnetion();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters;
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}