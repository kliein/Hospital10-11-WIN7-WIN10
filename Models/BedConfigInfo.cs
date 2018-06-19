using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 床位配置类
    /// </summary>
   public  class BedConfigInfo
    {
        public int  Bedcount { get; set; }//床总数
        public int  Bedrows { get; set; }//每一行的数量
    }

    public class HospitalAndDepartmentInfo
    {
        public List<byte> HospitalName = new List<byte>();//医院名称
        public List<byte> DepartMentName = new List<byte>();//科室名称
    }
}
