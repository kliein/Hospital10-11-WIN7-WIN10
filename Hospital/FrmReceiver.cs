using DAL;
using Models;
using Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UsbLibrary;

namespace Hospital
{
    public partial class FrmReceiver : Form
    {
        public UsbHidPort usbhid3 = null;
        public delegate void AddLRNum(int data);
        public delegate void ADDHD(HospitalAndDepartmentInfo OBJ);
        HospitalInfoService objHospitalInfoService = new HospitalInfoService();
        public FrmReceiver()
        {
            InitializeComponent();
        }

        private void btn_getwifidata_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[33];
            DataHelper.Flag = 17;
            data[0] = 0;data[1] = 12;
            for (int i = 0; i < DataHelper.CommandGetLRNum.Length; i++)
            {
                data[i + 2] = DataHelper.CommandGetLRNum[i];
            }
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_getwifidata_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_setwifidata_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 19;
            if ((this.comboBox1.Text.Trim().Length == 0)|| (this.comboBox1.Text.Trim().Length)>99)
            {
                MessageBox.Show("请输入正确的通道号！", "系统提示");
                return;
            }
            try
            {
                int a = Convert.ToInt16(this.comboBox1.Text.Trim());

            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的通道号！", "系统提示");
                return;
            }
            byte[] data = new byte[33];
            byte checksum = 0x55;
            data[0] = 1;data[1] = 13;
            data[2] = 0x5a;data[3] = 0x01;data[4] = 0xff;data[5] = 0x00;
            data[6] = 0x00; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x00; data[11] = 0x00; data[12] = 0x01; data[13] =Convert.ToByte( this.comboBox1.Text.Trim());
            for (int i = 0; i < 12; i++)
            {
                checksum += data[i + 3];
            }
            checksum &= 0xff;
            data[14] = checksum;
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_setwifidata_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
            this.comboBox1.Text = "";
        }

        private void FrmReceiver_Load(object sender, EventArgs e)
        {

        }


        public string gethospitalinfo(HospitalAndDepartmentInfo obj)
        {
            string str = string.Empty;
            List<byte> listone = new List<byte>();
            List<byte> listtwo = new List<byte>();
            byte[] data = new byte[obj.HospitalName.Count];
            for (int i = 0; i < obj.HospitalName.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listtwo.Add(obj.HospitalName[i]);
                }
                else
                {
                    listone.Add(obj.HospitalName[i]);
                }
            }


                for (int i = 0; i < obj.HospitalName.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        data[i] = listtwo[i];

                    }
                    else
                    {
                        data[i] = listone[i];
                    }

                }
            for (int i = 0; i < data.Length; i++)
            {
                str += data[i].ToString("X2");
            }

            string str3 = Unicode2String(str);
            return str3;
            
        }
        /// <summary>
        /// 解析医院信息
        /// </summary>
        /// <param name="obj"></param>
        public void addhD(HospitalAndDepartmentInfo obj)
        {


        //  string end=  gethospitalinfo(obj);

            string str = "", str2 = "";
            byte[] data = new byte[obj.HospitalName.Count];
            byte[] dataend = new byte[obj.HospitalName.Count];
            byte[] data1 = new byte[obj.DepartMentName.Count];
            byte[] data1end = new byte[obj.DepartMentName.Count];
            for (int i = 0; i < obj.HospitalName.Count; i++)
            {
                data[i] = obj.HospitalName[i];
            }
            for (int i = 0; i < obj.HospitalName.Count; i+=2)
            {
                dataend[i+1] = obj.HospitalName[i];
            }
            for (int i =1; i < obj.HospitalName.Count; i += 2)
            {
                dataend[i-1] = obj.HospitalName[i];
            }
            for(int i=0;i< dataend.Length;i++)
            {
              str+= dataend[i].ToString("X2");
            }
            string str1= Unicode2String(str);
            this.textBox1.Text = str1;

            for (int i = 0; i < obj.DepartMentName.Count; i++)
            {
                data1[i] = obj.DepartMentName[i];
            }
            for (int i = 0; i < obj.DepartMentName.Count; i += 2)
            {
                data1end[i + 1] = obj.DepartMentName[i];
            }
            for (int i = 1; i < obj.DepartMentName.Count; i += 2)
            {
                data1end[i - 1] = obj.DepartMentName[i];
            }
            for (int i = 0; i < data1end.Length; i++)
            {
                str2 += data1end[i].ToString("X2");
            }
            string str3 = Unicode2String(str2);
            this.textBox2.Text = str3;
            
        }

        /// <summary>
        /// 添加LR通道号
        /// </summary>
        /// <param name="data"></param>
        public void addLRnum(int data)
        {

            this.comboBox1.Text = data.ToString();
        }



        /// <summary>
        /// ////
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public string CharacterToCoding(string character)
        {
            string coding = "";

            for (int i = 0; i < character.Length; i++)
            {
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(character.Substring(i, 1));

                //取出二进制编码内容  
                string lowCode = System.Convert.ToString(bytes[0], 16);

                //取出低字节编码内容（两位16进制）  
                if (lowCode.Length == 1)
                {
                    lowCode = "0" + lowCode;
                }

                string hightCode = System.Convert.ToString(bytes[1], 16);

                //取出高字节编码内容（两位16进制）  
                if (hightCode.Length == 1)
                {
                    hightCode = "0" + hightCode;
                }

                coding += (hightCode + lowCode);

            }

            return coding;
        }


        private void btnset_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length == 0 || this.textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入正确信息！","系统提示！");
                this.textBox1.Focus();
                return;
            }
            DataHelper.HospitalNameflag = 0;
            DataHelper.CommandWriteHospitalName[4] = 0x30;
            DataHelper.CommandWriteDepartmentName[4] = 0x70;
            DataHelper.HospitalName = null;
            DataHelper.DepartmentName = null;
            timer1.Start();
            this.btnset.Enabled = false;
            this.btngethospiyal.Enabled = false;
            string str3 = this.textBox1.Text.Trim();
            string str =this.textBox2.Text.Trim();
            objHospitalInfoService.AddHospitalInfo(AddHospitalInfo(str3, str));

            DataHelper.HospitalName = System.Text.Encoding.Unicode.GetBytes(str3);
            DataHelper.DepartmentName= System.Text.Encoding.Unicode.GetBytes(str);
            DataHelper.Flag = 18;
            DataHelper.CommandWriteHospitalName[11] = DataHelper.HospitalName[DataHelper.HospitalNameflag];
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    //   Thread.Sleep(50);
                    this.usbhid3.SpecifiedDevice.SendData(DataHelper.WriteHospitalNameData());
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("  private void btnset_Click(object sender, EventArgs e)",ex.Message);
               // MessageBox.Show(ex.ToString());
            }
            DataHelper.HospitalNameflag++;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }
        /// <summary>
        /// 汉字转unicode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUnicode(string str)
        {
            byte[] bts = Encoding.Unicode.GetBytes(str);
            string r = "";
            for (int i = 0; i < bts.Length; i += 2) r +=   bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
            return r;
        }

        public static string String2Unicode(string source)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(source);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <param name="source">经过Unicode编码的字符串</param>
        /// <returns>正常字符串</returns>
        public static string Unicode2String(string source)
        {
            return new Regex(@"([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                         source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
        public static byte[] str2ASCII(String xmlStr)
        {
            return Encoding.Default.GetBytes(xmlStr);
        }

        private void btngethospiyal_Click(object sender, EventArgs e)
        {
            DataHelper.name.RemoveRange(0, DataHelper.name.Count);
            this.btnset.Enabled = false;
            this.btngethospiyal.Enabled = false;
            // string str= Unicode2String("4f60597d5e05");

            timer1.Start();
            DataHelper.Flag = 20;
            DataHelper.ISHORDFlag = 0;
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    //   Thread.Sleep(50);
                    this.usbhid3.SpecifiedDevice.SendData(DataHelper.ReadHospitalNameData());
                   DataHelper.CommandReadHospitalName[4] += 0x10;
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btngethospiyal_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.btnset.Enabled = true;
            this.btngethospiyal.Enabled = true;
            timer1.Stop();
        }
        public HospitalInfo AddHospitalInfo(string str1,string str2)
        {
            HospitalInfo objHospitalInfo = new HospitalInfo();
            objHospitalInfo.HospitalName = str1;
            objHospitalInfo.Department = str2;
            return objHospitalInfo;
        }
    }
}
