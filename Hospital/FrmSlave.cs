using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using UsbLibrary;
using System.Threading;
using DAL;
using Protocol;
using static Hospital.FrmSystemset;

namespace Hospital
{

    public partial class FrmSlave : Form
    {
        int count = 0;
        double intResult1 = 0;
        public delegate void GetInfo(byte data);
        public delegate void GetInfos(byte[] data);
        public delegate void Addbodyinfo(int[] data);
        public addstate addstates;
        DataHelper objDataHelper = new DataHelper();
        public List<PatientInfo> BedInfo = new List<PatientInfo>();
        public UsbHidPort usbhid3 = null;
        PatientService objPatientService = new PatientService();
        SendCommand objSendCommand = new SendCommand();

        Frmsetok objFrmsetok = new Frmsetok();
        public FrmSlave()
        {
            InitializeComponent();
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";            
        }

        private void FrmSlave_Load(object sender, EventArgs e)
        {
         

        }

        public void SendCommand()
        {
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 5; data[2] =0xf1;
              //  if (this.txt_jianhuID.Text.Trim() == "AA"| this.txt_jianhuID.Text.Trim() == "aa")
                    data[3] = 0XAA;
                if (this.usbhid3.SpecifiedDevice != null)
                {
                   // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public void SendCommand()",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 设置ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setid_Click(object sender, EventArgs e)
        {
             
            byte[] data = new byte[33];
            data[0] = 0x55;data[1] = 0xaa;data[2] = 0x00;data[3] = 0x01;

        }
        /// <summary>
        /// 获取仪器ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getid_Click(object sender, EventArgs e)
        {
            this.btn_getid.Enabled = false;
            DataHelper.Flag = 1;
            timer1.Start();
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    this.usbhid3.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.CommandGetO2ID));
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_getid_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
            timer2.Start();
        }
        /// <summary>
        /// 获取ID号
        /// </summary>
       
        /// <summary>
        /// 时间设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_settime_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 3;
            int checknum = 0;
            int LengthL = 0;
            intResult1 =Convert.ToInt64( ConvertDateTimeInt(DateTime.Now)+8*3600);
            string timehex= Ten2Hex(intResult1.ToString());
            int rs1 = Convert.ToByte(SixToTen(timehex[0].ToString()))*16+ Convert.ToByte(SixToTen(timehex[1].ToString()));  
            int rs2= Convert.ToByte(SixToTen(timehex[2].ToString())) * 16 + Convert.ToByte(SixToTen(timehex[3].ToString()));
            int rs3 = Convert.ToByte(SixToTen(timehex[4].ToString())) * 16 + Convert.ToByte(SixToTen(timehex[5].ToString()));
            int rs4 = Convert.ToByte(SixToTen(timehex[6].ToString())) * 16 + Convert.ToByte(SixToTen(timehex[7].ToString()));

         
           try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 16;
                data[2] = 0x5a;data[3] = 0x01;data[4] = 0xff;data[5] = 0x00;data[6] = 0x0c;data[7] = 0x00;
                data[8] = 0x00;data[9] = 0x30;data[10] = 0x00;data[11] = 0x00;data[12] = 0x04;
                data[13] = Convert.ToByte(rs4);
                data[14] = Convert.ToByte(rs3);
                data[15] = Convert.ToByte(rs2);
                data[16] = Convert.ToByte(rs1);
                for (int i = 3; i < 17; i++)
                {
                    checknum += data[i];
                }
                checknum += 0x55;
                LengthL = checknum & 0Xff;
                data[17] =Convert.ToByte(LengthL) ;

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("  private void btn_settime_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// 获取无线参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getwifidata_Click(object sender, EventArgs e)
        {
            this.btn_getwifidata.Enabled = false;
            timer2.Start();
            DataHelper.Flag = 33;
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.CommandGetWifiInfo));
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btn_getwifidata_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取无线开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openwifi_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 4;
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 12;

                for (int i = 0; i < DataHelper.CommandGetWifiOnOff.Length; i++)
                {
                    data[i + 2] = DataHelper.CommandGetWifiOnOff[i];
                }

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("  private void btn_openwifi_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取吸氧时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getO2time_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 6;
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 12;
                for (int i = 0; i < DataHelper.CommandGetGetO2time.Length; i++)
                {
                    data[i + 2] = DataHelper.CommandGetGetO2time[i];
                }

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_getO2time_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取自动流量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getstartliu_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 7;
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 11;
                for (int i = 0; i < DataHelper.CommandGetFlow_Auto.Length; i++)
                {
                    data[i + 2] = DataHelper.CommandGetFlow_Auto[i];
                }

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_getstartliu_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取手动流量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 8;
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 11;
                for (int i = 0; i < DataHelper.CommandGetFlow_Hand.Length; i++)
                {
                    data[i + 2] = DataHelper.CommandGetFlow_Hand[i];
                }

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void button2_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取设置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getdata_Click(object sender, EventArgs e)
        {
            this.btn_getdata.Enabled = false;
        //    this.label25.Text = "正在获取！";
            DataHelper.Flag = 5;
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 9;
                for (int i = 0; i < DataHelper.CommandGetSetInfo.Length; i++)
                {
                    data[i + 2] = DataHelper.CommandGetSetInfo[i];
                }

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btn_getdata_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
            timer2.Start();
        }
        /// <summary>
        /// 获取当前信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngetinfo_Click(object sender, EventArgs e)
        {
            DataHelper.Flag = 9;
            try
            {
                byte[] data = new byte[33];
                data[0] = 0;
                data[1] = 12;
                for (int i = 0; i < DataHelper.CommandgetInfo.Length; i++)
                {
                    data[i + 2] = DataHelper.CommandgetInfo[i];
                }

                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btngetinfo_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 设置无线参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setwifidata_Click(object sender, EventArgs e)
        {
            this.btn_setwifidata.Enabled = false;
            timer2.Start();
            if (this.cbxf.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入通道号！", "系统提示");
                this.cbxf.Focus();
                return;
            }
            int  sum = 0;
            byte[] data = new byte[33];
            data[0] = 0;data[1] = 13;
            data[2] = 0x5a; data[3] = 0x01; data[4] = 0xff; data[5] = 0x00;
            data[6] = 0x00; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x00;data[11] = 0x00; data[12] = 0x01; data[13] =Convert.ToByte(this.cbxf.Text.Trim());
            for (int i = 3; i <14; i++)
            {
                sum += data[i];
            }
            sum += 0x55;

            data[14]=Convert.ToByte(sum&0Xff);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btn_setwifidata_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        //    this.cbxf.Text = "";
            this.btn_setwifidata.Enabled = true;
        }
        /// <summary>
        /// 设置无线开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setwifi_Click(object sender, EventArgs e)
        {
            if (this.rad_openwifi.Checked==false&&this.rad_closewifi.Checked==false)
            {
                MessageBox.Show("请选择打开或者关闭！", "系统提示");
                return;
            }
            if (this.cbxbeep.Text.Trim().Length == 0)
            {
                MessageBox.Equals("请选择蜂鸣器打开或者关闭！","系统提示");
                return;
            }
            int sum = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 14;
            data[2] = 0x5a; data[3] = 0x01; data[4] = 0xff; data[5] = 0x00;
            data[6] = 0x06; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x00;data[11] = 0x00;data[12] = 0x02;
            if (this.rad_openwifi.Checked == true)
            {
                data[13] = 0;
            }
            else
            {
                data[13] = 1;
            }
            if (this.cbxbeep.Text.Trim() == "打开")
            {
                data[14] = 0;
            }
            else
            {
                data[14] = 1;
            }
            for (int i = 3; i < 15; i++)
            {
                sum += data[i];
            }
            sum += 0x55;
            data[15] = Convert.ToByte(sum & 0Xff);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btn_setwifi_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
         //   this.cbxbeep.Text = "";
        }
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setdata_Click(object sender, EventArgs e)
        {
            this.btn_setdata.Enabled = false;
            int sum = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 16;
            data[2] = 0x5a; data[3] = 0x01; data[4] = 0xff; data[5] = 0x00;
            data[6] = 0x10; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x00; data[11] = 0x00; data[12] = 0x04;
            data[13] =Convert.ToByte( this.nudO2.Value.ToString());
            data[14] = Convert.ToByte(this.nuderror.Value.ToString());
            data[15] = Convert.ToByte(this.nudcontroltime.Value.ToString());
            data[16] = 0x00;
           // data[14] = Convert.ToByte(this.nudelelow.Value.ToString());
           //if (this.cbxbeep.Text.Trim() == "打开")
           //    data[15] = 0;
           //else
           //{
           //    data[15] = 1;
           //}
           // data[16] = Convert.ToByte(this.nudendtime.Value.ToString());
            for (int i = 0; i < 14; i++)
            {
                sum += data[i + 3];
            }
            sum += 0x55;

            data[17] = Convert.ToByte(sum & 0Xff);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btn_setdata_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
            this.nudcontroltime.Value = 0;
            this.nudO2.Value = 0;
            this.nuderror.Value = 0;
            this.nudelelow.Value = 0;
            this.nudendtime.Value = 0;


            //    objFrmsetok.ShowDialog();
          //  label25.Text = "设置成功！正在重新获取！";
            
            Thread.Sleep(1000);
            timer2.Start();
            btn_getdata_Click(null,null);
        }
        /// <summary>
        /// 设置吸氧时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setO2time_Click(object sender, EventArgs e)
        {
            int sum = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 12;
            data[2] = 0x5a; data[3] = 0x01; data[4] = 0xff; data[5] = 0x00;
            data[6] = 0x14; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x02; data[11] = Convert.ToByte(this.nudgeto2time.Text.Trim());
            data[12] = 0;
            for (int i = 0; i < 11; i++)
            {
                sum += data[i + 3];
            }
            sum += 0x5555;

            data[13] = Convert.ToByte(sum & 0Xff);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_setO2time_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 设置自动初始流量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setliu_Click(object sender, EventArgs e)
        {
            int sum = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 12;
            data[2] = 0x55; data[3] = 0xaa; data[4] = 0x00; data[5] = 0x01;
            data[6] = 0x11; data[7] = 0x30; data[8] = 0x00; data[9] = 0x00;
            data[10] = 0x01; data[11] = Convert.ToByte(this.nudflowauto.Text.Trim());
            for (int i = 0; i < 8; i++)
            {
                sum += data[i + 4];
            }
            sum += 0x5555;

            data[12] = Convert.ToByte(sum & 0Xff);
            data[13] = Convert.ToByte(sum >> 8);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_setliu_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 设置手动初始流量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            data[2] = 0x5a; data[3] = 0x01; data[4] = 0xff; data[5] = 0x00;
            data[6] = 0x16; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x00; data[11] = 0x00; data[12] = 0x01; data[13] = Convert.ToByte(this.nudflowhand.Text.Trim());
            for (int i = 0; i < 12; i++)
            {
                sum += data[i + 3];
            }
            sum += 0x55;

            data[14] = Convert.ToByte(sum & 0Xff);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void button1_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 读取时钟时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gettime_Click(object sender, EventArgs e)
        {
            timer1.Start();
            DataHelper.Flag = 2;
            int sum = 0;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 12;
            data[2] = 0x5a; data[3] = 0x00; data[4] = 0xff; data[5] = 0x00;
            data[6] = 0x0c; data[7] = 0x00; data[8] = 0x00; data[9] = 0x30;
            data[10] = 0x00;data[11] = 0x00;data[12] = 4;
            for (int i = 3; i < 13; i++)
            {
                sum += data[i];
            }
            sum += 0x55;

            data[13] = Convert.ToByte(sum & 0Xff);
            try
            {
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" private void btn_gettime_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
          //  MessageBox.Show(ConvertIntDateTime(intResult1).ToString("yyyy/MM/dd hh:mm:ss"));
        }

        public void AddReceiveInfo(byte data)
        {
            switch (DataHelper.Flag)
            {
                case 1:
                    { }
                    break;
                case 2:
                    {
                        MessageBox.Show(data.ToString());
                    }
                    break;
                case 33:
                    {
                        this.cbxf.Text = data.ToString();
                        addstates("通信成功！");
                        this.btn_getwifidata.Enabled = true;
                    }
                    break;
                case 4:
                    {


                    }
                    break;
                case 5:
                    {
                        
                    }
                    break;
                case 6:
                    {
                        this.nudgeto2time.Value = data;
                    }
                    break;
                case 7:
                    {
                        this.nudflowauto.Value = data;
                    }
                    break;
                case 8:
                    {
                        this.nudflowhand.Value = data;
                    }
                    break;
                case 9:
                    {

                    }
                    break;
            }
        }

        public void addbodyinfo(int[] data)
        {
            this.txt_xueO2.Text = data[0].ToString();
            this.txt_maino.Text = data[1].ToString();
            this.txt_liuliang.Text = data[2].ToString();
            this.txt_getO2alltime.Text = (data[3] / 10.0).ToString();
        }
        public void AddReceiveInfos(byte[] data)
        {
            switch (DataHelper.Flag)
            {
                case 1:
                    {
                        timer1.Stop();
                        byte[] data1 = new byte[2];
                        for (int i = 0; i < 2; i++)
                        {
                            data1[i] = data[i];
                        }
                    //   string str1= ToHex(data[3].ToString("X2"));
                        if (data[3] == 1)
                        {
                            this.label13.Text = "#";
                            this.checkBox1.Checked = true;
                        }
                       string str = data[2].ToString("X2");
                       int second = Convert.ToInt32(str, 16);
                       string result = Encoding.Default.GetString(data1);
                        this.txtshuzi.Text = second.ToString();
                        addstates("通信成功！");
                        this.btn_getid.Enabled = true;
                    }
                    break;
                case 2:
                    {
                        timer1.Stop();
                        string str = data[3].ToString("X2") + data[2].ToString("X2") + data[1].ToString("X2") + data[0].ToString("X2");
                       long second= Convert.ToInt64(str, 16)-8*3600;
                       this.lbltimeget.Text=ConvertIntDateTime(Convert.ToDouble(second)).ToString();
                    }
                    break;
                case 4:
                    {
                        if (data[0] != 1 && data[0] != 0)
                        {
                            MessageBox.Show("数据错误！接收到数据为：" + data.ToString(), "系统提示");
                        }
                        if (data[0] == 0)
                        {
                            this.rad_openwifi.Checked = true;
                            this.rad_closewifi.Checked = false;
                        }
                        if (data[0] == 1)
                        {
                            this.rad_openwifi.Checked = false;
                            this.rad_closewifi.Checked = true;
                        }
                        if (data[1] != 1 && data[1] != 0)
                        {
                            MessageBox.Show("数据错误！接收到数据为：" + data.ToString(), "系统提示");
                        }
                        if (data[1] == 0)
                        {
                            this.cbxbeep.Text = "打开";
                        }
                        if (data[1] == 1)
                        {
                            this.cbxbeep.Text = "关闭";
                        }
                    }
                    break;
                case 5:
                    {
                        this.nudO2.Value = data[0];
                        this.nuderror.Value = data[1];
                        this.nudcontroltime.Value = data[2];
                      //  this.label25.Text = "获取成功！";
                        addstates("通信成功！");
                        this.btn_setdata.Enabled = true;
                        this.btn_getdata.Enabled = true;
                        //this.nudelelow.Value = data[3];
                        //this.cbxbeep.Text = " ";
                        //this.nudendtime.Value = data[5];
                    }
                    break;
                case 9:
                    {
                        this.txt_xueO2.Text = data[0].ToString();
                        this.txt_maino.Text = data[1].ToString();
                        this.txt_liuliang.Text = data[2].ToString();
                        this.txt_getO2alltime.Text = (data[3]/10.0).ToString();
                    }
                    break;
            }
        }

        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }
        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }

        /// <summary>
        /// 从十进制转换到十六进制
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

        public int SixToTen(string x)
        {
            switch (x)
            {
                case "0":
                    { return 0; } 

                case "1":
                    { return 1; } 
                case "2":
                    { return 2; } 
                case "3":
                    { return 3; }
                case "4":
                    { return 4; }
                case "5":
                    { return 5; }
                case "6":
                    { return 6; }
                case "7":
                    { return 7; }

                case "8":
                    { return 8; }

                case "9":
                    { return 9; }

                case "A":
                    { return 10; }

                case "B":
                    { return 11; }

                case "C":
                    { return 12; }

                case "D":
                    { return 13; }

                case "E":
                    { return 14; }

                case "F":
                    { return 15; }

            }
            return 16;
        }
        /// <summary>
        /// 输入ID校验，封装
        /// </summary>
        /// <returns></returns>
        public byte[] DataCheck()
        {
            byte[] result = new byte[4];
            string str1 = "AA";
            string str2 = this.txtshuzi.Text.Trim();
            string str1_1 = str1[0].ToString();
            string str1_2 = str1[1].ToString();
            int res= Asc(str1_1);
            int res1 = Asc(str1_2);
            int num = Convert.ToInt32(str2);
            if (this.checkBox1.Checked == true)
            {
                
                num += 256;
            }
   
            result[0] = Convert.ToByte(res);
            result[1] = Convert.ToByte(res1);
            string numhex= Ten2Hex(num.ToString());
            if (numhex.Length == 1)
            {
                result[3] = Convert.ToByte(Convert.ToByte(SixToTen(numhex[0].ToString())));
            }
            if(numhex.Length == 2)
            {
                result[3] = Convert.ToByte(Convert.ToByte(SixToTen(numhex[0].ToString())) * 16 + Convert.ToByte(SixToTen(numhex[1].ToString())));
            }
            if(numhex.Length == 3)
            {
                result[3] = Convert.ToByte(Convert.ToByte(SixToTen(numhex[1].ToString())) * 16 + Convert.ToByte(SixToTen(numhex[2].ToString())));
                result[2] = Convert.ToByte(SixToTen(numhex[0].ToString()));
            }
            return result;
            //MessageBox.Show(result[0].ToString()+"**" + result[1].ToString()+"**" + result[2].ToString()+"**" + result[3].ToString());
        }
        /// <summary>
        /// 获取一个字母的ASC值
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                SQLiteHelper.WriteLog(" public static int Asc(string character)", "Character is not valid.");
                throw new Exception("Character is not valid.");
            }
        }
        /// <summary>
        /// 设置ID号码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setid_Click_1(object sender, EventArgs e)
        {
            if (this.txtshuzi.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入正确的床号！0~255！", "系统提示");
                return;
            }
            DataHelper.Flag = 1;
            string str1 = "AA";
            int str2=0;
            try
            {
               str2 = Convert.ToInt16(this.txtshuzi.Text.Trim());
            }
            catch (Exception)
            {

                MessageBox.Show("请输入正确的床号！0~255！", "系统提示");
                return;
            }
           
            if (str2>=256)
            {
                MessageBox.Show("请输入正确的床号！0~255！","系统提示");
                return;
            }
            if (checkBox1.Checked == true)
            {
                str2 += 256;
            }

            string str1_1 = str1[0].ToString();
            string str1_2 = str1[1].ToString();
            int res = Asc(str1_1);
            int res1 = Asc(str1_2);
            int num = Convert.ToInt32(str2);
            
            byte[] datarece = new byte[4];
            byte[] data = new byte[33];
            int checksum = 0;
            datarece = DataCheck();
            try
            {
                data[0] = 0;
                data[1] = 16;
                data[2] = 0x5a;data[3] = 0x01;data[4] = 0xff;data[5] = 0x00;data[6] = 0x02;data[7] = 0x00;
                data[8] = 0x00;data[9] = 0x30;data[10] = 0x00;data[11] = 0x00;data[12] = 4;data[13] = datarece[0];
                data[14] = datarece[1];data[15] = datarece[3];data[16] = datarece[2];
                for (int i = 3; i < 17; i++)
                {
                    checksum += data[i];
                }
                checksum += 0x55;
                checksum = checksum & 0Xff;
                data[17] = Convert.ToByte(checksum);
                if (this.usbhid3.SpecifiedDevice != null)
                {
                    // Thread.Sleep(500);
                    this.usbhid3.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("private void btn_setid_Click_1(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
          //  this.txtshuzi.Text = "";
            timer2.Start();
        }

        public string ToHex(string str)
        {
            switch (str)
            {
                case "00":
                    { return ""; }
                case "01":
                    { return "1"; }
                case "02":
                    { return "2"; }
                case "03":
                    { return "3"; }
                case "04":
                    { return "4"; }
                case "05":
                    { return "5"; }
                case "06":
                    { return "6"; }
                case "07":
                    { return "7"; }
                case "08":
                    { return "8"; }
                case "09":
                    { return "9"; }
                case "0A":
                    { return "A"; }
                case "0B":
                    { return "B"; }
                case "0C":
                    { return "C"; }
                case "0D":
                    { return "D"; }
                case "0E":
                    { return "E"; }
                case "0F":
                    { return "F"; }

            }
            return "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            switch (DataHelper.Flag)
            {
                case 1:
                    {
                        if (count < 5)
                        {
                            btn_getid_Click(null, null);
                        }
                        else
                        {
                            timer1.Stop();
                            count = 0;
                        }
                       
                    }
                    break;
                case 2:
                    {
                        if (count < 5)
                        {
                            btn_gettime_Click(null, null);
                        }
                        else
                        {
                            timer1.Stop();
                            count = 0;
                        }
                        
                    }
                    break;
            }
        }

        private void btnreadsave_Click(object sender, EventArgs e)
        {

        }

        private void btnclearsave_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.label13.Text = "#";
            }
            else
            {
                this.label13.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            addstates("");
            timer2.Stop();
        }
    }
}
