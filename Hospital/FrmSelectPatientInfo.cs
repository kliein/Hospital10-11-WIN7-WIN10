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
    public partial class FrmSelectPatientInfo : Form
    {
        PatientBodyInfoService objPatientBodyInfoService = new PatientBodyInfoService();
        private List<PatientBodyInfo> list = null;
        private List<PatientBodyInfo> list1 = new List<PatientBodyInfo>();
        public FrmSelectPatientInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造方法传递病人信息
        /// </summary>
        /// <param name="objPatientInfo"></param>
        public FrmSelectPatientInfo(PatientInfo objPatientInfo)
        {
            InitializeComponent();
            this.txt_name.Text = objPatientInfo.PatientName;
            this.txt_gender.Text = objPatientInfo.PatientGender;
            this.txt_patientnum.Text = objPatientInfo.PatientNum;
            this.txt_time.Text =objPatientInfo.Patientstarttime.ToString();
            this.txt_Department.Text = objPatientInfo.PatientDepartment;
            this.txt_bednum.Text = objPatientInfo.PatientBednum.ToString();
            this.txt_age.Text = objPatientInfo.PatientAge.ToString();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmSelectPatientInfo_Load(object sender, EventArgs e)
        {
            string str = this.txt_bednum.Text.Trim();
            int bednum;
            if (str[0] == 35)
            {
                string subString2 = str.Substring(1, str.Length - 1);
                bednum = (Convert.ToInt16(subString2) + 256);

            }
            else
            {
                bednum = Convert.ToInt16(str);
            }
            list = objPatientBodyInfoService.GetPatientInfoByBednumNowDESC(bednum, 0);
            if (list.Count == 0)
            {
                //MessageBox.Show("没有任何记录！", "系统提示");
            }
            this.dgv_info.DataSource = null;
            this.dgv_info.AutoGenerateColumns = false;//禁止生成不需要的列
            for (int i = 0; i < list.Count; i += 4)
            {
                list1.Add(list[i]);
            }
            this.dgv_info.DataSource = list1;
            Commen.ISHour = true;
        }
        /// <summary>
        /// 查询当前病人的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            string str = this.txt_bednum.Text.Trim();
            int bednum;
            if (str[0] == 35)
            {
                string subString2 = str.Substring(1, str.Length - 1);
                bednum = (Convert.ToInt16(subString2) + 256);

            }
            else
            {
                bednum = Convert.ToInt16(str);
            }
            list = objPatientBodyInfoService.GetPatientInfoByBednumNowDESC(bednum, 0);
            if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
            this.dgv_info.DataSource = null;
            this.dgv_info.AutoGenerateColumns = false;//禁止生成不需要的列
            this.dgv_info.DataSource = list;
            Commen.ISHour = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgv_info_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string str = this.txt_bednum.Text.Trim();
            int bednum;
            if (str[0] == 35)
            {
                string subString2 = str.Substring(1, str.Length - 1);
                bednum = (Convert.ToInt16(subString2) + 256);

            }
            else
            {
                bednum = Convert.ToInt16(str);
            }
            string a = e.RowIndex.ToString();
             List<PatientBodyInfo> list2 = new List<PatientBodyInfo>();
            if (a == "-1")
            {
                if (Commen.ISHour)
                {
                    if (Commen.MouseClick % 2 == 0)
                    {
                        list = objPatientBodyInfoService.GetPatientInfoByBednumNowDESC(bednum, 0);
                        if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                        this.dgv_info.DataSource = null;
                        this.dgv_info.AutoGenerateColumns = false;//禁止生成不需要的列
                        for (int i = 0; i < list.Count; i += 4)
                        {
                            list2.Add(list[i]);
                        }
                        this.dgv_info.DataSource = list2;
                    }
                    else
                    {
                        list = objPatientBodyInfoService.GetPatientInfoByBednumNowASC(bednum, 0);
                        if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                        this.dgv_info.DataSource = null;
                        this.dgv_info.AutoGenerateColumns = false;//禁止生成不需要的列
                        for (int i = 0; i < list.Count; i += 4)
                        {
                            list2.Add(list[i]);
                        }
                        this.dgv_info.DataSource = list2;
                    }

                }
                else
                {
                    if (Commen.MouseClick % 2 == 0)
                    {
                        list = objPatientBodyInfoService.GetPatientInfoByBednumNowASC(bednum, 0);
                        if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                        this.dgv_info.DataSource = null;
                        this.dgv_info.AutoGenerateColumns = false;//禁止生成不需要的列
                        this.dgv_info.DataSource = list;
                    }
                    else
                    {
                        list = objPatientBodyInfoService.GetPatientInfoByBednumNowDESC(bednum, 0);
                        if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                        this.dgv_info.DataSource = null;
                        this.dgv_info.AutoGenerateColumns = false;//禁止生成不需要的列
                        this.dgv_info.DataSource = list;
                    }
                }
               
                Commen.MouseClick++;
            }
        }
    }
}
