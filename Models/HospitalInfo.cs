using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 医院信息
    /// </summary>
   public class HospitalInfo
    {
        public int ID { get; set; }//ID号
        public string HospitalName { get; set; }//医院名称
        public string Department { get; set; }//科室名称
    }
}
