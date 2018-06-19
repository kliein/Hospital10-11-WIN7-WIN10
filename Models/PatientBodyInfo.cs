using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Models
{
    /// <summary>
    /// 上传病人数据类
    /// </summary>
   public class PatientBodyInfo
    {
        public DateTime PatientBodyInfotime { get; set; }//开始时间
        public int PatientBednum { get; set; }//床号
        public string BloodO2 { get; set; }//血氧
        public string Pluse { get; set; }//脉搏
        public string GetO2time { get; set; }//吸氧时间
        public string Flux { get; set; }//流量
        public string Model { get; set; }//模式
        public string Error { get; set; }//报警
        public string GetO2totaltime { get; set; }//当日吸氧总时间
        public bool DataFlag { get; set; }//标志
        public int UseFlag { get; set; }

        //public  List<WindowsFormsShow.UserControl2> MyShowblock  { get; set; }
    }
   
}
