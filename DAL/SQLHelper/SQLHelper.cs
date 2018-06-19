using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;//引入读取配置文件类所在的命名空间

namespace DAL
{
   public class SQLHelper
    {

        //  private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        private static string connString = "Server=.;DataBase=HOSPITALDB;Uid=sa;Pwd=1314";

        // <add name = "connString" connectionString="Server=.;DataBase=HOSPITALDB;Uid=sa;Pwd=1314" />//连接配置文件
        /// <summary>
        /// 执行增、删、改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //写入系统日志

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取单一结果查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                //写入系统日志

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 返回一个结果集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                //写入系统日志

                conn.Close();
                throw ex;
            }
        }

        //利用DataSet数据集加载数据库查询到数据，传入查询语句，返回数据集
        public static DataSet getDS(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            //创建数据集对象
            DataSet DS = new DataSet();
            //创建数据库适配器对象
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            //清空数据集
            DS.Clear();
            //填充数据到数据集
            dap.Fill(DS);
            //返回数据集
            return DS;
        }

    }
}
