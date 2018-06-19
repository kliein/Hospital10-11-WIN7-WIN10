using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DAL
{
   public  class PatirntSaveDataService
    {
        public int AddPatientSaveInfo(PatientSaveData objPatientSaveData)
        {
            string sql = "insert into PatientSaveData(Time,Mode,Bloodo2,Pluse,Flow,Error,GetO2Time,GetO2AllTime)";
            sql += "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
            sql = string.Format(sql, objPatientSaveData.PatientBodyInfotime, objPatientSaveData.Model
                ,objPatientSaveData.BloodO2, objPatientSaveData.Pluse, objPatientSaveData.Flux,
                objPatientSaveData.Error, objPatientSaveData.GetO2time, objPatientSaveData.GetO2totaltime);
           try
            {
                return SQLiteHelper.Update(sql);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int AddPatientSaveInfo(PatientSaveData objPatientSaveData)",ex.Message);
                throw new Exception("添加数据出错！" + ex.Message);
            }
        }

        public int Clear()
        {
            string sql = "DELETE FROM PatientSaveData ";
            return SQLiteHelper.Update(sql);
        }

            public List<PatientSaveData> GetPatientInfoByBednum()
        {
            string sql = "select Time,Mode,Bloodo2,Pluse,Flow,Error,GetO2Time,GetO2AllTime from PatientSaveData";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            List<PatientSaveData> list = new List<PatientSaveData>();
            while (objReader.Read())
            {
                list.Add(new PatientSaveData()
                {
                    BloodO2 = objReader["Bloodo2"].ToString(),
                    Pluse = objReader["Pluse"].ToString(),
                    GetO2time = objReader["GetO2Time"].ToString(),
                    Flux = objReader["Flow"].ToString(),
                    Model = objReader["Mode"].ToString(),
                    Error = objReader["Error"].ToString(),
                    GetO2totaltime = objReader["GetO2AllTime"].ToString(),
                    PatientBodyInfotime = Convert.ToDateTime(objReader["Time"])
                });
            }
            objReader.Close();
            return list;
        }
        public DataTable  GetPatientHisInfo()
        {
            string sql = "select Time,Mode,Bloodo2,Pluse,Flow,Error,GetO2Time,GetO2AllTime from PatientSaveData";
            sql = string.Format(sql);
            return SQLiteHelper.getDt(sql);
        }

    }
}
