using System;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using Models;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public  class SQLiteHelper
    {
        /// <summary>
        /// 配置连接字符串
        /// </summary>
        /// 
      //  private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        private static string connString = "data source=" +PatientInfo.conn+ "\\HOSPITAL.db;Password=ph..19940918";
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SQLiteConnection cn = new SQLiteConnection(connString);
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            try
            {
                cn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //写入系统日志
                WriteLog("  public static int Update(string sql)", ex.Message.ToString());
                throw ex;
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void  Closecn()
        {
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Close();
        }
        /// <summary>
        /// 获取单一结果的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                //写入系统日志
                WriteLog(" public static object GetSingleResult(string sql)", ex.Message.ToString());
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
        public static SQLiteDataReader GetReader(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                conn.Close();              
                WriteLog(" public static SQLiteDataReader GetReader(string sql)", ex.Message.ToString());
                throw ex;
            }
        }
        /// <summary>
        /// 返回dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet getDS(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            //创建数据集对象
            DataSet DS = new DataSet();
            //创建数据库适配器对象
            SQLiteDataAdapter dap = new SQLiteDataAdapter(sql, conn);
            //清空数据集
            DS.Clear();
            //填充数据到数据集
            dap.Fill(DS);
            //返回数据集
            return DS;
        }

        public static DataTable getDt(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            //创建数据集对象
            DataTable DS = new DataTable();
            //创建数据库适配器对象
            SQLiteDataAdapter dap = new SQLiteDataAdapter(sql, conn);
            //清空数据集
            DS.Clear();
            //填充数据到数据集
            dap.Fill(DS);
            //返回数据集
            return DS;
        }

        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="ErrorInfo"></param>
        public static void WriteLog(string Hash, string ErrorInfo)
        {
            FileStream fs = new FileStream("ErrorLog.txt",FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
             //   sw.WriteLine(DateTime.Now+": 执行"+ Hash + "方法时发生以下错误:"+ ErrorInfo);
            }
            catch (Exception ex)
            {
                WriteLog("WriteLog", ex.Message);
            }
           
            sw.Close();
            fs.Close();
        }
    }
}
