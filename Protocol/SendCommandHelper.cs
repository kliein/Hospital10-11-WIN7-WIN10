using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    /// <summary>
    /// 发送数据组包
    /// </summary>
    public  class SendCommandHelper
    {
        public static byte[] SendWriteHead = { 0x5a };//固定
        public static byte[] SendAck = { 0x01 };//固定
        public static byte[] SendMachine = { 0xff, 0x00 };//固定
        public static byte[] SendRegisterAddress = { 0x00, 0x00, 0x00, 0x00 };//可写
        public static byte[] SendIDNum = { 0x00, 0x00 };//固定
        public static byte[] SendLength = { 0x00};//可写
        public static byte[] SendProtocol = { 0x00};//校验
        public static byte[] SendData = new byte[33];

        public static byte[] AddRegisterAddress(byte a,byte b,byte c,byte d)
        {
            SendRegisterAddress[0] = a;
            SendRegisterAddress[1] = b;
            SendRegisterAddress[2] = c;
            SendRegisterAddress[3] = d;
            return SendRegisterAddress;
        }

        public static byte[] AssembleData(byte[] Ack, byte[] Reg, byte[] length, byte[] data)
        {
            byte[] result = new byte[(12+data.Length)];
            byte checksun = 0x55;
            result = (SendWriteHead.Concat(Ack)).ToArray();
            result = (result.Concat(SendMachine)).ToArray();
            result = (result.Concat(Reg)).ToArray();
            result = (result.Concat(SendIDNum)).ToArray();
            result = (result.Concat(length)).ToArray();
            result = (result.Concat(data)).ToArray();
            for (int i = 0; i < result.Length - 1; i++)
            {
                checksun += result[i + 1];
            }
            checksun &= 0xff;
            SendProtocol[0] = checksun;
            result = (result.Concat(SendProtocol)).ToArray();
            return result;
        }

        public static byte[] AssembleSendData(byte[] data)
        {
            byte[] result = new byte[33];
            result[0] = 0;result[1] =Convert.ToByte(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                result[i + 2] = data[i];
            }
            return result;
        }
    }
}
