using Models;
using Protocol;
using System;
using System.Collections.Generic;


namespace Protocol
{

    
    /// <summary>
    /// USB数据分析
    /// </summary>
    public class DataHelper
    {

        #region
        public static int patientstate;
        public static byte Isnewmachine;
        public static byte Flag=0;
        public static bool Asxflag;
        public static bool  Flagexit;
        public static int datacont;
        public static int ISHORD;
        public static int ISHORDFlag;
        public static int HDdatacount=0;
        public static int senddatacont=0;
        public static byte[] HospitalName;
        public static byte[] DepartmentName;
        public static int HospitalNameflag=0;
        public static  List<byte> name = new List<byte>();
        public static List<byte> depatmentname = new List<byte>();
        public static byte[] Department;
#endregion       
        /// <summary>
        /// 固定长度
        /// </summary>
        public static byte DataFixedCount = 13;  
        /// <summary>
        /// 发送包头
        /// </summary>
        public static byte ProtocolSendHead = 0x5A;
        /// <summary>
        /// 接收包头
        /// </summary>
        public static byte ProtocolReceHead = 0xA5;
#region
        /// <summary>
        /// 获取信息命令 3.22
        /// </summary>
        /// 
        public static byte[] CommandGetInfo = { 0x5A, 0x00, 0x41, 0x41, 0x01, 0x00, 0x00, 0x20,0x7B,0x00, 0x0D, 0x7E};
        public static byte[] CommandgetInfo = { 0x5A, 0x00, 0xff, 0x00, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x0B, 0x7E };
        public static byte[] Isreceuverorslave = { 0x5A, 0x00, 0xff, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x01, 0x75};
        /// <summary>
        /// 询问命令
        /// </summary>
        public static byte[] CommandNewSlave = { 0x5a, 0x00, 0xff, 0x00, 0x04, 0x00, 0x00, 0x30, 0xff, 0xff, 0x02, 0x88};
        /// <summary>
        /// 获取血氧仪ID
        /// </summary>
        public static byte[] CommandGetO2ID = { 0x5A, 0x00, 0xff, 0x00, 0x02, 0x00, 0x00, 0x30, 0x00, 0x00, 0x04,0x8a };
        /// <summary>
        /// 获取无线参数
        /// </summary>
        public static byte[] CommandGetWifiInfo = { 0x5a, 0x00, 0xff, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x00, 0x01,0x85};
        /// <summary>
        /// 获取无线开关
        /// </summary>
        public static byte[] CommandGetWifiOnOff = { 0x5a, 0x00, 0xff, 0x00, 0x06, 0x00, 0x00, 0x30, 0x00, 0x00, 0x02,0x8b };
        /// <summary>
        /// 获取吸氧时间
        /// </summary>
        public static byte[] CommandGetGetO2time = { 0x5a, 0x00, 0xff,0x00, 0x14, 0x00, 0x00, 0x30, 0x00, 0x00, 0x02, 0x9a };
        /// <summary>
        /// 获取自动模式流量
        /// </summary>
        public static byte[] CommandGetFlow_Auto = { 0x5a, 0x00, 0xff, 0x00, 0x16, 0x00, 0x00, 0x30, 0x00, 0x00, 0x01,0x57 };
        /// <summary>
        /// 获取手动模式流量
        /// </summary>
        public static byte[] CommandGetFlow_Hand = { 0x5a, 0x00, 0xff, 0x00, 0x16, 0x00, 0x00, 0x30, 0x00, 0x00, 0x01, 0x9c };
        /// <summary>
        /// 获取设置参数
        /// </summary>
        public static byte[] CommandGetSetInfo = { 0x5a, 0x00, 0xff, 0x00, 0x10, 0x00, 0x00, 0x30,0x00,0x00, 0x04, 0x98 };
        public static byte[] CommandGetSavedatacount = { 0x5a, 0x00, 0xff, 0x00, 0x0e, 0x00, 0x00, 0x20, 0x00, 0x00, 0x02,0x84};
        public static byte[] CommandGetSavedata = { 0x5a, 0x01, 0xff, 0x00, 0x00, 0x02, 0x00, 0x10, 0x00, 0x00, 0x02,0x00,0x00,0x85 };
        public static byte[] CommandReadRegister = { 0x5a, 0x00, 0xff, 0x00, 0x06, 0x02, 0x00, 0x20, 0x00, 0x00, 0x11, 0x8d};
        public static byte[] CommandReadRegisterstate = { 0x5a, 0x01, 0xff, 0x00, 0x02, 0x02, 0x00, 0x10, 0x00, 0x00, 0x01, 0x01,0x6b };
        public static byte[] CommandReadRegisterstateover = { 0x5a, 0x01, 0xff, 0x00, 0x02, 0x02, 0x00, 0x10, 0x00, 0x00, 0x01, 0x00, 0x6a};
        public static byte[] CommandReadRegisterclear = { 0x5a, 0x01, 0xff, 0x00, 0x02, 0x00, 0x00, 0x10, 0x00, 0x00, 0x01, 0x01, 0x69 };
        public static byte[] CommandGetLRNum = { 0x5a, 0x00, 0xff, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x00, 0x01, 0x85};
        public static byte[] CommandWriteHospitalName = { 0x5a, 0x01, 0xff, 0x00, 0x30, 0x00, 0x00, 0x30, 0x00, 0x00, 0x01, 0x01,0x85 };
        public static byte[] CommandWriteDepartmentName = { 0x5a, 0x01, 0xff, 0x00, 0x70, 0x00, 0x00, 0x30, 0x00, 0x00, 0x01, 0x01, 0x85 };
        public static byte[] CommandReadHospitalName = { 0x5a, 0x00, 0xff, 0x00, 0x30, 0x00, 0x00, 0x30, 0x00, 0x00, 0x10, 0x85 };
        public static byte[] CommandReadDepartmentName = { 0x5a, 0x00, 0xff, 0x00, 0x70, 0x00, 0x00, 0x30, 0x00, 0x00, 0x10, 0x85 };




        public static byte[] CommandReadDepartmentNameOver = { 0x5a, 0x01, 0xff, 0x00, 0x03, 0x00, 0x00, 0x10, 0x00, 0x00, 0x01, 0x01,0x6a };
        #endregion
        /// <summary>
        /// 获得无线参数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte GetWifiInfo(List<byte> data)
        {
            if (Protocolanalyse(data))
            {
                return data[13];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取无线开关
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] GetWifiOnOff(List<byte> data)
        {
            byte[] Info = new byte[2];
            if (Protocolanalyse(data))
            {
                Info[0] = data[13];
                Info[1] = data[14];
                return Info;
            }
            else
            {
                Info[0] = 0;
                Info[1] = 0;
                return Info;
            }
        }
        /// <summary>
        /// 获取设置参数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>.
        /// 55 AA 00 01 02 30 00 00 06 37 37 37 37 00 18 82 56 
        public byte[] GetSetInfo(List<byte> data)
        {
            byte[] Info = new byte[6];

            if (Protocolanalyse(data))
            {
                Info[2] = Convert.ToByte((data[16].ToString("X2") + data[15].ToString("X2")), 16);
                Info[0] = Convert.ToByte( data[13].ToString("X2"),16);
                Info[1] = Convert.ToByte(data[14].ToString("X2"),16);
                return Info;
            }
            else
            {
                Info[0] = 0;
                Info[1] = 0;
                Info[2] = 0;
                return Info;
            }
        }
        /// <summary>
        /// 获取吸氧时间
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte GetGetO2Time(List<byte> data)
        {
            
            if (Protocolanalyse(data))
            {
                return Convert.ToByte((data[12].ToString("X2")+data[11].ToString("x2")),16);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取自动初始流量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte GetAutoFlow(List<byte> data)
        {
            if (Protocolanalyse(data))
            {
                return data[10];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取手动初始流量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte GetHandFlow(List<byte> data)
        {

            if (Protocolanalyse(data))
            {
                return data[13];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取当前信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int[] GetInfoNOW(List<byte> data)
        {
            int[] Info = new int[10];
            if (Protocolanalyse(data))
            {
                Info[0] = data[17];//血氧饱和度
                Info[1] = Convert.ToByte((data[19].ToString("X2") + data[18].ToString("X2")), 16);//脉率
                Info[2] = Convert.ToByte((data[21].ToString("X2") + data[20].ToString("X2")), 16);//流量
                Info[3] = Convert.ToByte((data[23].ToString("X2") + data[22].ToString("X2")), 16);//累计时长
                Info[4] = Convert.ToByte((data[11].ToString("X2") + data[10].ToString("X2")), 16);
                Info[5] = Convert.ToByte(data[13].ToString("X2"), 16);//电量
                try
                {
                    Info[6] = Convert.ToInt16((data[15].ToString("X2") + data[14].ToString("X2")), 16);//运行状态
                }
                catch (Exception ex)
                {

                    throw ex;
                }
              
             //   string a = (data[25].ToString("X2") + data[24].ToString("X2"));
                Info[7] = Convert.ToByte((data[25].ToString("X2") + data[24].ToString("X2")), 16);//本次时长
            }
            return Info;
        }
        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] GetTime(List<byte> data)
        {
            byte[] Info = new byte[4];

            if (Protocolanalyse(data))
            {
                Info[0] = data[13];
                Info[1] = data[14];
                Info[2] = data[15];
                Info[3] = data[16];
                return Info;
            }
            else
            {
                Info[0] = 0;
                Info[1] = 0;
                Info[2] = 0;
                Info[3] = 0;
                return Info;
            }
        }
        /// <summary>
        /// 获取床号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] GetID(List<byte> data)
        {
            byte[] Info = new byte[4];

            if (Protocolanalyse(data))
            {
                Info[0] = data[13];
                Info[1] = data[14];
                Info[2] = data[15];
                Info[3] = data[16];
                return Info;
            }
            else
            {
                Info[0] = 0;
                Info[1] = 0;
                Info[2] = 0;
                Info[3] = 0;
                return Info;
            }
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int [] GetInfo(List<byte> data)
        {
            int [] Info = new int [10];
            if (Protocolanalyse(data))
            {
                Info[0] = data[17];
                Info[1] = Convert.ToInt32((data[19].ToString("X2") + data[18].ToString("X2")),16);
                Info[2] = Convert.ToInt32((data[21].ToString("X2") + data[20].ToString("X2")),16);
                Info[3] = Convert.ToInt32((data[23].ToString("X2") + data[22].ToString("X2")),16);
                Info[4] = Convert.ToInt32((data[11].ToString("X2") + data[10].ToString("X2")),16);
                Info[5] = Convert.ToInt32(data[13].ToString("X2"),16);
                Info[6] = Convert.ToInt32((data[15].ToString("X2") + data[14].ToString("X2")),16);
                Info[7]= Convert.ToInt32((data[25].ToString("X2") + data[24].ToString("X2")), 16);
            }
            return Info;
        }
      
        public static int GetLRnum(List<byte> data)
        {
            int a=0;
            if (Protocolanalyse(data))
            {
                a = data[13];
            }
            return a;
        }

        /// <summary>
        /// 解析监护仪记录数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int[] GetRegisterdata(List<byte> data)
        {
            int[] Info = new int[10];
            if (Protocolanalyse(data))
            {
                Info[0] = Convert.ToInt32((data[14].ToString("X2") + data[13].ToString("X2")), 16);//运行状态
                Info[1] = Convert.ToInt32((data[18].ToString("X2") + data[17].ToString("X2") + data[16].ToString("X2") + data[15].ToString("X2")), 16);//时间
                Info[2] = Convert.ToInt32((data[22].ToString("X2") + data[21].ToString("X2") + data[20].ToString("X2") + data[19].ToString("X2")), 16);//流量
                Info[3] = Convert.ToInt32((data[24].ToString("X2") + data[23].ToString("X2")), 16);//本次计时
                Info[4] = Convert.ToInt32((data[26].ToString("X2") + data[25].ToString("X2")), 16);//累计计时
                Info[5] = Convert.ToInt32((data[28].ToString("X2") + data[27].ToString("X2")), 16);//脉率
                Info[6] = Convert.ToInt32(data[29].ToString("X2"), 16);//血氧               
            }
            return Info;
        }

        /// <summary>
        /// 读取监护仪记录数据，返回封装好的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PatientSaveData ProtocolaSqlSavedata(int [] data)
        {
            string str = "";
            PatientSaveData objPatientSaveData = new PatientSaveData();
            if ((data[0] & 2) == 2)
            {
                objPatientSaveData.PatientBodyInfotime = ConvertIntDateTime(Convert.ToDouble((data[1]- 8 * 3600)));
                objPatientSaveData.Flux = data[2].ToString();
                objPatientSaveData.GetO2time = (data[3]/10.0).ToString();
                objPatientSaveData.GetO2totaltime = (data[4]/10.0).ToString();
                objPatientSaveData.Pluse = data[5].ToString();
                objPatientSaveData.BloodO2 = data[6].ToString();
                if ((data[0] & 1) == 0)
                {
                    objPatientSaveData.Model = "手动";
                }
                else
                {
                    objPatientSaveData.Model = "自动";
                }
                if ((data[0] & 4) == 4)
                {
                    str += "吸氧时间到,";
                }
                if ((data[0] & 8) == 8)
                {
                    str += "电池电压低,";
                }
                if ((data[0] & 16) == 16)
                {
                    str += "无湿化瓶,";
                }
                if ((data[0] & 32) == 32)
                {
                    str += "压力异常,";
                }
                if ((data[0] & 64) == 64)
                {
                    str += "血氧饱和度异常,";
                }
                if ((data[0] & 128) == 128)
                {
                    str += "血氧探头脱落,";
                }
                if ((data[0] & 256) == 256)
                {
                    str += "运动干扰,";
                }
                if ((data[0] & 512) == 512)
                {
                    str += "低灌注";
                }
                objPatientSaveData.Error = str;
                return objPatientSaveData;
            }
            else
            {
                objPatientSaveData.PatientBodyInfotime = ConvertIntDateTime(Convert.ToDouble((data[1] - 8 * 3600)));
                objPatientSaveData.Error = "暂停";
                return objPatientSaveData;
            }
            

        }

        private static DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        public static bool GetSaveDataCount(List<byte> data)
        {
            if (Protocolanalyse(data))
            {
                DataHelper.datacont = Convert.ToInt32((data[14].ToString("X2") + data[13].ToString("X2")), 16);
                return true;
            }
            else
            { return false; }
        }
        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Protocolanalyse(List<byte> data)
        {
            byte checknum = 0;
            byte Data_L = 0;
            if (data[2] == ProtocolReceHead)
            {
                for (int i = 3; i < DataFixedCount + data[12]; i++)
                {
                    checknum += data[i];
                }
                checknum += 0x55;
                Data_L = Convert.ToByte(checknum & 0XFF);
                if (Data_L == data[DataFixedCount + data[12]])
                {
                   // data.RemoveRange(0, data.Count);
                    return true;
                }
            }
           // data.RemoveRange(0,data.Count);
            return false;
        }
        /// <summary>
        /// 处理要发送的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ReturnSendData(byte[]data)
        {
            byte checksum = 0;
            byte[] data1 = new byte[33];
            data1[0] = 0;data1[1] = 12;
            for (int i = 1; i < data.Length - 1; i++)
            {
                checksum += data[i];
            }
            checksum += 0x55;
            checksum &= 0xff;
            data[11] = checksum;
            for (int i = 0; i <data.Length; i++)
            {
                data1[i+2 ] = data[i];
            }
            return data1;
        }
        /// <summary>
        /// 十进制转换为十六进制
        /// </summary>
        /// <param name="ten"></param>
        /// <returns></returns>
        public static string Ten2Hex(string ten)
        {
            ulong tenValue = Convert.ToUInt64(ten);
            ulong divValue, resValue;
            string hex = "";
            do
            {
                //divValue = (ulong)Math.Floor(tenValue / 16);

                divValue = (ulong)Math.Floor((decimal)(tenValue / 16));

                resValue = tenValue % 16;
                hex = tenValue2Char(resValue) + hex;
                tenValue = divValue;
            }
            while (tenValue >= 16);
            if (tenValue != 0)
                hex = tenValue2Char(tenValue) + hex;
            return hex;
        }

        public static string tenValue2Char(ulong ten)
        {
            switch (ten)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return ten.ToString();
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return "";
            }

        }

        /// <summary>
        /// 封装要存入数据库的信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PatientBodyInfo ProtocolaSqldata(int[] data)
        {
            string str = "";
            PatientBodyInfo objPatientBodyInfo = new PatientBodyInfo();
            if ((data[0] == 0xff) && (data[1] == 0xff) && (data[2] == 0xff) & (data[3] == 0xff))
            {
                str = "连接断开,";
            }
            if ((data[6] & 2) == 2)
            {
                objPatientBodyInfo.PatientBednum = Convert.ToInt16(data[4]);
                objPatientBodyInfo.BloodO2 = data[0].ToString();
                objPatientBodyInfo.Flux = (data[2] / 10.0).ToString();
                objPatientBodyInfo.Pluse = (data[1]).ToString();
                objPatientBodyInfo.GetO2time = (data[7]/10.0).ToString();
                objPatientBodyInfo.GetO2totaltime = (data[3]/10.0).ToString();

                if ((data[6] & 1) == 1)
                {
                    objPatientBodyInfo.Model = "智能模式";
                }
                else
                {
                    objPatientBodyInfo.Model = "人工模式";
                }
                //if ((data[6] & 4) == 4)
                //{
                //    str += "吸氧时间到,";
                //}
                if ((data[6] & 8) == 8)
                {
                    str += "电池电压低,";
                }
                //if ((data[6] & 16) == 16)
                //{
                //    str += "湿化瓶错误,";
                //}
                if ((data[6] & 32) == 32)
                {
                    str += "压力异常,";
                }
                if ((data[6] & 64) == 64)
                {
                    str += "血氧饱和度异常,";
                }
                if ((data[6] & 128) == 128)
                {
                    str += "血氧探头脱落,";
                }
                if ((data[6] & 256) == 256)
                {
                    str += "运动干扰,";
                }
                if ((data[6] & 512) == 512)
                {
                    str += "低灌注";
                }
                if (str.Length == 0)
                {

                    str = "正常";
                }
            }
            else
            {
                if ((data[6] & 4) == 4)
                {
                    str += "吸氧时间到,";
                }
                if ((data[6] & 16) == 16)
                {
                    str += "湿化瓶错误,";
                }
                str += "手动暂停";
            }
            objPatientBodyInfo.Error = str;
            objPatientBodyInfo.PatientBednum = Convert.ToInt16(data[4]);
            objPatientBodyInfo.PatientBodyInfotime =Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd HH:mm")); 
            objPatientBodyInfo.UseFlag = 0;
                return objPatientBodyInfo;

           
            
        }

        public static byte[] ReadData(int count,byte [] command)
        {
            byte[] data = new byte[33];
            byte checksum = 0x55;
            data[0] = 0; data[1] = 14;
            string str = count.ToString("X2");
            if (str.Length > 2)
            {
                command[11] = Convert.ToByte((str[1].ToString() + str[2].ToString()), 16);
                command[12] = Convert.ToByte(str[0].ToString(), 16);
            }
            else
            {
                command[11] = Convert.ToByte(str, 16);
                command[12] = 0;
            }
            for(int i=0;i<12;i++)
            {
                checksum += command[i+1];

            }
            checksum &= 0xff;
            command[13] = checksum;
            for (int i = 0; i < command.Length; i++)
            {
                data[2 + i] = command[i];
            }
            return data;
        }

        public static byte[] WriteHospitalNameData()
        {
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            
            byte checksum = 0x55;
            for (int i = 0; i < CommandWriteHospitalName.Length - 2; i++)
            {
                checksum += CommandWriteHospitalName[i + 1];
            }
            checksum &= 0xff;
            CommandWriteHospitalName[12] = checksum;
            for (int i = 0; i < CommandWriteHospitalName.Length; i++)
            {
                data[i + 2] = CommandWriteHospitalName[i];
            }
            CommandWriteHospitalName[4]++;
            return data;
        }
        public static byte[] WriteDepartNameData()
        {
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;

            byte checksum = 0x55;
            for (int i = 0; i < CommandWriteDepartmentName.Length - 2; i++)
            {
                checksum += CommandWriteDepartmentName[i + 1];
            }
            checksum &= 0xff;
            CommandWriteDepartmentName[12] = checksum;
            for (int i = 0; i < CommandWriteDepartmentName.Length; i++)
            {
                data[i + 2] = CommandWriteDepartmentName[i];
            }
            CommandWriteDepartmentName[4]++;
            return data;
        }

        public static byte[] ReadHospitalNameData()
        {
            DataHelper.Flag = 20;
            DataHelper.ISHORDFlag = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 12;
            byte checksum = 0x55;
            for (int i = 0; i < CommandReadHospitalName.Length-2; i++)
            {
                checksum += CommandReadHospitalName[i + 1];
            }
            checksum &= 0xff;
            CommandReadHospitalName[11] = checksum;
            
            for (int i = 0; i < CommandReadHospitalName.Length; i++)
            {
                data[i + 2] = CommandReadHospitalName[i];
            }
            return data;
        }

        public static byte[] ReadDepartmentNameData()
        {
            DataHelper.Flag = 20;
            DataHelper.ISHORDFlag = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 12;
            byte checksum = 0x55;
            for (int i = 0; i < CommandReadDepartmentName.Length - 2; i++)
            {
                checksum += CommandReadDepartmentName[i + 1];
            }
            checksum &= 0xff;
            CommandReadDepartmentName[11] = checksum;

            for (int i = 0; i < CommandReadDepartmentName.Length; i++)
            {
                data[i + 2] = CommandReadDepartmentName[i];
            }
            return data;
        }
        public static void GetHandDdata(List<byte> data)
        {
                   
            if (Protocolanalyse(data))
            {
                for (int i = 0; i < 16; i++)
                {
                    if (DataHelper.HDdatacount < 4)
                        name.Add(data[13 + i]);
                    else
                    {
                        depatmentname.Add(data[13 + i]);
                    }
                }
            }
        }
        public static HospitalAndDepartmentInfo ProHDdata()
        {
            int a=0;
            bool flag = false; 
            HospitalAndDepartmentInfo objHospitalAndDepartmentInfo = new HospitalAndDepartmentInfo();
            for (int i = 0; i < name.Count; i+=2)
            {
                
                if (name[i] == 0)
                {
                    if (name[i + 1] == 0)
                    {
                        a = i;
                        break;
                    }

                   
                }
                objHospitalAndDepartmentInfo.HospitalName.Add(name[i]);
                objHospitalAndDepartmentInfo.HospitalName.Add(name[i+1]);
            }
            for (int i = 0; i < depatmentname.Count; i+=2)
            {
                if (depatmentname[i] == 0)
                {
                    if (depatmentname[i + 1] == 0)
                    {
                        break;
                    }


                }
                objHospitalAndDepartmentInfo.DepartMentName.Add(depatmentname[i]);
                objHospitalAndDepartmentInfo.DepartMentName.Add(depatmentname[i + 1]);
            }
            depatmentname.RemoveRange(0, depatmentname.Count);
            return objHospitalAndDepartmentInfo;
        }
    }
}
