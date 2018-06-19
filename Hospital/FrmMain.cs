
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Models;
using DAL;
using UsbLibrary;
using static Hospital.FrmSlave;
using Protocol;
using System.Threading;
using static Hospital.FrmDataSave;
using static Hospital.FrmReceiver;
using System.Data;
using System.Management;
using static Hospital.FrmSystemset;
using static Hospital.FrmPatientInfo;
using System.IO;
using System.Text;

namespace Hospital
{
    /// <summary>
    /// 委托声明
    /// </summary>
    #region
    public delegate void btndelegate();
    public delegate void selectBtn();
    public delegate void exportBtn();
    public delegate void connectBtn();
    public delegate void openBtn();
    public delegate void SetColor(Color c);

    public delegate void setbed();
    public delegate void SetWifi(byte[] connand);
    public delegate void addshowblock(int x, int y);
    public delegate void addPatientInfo(PatientInfo objPatientInfo);
    public delegate void setpart();
    public delegate void AddHospitalInfo(HospitalInfo objHospitalInfo);
    #endregion
    /// <summary>
    /// 显示界面
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 变量声明
        /// </summary>
        #region
        
        public selectBtn objselectBtn;
        public exportBtn objexportBtn;
        public connectBtn objconnectBtn;
        public openBtn objopenBtn;
        public addstate Addstate;
        public adddata Adddata;
        public static GetInfo getinfo;
        public static Addbodyinfo addbodyinfo;
        public static GetInfos getinfos;
        public static AddLRNum addLRNum;
        public static ADDHD addHD;
        public static AddRegisterdata addRegisterdata;
        public bool Save_flag = true;
        public int Portcount = 0;
        public int Sendcount = 0;
        int count = 0;
        int countflag = 1;
     //   int y = 0;
        //  int bed_count = 0;
        int[] INFO = new int[10];
        SetInfo objSetInfo = new SetInfo();
        public static bool closeflag = true;
        DataHelper objDataHelper = new DataHelper();
        public WindowsFormsShow.UserControl2 u2 = null;
        public List<int> bednum = new List<int>();
        public List<byte> datarece = new List<byte>();
        public List<PatientBodyInfo> Patientdata = new List<PatientBodyInfo>();
        public List<PatientInfo> bed_name = new List<PatientInfo>();
        public List<PatientInfo> additionalbed_name = new List<PatientInfo>();
        public static List<WindowsFormsShow.UserControl2> MyShowblock = new List<WindowsFormsShow.UserControl2>();//存储控件的集合
        public static List<WindowsFormsShow.UserControl2> MyShowblock1 = new List<WindowsFormsShow.UserControl2>();//存储全部控件的集合
        WindowsFormsShow.UserControl2[] MyShowblock3 = new WindowsFormsShow.UserControl2[1000];
        int[] patientsstate = new int[1000];

        PatientBodyInfo[] f15min_Info = new PatientBodyInfo[200];

         BedConfigInfoService objBedConfigInfoService = new BedConfigInfoService();
        PatientService objPatientService = new PatientService();
        SetInfoService objSetInfoService = new SetInfoService();
        ShowInfoService objShowInfoService = new ShowInfoService();
        HospitalInfoService objHospitalInfoService = new HospitalInfoService();
        PatientBodyInfoService objPatientBodyInfoService = new PatientBodyInfoService();
        PatirntSaveDataService objPatirntSaveDataService = new PatirntSaveDataService();
        AdditionalPatientsService objAdditionalPatientsService = new AdditionalPatientsService();
        List<PatientInfo> cutList = new List<PatientInfo>();//存储中断床位
        //public System.Timers.Timer Timers_Timer = null;
        public bool Deviceflag;
        System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置间隔时间为10000毫秒； 

        Object thisLock = new Object();


       // Thread th = null;
        //Thread th = null;
        #endregion
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        /// <summary>
        /// MIAN函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            GetUUID();
            this.toolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Left;
            SetbedInfo();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)； 
                               //   t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件

            for (int i = 0; i < 200; i++)
            {
                f15min_Info[i] = new PatientBodyInfo();
                f15min_Info[i].PatientBednum = -1;
            }
        }


        private void 系统配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Commen.IsOpen)
            //{
            //    MessageBox.Show("请先关闭监控！","系统提示！");
            //    return;
            //}
            FrmSystemset objFrmSystemset = new FrmSystemset(Deviceflag);
            FrmSlave objFrmSlave = new FrmSlave();
            objFrmSystemset.usbhid1 = this.usb;
            this.Addstate = objFrmSystemset.state;
            objFrmSystemset.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 界面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmshowWindowset objFrmshowWindowset = new FrmshowWindowset();
            objFrmshowWindowset.addblock = this.addShowblock;//子窗口委托关联主窗口的方法
            objFrmshowWindowset.Setpartbed = this.SetbedInfo;
            objFrmshowWindowset.addhospitalinfo = this.AddHospitalInfo;
            objFrmshowWindowset.setColor = this.SetColor;
            objFrmshowWindowset.ShowDialog();
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            Read();
            Connectdevice();

            //th = new Thread(AskInfo);
            //th.IsBackground = true;
        }

        public void  Read()
        {
            StreamReader sr = new StreamReader("Color.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string c=  line.ToString();
                try
                {
                    Convert.ToInt32("0x"+c,16);
                    Color d = ColorTranslator.FromHtml("#" + c);
                    SetColor(d);
                }
                catch (Exception)
                {
                    Color d = ColorTranslator.FromHtml( c);
                    SetColor(d);
                }

               
            }
            sr.Close();
        }
        public void AddHospitalInfo(HospitalInfo objHospitalInfo)
        {
            this.toolStripStatusLabel7.Text = objHospitalInfo.HospitalName.ToString();
            this.toolStripStatusLabel9.Text = objHospitalInfo.Department;
        }
        /// <summary>
        /// 检测到设备询问设备类型
        /// </summary>
        public void IS_receiver_or_slave()
        {
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    DataHelper.Flag = 10;
                    Thread.Sleep(1000);
                    this.usb.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.Isreceuverorslave));
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public void IS_receiver_or_slave()", ex.ToString ());
            }
        }
        /// <summary>
        /// 病人出院
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_endBtnClick(object sender, EventArgs e)
        {
            string str2 = "";
            int flag = 0;
            int flag1 = 0;
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
            flag1 = objShowInfo.AllOrPart;
            if (flag1 == 0)
            {
                for (int i = 0; i < MyShowblock.Count; i++)
                {
                    if (btn.Tag.ToString() == MyShowblock[i].Bednum)
                    {
                        if (Convert.ToInt16(MyShowblock[i].Bednum) > 255)
                        {
                            str2 = "#" + (Convert.ToInt16(MyShowblock[i].Bednum) - 256).ToString();
                        }
                        else
                        {
                            str2 = MyShowblock[i].Bednum;
                        }
                        
                        flag = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < MyShowblock1.Count; i++)
                {
                    if (btn.Tag.ToString() == MyShowblock1[i].Bednum)
                    {
                        if (Convert.ToInt16(MyShowblock1[i].Bednum) > 255)
                        {
                            str2 = "#" + (Convert.ToInt16(MyShowblock1[i].Bednum) - 256).ToString();
                        }
                        else
                        {
                            str2 = MyShowblock1[i].Bednum;
                        }
                       
                        flag = i;
                        break;
                    }
                }
            }


            DialogResult result = MessageBox.Show("确定为" + str2 + "床病人办理出院手续吗？", "系统提示!",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (Convert.ToInt16(btn.Tag) > 255)
            {
                objAdditionalPatientsService.addendtime(Convert.ToInt32(btn.Tag));
                objAdditionalPatientsService.setuseflag(Convert.ToInt32(btn.Tag));
                objPatientBodyInfoService.setuseflag1(Convert.ToInt32(btn.Tag));

            }
            else
            {
                int a = objPatientService.addendtime(Convert.ToInt32(str2));
                int result1 = objPatientService.setuseflag(Convert.ToInt32(Convert.ToInt32(str2)));
                objPatientBodyInfoService.setuseflag1(Convert.ToInt32(str2));
                int result13 = objSetInfoService.delSetInfo(Convert.ToInt32(str2));
            }



            if (flag1 == 0)
            {
                MyShowblock[flag].myBackColor = Color.LightCyan;
                MyShowblock[flag].Peoplename = "";
                MyShowblock[flag].Falg = true;
                MyShowblock.RemoveAt(flag);
               // WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();
                MyShowblock3[Convert.ToInt16((btn.Tag))]= null;
             //   MessageBox.Show(str2 + "号床病人成功出院！", "系统提示");
                Shuaxinpart();
            }
            else
            {
                for (int i = 0; i < MyShowblock.Count; i++)
                {
                    if (MyShowblock[i].Bednum == (btn.Tag).ToString())
                    {
                        MyShowblock.RemoveAt(i);
                        break;
                    }
                   
                }               
                MyShowblock1[flag].myBackColor = Color.LightCyan;
                MyShowblock1[flag].Peoplename = "";
                MyShowblock1[flag].Falg = true;
                SetbedInfo();
               // MessageBox.Show(str2 + "号床病人成功出院！", "系统提示");

            }

        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_writeBtnClick(object sender, EventArgs e)
        {
            string bednum = "";
            string FFlag =string.Empty;
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
            if (objShowInfo.AllOrPart == 1)
            {
                
                bednum = btn.Tag.ToString();
                for (int i = 0; i < MyShowblock1.Count; i++)
                {
                    if (btn.Tag.ToString() == MyShowblock1[i].Bednum.ToString())
                    {
                        FFlag = i.ToString();
                    }
                }
                      //  PatientInfo objPatientInfo = objPatientService.GetPatientInfoBybednum(Convert.ToInt32(bednum));

                        PatientInfo objPatientInfo = null;
               
                FrmPatientInfoRevise objFrmPatientInfoRevise = null;
                
                for (int i = 0; i < MyShowblock.Count; i++)
                {
                    if (btn.Tag.ToString() == MyShowblock[i].Bednum)
                    {

                        bednum = MyShowblock[i].Bednum;
                        int bednum1 = Convert.ToInt32(bednum);
                        if (bednum1 < 256)
                        {
                            objPatientInfo = objPatientService.GetPatientInfoBybednum(bednum1);
                        }
                        else
                        {
                            objPatientInfo = objAdditionalPatientsService.GetPatientInfoBybednum(bednum1);
                        }
                        objPatientInfo.flag =Convert.ToInt16(FFlag);
                        objFrmPatientInfoRevise= new FrmPatientInfoRevise(objPatientInfo, bednum,false);
                        objFrmPatientInfoRevise.ShowDialog();

                        return;
                    }
                  
                }

                //        objPatientInfo.flag = i;
                //        objPatientInfo.PatientBednum =( i + 1).ToString();
                //        objPatientInfo.PatientAge = "未录入";
                //        objPatientInfo.PatientName = "未录入";
                //        objPatientInfo.PatientGender = "未录入";
                //        objPatientInfo.PatientDepartment = "未录入";
                //        objPatientInfo.PatientNum = "未录入";
                //        objPatientInfo.Patientstarttime = DateTime.Now;
                        NewMyport((Convert.ToInt16(bednum)));
                         objFrmPatientInfoRevise = new FrmPatientInfoRevise(objPatientInfo, bednum,true);
                        objFrmPatientInfoRevise.ShowDialog();
                  //  }
               // }
            }
            else
            {
                PatientInfo objPatientInfo = null;
                for (int i = 0; i < MyShowblock.Count; i++)
                {
                    if (btn.Tag.ToString() == MyShowblock[i].Bednum)
                    {

                        bednum = MyShowblock[i].Bednum;
                        int bednum1 = Convert.ToInt32(bednum);
                        if (bednum1 < 256)
                        {
                             objPatientInfo = objPatientService.GetPatientInfoBybednum(bednum1);
                        }
                        else
                        {
                             objPatientInfo = objAdditionalPatientsService.GetPatientInfoBybednum(bednum1);
                        }
                     //   PatientInfo objPatientInfo = objPatientService.GetPatientInfoBybednum(Convert.ToInt32(bednum));
                        objPatientInfo.flag = i;
                        FrmPatientInfoRevise objFrmPatientInfoRevise = new FrmPatientInfoRevise(objPatientInfo,bednum,false);
                        objFrmPatientInfoRevise.ShowDialog();
                    }
                }

            }



        }

        /// <summary>
        /// 录入信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_getBtnClick(object sender, EventArgs e)
        {
            //ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            //string bednum = MyShowblock[Convert.ToInt32(btn.Tag)].Bednum;
            //FrmPatientInfo objFrmPatientInfo = new FrmPatientInfo(bednum);
            //objFrmPatientInfo.ShowDialog();

        }
        /// <summary>
        /// 打开监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_openBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string str1 = MyShowblock[Convert.ToInt32(btn.Tag)].Peoplename;
            string str2 = MyShowblock[Convert.ToInt32(btn.Tag)].Bednum;

            MessageBox.Show(str2);
        }
        /// <summary>
        /// 数据连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_connectBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string str1 = MyShowblock[Convert.ToInt32(btn.Tag)].Peoplename;
            string str2 = MyShowblock[Convert.ToInt32(btn.Tag)].Bednum;

            MessageBox.Show(str1 + " " + str2);
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_exportBtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string str2 = "";
            for (int i = 0; i < MyShowblock.Count; i++)
            {
                if (MyShowblock[i].Bednum == btn.Tag.ToString())
                {
                    str2 = MyShowblock[i].Bednum;
                    break;
                }
            }
            if (str2 == "")
            {
                MessageBox.Show("该床未录入病人信息！","系统提示！");
                return;
            }
            FrmDataExport objFrmDataExport = new FrmDataExport(str2);
            objFrmDataExport.ShowDialog();


        }
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U_selectBtnClick(object sender, EventArgs e)
        {
            PatientInfo objPatientInfo = null;
            Button btn = (Button)sender;
            if (Convert.ToInt16(btn.Tag) > 255)
            {
                objPatientInfo = objAdditionalPatientsService.GetPatientInfoBybednum((Convert.ToInt32(btn.Tag)));
            }
            else
            {
                 objPatientInfo = objPatientService.GetPatientInfoBybednum((Convert.ToInt32(btn.Tag)));
            }
            
            if (objPatientInfo == null) return;
            FrmSelectPatientInfo objFrmSelectPatientInfo = new FrmSelectPatientInfo(objPatientInfo);
            objFrmSelectPatientInfo.ShowDialog();


        }
        /// <summary>
        /// 添加显示控件
        /// </summary>
        /// <param name="bencount"></param>
        /// <param name="bedrow"></param>
        public void addShowblock(int bencount, int bedrow)
        {
            int lastx, lasty,lastj=0;
            this.添加病床ToolStripMenuItem.Text = "添加额外病床";
            
            int x = 0, y = 20, j = 0;
            //  MyShowblock.RemoveRange(0, MyShowblock.Count);
            this.panel_window1.Controls.Clear();
            for (int i = 0; i < bencount; i++)//动态添加控件
            {
                x = j * 220 + 60;
                WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();
                if (i >= bedrow)
                {
                    y = (i / bedrow) * 270 + 20;
                }
                u.Location = new Point(x, y);
                j++;
                if (j == bedrow) j = 0;
                u.Tag = i + 1;
                u.selectBtnClick += U_selectBtnClick;
                u.exportBtnClick += U_exportBtnClick;
                u.connectBtnClick += U_connectBtnClick;
                u.openBtnClick += U_openBtnClick;
                u.getBtnClick += U_getBtnClick;
                u.writeBtnClick += U_writeBtnClick;
                u.endBtnClick += U_endBtnClick;
                u.Btnexporttag = i + 1;
                u.Btnpipeitag = i + 1;
                u.Btnselecttag = i + 1;
                u.Btnstarttag = i + 1;
                
                u.WriteToolStripMenuItemtag = i + 1;
                u.GetToolStripMenuItemtag = i + 1;
                u.EndToolStripMenuItemtag = i + 1;
                u.Bednum = (i + 1).ToString();
                MyShowblock1.Add(u);
                this.panel_window1.Controls.Add(u);
            }
            lastx = MyShowblock1[MyShowblock1.Count - 1].Location.X;
            lasty = MyShowblock1[MyShowblock1.Count - 1].Location.Y;
            for (int a = 0; a < MyShowblock.Count; a++)
            {
                for (int i = 0; i < MyShowblock1.Count; i++)
                {
                    if (MyShowblock[a].Bednum == MyShowblock1[i].Bednum)
                    {
                        MyShowblock1[i].Peoplename = MyShowblock[a].Peoplename;
                        MyShowblock1[i].Falg = false;
                        MyShowblock1[i].myBackColor = Color.DeepSkyBlue;
                    }
                }
            }



            if (bencount % bedrow == 0)
            {
                lasty = MyShowblock1[MyShowblock1.Count - 1].Location.Y + 20;
                lastx = 0;
            }
            else
            {
                lasty = MyShowblock1[MyShowblock1.Count - 1].Location.Y + 290;
                lastx = 0;
            }
            for (int i = 0; i < additionalbed_name.Count; i++)//动态添加额外控件
            {
                lastx = lastj * 220 + 60;
                WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();
                if (i >= bedrow)
                {
                    lasty = (i / bedrow) * 270 + 20;
                }
                u.Location = new Point(lastx, lasty);
                lastj++;
                if (lastj == bedrow) lastj = 0;
                u.Tag = additionalbed_name[i].PatientBednum;
                u.selectBtnClick += U_selectBtnClick;
                u.exportBtnClick += U_exportBtnClick;
                u.connectBtnClick += U_connectBtnClick;
                u.openBtnClick += U_openBtnClick;
                u.getBtnClick += U_getBtnClick;
                u.writeBtnClick += U_writeBtnClick;
                u.endBtnClick += U_endBtnClick;
                u.Btnexporttag =Convert.ToInt16( additionalbed_name[i].PatientBednum);
                u.Btnpipeitag = Convert.ToInt16(additionalbed_name[i].PatientBednum);
                u.Btnselecttag = Convert.ToInt16(additionalbed_name[i].PatientBednum);
                u.Btnstarttag = Convert.ToInt16(additionalbed_name[i].PatientBednum);
                u.WriteToolStripMenuItemtag = Convert.ToInt16(additionalbed_name[i].PatientBednum);
                u.GetToolStripMenuItemtag = Convert.ToInt16(additionalbed_name[i].PatientBednum);
                u.EndToolStripMenuItemtag = Convert.ToInt16(additionalbed_name[i].PatientBednum);
                u.Bednum = additionalbed_name[i].PatientBednum;
                u.myBackColor = Color.DeepSkyBlue;
                MyShowblock1.Add(u);

               // this.panel_window1
                this.panel_window1.Controls.Add(u);
            }
        }
        /// <summary>
        /// 显示上次退出程序时的界面
        /// </summary>
        public void SetbedInfo()
        {
            this.panel_window1.Controls.Clear();
            MyShowblock.RemoveRange(0, MyShowblock.Count);
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
            HospitalInfo objHospitalInfo = objHospitalInfoService.GetHospitalInfo();
            if (objHospitalInfo != null)
            {
                this.toolStripStatusLabel7.Text = objHospitalInfo.HospitalName.ToString();
                this.toolStripStatusLabel9.Text = objHospitalInfo.Department;
            }
            else
            {
                this.toolStripStatusLabel7.Text = "未设置";
                this.toolStripStatusLabel9.Text = "未设置";
            }
            bed_name = objPatientService.Getbednumandname();
            additionalbed_name = objAdditionalPatientsService.Getadditionalbednumandname();
            for (int i = 0; i < additionalbed_name.Count; i++)
            {
                bed_name.Add(additionalbed_name[i]);
            }
            if (objShowInfo.AllOrPart == 0)
            {
                this.添加病床ToolStripMenuItem.Text = "添加病床";
                for (int i = 0; i < bed_name.Count; i++)
                {
                    WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();
                    u.Location = new Point(i * 300, 10);

                    u.Peoplename = bed_name[i].PatientName;
                    //if (bed_name[i].PatientBednum > 255)
                    //{
                    //    u.Bednum = "#" + (bed_name[i].PatientBednum - 256).ToString();
                    //    u.Tag = bed_name[i].PatientBednum;
                    //}
                    //else
                    {
                        u.Bednum =(bed_name[i].PatientBednum ).ToString();
                    }
                    u.Falg = false;//如果已经录入，失能按钮
                    u.myBackColor = Color.DeepSkyBlue;
                    
                    u.Btnexporttag =Convert.ToInt16( bed_name[i].PatientBednum);
                    u.Btnpipeitag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.Btnselecttag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.Btnstarttag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.WriteToolStripMenuItemtag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.GetToolStripMenuItemtag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.EndToolStripMenuItemtag = Convert.ToInt16(bed_name[i].PatientBednum);
                    //u.selectBtnClick += U_selectBtnClick;
                    //u.exportBtnClick += U_exportBtnClick;
                    //u.connectBtnClick += U_connectBtnClick;
                    //u.openBtnClick += U_openBtnClick;
                    //u.getBtnClick += U_getBtnClick;
                    //u.writeBtnClick += U_writeBtnClick;
                    //u.endBtnClick += U_endBtnClick;
                    MyShowblock3[Convert.ToInt16(bed_name[i].PatientBednum)] = u;
                    AddPatientBed(u);

                    MyShowblock.Add(u);
                }
            }
            else
            {
                this.添加病床ToolStripMenuItem.Text = "加额外病床";
                for (int i = 0; i < bed_name.Count; i++)
                {
                    WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();

                    u.Peoplename = bed_name[i].PatientName;
                    u.Bednum = bed_name[i].PatientBednum.ToString();
                    u.Falg = false;//如果已经录入，失能按钮
                    u.myBackColor = Color.DeepSkyBlue;
                    //u.O2 = MyShowblock[i].O2;
                    u.Btnexporttag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.Btnpipeitag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.Btnselecttag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.Btnstarttag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.WriteToolStripMenuItemtag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.GetToolStripMenuItemtag = Convert.ToInt16(bed_name[i].PatientBednum);
                    u.EndToolStripMenuItemtag = Convert.ToInt16(bed_name[i].PatientBednum);
                    //u.selectBtnClick += U_selectBtnClick;
                    //u.exportBtnClick += U_exportBtnClick;
                    //u.connectBtnClick += U_connectBtnClick;
                    //u.openBtnClick += U_openBtnClick;
                    //u.getBtnClick += U_getBtnClick;
                    //u.writeBtnClick += U_writeBtnClick;
                    //u.endBtnClick += U_endBtnClick;
                    MyShowblock.Add(u);
                }

                BedConfigInfo objBedConfigInfo = objBedConfigInfoService.GetBedInfoByBedflag(1);
                int bencount = objBedConfigInfo.Bedcount;

                int bedrow = objBedConfigInfo.Bedrows;
                addShowblock(bencount, bedrow);
               
            }

            Read();
        }
        /// <summary>
        /// 将录入的信息加载到显示窗口
        /// </summary>
        /// <param name="objPatientInfo"></param>
        public void AddPatientInfo(PatientInfo objPatientInfo)
        {

            if (objPatientInfo == null)
            {
                return;
            }
            for (int i = 0; i < MyShowblock.Count; i++)
            {
                if (MyShowblock[i].Bednum == objPatientInfo.PatientBednum.ToString())
                {
                    MyShowblock[i].Peoplename = objPatientInfo.PatientName;
                    MyShowblock[i].Falg = false;//如果已经录入，失能按钮
                    MyShowblock[i].myBackColor = Color.DeepSkyBlue;
                    break;
                }
            }
            Read();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel4.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.toolStripStatusLabel3.Text = "当前住院人数：" + MyShowblock.Count.ToString() + "人";

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问",
    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {  
                e.Cancel = true;
            }
        }

        private void 全部开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.usb.SpecifiedDevice == null)
            {
                MessageBox.Show("请先连接设备！","系统提示！");
                return;
            }
   
            if (this.全部开启ToolStripMenuItem.Text == "开启监控")
            {

                MyShowblock.RemoveRange(0,MyShowblock.Count);
                MyShowblock1.RemoveRange(0, MyShowblock.Count);
                SetbedInfo();
                DataHelper.Flag = 0;
                SendInfo();              
                Commen.stop = 1;
                Thread    th = new Thread(AskInfo);
                th.IsBackground = true;
                th.Start();
                timer3.Start();
                this.全部开启ToolStripMenuItem.BackColor = Color.Pink;
                this.全部开启ToolStripMenuItem.Text = "关闭监控";
            }
            else
            {
                Commen.stop = 0;
                t.Stop();
                timer3.Stop();
                this.全部开启ToolStripMenuItem.BackColor = Color.LightBlue;
                this.全部开启ToolStripMenuItem.Text = "开启监控";
            }

        }

        #region//USB操作

        /// <summary>
        /// 连接设备
        /// </summary>
        public void Connectdevice()
        {
            try
            {
                this.usb.ProductId = Int32.Parse("e010", System.Globalization.NumberStyles.HexNumber);
                this.usb.VendorId = Int32.Parse("1a86", System.Globalization.NumberStyles.HexNumber);
                bool flag = this.usb.CheckDevicePresent();
                if (flag)
                {
                    Deviceflag = true;
                }
                else { MessageBox.Show("请检查设备是否连接！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }

            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog(" public void Connectdevice()",ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            // this.toolStripStatusLabel5.Text = "找到新设备！";
        }

        private void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            // this.toolStripStatusLabel5.Text = "设备移除！";
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            this.toolStripStatusLabel5.ForeColor = Color.Red;
            Deviceflag = true;
            this.toolStripStatusLabel5.Text = "连接到设备";
            Thread th = new Thread(IS_receiver_or_slave);
            th.IsBackground = true;
            th.Start();
            if (Addstate == null)
            {
                return;
            }
            else
            {
                Addstate("连接到设备");
            }
          
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            Deviceflag = false;
            Commen.IsOpen = false;
            t.Stop();
            this.toolStripStatusLabel5.Text = "设备已移除";
            this.全部开启ToolStripMenuItem.BackColor = Color.LightBlue;
            this.全部开启ToolStripMenuItem.Text = "开启监控";
            //所有设备显示连接中断
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
            if (objShowInfo.AllOrPart == 0)
            {

                for (int i = 0; i < MyShowblock.Count; i++)
                {
                    MyShowblock[i].Lblbackcolor = Color.Red;
                    MyShowblock[i].myBackColor = Color.Red;
                    MyShowblock[i].State = "连接中断";
                    MyShowblock[i].O2 = "连接中断";
                    MyShowblock[i].O2flow = "连接中断";
                    MyShowblock[i].Bpm = "连接中断";
                    MyShowblock[i].Time = "连接中断";
                }

            }


            else
            {
                for (int i = 0; i < MyShowblock1.Count; i++)
                {

                    //异常判断
                    if (INFO[4].ToString() == MyShowblock1[i].Bednum)
                    {
                        MyShowblock1[i].Lblbackcolor = Color.Red;
                        MyShowblock1[i].myBackColor = Color.Red;
                        MyShowblock1[i].State = "连接中断";
                        MyShowblock1[i].O2 = "连接中断";
                        MyShowblock1[i].O2flow = "连接中断";
                        MyShowblock1[i].Bpm = "连接中断";
                        MyShowblock1[i].Time = "连接中断";
                    }
                }
            }
            //FrmslaveRemove objFrmslaveRemove = new FrmslaveRemove();
            //objFrmslaveRemove.ShowDialog();
            //objFrmslaveRemove.Dispose();

            if (Addstate == null)
            {
                return;
            }
            else
            {
                Addstate("设备已移除");
            }

        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usb.RegisterHandle(Handle);
        }
        protected override void WndProc(ref Message m)
        {
            usb.ParseMessages(ref m);
            base.WndProc(ref m);	// pass message on to base form
        }

        private void usb_OnDataSend(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            datarece.RemoveRange(0, datarece.Count);
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new DataRecievedEventHandler(usb_OnDataRecieved), new object[] { sender, args });
                }
                catch (Exception ex)
                {
                    SQLiteHelper.WriteLog("private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)",ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {

                string rec_data = "";
                foreach (byte myData in args.data)
                {
                    rec_data += myData.ToString("X2") + " ";
                    datarece.Add(myData);
                }
                // Adddata("RECE:" + rec_data+"  //  "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                switch (DataHelper.Flag)
                {
                    case 0:
                        {
                           // this.timer_send_command.Stop();
                            //Timers_Timer.Stop();
                            t.Stop();
                            Commen.IsOpen = true;
                            rece_USB(datarece, rec_data);
                        }
                        break;
                    case 1:
                        {
                            getinfos(objDataHelper.GetID(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 2:
                        {
                            getinfos(objDataHelper.GetTime(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 33:
                        {
                            getinfo(objDataHelper.GetWifiInfo(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 4:
                        {
                            getinfos(objDataHelper.GetWifiOnOff(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 5:
                        {
                            getinfos(objDataHelper.GetSetInfo(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 6:
                        {
                            getinfo(objDataHelper.GetGetO2Time(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 7:
                        {
                            getinfo(objDataHelper.GetAutoFlow(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 8:
                        {
                            getinfo(objDataHelper.GetHandFlow(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 9:
                        {
                            addbodyinfo(objDataHelper.GetInfoNOW(datarece));
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 10:
                        {
                            if (datarece[13] == 1)
                            {
                                //FrmReceiverorSlave objFrmReceiverorSlave = new FrmReceiverorSlave("当前连接设备为接收机！");
                                //objFrmReceiverorSlave.ShowDialog();
                                this.toolStripStatusLabel5.Text = "当前连接设备为接收机！";
                                datarece.RemoveRange(0, datarece.Count);
                                //objFrmReceiverorSlave.Dispose();
                            }
                            else if (datarece[13] == 2)
                            {
                                //FrmReceiverorSlave objFrmReceiverorSlave = new FrmReceiverorSlave("当前连接设备为监护仪！");
                                //objFrmReceiverorSlave.ShowDialog();
                                this.toolStripStatusLabel5.Text = "当前连接设备为监护仪！";
                                datarece.RemoveRange(0, datarece.Count);
                                //objFrmReceiverorSlave.Dispose();
                            }

                        }
                        break;
                    case 11:
                        {
                            if (DataHelper.GetSaveDataCount(datarece))
                            {
                                ReadSaveData();
                                datarece.RemoveRange(0, datarece.Count);
                            }
                        }
                        break;
                    case 12:
                        {
                            ReadRegister();
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 13:
                        {
                            objPatirntSaveDataService.AddPatientSaveInfo(DataHelper.ProtocolaSqlSavedata(DataHelper.GetRegisterdata(datarece)));
                            datarece.RemoveRange(0, datarece.Count);
                            if (DataHelper.senddatacont < DataHelper.datacont)
                            {
                                ReadSaveData();
                            }
                            else
                            {
                                ReadRegisterOver();
                            }

                        }
                        break;
                    case 14:
                        {
                            getdatacount();
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        break;
                    case 15:
                        {
                            addRegisterdata();

                        }
                        break;
                    case 16:
                        {
                            WriteDepartmentName();
                        }
                        break;
                    case 17:
                        {
                            addLRNum(DataHelper.GetLRnum(datarece));
                        }
                        break;
                    case 18:
                        {
                            WriteHospitalName();
                        }
                        break;
                    case 19:
                        {
                            datarece.RemoveRange(0, datarece.Count);
                            //none
                        }
                        break;
                    case 21:
                        {
                            WriteHospitalANDDepartmentover();
                            DataHelper.Flag = 19;
                        }
                        break;
                    case 22:
                        {
                            sendzero();
                            DataHelper.Flag = 55;
                        }
                        break;
                    case 55:
                        {
                            sendzero();
                            DataHelper.Flag = 21;
                        }
                        break;
                    case 23:
                        {
                            sendHzero();
                            DataHelper.Flag = 56;
                        }
                        break;
                    case 56:
                        {
                            sendHzero();
                            DataHelper.Flag = 16;
                        }
                        break;
                    case 20:
                        {
                            switch (DataHelper.ISHORD)
                            {

                                case 0:
                                    {
                                       
                                        DataHelper.GetHandDdata(datarece);
                                        datarece.RemoveRange(0, datarece.Count);
                                        ReadHospitalANDDepartment();
                                        DataHelper.HDdatacount++;
                                        if (DataHelper.HDdatacount > 8)
                                        {
                                            DataHelper.Flag = 19;
                                            DataHelper.HDdatacount = 0;
                                            DataHelper.CommandReadHospitalName[4] = 0x30;
                                            DataHelper.CommandReadDepartmentName[4] = 0x70;
                                            addHD(DataHelper.ProHDdata());

                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }

            }
        }
        #endregion

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            // this.panel_window.Size = this.Size;
        }

        private void 添加病床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();
            FrmPatientInfo objFrmPatientInfo = new FrmPatientInfo(this.添加病床ToolStripMenuItem.Text.Trim());
            objFrmPatientInfo.u3 = u;
            objFrmPatientInfo.addinfo = this.AddPatientInfo;
            objFrmPatientInfo.Setbed = this.SetbedInfo;
            objFrmPatientInfo.ShowDialog();
            if (DataHelper.Flagexit)
            {
                MyShowblock.Add(u);
                PatientInfo objPatientInfo = new PatientInfo();
                objPatientInfo.PatientBednum = (u.Bednum).ToString();
                AddPatientInfo(objPatientInfo);
                Shuaxin();
            }
            DataHelper.Flagexit = false;
        }

        /// <summary>
        /// 添加病床
        /// </summary>
        public void AddPatientBed(WindowsFormsShow.UserControl2 u)
        {


            BedConfigInfo objBedConfigInfo = objBedConfigInfoService.GetBedInfoByBedflag(1);
            int bencount = objBedConfigInfo.Bedcount;

            int bedrow = objBedConfigInfo.Bedrows;
            if (MyShowblock.Count > bencount)
            {
                MessageBox.Show("床位到达上限！", "系统提示");
                return;
            }
            //  int a = Convert.ToInt16(objSetInfoService.GetCount());
            int a = MyShowblock.Count;

            if (a < bedrow)
            {
                u.Location = new Point(a * 220 + 40, 20);

            }
            else
            {

                int row1 = a / bedrow;
                int lastcount = a % bedrow;
                u.Location = new Point(lastcount * 220 + 40, 20 + 280 * row1);

            }

            count++;
            countflag++;
            u.selectBtnClick += U_selectBtnClick;
            u.exportBtnClick += U_exportBtnClick;
            u.connectBtnClick += U_connectBtnClick;
            u.openBtnClick += U_openBtnClick;
            u.getBtnClick += U_getBtnClick;
            u.writeBtnClick += U_writeBtnClick;
            u.endBtnClick += U_endBtnClick;
            //   MyShowblock.Add(u);
            this.panel_window1.Controls.Add(u);
            u2 = u;
        }
        //刷新界面
        public void Shuaxinpart()
        {
            this.panel_window1.Controls.Clear();
            count = 0;
            countflag = 0;
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
            BedConfigInfo objBedConfigInfo = objBedConfigInfoService.GetBedInfoByBedflag(1);
            int bencount = objBedConfigInfo.Bedcount;
            int bedrow = objBedConfigInfo.Bedrows;
            int a = 0;
            if (objShowInfo.AllOrPart == 0)
            {
                this.添加病床ToolStripMenuItem.Enabled = true;
                for (int i = 0; i < MyShowblock3.Length; i++)
                {

                    if (MyShowblock3[i] != null)
                    {
                        if (MyShowblock.Count > bencount)
                        {
                            MessageBox.Show("床位到达上限！", "系统提示");
                            return;
                        }

                        if (a < bedrow)
                        {
                            MyShowblock3[i].Location = new Point(a * 220 + 40, 20);
                        }
                        else
                        {

                            int row1 = a / bedrow;
                            int lastcount = a % bedrow;
                            MyShowblock3[i].Location = new Point(lastcount * 220 + 40, 20 + 280 * row1);

                        }
                        a++;
                        this.panel_window1.Controls.Add(MyShowblock3[i]);
                    }


                }
            }
        }
        public void Shuaxin()
        {
            this.panel_window1.Controls.Clear();
            MyShowblock.RemoveRange(0, MyShowblock.Count);
            count = 0;
            countflag = 0;
            SetbedInfo();
        }

        public void shuaxin1()
        {
            this.panel_window1.Controls.Clear();
            BedConfigInfo objBedConfigInfo = objBedConfigInfoService.GetBedInfoByBedflag(1);
            int bencount = objBedConfigInfo.Bedcount;

            int bedrow = objBedConfigInfo.Bedrows;
            int a = MyShowblock.Count;
            for (int i = 0; i < MyShowblock1.Count; i++)
            {
                if (a < bedrow)
                {
                    MyShowblock1[i].Location = new Point(a * 220 + 40, 20);

                }
                else
                {

                    int row1 = a / bedrow;
                    int lastcount = a % bedrow;
                    MyShowblock1[i].Location = new Point(lastcount * 220 + 40, 20 + 280 * row1);

                }
                this.panel_window1.Controls.Add(MyShowblock1[i]);
            }
        }


        public void SetColor(Color c)
        {
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
            if (objShowInfo.AllOrPart == 0)
            {
                for (int i = 0; i < MyShowblock.Count; i++)
                {
                    MyShowblock[i].Textbackcolor = c;
                }
            }
            else
            {
                for (int i = 0; i < MyShowblock1.Count; i++)
                {
                    MyShowblock1[i].Textbackcolor = c;
                }
            }
        }

        public void rece_USB(List<byte> datarece, string rec_data)
        {

            switch (DataHelper.Isnewmachine)
            {
                case 0:
                    {
                        ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
                        if (objShowInfo.AllOrPart == 0)
                        {
                            INFO = DataHelper.GetInfo(datarece);
                            
                            for (int i = 0; i < MyShowblock.Count; i++)
                            {

                                //异常判断
                                if (INFO[4].ToString() == MyShowblock[i].Bednum)
                                {
                                    #region
                                    if ((INFO[6] & 2) == 2)
                                    {


                                        if (((INFO[6] & 8) == 8)
                                       || ((INFO[6] & 32) == 32) || ((INFO[6] & 128) == 128)
                                       || ((INFO[6] & 256) == 256) || ((INFO[6] & 512) == 512))
                                        {
                                            MyShowblock[i].Lblbackcolor = Color.Orange;
                                            MyShowblock[i].myBackColor = Color.Orange;
                                            if (Commen.Ischeckd)
                                            { timer2.Start(); }
                                            MyShowblock[i].State = "异常，请查看数据";
                                            MyShowblock[i].O2 = INFO[0].ToString();
                                            MyShowblock[i].O2flow = (INFO[2] / 10.0).ToString();
                                            MyShowblock[i].Bpm = INFO[1].ToString();
                                            MyShowblock[i].Time = (INFO[3] / 10.0).ToString();
                                            if (patientsstate[ INFO[4] ] != INFO[6])
                                            {
                                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                 patientsstate[INFO[4]]= INFO[6];
                                            }
                                            
                                        }
                                        else if (((INFO[6] & 64) == 64))
                                        {
                                            MyShowblock[i].Lblbackcolor = Color.Red;
                                            MyShowblock[i].myBackColor = Color.Red;
                                            MyShowblock[i].State = "血氧饱和度异常";
                                            MyShowblock[i].O2 = INFO[0].ToString();
                                            MyShowblock[i].O2flow = (INFO[2] / 10.0).ToString();
                                            MyShowblock[i].Bpm = INFO[1].ToString();
                                            MyShowblock[i].Time = (INFO[3] / 10.0).ToString();
                                            if (patientsstate[INFO[4]] != INFO[6])
                                            {
                                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                patientsstate[INFO[4]] = INFO[6];
                                            }

                                        }
                                        else
                                        {
                                            timer2.Stop();
                                            MyShowblock[i].myBackColor = Color.DeepSkyBlue;
                                            MyShowblock[i].Lblbackcolor = Color.SpringGreen;
                                            MyShowblock[i].State = "正常";
                                            MyShowblock[i].O2 = INFO[0].ToString();
                                            MyShowblock[i].O2flow = (INFO[2]/10.0).ToString();
                                            MyShowblock[i].Bpm = INFO[1].ToString();
                                            MyShowblock[i].Time = (INFO[3] / 10.0).ToString();
                                            patientsstate[INFO[4]] = INFO[6];
                                        }

                                       
                                    }
                                    else
                                    {
                                        if (((INFO[6] & 4) != 4) && ((INFO[6] & 16) != 16))
                                        {
                                            MyShowblock[i].Lblbackcolor = Color.Orange;
                                            MyShowblock[i].myBackColor = Color.Orange;
                                            MyShowblock[i].State = "手动暂停";
                                            MyShowblock[i].O2 = "暂停";
                                            MyShowblock[i].O2flow = "暂停";
                                            MyShowblock[i].Bpm = "暂停";
                                            MyShowblock[i].Time = "暂停";
                                            if (patientsstate[INFO[4]] != INFO[6])
                                            {
                                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                patientsstate[INFO[4]] = INFO[6];
                                            }

                                        }
                                        else
                                        {
                                            if ((INFO[6] & 4) == 4)
                                            {
                                                MyShowblock[i].Lblbackcolor = Color.Red;
                                                MyShowblock[i].myBackColor = Color.Red;
                                                MyShowblock[i].State = "吸氧时间到";
                                                MyShowblock[i].O2 = "暂停";
                                                MyShowblock[i].O2flow = "暂停";
                                                MyShowblock[i].Bpm = "暂停";
                                                MyShowblock[i].Time = "暂停";
                                                if (patientsstate[INFO[4]] != INFO[6])
                                                {
                                                    objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                    patientsstate[INFO[4]] = INFO[6];
                                                }
                                            }
                                            if ((INFO[6] & 16) == 16)
                                            {
                                                MyShowblock[i].Lblbackcolor = Color.Red;
                                                MyShowblock[i].myBackColor = Color.Red;
                                                MyShowblock[i].State = "湿化瓶错误";
                                                MyShowblock[i].O2 = "暂停";
                                                MyShowblock[i].O2flow = "暂停";
                                                MyShowblock[i].Bpm = "暂停";
                                                MyShowblock[i].Time = "暂停";
                                                if (patientsstate[INFO[4]] != INFO[6])
                                                {
                                                    objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                    patientsstate[INFO[4]] = INFO[6];
                                                }
                                            }

                                        }
                                        
                                    }

                                    f15min_Info[INFO[4]] = DataHelper.ProtocolaSqldata(INFO);

                                    #endregion
                                    if (Save_flag)
                                    {
                                        //for (int J = 0; J < 200; J++)
                                        //{
                                        //    if (f15min_Info[i].PatientBednum != -1)
                                        //    {
                                        //        objPatientBodyInfoService.AddPatientBodyInfo(f15min_Info[i]);
                                        //    }
                                        //}
                                        //Save_flag = false;
                                        objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                        Portcount++;
                                        if (Portcount >= MyShowblock.Count)
                                        {
                                            Save_flag = false;
                                            Portcount = 0;
                                        }
                                    }
                                   
                                    //电量显示
                                    switch (INFO[5])
                                    {
                                        case 0:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\空.png");
                                            }
                                            break;
                                        case 1:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\一格.png");
                                            }
                                            break;
                                        case 2:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\两格.png");
                                            }
                                            break;
                                        case 3:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\三格.png");
                                            }
                                            break;
                                        case 4:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\满格.png");
                                            }
                                            break;
                                        case 5:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\充电.png");
                                            }
                                            break;
                                    }
                                    datarece.RemoveRange(0, datarece.Count);
                                }

                            }
                        }
                        else
                        {
                            INFO = DataHelper.GetInfo(datarece);
                            for (int i = 0; i < MyShowblock1.Count; i++)
                            {

                                //异常判断
                                if (INFO[4].ToString() == MyShowblock1[i].Bednum)
                                {
                                    #region
                                    if ((INFO[6] & 2) == 2)
                                    {
                                        if ( ((INFO[6] & 32) == 32) || ((INFO[6] & 128) == 128)
                                       /*|| ((INFO[6] & 256) == 256) || ((INFO[6] & 512) == 512)*/)
                                        {
                                            MyShowblock1[i].Lblbackcolor = Color.Orange;
                                            MyShowblock1[i].myBackColor = Color.Orange;
                                            if (Commen.Ischeckd)
                                            { timer2.Start(); }
                                            MyShowblock1[i].State = "异常，请查看数据";
                                            MyShowblock1[i].O2 = INFO[0].ToString();
                                            MyShowblock1[i].O2flow = (INFO[2] / 10.0).ToString();
                                            MyShowblock1[i].Bpm = INFO[1].ToString();
                                            MyShowblock1[i].Time = (INFO[3] / 10.0).ToString();
                                            if (patientsstate[INFO[4]] != INFO[6])
                                            {
                                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                patientsstate[INFO[4]] = INFO[6];
                                            }
                                        }
                                        else if (((INFO[6] & 64) == 64))
                                        {
                                            MyShowblock1[i].Lblbackcolor = Color.Red;
                                            MyShowblock1[i].myBackColor = Color.Red;
                                            MyShowblock1[i].State = "血氧饱和度异常";
                                            MyShowblock1[i].O2 = INFO[0].ToString();
                                            MyShowblock1[i].O2flow = (INFO[2] / 10.0).ToString();
                                            MyShowblock1[i].Bpm = INFO[1].ToString();
                                            MyShowblock1[i].Time = (INFO[3] / 10.0).ToString();
                                            if (patientsstate[INFO[4]] != INFO[6])
                                            {
                                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                patientsstate[INFO[4]] = INFO[6];
                                            }
                                        }
                                        else
                                        {
                                            timer2.Stop();
                                            MyShowblock1[i].myBackColor = Color.DeepSkyBlue;
                                            MyShowblock1[i].Lblbackcolor = Color.SpringGreen;
                                            MyShowblock1[i].State = "正常";
                                            MyShowblock1[i].O2 = INFO[0].ToString();
                                            MyShowblock1[i].O2flow = (INFO[2] / 10.0).ToString();
                                            MyShowblock1[i].Bpm = INFO[1].ToString();
                                            MyShowblock1[i].Time = (INFO[3] / 10.0).ToString();
                                            patientsstate[INFO[4]] = INFO[6];
                                        }

                                    }
                                    else
                                    {

                                        if (((INFO[6] & 4) != 4) && ((INFO[6] & 16) != 16))
                                        {
                                            MyShowblock1[i].Lblbackcolor = Color.Orange;
                                            MyShowblock1[i].myBackColor = Color.Orange;
                                            MyShowblock1[i].State = "手动暂停";
                                            MyShowblock1[i].O2 = "暂停";
                                            MyShowblock1[i].O2flow = "暂停";
                                            MyShowblock1[i].Bpm = "暂停";
                                            MyShowblock1[i].Time = "暂停";
                                            if (patientsstate[INFO[4]] != INFO[6])
                                            {
                                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                patientsstate[INFO[4]] = INFO[6];
                                            }
                                        }
                                        else
                                        {
                                            if (((INFO[6] & 4) == 4))
                                            {
                                                MyShowblock1[i].Lblbackcolor = Color.Red;
                                                MyShowblock1[i].myBackColor = Color.Red;
                                                MyShowblock1[i].State = "吸氧时间到";
                                                MyShowblock1[i].O2 = "暂停";
                                                MyShowblock1[i].O2flow = "暂停";
                                                MyShowblock1[i].Bpm = "暂停";
                                                MyShowblock1[i].Time = "暂停";
                                                if (patientsstate[INFO[4]] != INFO[6])
                                                {
                                                    objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                    patientsstate[INFO[4]] = INFO[6];
                                                }
                                            }
                                            if (((INFO[6] & 16) == 16))
                                            {
                                                MyShowblock1[i].Lblbackcolor = Color.Red;
                                                MyShowblock1[i].myBackColor = Color.Red;
                                                MyShowblock1[i].State = "湿化瓶错误";
                                                MyShowblock1[i].O2 = "暂停";
                                                MyShowblock1[i].O2flow = "暂停";
                                                MyShowblock1[i].Bpm = "暂停";
                                                MyShowblock1[i].Time = "暂停";
                                                if (patientsstate[INFO[4]] != INFO[6])
                                                {
                                                    objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                                    patientsstate[INFO[4]] = INFO[6];
                                                }
                                            }
                                        }
                                       
                                    }

                                    #endregion

                                    f15min_Info[INFO[4]] = DataHelper.ProtocolaSqldata(INFO);
                                    if (Save_flag)
                                    {
                                        //for (int J = 0; J < 200; J++)
                                        //{
                                        //    if (f15min_Info[i].PatientBednum != -1)
                                        //    {
                                        //        objPatientBodyInfoService.AddPatientBodyInfo(f15min_Info[i]);
                                        //    }
                                        //}
                                        //Save_flag = false;



                                        objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));
                                        Portcount++;
                                        if (Portcount >= MyShowblock.Count)
                                        {
                                            Save_flag = false;
                                            Portcount = 0;
                                        }
                                    }
                                    //zzx2020690
                                    //电量显示
                                    switch (INFO[5])
                                    {
                                        case 0:
                                            {
                                                MyShowblock1[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\空.png");
                                            }
                                            break;
                                        case 1:
                                            {
                                                MyShowblock1[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\一格.png");
                                            }
                                            break;
                                        case 2:
                                            {
                                                MyShowblock1[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\两格.png");
                                            }
                                            break;
                                        case 3:
                                            {
                                                MyShowblock1[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\三格.png");
                                            }
                                            break;
                                        case 4:
                                            {
                                                MyShowblock1[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\满格.png");
                                            }
                                            break;
                                        case 5:
                                            {
                                                MyShowblock[i].Batteryimage = new Bitmap(PatientInfo.conn + "\\充电.png");
                                            }
                                            break;
                                    }

                                    datarece.RemoveRange(0, datarece.Count);
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    {

                        byte[] INFO = new byte[2];
                        ShowInfo objShowInfo = objShowInfoService.GetShowInfo();
                        INFO= ReceiveCommandHelper.ReturnProtocolData(datarece);
                        for (int i = 0; i < MyShowblock.Count; i++)
                        {
                            if (MyShowblock[i].Bednum == INFO[0].ToString())
                            {
                                return;
                            }
                        }
                        if (objShowInfo.AllOrPart == 0)
                        {
                            WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();

                            if (INFO[1] == 1)
                            {
                                u.Btnexporttag = Convert.ToInt16(INFO[0])+256;
                                u.Btnpipeitag = Convert.ToInt16(INFO[0])+256;
                                u.Btnselecttag = Convert.ToInt16(INFO[0])+256;
                                u.Btnstarttag = Convert.ToInt16(INFO[0])+256;
                                u.WriteToolStripMenuItemtag = Convert.ToInt16(INFO[0])+256;
                                u.GetToolStripMenuItemtag = Convert.ToInt16(INFO[0])+256;
                                u.EndToolStripMenuItemtag = Convert.ToInt16(INFO[0])+256;
                                u.Bednum = (INFO[0]+256).ToString();
                            }
                            else
                            {
                                u.Btnexporttag = Convert.ToInt16(INFO[0]);
                                u.Btnpipeitag = Convert.ToInt16(INFO[0]);
                                u.Btnselecttag = Convert.ToInt16(INFO[0]);
                                u.Btnstarttag = Convert.ToInt16(INFO[0]);
                                u.WriteToolStripMenuItemtag = Convert.ToInt16(INFO[0]);
                                u.GetToolStripMenuItemtag = Convert.ToInt16(INFO[0]);
                                u.EndToolStripMenuItemtag = Convert.ToInt16(INFO[0]);
                                u.Bednum = INFO[0].ToString();
                            }
                          
                            u.selectBtnClick += U_selectBtnClick;
                            u.exportBtnClick += U_exportBtnClick;
                            u.connectBtnClick += U_connectBtnClick;
                            u.openBtnClick += U_openBtnClick;
                            u.getBtnClick += U_getBtnClick;
                            u.writeBtnClick += U_writeBtnClick;
                            u.endBtnClick += U_endBtnClick;
                         
                            for (int i = 0; i < MyShowblock.Count; i++)
                            {
                                if (MyShowblock[i].Bednum == INFO[0].ToString())
                                {
                                    return;
                                }
                            }
                            MyShowblock.Add(u);
                            MyShowblock3[INFO[0]]=u;
                            PatientInfo objPatientInfo = new PatientInfo();
                            objPatientInfo.PatientBednum =( (u.Bednum)).ToString();
                            objPatientInfo.Patientstarttime = DateTime.Now;
                           
                            AddPatientInfo(objPatientInfo);
                            if (INFO[1] == 1)
                            {
                                objAdditionalPatientsService.Add_AdditionalPatients(objPatientInfo);
                            }
                            else
                            {
                                objPatientService.AddUsbPatient(objPatientInfo);
                            }
                           
                            objSetInfo.IsEnable = 1;
                            objSetInfo.PatientBednum = Convert.ToInt16(INFO[0])+255;
                            objSetInfoService.AddSetInfo(objSetInfo);
                            Shuaxinpart();
                            datarece.RemoveRange(0, datarece.Count);
                        }
                        else
                        {

                            for (int i = 0; i < MyShowblock.Count; i++)
                            {
                                if (MyShowblock[i].Bednum == INFO[0].ToString())
                                {
                                    return;
                                }
                            }

                            MyShowblock1[INFO[0] - 1].myBackColor = Color.DeepSkyBlue;
                            MyShowblock1[INFO[0] - 1].Bednum = INFO[0].ToString();
                            NewMyport(INFO[0]);
                            objPatientService.AddPatients(NewPatient(INFO[0]));

                        }
                        SendOnce(INFO);

                    }
                    break;
                case 2:
                    {

                    }
                    break;
            }


        }

        private void 调试窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendInfo();

        }
        //询问子线程函数
        public void AskInfo()
        {
            try
            {
                lock (thisLock)
                {
                    while (Commen.stop==1)
                    {
                        Thread.VolatileRead(ref Commen.stop);
                        if (MyShowblock.Count == 0)
                        {
                            DataHelper.Isnewmachine = 1;
                            try
                            {
                                this.usb.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.CommandNewSlave));
                            }
                            catch (Exception ex)
                            {
                                SQLiteHelper.WriteLog("public void AskInfo()", ex.Message);
                                //MessageBox.Show(ex.ToString());
                            }
                            Thread.Sleep(5000);
                        }
                        for (int i = 0; i < MyShowblock.Count; i++)
                        {
                            try
                            {
                                if (this.usb.SpecifiedDevice != null)
                                {
                                    DataHelper.Isnewmachine = 0;
                                    DataHelper.Flag = 0;
                                    int a = Convert.ToInt32(MyShowblock[i].Bednum);
                                    if (a > 255)
                                    {
                                        DataHelper.CommandGetInfo[8] = Convert.ToByte(a - 256);
                                        DataHelper.CommandGetInfo[9] = 1;
                                    }
                                    else
                                    {
                                        DataHelper.CommandGetInfo[8] = Convert.ToByte(MyShowblock[i].Bednum);
                                        DataHelper.CommandGetInfo[9] = 0;
                                    }

                                    try
                                    {
                                        if (Commen.IsOpen)
                                        {
                                            this.usb.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.CommandGetInfo));
                                        }

                                        Commen.lastcommand = DataHelper.ReturnSendData(DataHelper.CommandGetInfo);
                                        //System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置间隔时间为10000毫秒； 
                                        //t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
                                        //t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)； 
                                        t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件
                                                         //Timers_Timer = t;
                                        t.Start();
                                        // this.timer_send_command.Enabled = true;
                                        //this.timer_send_command.Start();
                                        Sendcount++;
                                        Thread.Sleep(5000);
                                    }
                                    catch (Exception ex)
                                    {
                                        SQLiteHelper.WriteLog("public void AskInfo()", ex.Message);
                                        //MessageBox.Show(ex.ToString());
                                    }
                                    

                                }
                                else
                                {
                                    Commen.IsOpen = false;
                                    return;
                                }
                                if (Sendcount % 2 == 0)
                                {
                                    DataHelper.Isnewmachine = 1;
                                    try
                                    {
                                        this.usb.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.CommandNewSlave));
                                        Thread.Sleep(5000);
                                    }
                                    catch (Exception ex)
                                    {
                                        SQLiteHelper.WriteLog("  public void AskInfo()", ex.Message);
                                        MessageBox.Show(ex.ToString());
                                    }
                                   
                                }
                            }
                            catch (Exception ex)
                            {
                                SQLiteHelper.WriteLog("  public void AskInfo()", ex.Message);
                                MessageBox.Show(ex.ToString());
                            }
                        }

                    }
                }
            }
            catch(Exception EX)
            {
                SQLiteHelper.WriteLog(" public void AskInfo()",EX.Message);
            }
        }
        //新建控件
        public void NewMyport( int  num)
        {
            WindowsFormsShow.UserControl2 u = new WindowsFormsShow.UserControl2();
            u.Btnexporttag = Convert.ToInt16(num);
            u.Btnpipeitag = Convert.ToInt16(num);
            u.Btnselecttag = Convert.ToInt16(num);
            u.Btnstarttag = Convert.ToInt16(num);
            u.WriteToolStripMenuItemtag = Convert.ToInt16(num);
            u.GetToolStripMenuItemtag = Convert.ToInt16(num);
            u.EndToolStripMenuItemtag = Convert.ToInt16(num);
            u.Bednum = num.ToString();
            MyShowblock.Add(u);
        }
        //新机器添加结束立即询问一次
        public void SendOnce(byte [] data)
        {
            try
            {

                if (this.usb.SpecifiedDevice != null)
                {
                    DataHelper.Isnewmachine = 0;
                    DataHelper.Flag = 0;
                    DataHelper.CommandGetInfo[8] = data[0];
                    this.usb.SpecifiedDevice.SendData(DataHelper.ReturnSendData(DataHelper.CommandGetInfo));
                    Thread.Sleep(2000);

                }
                else
                {
                    DataHelper.Asxflag = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //病人信息插入数据库
        public void InsertInfo()
        {

            objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(INFO)));//写入数据库
        }
        //新机器写入数据库
        public PatientInfo NewPatient(byte num)
        {
            PatientInfo objPatientInfo = new PatientInfo();
            objPatientInfo.PatientBednum = num.ToString();
            objPatientInfo.PatientAge = "未录入";
            objPatientInfo.PatientDepartment = "未录入";
            objPatientInfo.PatientName = "未录入";
            objPatientInfo.PatientGender = "未录入";
            objPatientInfo.PatientNum = "未录入";
            objPatientInfo.Patientstarttime = DateTime.Now;
            return objPatientInfo;
        }
        //获取询问列表
        public List<int> SendInfo()
        {
            bed_name = objPatientService.Getbednumandname();
            for (int i = 0; i < bed_name.Count; i++)
            {
                bednum.Add(Convert.ToInt16(bed_name[i].PatientBednum));
            }
            return bednum;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Hand.Play();
        }

        //private void 关闭报警ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    timer2.Stop();
        //}
        /// <summary>
        /// 发送获取第几条
        /// </summary>
        public void ReadSaveData()
        {
            DataHelper.Flag = 12;
            byte[] data = new byte[33];
            data = DataHelper.ReadData(DataHelper.senddatacont++, DataHelper.CommandGetSavedata);
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //  Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //读寄存器
        public void ReadRegister()
        {
            DataHelper.Flag = 13;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 12;
            for (int i = 0; i < DataHelper.CommandReadRegister.Length; i++)
            {
                data[i + 2] = DataHelper.CommandReadRegister[i];
            }
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //   Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //获取条数
        public void getdatacount()
        {
            DataHelper.Flag = 11;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            for (int i = 0; i < DataHelper.CommandGetSavedatacount.Length; i++)
            {
                data[2 + i] = DataHelper.CommandGetSavedatacount[i];
            }
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    // Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //结束读取寄存器
        public void ReadRegisterOver()
        {
            DataHelper.Flag = 15;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            for (int i = 0; i < DataHelper.CommandReadRegisterstateover.Length; i++)
            {
                data[2 + i] = DataHelper.CommandReadRegisterstateover[i];
            }
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //  Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void  sendHzero()
        {
            DataHelper.CommandWriteHospitalName[11] = 0;
            this.usb.SpecifiedDevice.SendData(DataHelper.WriteHospitalNameData());
        }
        //写医院名称
        public void WriteHospitalName()
        {
            DataHelper.Flag = 18;

            DataHelper.CommandWriteHospitalName[11] = DataHelper.HospitalName[DataHelper.HospitalNameflag];
            DataHelper.HospitalNameflag++;
            if (DataHelper.HospitalNameflag> DataHelper.HospitalName.Length-1)
            {
                DataHelper.HospitalNameflag = 0;
                DataHelper.Flag = 23;
            }
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //   Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(DataHelper.WriteHospitalNameData());

                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           

        }
        //写科室名称
        public void WriteDepartmentName()
        {
            DataHelper.Flag = 16;

            DataHelper.CommandWriteDepartmentName[11] = DataHelper.DepartmentName[DataHelper.HospitalNameflag];
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //   Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(DataHelper.WriteDepartNameData());
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            DataHelper.HospitalNameflag++;
            if (DataHelper.HospitalNameflag >=DataHelper.DepartmentName.Length)
            {

                DataHelper.HospitalNameflag = 0;
                DataHelper.Flag = 22;
                DataHelper.DepartmentName = null;
                DataHelper.HospitalName = null;
               
            }
            
        }
        //读医院名称和科室名称
        public void ReadHospitalANDDepartment()
        {
            DataHelper.Flag = 20;
            DataHelper.ISHORDFlag = 0;
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //   Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(DataHelper.ReadHospitalNameData());
                    DataHelper.CommandReadHospitalName[4] += 0x10;
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //结束写
        public void WriteHospitalANDDepartmentover()
        {
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            for (int i = 0; i < DataHelper.CommandReadDepartmentNameOver.Length; i++)
            {
                data[i + 2] = DataHelper.CommandReadDepartmentNameOver[i];
            }
            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    //  Thread.Sleep(50);
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("请插入设备！ ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //发送零
        public void sendzero()
        {
            DataHelper.CommandWriteDepartmentName[11] = 0;
            this.usb.SpecifiedDevice.SendData(DataHelper.WriteDepartNameData());
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Save_flag = true;
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", PatientInfo.conn+ "\\帮助文档.txt");
        }

        private void GetUUID()
        {
            string code = null;
            SelectQuery query = new SelectQuery("select * from Win32_ComputerSystemProduct");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (var item in searcher.Get())
                {
                    using (item) code = item["UUID"].ToString();
                }
            }
            Commen.UUID=objPatientService.GetUUID();
            if (code != Commen.UUID)
            {
                DialogResult result = MessageBox.Show("系统检测到该电脑首次使用该系统，是否删除之前的配置和数据？（如果是新的用户，建议删除）", "删除询问",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    Commen.UUID = code;
                    objPatientService.UpdateUUID(code);
                    objPatientService.DeleAll();
                    System.Diagnostics.Process.Start("notepad.exe", PatientInfo.conn + "\\updete.txt");
                    //  MessageBox.Show("1、修改数据量过大不能导出的BUG。2、优化部分程序。","更新信息提示！");
                }

            }
            else
            {
                return;
            }
        }


        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            int lastbednum;
            int[] data = new int[8];
            ShowInfo objShowInfo = objShowInfoService.GetShowInfo();//获取床位设置状态
            // System.Timers.Timer t = (System.Timers.Timer)source;
            Commen.IsOpen = false;//关闭发送线程
            if (Commen.lastcommand[11] == 1)
            {
                lastbednum = Commen.lastcommand[10] + 256;
            }
            else
            {
                lastbednum = Commen.lastcommand[10];
            }
          
            DataHelper.Isnewmachine = 0;
            DataHelper.Flag = 0;
            try
            {
                this.usb.SpecifiedDevice.SendData(Commen.lastcommand);//如果超时，再发送一次
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("public void theout(object source, System.Timers.ElapsedEventArgs e)",ex.Message);
            }
            
            Commen.sendcountnum++;//超时次数加一

            if (Commen.sendcountnum > 1)//如果超时两次
            {          
                if (objShowInfo.AllOrPart == 0)
                {
                   // int lastbednum = Commen.lastcommand[10];
                    for (int i = 0; i < MyShowblock.Count; i++)
                    {

                 
                        if (lastbednum.ToString() == MyShowblock[i].Bednum)
                        {
                           
                            if (MyShowblock[i].InvokeRequired)
                            {
                                MyShowblock[i].Invoke(new Action<Color>(s => { MyShowblock[i].myBackColor = s; }), Color.Red);
                                MyShowblock[i].Invoke(new Action<Color>(s => { MyShowblock[i].Lblbackcolor = s; }), Color.Red);
                                MyShowblock[i].Invoke(new Action<string>(s => { MyShowblock[i].State = s; }), "连接中断");
                                MyShowblock[i].Invoke(new Action<string>(s => { MyShowblock[i].O2 = s; }), "连接中断");
                                MyShowblock[i].Invoke(new Action<string>(s => { MyShowblock[i].O2flow = s; }), "连接中断");
                                MyShowblock[i].Invoke(new Action<string>(s => { MyShowblock[i].Time = s; }), "连接中断");
                                MyShowblock[i].Invoke(new Action<string>(s => { MyShowblock[i].Bpm = s; }), "连接中断");

                                //for (int j = 0; j < cutList.Count; j++)
                                //{
                                //    if(cutList[j].PatientBednum==lastbednum.ToString())
                                //    {
                                //        break;
                                //    }
                                //    if (j++ >= cutList.Count)
                                //    {
                                //        PatientInfo p = new PatientInfo();
                                //        p.Patientendtime = DateTime.Now;
                                //        p.PatientBednum = lastbednum.ToString();
                                //        cutList.Add(p);
                                //    }
                                //}
                                //    for (int j = 0; j < cutList.Count; j++)
                                //    {
                                //    if (cutList[j].PatientBednum == lastbednum.ToString())
                                //    {
                                //        if (DateTime.Now > cutList[j].Patientendtime)
                                //        {
                                //            data[0] = 0xff;
                                //            data[1] = 0xff;
                                //            data[2] = 0xff;
                                //            data[3] = 0xff;
                                //            data[4] = lastbednum;
                                //            objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(data)));
                                //        }
                                //    }
                                //}
                                //string sql1 = "UPDATE JHCDAS_PAT_ARCHIVE_INFO SET ARCHIVE_DATETIME='{0}' WHERE PATIENT_ID='{1}' ";

                                //sql1 = string.Format(DateTime.Now.ToString(),10001);

                            }
                        }
                    }

                   
                }
                else
                {
                    for (int i = 0; i < MyShowblock1.Count; i++)
                    {


                        if (lastbednum.ToString() == MyShowblock1[i].Bednum)
                        {

                            if (MyShowblock1[i].InvokeRequired)
                            {
                                MyShowblock1[i].Invoke(new Action<Color>(s => { MyShowblock1[i].myBackColor = s; }), Color.Red);
                                MyShowblock1[i].Invoke(new Action<Color>(s => { MyShowblock1[i].Lblbackcolor = s; }), Color.Red);
                                MyShowblock1[i].Invoke(new Action<string>(s => { MyShowblock1[i].State = s; }), "连接中断");
                                MyShowblock1[i].Invoke(new Action<string>(s => { MyShowblock1[i].O2 = s; }), "连接中断");
                                MyShowblock1[i].Invoke(new Action<string>(s => { MyShowblock1[i].O2flow = s; }), "连接中断");
                                MyShowblock1[i].Invoke(new Action<string>(s => { MyShowblock1[i].Time = s; }), "连接中断");
                                MyShowblock1[i].Invoke(new Action<string>(s => { MyShowblock1[i].Bpm = s; }), "连接中断");
                                data[0] = 0xff;
                                data[1] = 0xff;
                                data[2] = 0xff;
                                data[3] = 0xff;
                                data[4] = lastbednum;
                                objPatientBodyInfoService.AddPatientBodyInfo((DataHelper.ProtocolaSqldata(data)));
                            }
                        }
                    }
                }
                t.Stop();
                Commen.IsOpen = true;
                Commen.sendcountnum = 0;//次数清零
            }
        }
        private void timer_send_command_Tick(object sender, EventArgs e)//询问超时定时器
        {
            //    Commen.IsOpen = false;//关闭发送线程
            //    Commen.sendcount++;//超时次数加一
            //this.usb.SpecifiedDevice.SendData(Commen.lastcommand);//如果超时，再发送一次
            //if (Commen.sendcount > 2)//如果超时两次
            //{
            //    Commen.sendcount = 0;//次数清零
            //    ShowInfo objShowInfo = objShowInfoService.GetShowInfo();//获取床位设置状态
            //    if (objShowInfo.AllOrPart == 0)
            //    {
            //        int lastbednum = Commen.lastcommand[8];
            //        MyShowblock[lastbednum].State = "连接中断！";
            //    }
            //    else
            //    {
            //        int lastbednum = Commen.lastcommand[8];
            //        MyShowblock1[lastbednum].State = "连接中断！";
            //    }
            //    Commen.IsOpen = true;
            //    timer_send_command.Stop();
            //}
        }

        private void 继续监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   th.Resume();
        }
    }

    /// <summary>
    /// 重写panel滚动条
    /// </summary>
    public partial class Panel_window : Panel
    {

        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }



}
