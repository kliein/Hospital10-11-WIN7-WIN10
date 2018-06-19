using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;


namespace Hospital
{
    public partial class FrmPatientInfoRevise : Form
    {
        private int flag=0;
        private bool newold = true;
        PatientService objPatientService = new PatientService();
        ShowInfoService objShowInfoService = new ShowInfoService();
        AdditionalPatientsService objAdditionalPatientsService = new AdditionalPatientsService();
        public bool Ischange ;
        public FrmPatientInfoRevise()
        {
            InitializeComponent();
            this.dtp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
        /// <summary>
        /// 构造函数传递所选病人信息
        /// </summary>
        /// <param name="objPatientInfo"></param>
        public FrmPatientInfoRevise(PatientInfo objPatientInfo,string bednum,bool IsChange)
        {
            InitializeComponent();
            this.flag =Convert.ToInt16( bednum)-1;
            Ischange = IsChange;
            if (objPatientInfo != null)
            {
                this.dtp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                if (objPatientInfo == null) return;
                this.txt_bedbum.Text = (objPatientInfo.PatientBednum).ToString();
                this.txt_name.Text = objPatientInfo.PatientName;
                this.txt_age.Text = objPatientInfo.PatientAge.ToString();
                this.txt_keshi.Text = objPatientInfo.PatientDepartment;
                this.txt_zhuyuannum.Text = objPatientInfo.PatientNum;
                this.flag = objPatientInfo.flag;
                this.newold = objPatientInfo.NewOId;
                if (objPatientInfo.PatientGender == "男")
                { this.rad_man.Checked = true; }
                else
                { this.rad_woman.Checked = true; }
                // this.dtp_time.Text = objPatientInfo.Patientstarttime.ToString();
                this.txt_bedbum.ReadOnly = true;
            }
            else
            {
                this.txt_bedbum.Text = bednum;
            }
        }


        private void FrmPatientInfoRevise_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            PatientInfo objPatientInfo = new PatientInfo()
            {
                PatientName = this.txt_name.Text.Trim(),
                PatientAge=this.txt_age.Text.Trim(),
                PatientGender = this.rad_man.Checked ? "男" : "女",
                PatientNum = this.txt_zhuyuannum.Text.Trim(),
                Patientstarttime = dtp_time.Value,
                PatientDepartment = this.txt_keshi.Text.Trim(),
                PatientBednum=(this.txt_bedbum.Text.Trim())
            };
           ShowInfo objShowInfo= objShowInfoService.GetShowInfo();

            if (objShowInfo.AllOrPart == 1)
            {

                if (Ischange)
                {
                    FrmMain.MyShowblock1[flag].Peoplename = objPatientInfo.PatientName;
                    FrmMain.MyShowblock1[flag].myBackColor = Color.DeepSkyBlue;
                    int result = objPatientService.AddPatients(objPatientInfo);
                    if (result == 1)
                    {
                        MessageBox.Show("添加成功！", "系统提示！");
                    }
                }
                else
                {
                    int result = 0;

                    FrmMain.MyShowblock1[flag].Peoplename = objPatientInfo.PatientName;
                    FrmMain.MyShowblock1[flag].myBackColor = Color.DeepSkyBlue;
                    objPatientInfo.PatientBednum = FrmMain.MyShowblock1[flag].Bednum;
                    if (Convert.ToInt16(FrmMain.MyShowblock1[flag].Bednum) > 256)
                    {
                        result = objAdditionalPatientsService.UpdatePatientInfo(objPatientInfo);
                    }
                    else
                    {
                        result = objPatientService.UpdatePatientInfo(objPatientInfo);
                    }
                    
                    if (result == 1)
                    {
                        MessageBox.Show("修改成功！", "系统提示！");
                    }
                }
            }
            else
            {
                FrmMain.MyShowblock[flag].Peoplename = objPatientInfo.PatientName;
                FrmMain.MyShowblock[flag].myBackColor = Color.DeepSkyBlue;
                int result = 0;
                objPatientInfo.PatientBednum = FrmMain.MyShowblock[flag].Bednum;
                if (Convert.ToInt16(FrmMain.MyShowblock[flag].Bednum) > 256)
                {
                    
                    result = objAdditionalPatientsService.UpdatePatientInfo(objPatientInfo);
                }
                else
                {
                    result = objPatientService.UpdatePatientInfo(objPatientInfo);
                }
                
                if (result == 1)
                {
                    MessageBox.Show("修改成功！", "系统提示！");
                }
            }


            this.Close();

        }

        private void btn_cacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtp_time_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
