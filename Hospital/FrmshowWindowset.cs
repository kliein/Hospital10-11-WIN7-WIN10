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
using System.IO;

namespace Hospital
{

    public partial class FrmshowWindowset : Form
    {
        HospitalInfoService objHospitalInfoService = new HospitalInfoService();
        BedConfigInfoService objBedConfigInfoService = new BedConfigInfoService();
        ShowInfoService objShowInfoService = new ShowInfoService();

        Color c;
        public FrmshowWindowset()
        {
            InitializeComponent();
        }
        public addshowblock addblock;//声明委托
        public setpart Setpartbed;
        public AddHospitalInfo addhospitalinfo;
        public SetColor setColor;
        private void FrmshowWindowset_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 添加床位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setbednum_Click(object sender, EventArgs e)
        {
            int x, y;
            if (this.numdown_bedcount.Text == "" || this.numdown_rowcount.Text == "")
            {
                MessageBox.Show("请输入正确的信息！", "系统提示");
                return;
            }
            if (this.radall.Checked == false && this.radpart.Checked == false)
            {
                MessageBox.Show("请选择一种模式！", "系统提示");
                return;
            }

            x = Convert.ToInt32(this.numdown_bedcount.Text.Trim());
            y= Convert.ToInt32(this.numdown_rowcount.Text.Trim());
            BedConfigInfo objBedConfigInfo = new BedConfigInfo()
            {
                Bedcount= x,
                Bedrows=y

            };
            objBedConfigInfoService.InsertBedInfo(objBedConfigInfo);
            if(this.radpart.Checked==true)
            {
                objShowInfoService.SetShowInfo(0);                
                Setpartbed();
                MessageBox.Show("设置成功！", "系统提示！");
            }
            if (addblock != null&this.radall.Checked==true)
            {
                objShowInfoService.SetShowInfo(1);
                //addblock(x, y);
                Setpartbed();

                MessageBox.Show("设置成功！", "系统提示！");
               

            }
            else
            { return; }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmshowWindowset_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_savehospital_Click(object sender, EventArgs e)
        {
            
            if (this.txthospitalname.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入医院名称！", "系统提示！");
                this.txthospitalname.Focus();
                return;
            }
            if (this.txtdepartment.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入科室名称！", "系统提示！");
                this.txtdepartment.Focus();
                return;
            }

            HospitalInfo objHospitalInfo = new HospitalInfo();
            objHospitalInfo.Department =this.txtdepartment.Text.Trim();
            objHospitalInfo.HospitalName = this.txthospitalname.Text.Trim();
            addhospitalinfo(objHospitalInfo);
            int res = objHospitalInfoService.AddHospitalInfo(objHospitalInfo);
            if (res > 0)
            {
                MessageBox.Show("添加成功！", "系统提示！");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setColor(c);
            FileStream fs = new FileStream("Color.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                   sw.WriteLine(c.Name);
                //ColorTranslator.FromHtml("#FF0000")
            }
            catch (Exception ex)
            {
            }

            sw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            c= colorDialog1.Color;
            this.lblcolor.BackColor = c;
        }

        //private void chkboxsounderror_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chkboxsounderror.Checked)
        //    {
        //        Commen.Ischeckd = true;
        //    }
        //    else
        //    {
        //        Commen.Ischeckd = false;
        //    }
        //}
    }
}
