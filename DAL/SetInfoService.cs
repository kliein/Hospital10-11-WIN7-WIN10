using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace DAL
{
    /// <summary>
    /// 设置信息存储
    /// </summary>
   public  class SetInfoService
    {
        public int  AddSetInfo(SetInfo objSetInfo)
        {
         
            string sql = "insert into SetInfo(PatientBednum,IsEnable)";
            sql += "values({0},{1})";
            sql = string.Format(sql, objSetInfo.PatientBednum, objSetInfo.IsEnable);
            try
            {
                return SQLiteHelper .Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int  AddSetInfo(SetInfo objSetInfo)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }

        /// <summary>
        /// 获取设置信息
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public SetInfo GetSetInfo(int bednum)
        {
            string sql = "select IsEnable from SetInfo where PatientBednum=" + bednum;
           SQLiteDataReader  objReader = SQLiteHelper.GetReader(sql);
            SetInfo objSetInfo = null;
            if (objReader.Read())
            {
                objSetInfo = new SetInfo()
                {
                    IsEnable = Convert.ToInt32(objReader["IsEnable"])
                };

            }
            objReader.Close();
            return objSetInfo;
        }

        public int delSetInfo(int bednum)
        {
            string sql = "DELETE FROM SetInfo WHERE PatientBednum ={0} ";
            sql = string.Format(sql, bednum);
            return SQLiteHelper .Update(sql);
        }

        public object  GetCount()
        {
            string sql = "SELECT COUNT(*) FROM SetInfo";
            return SQLiteHelper.GetSingleResult(sql);
        }
    }


}
