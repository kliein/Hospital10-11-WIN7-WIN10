using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DAL
{
public    class AdditionalPatientsService
    {
        /// <summary>
        /// 添加额外新增的病人信息
        /// </summary>
        /// <param name="objPatientInfo"></param>
        /// <returns></returns>
        public int Add_AdditionalPatients(PatientInfo objPatientInfo)
        {
            string sql = "insert into AdditionalPatients(PatientName,PatientBednum,PatientGender,PatientAge,Patientstarttime,PatientDepartment,PatientNum,UseFlag)";
            sql += "values('{0}',{1},'{2}','{3}','{4}','{5}','{6}',{7})";
            sql = string.Format(sql, objPatientInfo.PatientName, objPatientInfo.PatientBednum, objPatientInfo.PatientGender, objPatientInfo.PatientAge
                , objPatientInfo.Patientstarttime, objPatientInfo.PatientDepartment, objPatientInfo.PatientNum, 0);
            try
            {
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int Add_AdditionalPatients(PatientInfo objPatientInfo)",ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }

        }

        /// <summary>
        /// 获取额外床位list
        /// </summary>
        /// <returns></returns>
        public List<PatientInfo> Getadditionalbednumandname()
        {
            string sql = "select PatientName,PatientBednum from AdditionalPatients where UseFlag=0 ORDER BY PatientBednum ASC ";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientInfo> list = new List<PatientInfo>();
            while (objReader.Read())
            {
                list.Add(new PatientInfo()
                {
                    PatientName = objReader["PatientName"].ToString(),
                    PatientBednum = (objReader["PatientBednum"]).ToString(),
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 设置出院标志
        /// </summary>
        public int setuseflag(int bednum)
        {
            string sql = "update AdditionalPatients set UseFlag = 1 where PatientBednum={0}";
            sql = string.Format(sql, bednum);
            try
            {
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int setuseflag(int bednum)",ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }
        /// <summary>
        /// 出院
        /// </summary>
        /// <param name="budnum"></param>
        /// <returns></returns>
        public int addendtime(int budnum)
        {
            string sql = " update AdditionalPatients set Patientendtime = '{0}' where PatientBednum=" + budnum.ToString() + " and UseFlag=0";
            sql = string.Format(sql, DateTime.Now.ToString());
            try
            {
                return Convert.ToInt32(SQLiteHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                SQLiteHelper.WriteLog(" public int addendtime(int budnum)",ex.Message);
               throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int addendtime(int budnum)", ex.Message);
               throw ex;
            }
        }



        /// <summary>
        /// 修改病人信息
        /// </summary>
        /// <param name="objPatientInfo"></param>
        /// <returns></returns>
        public int UpdatePatientInfo(PatientInfo objPatientInfo)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update AdditionalPatients set PatientName='{0}',PatientGender='{1}'," +
                "Patientstarttime='{2}',PatientAge='{3}',PatientDepartment='{4}',PatientNum='{5}'");
            sqlBuilder.Append(" where PatientBednum={6} and UseFlag=0");
            string sql = string.Format(sqlBuilder.ToString(), objPatientInfo.PatientName, objPatientInfo.PatientGender,
                objPatientInfo.Patientstarttime, objPatientInfo.PatientAge, objPatientInfo.PatientDepartment,
                objPatientInfo.PatientNum, objPatientInfo.PatientBednum);
            try
            {
                return Convert.ToInt32(SQLiteHelper.Update(sql));
            }
            catch (SQLiteException ex)
            {
                SQLiteHelper.WriteLog(" public int UpdatePatientInfo(PatientInfo objPatientInfo)", ex.Message);
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int UpdatePatientInfo(PatientInfo objPatientInfo)", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 根据床号查询病人信息
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public PatientInfo GetPatientInfoBybednum(int bednum)
        {
            string sql = "select PatientName,PatientAge,PatientGender,Patientstarttime,PatientDepartment," +
                "PatientNum from AdditionalPatients where PatientBednum=" + bednum.ToString() + " and UseFlag=0";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            PatientInfo objPatientInfo = null;
            try
            {

                if (objReader.Read())
                {
                    objPatientInfo = new PatientInfo()
                    {
                        PatientBednum = Convert.ToInt16(bednum) > 256 ? "#" + (Convert.ToInt16(bednum) - 256).ToString() : Convert.ToInt16(bednum).ToString(),
                        PatientName = objReader["PatientName"].ToString(),
                        PatientAge = (objReader["PatientAge"]).ToString(),
                        PatientGender = objReader["PatientGender"].ToString(),
                        PatientDepartment = objReader["PatientDepartment"].ToString(),
                        PatientNum = objReader["PatientNum"].ToString(),
                        Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"])
                    };
                }

            }
            catch(Exception ex)
            {
                SQLiteHelper.WriteLog(" public PatientInfo GetPatientInfoBybednum(int bednum)",ex.Message);
                objPatientInfo = new PatientInfo();
                objPatientInfo.PatientBednum = bednum.ToString();
                objPatientInfo.Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"]);
            }
            objReader.Close();
            return objPatientInfo;
        }

        public List<PatientInfo> GetPatientInfoByBednum(int bednum, int useflag)
        {
            string sql = "select PatientName,Patientstarttime,Patientendtime,PatientNum from AdditionalPatients where PatientBednum=" + bednum.ToString() + " and UseFlag=" + useflag.ToString();
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientInfo> list = new List<PatientInfo>();
            if (useflag == 1)
            {
                while (objReader.Read())
                {
                    list.Add(new PatientInfo()
                    {
                        PatientName = objReader["PatientName"].ToString(),
                        PatientBednum = Convert.ToInt16(bednum) > 256 ? "#" + (Convert.ToInt16(bednum) - 256).ToString() : Convert.ToInt16(bednum).ToString(),
                        PatientNum = objReader["PatientNum"].ToString(),
                        Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"]),
                        Patientendtime = Convert.ToDateTime(objReader["Patientendtime"])
                    });
                }
            }
            else
            {
                while (objReader.Read())
                {
                    list.Add(new PatientInfo()
                    {
                        PatientName = objReader["PatientName"].ToString(),
                        PatientBednum = Convert.ToInt16(bednum) > 256 ? "#" + (Convert.ToInt16(bednum) - 256).ToString() : Convert.ToInt16(bednum).ToString(),
                        PatientNum = objReader["PatientNum"].ToString(),
                        Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"]),
                    });
                }
            }

            objReader.Close();
            return list;
        }
    }
}
