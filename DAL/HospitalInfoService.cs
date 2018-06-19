using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using System.Data.SQLite;
namespace DAL
{
    /// <summary>
    /// 医院信息数据访问类
    /// </summary>
   public  class HospitalInfoService
    {
        /// <summary>
        /// 添加医院信息
        /// </summary>
        public int  AddHospitalInfo(HospitalInfo objHospitalInfo)
        {
            string sql = "update HospitalInfo set HospitalName='{0}',Department='{1}' where Flag=1";
            sql = string.Format(sql, objHospitalInfo.HospitalName, objHospitalInfo.Department);
            int res = SQLiteHelper.Update(sql);
            return res;
        }
        /// <summary>
        /// 查询医院信息
        /// </summary>
        /// <returns></returns>
        public HospitalInfo GetHospitalInfo()
        {
            string sql = "select HospitalName,Department from HospitalInfo where Flag=1";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            HospitalInfo objHospitalInfo = null;
            if (objReader.Read())
            {
                objHospitalInfo = new HospitalInfo()
                {

                    HospitalName = objReader["HospitalName"].ToString(),
                    Department = objReader["Department"].ToString()
                };
            }
            objReader.Close();
            return objHospitalInfo;
        }
    }
}
