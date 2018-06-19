using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 信息设置类
    /// </summary>
   public  class SetInfo
    {
        public int  ID { get; set; }//ID
        public int PatientBednum { get; set; }//床号
        public int IsEnable { get; set; }//使能
    }
}
