using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 病人信息类
    /// </summary>
   public class PatientInfo
    {
        public static string conn;
        public bool NewOId { get; set; }
        public int flag { get; set; }//索引
        public string PatientName { get; set; }//姓名
        public string PatientAge { get; set; }//年龄
        public string  PatientBednum { get; set; }//床号
        public string PatientGender { get; set; }//性别
        public DateTime Patientstarttime { get; set; }//住院时间
        public string PatientDepartment { get; set; }//科室
        public string PatientNum { get; set; }//住院号
        public DateTime Patientendtime { get; set; }//出院时间
        public int UseFlag { get; set; }//出院标志0：没有出院，1：已经出院
    }
}
