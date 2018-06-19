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
    /// 病人信息访问类
    /// </summary>
   public class PatientService
    {
        /// <summary>
        /// 添加病人信息
        /// </summary>
        /// <param name="objPatientInfo"></param>
        /// <returns></returns>
        public int AddPatients(PatientInfo objPatientInfo)
        {
            string sql = "insert into Patients(PatientName,PatientBednum,PatientGender,PatientAge,Patientstarttime,PatientDepartment,PatientNum,UseFlag)";
            sql += "values('{0}',{1},'{2}','{3}','{4}','{5}','{6}',{7})";
            sql = string.Format(sql,objPatientInfo.PatientName, objPatientInfo.PatientBednum, objPatientInfo.PatientGender, objPatientInfo.PatientAge
                , objPatientInfo.Patientstarttime, objPatientInfo.PatientDepartment, objPatientInfo.PatientNum,0);
            try
            {
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {

                throw new Exception("添加数据出错！" + ex.Message);
            }

        }
        /// <summary>
        /// 根据床号查询病人信息
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public PatientInfo GetPatientInfoBybednum(int  bednum)
        {
            string sql = "select PatientName,PatientAge,PatientGender,Patientstarttime,PatientDepartment," +
                "PatientNum from Patients where PatientBednum=" + bednum.ToString()+ " and UseFlag=0";
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
                        PatientAge =(objReader["PatientAge"]).ToString(),
                        PatientGender = objReader["PatientGender"].ToString(),
                        PatientDepartment = objReader["PatientDepartment"].ToString(),
                        PatientNum = objReader["PatientNum"].ToString(),
                        Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"])
                    };
                }

            }
            catch(Exception ex)
            {
                SQLiteHelper.WriteLog("public PatientInfo GetPatientInfoBybednum(int  bednum)", ex.Message);
                objPatientInfo = new PatientInfo();
                objPatientInfo.PatientBednum = bednum.ToString();
                objPatientInfo.Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"]);
            }
            objReader.Close();           
            return objPatientInfo;
        }
        /// <summary>
        /// 修改病人信息
        /// </summary>
        /// <param name="objPatientInfo"></param>
        /// <returns></returns>
        public int UpdatePatientInfo(PatientInfo objPatientInfo)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Patients set PatientName='{0}',PatientGender='{1}'," +
                "PatientAge='{2}',PatientDepartment='{3}',PatientNum='{4}'");
            sqlBuilder.Append(" where PatientBednum={5} and UseFlag=0");
            string sql = string.Format(sqlBuilder.ToString(), objPatientInfo.PatientName, objPatientInfo.PatientGender,
                objPatientInfo.PatientAge, objPatientInfo.PatientDepartment,
                objPatientInfo.PatientNum,objPatientInfo.PatientBednum);
            try
            {
                return Convert.ToInt32(SQLiteHelper.Update(sql));
            }
            catch (SQLiteException ex)
            {
                SQLiteHelper.WriteLog(" public int UpdatePatientInfo(PatientInfo objPatientInfo)", ex.Message);
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch(Exception ex)
            {
                SQLiteHelper.WriteLog(" public int UpdatePatientInfo(PatientInfo objPatientInfo)", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 根据床号精确查询
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public List<PatientInfo> GetPatientInfoByBednum(int bednum,int useflag)
        {
            string sql = "select PatientName,Patientstarttime,Patientendtime,PatientNum from Patients where PatientBednum=" + bednum.ToString()+ " and UseFlag="+ useflag.ToString();
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientInfo> list = new List<PatientInfo>();
            if (useflag == 1)
            {
                while (objReader.Read())
                {
                    list.Add(new PatientInfo()
                    {
                        PatientName = objReader["PatientName"].ToString(),
                        PatientBednum =Convert.ToInt16( bednum)>256?"#"+ (Convert.ToInt16(bednum)-256).ToString(): Convert.ToInt16(bednum).ToString(),
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
        /// <summary>
        /// 根据姓名精确查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<PatientInfo> GetPatientInfoByPatientname(string name,int useflag)
        {
            string sql = "select PatientBednum,Patientstarttime,Patientendtime,PatientNum from Patients where PatientName='{0}' and UseFlag='{1}'";
            sql = string.Format(sql, name, useflag);
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientInfo> list = new List<PatientInfo>();
            if (useflag == 1)
            {
                while (objReader.Read())
                {
                    list.Add(new PatientInfo()
                    {
                        PatientName = name,
                        PatientBednum = (objReader["PatientBednum"]).ToString(),
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
                        PatientName = name,
                        PatientBednum = (objReader["PatientBednum"]).ToString(),
                        PatientNum = objReader["PatientNum"].ToString(),
                        Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"]),

                    });
                }
            }

            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据住院号精确查询
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public List<PatientInfo> GetPatientInfoByPatientNum(string Num,int useflag)
        {
            string sql = "select PatientBednum,Patientstarttime,Patientendtime,PatientName from Patients where PatientNum=" + Num + " and UseFlag="+ useflag.ToString();
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientInfo> list = new List<PatientInfo>();
            if (useflag == 1)
            {
                while (objReader.Read())
                {
                    list.Add(new PatientInfo()
                    {
                        PatientName = objReader["PatientName"].ToString(),
                        PatientBednum = (objReader["PatientBednum"]).ToString(),
                        PatientNum = Num,
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
                        PatientBednum =(objReader["PatientBednum"]).ToString(),
                        PatientNum = Num,
                        Patientstarttime = Convert.ToDateTime(objReader["Patientstarttime"]),
                    });
                }
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bednum"></param>
        /// <returns></returns>
        public int DeletePatientInfo(int bednum)
        {
            string sql = "DELETE FROM Patients WHERE PatientBednum ={0} ";
            sql = string.Format(sql, bednum);
            return SQLiteHelper.Update(sql);
        }

        public int DeletePatientHisInfo()
        {
            string sql = "DELETE FROM Patients WHERE UseFlag =1 ";
            sql = string.Format(sql);
            return SQLiteHelper.Update(sql);
        }

        /// <summary>
        /// 查询所有病人的详细信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPabientInfo()
        {
            string sql = "select PatientName,PatientBednum,PatientGender,PatientAge,PatientNum, " +
                "PatientDepartment,Patientstarttime,Patientendtime from Patients where UseFlag=0";

            DataTable ds = SQLiteHelper.getDt(sql);
            return ds;
        }

        public DataTable GetOnePabientInfo(int bednum)
        {
            string sql = "select PatientName,PatientBednum,PatientGender,PatientAge,PatientNum, " +
                "PatientDepartment,Patientstarttime,Patientendtime from Patients where UseFlag=0 and PatientBednum={0}";
            sql = string.Format(sql, bednum);
            DataTable ds = SQLiteHelper.getDt(sql);
            return ds;
        }
        /// <summary>
        /// 查询历史病人信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPabienthisInfo()
        {
            string sql = "select PatientName,PatientBednum,PatientGender,PatientAge,PatientNum, " +
                "PatientDepartment,Patientstarttime,Patientendtime from Patients where UseFlag=1";

            DataTable ds = SQLiteHelper.getDt(sql);
            return ds;
        }

        /// <summary>
        /// 设置出院标志
        /// </summary>
        public int  setuseflag(int bednum)
        {
            string sql = "update Patients set UseFlag = 1 where PatientBednum={0}";
            sql = string.Format(sql, bednum);
            try
            {
                return SQLiteHelper .Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("public int  setuseflag(int bednum)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }

        public int addendtime(int budnum)
        {
            string sql = " update Patients set Patientendtime = '{0}' where PatientBednum="+ budnum.ToString()+ " and UseFlag=0";
            sql = string.Format(sql, DateTime.Now.ToString());
            try
            {
                return Convert.ToInt32(SQLiteHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                SQLiteHelper.WriteLog("  public int addendtime(int budnum)", ex.Message);
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("  public int addendtime(int budnum)", ex.Message);
                throw ex;
            }
        }

        public int  AddUsbPatient(PatientInfo objPatientInfo)
        {
            string sql = "insert into Patients(PatientBednum,Patientstarttime,UseFlag)";
            sql += " values({0},'{1}',{2})";
            sql = string.Format(sql, objPatientInfo.PatientBednum, objPatientInfo.Patientstarttime, 0);
            try
            {
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("  public int  AddUsbPatient(PatientInfo objPatientInfo)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }

        public List<PatientInfo> Getbednumandname()
        {
            string sql = "select PatientName,PatientBednum from Patients where UseFlag=0 ORDER BY PatientBednum ASC ";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientInfo> list = new List<PatientInfo>();
            while (objReader.Read())
            {
                list.Add(new PatientInfo()
                {
                    PatientName = objReader["PatientName"].ToString(),
                    PatientBednum =(objReader["PatientBednum"]).ToString() ,
                });
            }
            objReader.Close();
            return list;
        }

        public int Addbednum(int bednum)
        {
            string sql = "insert into Patients(PatientBednum,UseFlag)";
            sql += "values({0},{1})";
            sql = string.Format(sql, bednum, 0);
            try
            {
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int Addbednum(int bednum)", ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }

        public int  SelectIsNo(int bendnum)
        {
            string sql = "select count(*) from  Patients where PatientBednum=" + bendnum.ToString() +" and UseFlag=0";
            return Convert.ToInt32( SQLiteHelper.GetSingleResult(sql));
        }

        public int  UpdateUUID(String UUID)
        {
            string sql = "update UUIDINFO set UUID='{0}'";
            sql = string.Format(sql,UUID);
            return SQLiteHelper.Update(sql);
        }
        public string GetUUID()
        {
            string sql = "select *from UUIDINFO";
            string uuid = "";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            while (objReader.Read())
            {
                uuid = objReader["UUID"].ToString();
            }
            return uuid;
        }

        public int DeleAll()
        {
            string sql = "DELETE FROM PatientBodyInfo";
            string sql1 = "DELETE FROM Patients";
            string sql2 = "DELETE FROM AdditionalPatients";

            SQLiteHelper.Update(sql1);
            SQLiteHelper.Update(sql2);
            return SQLiteHelper.Update(sql);

        }
    }
}
