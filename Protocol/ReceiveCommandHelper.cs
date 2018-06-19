using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    /// <summary>
    /// 接收数据解析
    /// </summary>
    public  class ReceiveCommandHelper
    {
        //{ 0x5a, 0x00, 0xff, 0x00, 0x70, 0x00, 0x00, 0x30, 0x00, 0x00, 0x10, 0x85 };


        public static byte[] ProtocolReadHead = { 0xa5 };

        /// <summary>
        /// 返回接收数据头
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte ReturnProtocolWriteHead(List<byte> data)
        {
            return data[2];
        }
        /// <summary>
        /// 返回接收数据ACK
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte ReturnProtocolAck(List<byte> data)
        {
            return data[3];
        }
        /// <summary>
        /// 返回接收数据ASC码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ReturnProtocolIDASC(List<byte> data)
        {
            byte[] Ack = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                Ack[i] = data[4 + i];
            }
            return Ack;
        }
        /// <summary>
        /// 返回接收数据寄存器地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ReturnRegisterAddress(List<byte> data)
        {
            byte[] RegisterAddress = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                RegisterAddress[i] = data[6+ i];
            }
            return RegisterAddress;
        }
        /// <summary>
        /// 返回接收数据NUM
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ReturnProtocolIDNum(List<byte> data)
        {
            byte[] IDNum = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                IDNum[i] = data[10 + i];
            }
            return IDNum;
        }
        /// <summary>
        /// 返回接收数据长度
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte ReturnProtocolLength(List<byte> data)
        {
            return data[12];
        }
        /// <summary>
        /// 返回接收数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ReturnProtocolData(List<byte> data)
        {
            byte[] ProtocolData = new byte[data[12]];
            for (int i = 0; i < data[12]; i++)
            {
                ProtocolData[i] = data[13 + i];
            }
            return ProtocolData;
        }
        /// <summary>
        /// 返回接收数据的校验和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte ReturnProtocolNum(List<byte> data)
        {
            return data[(13 + data[12])];
        }
        /// <summary>
        /// 计算接收数据的校验和并返回是否正确
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ReturnCalculateNum(List<byte> data)
        {
            byte checknum = 0;
            byte Data_L = 0;
            if (data[2] == ProtocolReadHead[0])
            {
                for (int i = 3; i < 13 + data[12]; i++)
                {
                    checknum += data[i];
                }
                checknum += 0x55;
                Data_L = Convert.ToByte(checknum & 0XFF);
                if (Data_L == data[13 + data[12]])
                {
                    return true;
                }
            }
            return false;
        }



    }
}
