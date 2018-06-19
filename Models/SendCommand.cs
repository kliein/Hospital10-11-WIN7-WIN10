using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Models
{
    /// <summary>
    /// 存储配置命令类
    /// </summary>
    public class SendCommand
    {
        public string Connand { get;  }
        private byte [] flag=new byte[2];
        public byte[] Falg      
        {
            get
            {
                flag[0]=66;
                flag[1]=66;
                return flag;
            }
        }
    }

   

    
}
