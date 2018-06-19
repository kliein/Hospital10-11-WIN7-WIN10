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
using System.Windows.Forms;

namespace Hospital
{
    public partial class FrmDataExport : Form
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        PatientService objPatientService = new PatientService();
        PatientBodyInfoService objPatientBodyInfoService = new PatientBodyInfoService();
        public FrmDataExport()
        {
            InitializeComponent();
        }
        public FrmDataExport(string bednum)
        {
            InitializeComponent();
            int bed = Convert.ToInt16(bednum);
            string bedstr = "";
            if (bed > 255)
            {
                bedstr ="#"+ (bed - 256).ToString();
            }
            else
            {
                bedstr = bed.ToString();
            }
            this.txt_bednum.Text = bedstr;
            PatientInfo patientInfo=  objPatientService.GetPatientInfoBybednum(Convert.ToInt16( bednum));
            HospitalInfo hospitalInfo = new HospitalInfoService().GetHospitalInfo();
            if (hospitalInfo == null)
            {
                hospitalInfo = new HospitalInfo();
                hospitalInfo.Department = "科室名称";
                hospitalInfo.HospitalName = "医院名称";
            }
            dic.Add("name",patientInfo.PatientName);
            dic.Add("age", patientInfo.PatientAge);
            dic.Add("bednum",patientInfo.PatientBednum);
            dic.Add("patientnum", patientInfo.PatientNum);
            dic.Add("hospital",hospitalInfo.HospitalName);
            dic.Add("depart",hospitalInfo.Department);
            dic.Add("gender",patientInfo.PatientGender);
        }
        /// <summary>
        /// 导出病人基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_patient_Click(object sender, EventArgs e)
        {
            string str = this.txt_bednum.Text.Trim();
            string bednum = "";
            if (str[0] == 35)
            {
                string subString2 = str.Substring(1, str.Length - 1);
                bednum = (Convert.ToInt16(subString2) + 256).ToString();
            }
            else
            {
                bednum = str;
            }
            string strSaveFileLocation = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName = this.txt_bednum.Text.Trim() + "号病人基本信息";//设置默认文件名
            saveFileDialog1.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            saveFileDialog1.CheckPathExists = true;//检查目录
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strSaveFileLocation = saveFileDialog1.FileName;//文件路径
            }
            else
            {
                return;
            }
            string patientbednum = this.txt_bednum.Text.Trim();
            DataTable dt = objPatientService.GetOnePabientInfo(Convert.ToInt32(bednum));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有任何记录！", "系统提示！");
                return;
            }

            NPOI.PatientBasicInfoToExcel(dt, patientbednum, strSaveFileLocation);
        }
        /// <summary>
        /// 详细信息导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_patientbodyinfo_Click(object sender, EventArgs e)
        {
            int count = 4;
            string strSaveFileLocation = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName = this.txt_bednum.Text.Trim()+"号病人详细信息";//设置默认文件名
            saveFileDialog1.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            saveFileDialog1.CheckPathExists = true;//检查目录
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strSaveFileLocation = saveFileDialog1.FileName;//文件路径
            }
            else
            {
                return  ;
            }
            DataTable dt = objPatientBodyInfoService.GetPatientIndtfoBybednum(Convert.ToInt32(this.txt_bednum.Text.Trim()));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有任何记录！", "系统提示！");
                return;
            }
            dic.Add("stime", dt.Rows[0][0].ToString());
            dic.Add("etime", dt.Rows[dt.Rows.Count-1][0].ToString());
            if ((checkBox_30.Checked == true) && (checkBox_60.Checked == true))
            {
                MessageBox.Show("不能同时选中两种导出设置！","系统提示");
            }
            if (checkBox_30.Checked == true)
                count = 2;
            if (checkBox_60.Checked == true)
                count = 1;

            //  Hospital.NPOI.ExportDataTableToExcel(dt, strSaveFileLocation,count);
            try
            {
                NPOI.ExcelPrint("导出数据格式.xls", dt, dic, strSaveFileLocation, count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dic.Clear();
        }

        private void FrmDataExport_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox_60_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_60.Checked==true)
                this.checkBox_30.Checked = false;
        }

        private void checkBox_30_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_30.Checked == true)
                this.checkBox_60.Checked = false;
        }
    }
}
