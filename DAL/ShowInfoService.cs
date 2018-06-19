using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Models;
using DAL;

namespace DAL
{
   public  class ShowInfoService
    {
        public int  SetShowInfo(int a)
        {
            string sql = " update ShowInfo set AllOrPart="+a.ToString();
            try
            {
                return Convert.ToInt32(SQLiteHelper.Update(sql));
            }
            catch (SQLiteException ex)
            {
                SQLiteHelper.WriteLog(" public int  SetShowInfo(int a)", ex.Message);
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public int  SetShowInfo(int a)", ex.Message);
                throw ex;
            }
        }
        public ShowInfo GetShowInfo()
        {
            string sql = "select AllOrPart from ShowInfo where Flag=1";
            SQLiteDataReader objReader = SQLiteHelper.GetReader(sql);
            ShowInfo objShowInfo = null;
            if (objReader.Read())
            {
                objShowInfo = new ShowInfo()
                {
                    AllOrPart= Convert.ToInt32(objReader["AllOrPart"])
                };
            }
            objReader.Close();
            return objShowInfo;
        }
    }
}
