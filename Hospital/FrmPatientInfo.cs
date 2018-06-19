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
using Protocol;

namespace Hospital
{
    public partial class FrmPatientInfo : Form
    {
        public addPatientInfo addinfo;
        public setbed Setbed;
        private PatientService objPatientService = new PatientService();
        private SetInfoService objSetInfoService = new SetInfoService();
        private AdditionalPatientsService objAdditionalPatientsService = new AdditionalPatientsService();
        private SetInfo objSetInfo = new SetInfo();
        private string text;
        public FrmPatientInfo()
        {
            InitializeComponent();
            this.dtp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
        //public FrmPatientInfo(string info)
        //{
        //    InitializeComponent();
        //    this.dtp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //}
        public FrmPatientInfo(int bednum)
        {
            InitializeComponent();
            this.txt_bedbum.Text = bednum.ToString();
            this.dtp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        public FrmPatientInfo(string bednum)
        {
            InitializeComponent();
            this.dtp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
          //  this.txt_bedbum.ReadOnly = true;
            text = bednum;
            if (bednum == "添加病床")
            {

                //this.text = "[添加病床]";
            }
            else
            {
                this.label2.Text = "#";
                this.ckdnewbed.Checked = true;
                this.ckdnewbed.Enabled = false;
               // this.text = "[添加额外病床]";
            }
        }
        public WindowsFormsShow.UserControl2 u3 = null;
        private void FrmPatientInfo_Load(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            int result;
            //信息校验
            if (this.txt_bedbum.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入病人床号！", "系统提示！");
                this.txt_name.Focus();
                return;
            }
            //if (this.txt_age.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("请输入病人年龄！", "系统提示！");
            //    this.txt_age.Focus();
            //    return;
            //}
            //if (this.txt_keshi.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("请输入病人所在科室！", "系统提示");
            //    this.txt_keshi.Focus();
            //    return;
            //}
            //if (this.txt_zhuyuannum.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("请输入病人住院号！", "系统提示！");
            //    this.txt_zhuyuannum.Focus();
            //    return;
            //}
            //if (rad_man.Checked == false && rad_woman.Checked == false)
            //{
            //    MessageBox.Show("请选择性别！", "系统提示！");
            //    return;
            //}
            //封装病人信息
            PatientInfo objPatientInfo = new PatientInfo();
            objPatientInfo.PatientName = this.txt_name.Text.Trim();
            objPatientInfo.PatientAge = this.txt_age.Text.Trim();
            if (this.ckdnewbed.Checked == true)
            {
                objPatientInfo.PatientBednum =( Convert.ToInt32(this.txt_bedbum.Text.Trim())+256).ToString();
            }
            else
            {
                objPatientInfo.PatientBednum = this.txt_bedbum.Text.Trim();
            }
           
            if (this.rad_man.Checked == true)
            {
                objPatientInfo.PatientGender = "男";
            }
            else if (this.rad_woman.Checked == true)
            {
                objPatientInfo.PatientGender = "女";
            }
            else
            {
                objPatientInfo.PatientGender = "未录入";
            }
            objPatientInfo.PatientDepartment = this.txt_keshi.Text.Trim();
            objPatientInfo.PatientNum = this.txt_zhuyuannum.Text.Trim();
            objPatientInfo.Patientstarttime = dtp_time.Value;
          

            for (int i = 0; i < FrmMain.MyShowblock.Count; i++)
            {
                if (objPatientInfo.PatientBednum.ToString() == FrmMain.MyShowblock[i].Bednum)
                {
                    MessageBox.Show("该床已经存在病人！请查看！", "系统提示！");
                    this.txt_bedbum.Focus();
                    return;
                }
            }
            if (this.ckdnewbed.Checked == true)
            {
                result=objAdditionalPatientsService.Add_AdditionalPatients(objPatientInfo);
                Setbed();
            }
            else
            {
                 result = objPatientService.AddPatients(objPatientInfo);
            }
                    
            u3.Bednum = objPatientInfo.PatientBednum.ToString(); 
            u3.Peoplename = objPatientInfo.PatientName;
            u3.Btnexporttag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            u3.Btnpipeitag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            u3.Btnselecttag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            u3.Btnstarttag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            u3.WriteToolStripMenuItemtag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            u3.GetToolStripMenuItemtag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            u3.EndToolStripMenuItemtag = Convert.ToInt32(this.txt_bedbum.Text.Trim());
          //  FrmMain.MyShowblock.Add(u3);  
            addinfo(objPatientInfo);
            if (result == 1)
            {
                MessageBox.Show("录入成功！", "系统提示！");
                DataHelper.Flagexit = true;
            }
            objSetInfo.IsEnable = 1;
            objSetInfo.PatientBednum = Convert.ToInt32(this.txt_bedbum.Text.Trim());
            objSetInfoService.AddSetInfo(objSetInfo);
            this.Close();
        }

        private void btn_cacel_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMain.closeflag = false;
        }

        private void dtp_time_ValueChanged(object sender, EventArgs e)
        {
            dtp_time.CustomFormat = "yyyy-MM-dd HH-mm-ss";
        }

        private void ckdnewbed_CheckedChanged(object sender, EventArgs e)
        {
            if (text == "添加病床")
            {
                if (this.ckdnewbed.Checked == true)
                {
                    this.label2.Text = "#";
                }
                else
                {
                    this.label2.Text = "";
                }
            }

        }
    }
}
