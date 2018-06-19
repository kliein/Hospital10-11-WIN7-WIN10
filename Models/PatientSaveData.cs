using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
   public  class PatientSaveData
    {
        public DateTime PatientBodyInfotime { get; set; }//开始时间
        public string BloodO2 { get; set; }//血氧
        public string Pluse { get; set; }//脉搏      
        public string Flux { get; set; }//流量
        public string Model { get; set; }//模式
        public string Error { get; set; }//报警
        public string GetO2time { get; set; }//吸氧时间
        public string GetO2totaltime { get; set; }//当日吸氧总时间
    }
}
