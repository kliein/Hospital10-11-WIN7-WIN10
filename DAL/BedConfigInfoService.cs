using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace DAL
{
    /// <summary>
    /// 床位配置查询类
    /// </summary>
   public class BedConfigInfoService
    {
        /// <summary>
        /// 添加床位信息
        /// </summary>
        public int  addBedcount(BedConfigInfo objBedConfigInfo)
        {
            string sql = "insert into BedConfig(Bedcount,Bedrows)values({0},{1})";
            sql = string.Format(sql, objBedConfigInfo.Bedcount, objBedConfigInfo.Bedrows);
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int  addBedcount(BedConfigInfo objBedConfigInfo)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }
        /// 获取上次设置的床位信息
        /// </summary>
        /// <param name="Bedflag"></param>
        /// <returns></returns>
        public BedConfigInfo GetBedInfoByBedflag(int Bedflag)
        {
            string sql = "select Bedcount,Bedrows from BedConfig where Bedflag={0}";
            sql = string.Format(sql, Bedflag);
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            BedConfigInfo objBedConfigInfo = null;
            if (objReader.Read())
            {
                objBedConfigInfo = new BedConfigInfo()
                {
                    Bedcount = Convert.ToInt32(objReader["Bedcount"]),
                    Bedrows = Convert.ToInt32(objReader["Bedrows"])
                };
            }
            objReader.Close();
            return objBedConfigInfo;
        }
        /// <summary>
        /// 插入新配置的床位信息，覆盖上次的信息
        /// </summary>
        /// <param name="objBedConfigInfo"></param>
        /// <returns></returns>
        public int InsertBedInfo(BedConfigInfo objBedConfigInfo)
        {
            string sql = "update BedConfig set Bedcount='{0}', Bedrows='{1}' where Bedflag=1";
            sql = string.Format(sql, objBedConfigInfo.Bedcount, objBedConfigInfo.Bedrows);
            return SQLiteHelper.Update(sql);
        }




    }
}
