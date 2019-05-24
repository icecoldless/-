using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace CodeCreator.Common
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
    public class SQLHelper
    {
        public string connString = string.Empty;

        public SQLHelper(string connStr)
        {
            connString = connStr;
        }
        /// <summary>
        /// 执行结果集查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader GetReader(string sql, SqlParameter[] param = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (param != null)
                cmd.Parameters.AddRange(param);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }
    
        /// <summary>
        /// 存储过程结果集查询
        /// </summary>
        /// <param name="name">存储过程的名称</param>
        /// <param name="param">参数数组</param>
        /// <returns>结果集</returns>
        public SqlDataReader GetReaderByProcedure(string name, SqlParameter[] param = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            //将存储名称给予
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = name;
                if (param != null)
                    cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 使用dataSet查询结果数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                //填充表的数据结构
                da.FillSchema(ds, SchemaType.Source);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        /// <summary>
        /// 返回一个数据库里面的所有表容器
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public DataSet GetDataSet(Dictionary<string,string> dic)  //key tbName, value sql 
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                foreach (KeyValuePair<string,string> kv in dic)
                {
                    cmd.CommandText = kv.Value;
                    //填充表的数据结构
                    da.FillSchema(ds, SchemaType.Source,kv.Key);
                    da.Fill(ds,kv.Key);
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得某一个表的主键名
        /// </summary>
        /// <returns></returns>
        public string GetPkColumnName(string tbName)
        {
            string res = string.Empty;
            try
            {
                SqlDataReader reader = GetReaderByProcedure("sp_pkeys", new SqlParameter[] { new SqlParameter("@table_name", tbName) });
                while (reader.Read())
                {
                    res = reader["COLUMN_NAME"].ToString();
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
