using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Models;
using System.Data;
using System.Data.SQLite;
namespace DAL
{
    /// <summary>
    /// 病人详细数据访问类
    /// </summary>
   public  class PatientBodyInfoService
    {
        /// <summary>
        /// 根据床号查询所有的记录
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public List<PatientBodyInfo> GetPatientInfoByBednum(int bednum,int userflag,string stime,string etime)
        {
            string sql = "select PatientBodyInfotime,BloodO2,Pluse,GetO2time,Flux,Model,Error,GetO2totaltime from PatientBodyInfo where PatientBednum=" + bednum.ToString() + " and UseFlag="+userflag.ToString() + " and PatientBodyInfotime between  '{0}' and  '{1}'" + " ORDER BY PatientBodyInfotime DESC";
            sql = string.Format(sql,stime,etime);
           SQLiteDataReader  objReader = SQLiteHelper.GetReader(sql);
            List<PatientBodyInfo> list = new List<PatientBodyInfo>();
            while (objReader.Read())
            {
                list.Add(new PatientBodyInfo()
                {
                    PatientBednum= bednum,
                    BloodO2 = objReader["BloodO2"].ToString(),
                    Pluse = objReader["Pluse"].ToString(),
                    GetO2time = objReader["GetO2time"].ToString(),
                    Flux = objReader["Flux"].ToString(),
                    Model= objReader["Model"].ToString(),
                    Error= objReader["Error"].ToString(),
                    GetO2totaltime= objReader["GetO2totaltime"].ToString(),
                    PatientBodyInfotime = Convert.ToDateTime(objReader["PatientBodyInfotime"])
                });
            }
            objReader.Close();
            return list;
        }

        public List<PatientBodyInfo> GetPatientInfoByBednumNowDESC(int bednum, int userflag)
        {
            string sql = "select DISTINCT PatientBodyInfotime,BloodO2,Pluse,GetO2time,Flux,Model,Error,GetO2totaltime from PatientBodyInfo where PatientBednum=" + bednum.ToString() + " and UseFlag=" + userflag.ToString() + " group  by  PatientBodyInfotime " + " ORDER BY PatientBodyInfotime DESC";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientBodyInfo> list = new List<PatientBodyInfo>();
            while (objReader.Read())
            {
                list.Add(new PatientBodyInfo()
                {
                    BloodO2 = objReader["BloodO2"].ToString(),
                    Pluse = objReader["Pluse"].ToString(),
                    GetO2time = objReader["GetO2time"].ToString(),
                    Flux = objReader["Flux"].ToString(),
                    Model = objReader["Model"].ToString(),
                    Error = objReader["Error"].ToString(),
                    GetO2totaltime =objReader["GetO2totaltime"].ToString(),
                    PatientBodyInfotime = Convert.ToDateTime(objReader["PatientBodyInfotime"])
                });
            }
            objReader.Close();
            return list;
        }

        public List<PatientBodyInfo> GetPatientInfoByBednumNowASC(int bednum, int userflag)
        {
            string sql = "select PatientBodyInfotime,BloodO2,Pluse,GetO2time,Flux,Model,Error,GetO2totaltime from PatientBodyInfo where PatientBednum=" + bednum.ToString() + " and UseFlag=" + userflag.ToString() + " ORDER BY PatientBodyInfotime ASC";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientBodyInfo> list = new List<PatientBodyInfo>();
            while (objReader.Read())
            {
                list.Add(new PatientBodyInfo()
                {
                    BloodO2 = objReader["BloodO2"].ToString(),
                    Pluse = objReader["Pluse"].ToString(),
                    GetO2time = objReader["GetO2time"].ToString(),
                    Flux = objReader["Flux"].ToString(),
                    Model = objReader["Model"].ToString(),
                    Error = objReader["Error"].ToString(),
                    GetO2totaltime = objReader["GetO2totaltime"].ToString(),
                    PatientBodyInfotime = Convert.ToDateTime(objReader["PatientBodyInfotime"])
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public int DeletePatientBodyInfo(int bednum)
        {
            string sql = "DELETE FROM PatientBodyInfo WHERE PatientBednum ={0} ";
            sql = string.Format(sql, bednum);
            return SQLiteHelper.Update(sql);
        }

        public int DeletePatientHisBodyInfo()
        {
            string sql = "DELETE FROM PatientBodyInfo WHERE UseFlag =1 ";
            sql = string.Format(sql);
            return SQLiteHelper.Update(sql);
        }

        /// <summary>
        /// 查询信息返回数据集用于导出数据
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public DataTable GetPatientInfoBybednum(int bednum,string stime,string etime)
        {
            string sql = "select DISTINCT PatientBodyInfo.PatientBodyInfotime,PatientBodyInfo.BloodO2,PatientBodyInfo.Pluse,PatientBodyInfo.GetO2time,PatientBodyInfo.Flux,Model,PatientBodyInfo.Error,PatientBodyInfo.GetO2totaltime from PatientBodyInfo, Patients where  PatientBodyInfo.PatientBednum = {0} and PatientBodyInfotime between  '{1}' and  '{2}' and Patients.PatientBednum = {3}  group  by  PatientBodyInfo.PatientBodyInfotime";
            sql = string.Format(sql, bednum,stime,etime, bednum);
            return SQLiteHelper .getDt(sql);
        }

        public DataTable GetPatientIndtfoBybednum(int bednum)
        {
            string sql = "select DISTINCT PatientBodyInfo.PatientBodyInfotime,PatientBodyInfo.BloodO2,PatientBodyInfo.Pluse,PatientBodyInfo.Flux,PatientBodyInfo.Model,PatientBodyInfo.Error,PatientBodyInfo.GetO2time,PatientBodyInfo.GetO2totaltime from PatientBodyInfo, Patients where  PatientBodyInfo.PatientBednum = {0} and Patients.PatientBednum = {1}  and Patients.UseFlag = {2} and PatientBodyInfo.UseFlag={3}  group  by  PatientBodyInfo.PatientBodyInfotime";
            sql = string.Format(sql, bednum, bednum,0,0);
            return SQLiteHelper.getDt(sql);
        }
        public int setuseflag1(int bednum)
        {
            string sql = "update PatientBodyInfo set UseFlag = 1 where PatientBednum={0}";
            sql = string.Format(sql, bednum);
            try
            {
                return SQLiteHelper .Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("public int setuseflag1(int bednum)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }

        /// <summary>
        /// 根据接收到的数据添加到数据库
        /// </summary>
        /// <param name="objPatientBodyInfo"></param>
        /// <returns></returns>
        public int  AddPatientBodyInfo(PatientBodyInfo objPatientBodyInfo)
        {
            if (objPatientBodyInfo == null)
            {
                return 0;
            }
            string sql = "insert into PatientBodyInfo(PatientBodyInfotime,PatientBednum,BloodO2,Pluse,GetO2time,Flux,Model,Error,GetO2totaltime,UseFlag)";
            sql += "values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})";
            sql = string.Format(sql, objPatientBodyInfo.PatientBodyInfotime, objPatientBodyInfo.PatientBednum, objPatientBodyInfo.BloodO2,
                objPatientBodyInfo.Pluse, objPatientBodyInfo.GetO2time, objPatientBodyInfo.Flux, objPatientBodyInfo.Model, objPatientBodyInfo.Error,
                objPatientBodyInfo.GetO2totaltime, objPatientBodyInfo.UseFlag);
            try
            {
               // SQLiteHelper.WriteLog("    public int  AddPatientBodyInfo(PatientBodyInfo objPatientBodyInfo)", ex.Message);
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("    public int  AddPatientBodyInfo(PatientBodyInfo objPatientBodyInfo)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }
    }


}
