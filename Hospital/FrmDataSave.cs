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
using UsbLibrary;
using Protocol;

namespace Hospital
{
    public partial class FrmDataSave : Form
    {
        private bool flag;
        public delegate void AddRegisterdata();
        public UsbHidPort usbhid3 = null;
        private List<PatientInfo> list = null;
        private List<PatientBodyInfo> list1 = null;
        private List<PatientSaveData> list2 = null;
        string starttime = "";
        string endtime = "";
        string patientname = "";
    //    private List<PatientInfo> list2 = null;
       PatientService objPatientService = new PatientService();
        PatientBodyInfoService objPatientBodyInfoService = new PatientBodyInfoService();
        PatirntSaveDataService objPatirntSaveDataService = new PatirntSaveDataService();
        AdditionalPatientsService objAdditionalPatientsService = new AdditionalPatientsService();

        Dictionary<string, string> dic = new Dictionary<string, string>();
        public FrmDataSave()
        {
            InitializeComponent();
        }

        private void FrmDataSave_Load(object sender, EventArgs e)
        {

        }

        private void rad_datahour_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            flag = false;
            int  bednum=0;
            this.dgv_patientinfo.DataSource = null;
            this.dgv_bodyinfo.DataSource = null;
            string str = this.txt_get.Text.Trim();

            if (this.txt_get.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入查询条件！", "系统提示");
                this.txt_get.Focus();
                return;
            }

            if (this.rad_bednum.Checked == true)
            {

                if (this.cbxadd.Checked == true)
                {
                    try
                    {
                        bednum = (Convert.ToInt16(str) + 256);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("输入信息有误！", "系统提示");
                        return;
                    }
                   
                }
                else
                {
                    try
                    {
                        bednum = Convert.ToInt16(str);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("输入信息有误！", "系统提示");
                        return;
                    }
                   
                }
                if (this.cbxadd.Checked == true)
                {
                    try
                    {
                        list = objAdditionalPatientsService.GetPatientInfoByBednum(bednum, 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("输入信息有误！","系统提示");
                        return;
                    }

                   
                }
                else
                {
                    try
                    {
                        list = objPatientService.GetPatientInfoByBednum(bednum, 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("输入信息有误！", "系统提示");
                        return;
                    }
                   
                }
                
                if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                this.dgv_patientinfo.DataSource = null;
                this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
                this.dgv_patientinfo.DataSource = list;

            }
            else if (this.rad_name.Checked == true)
            {
                try
                {
                    list = objPatientService.GetPatientInfoByPatientname(str.ToString(), 0);
                }
                catch (Exception)
                {
                    MessageBox.Show("输入信息有误！", "系统提示");
                    return;
                }
               
                if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                this.dgv_patientinfo.DataSource = null;
                this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
                this.dgv_patientinfo.DataSource = list;
            }
            else
            {
                try
                {
                    list = objPatientService.GetPatientInfoByPatientNum(str.ToString(), 0);
                }
                catch (Exception)
                {
                    MessageBox.Show("输入信息有误！", "系统提示");
                    return;
                }
               
                if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                this.dgv_patientinfo.DataSource = null;
                this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
                this.dgv_patientinfo.DataSource = list;
            }
        }

        public int getbednum(string str)
        {
            int bednum;
            if (str[0] == 35)
            {
                string subString2 = str.Substring(1, str.Length - 1);
                bednum = (Convert.ToInt16(subString2) + 256);
                return bednum;
            }
            else
            {
                return Convert.ToInt16(str);
            }
        }
        private void dgv_patientinfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string patientbednum = this.dgv_patientinfo.CurrentRow.Cells["PatientBednum"].Value.ToString();

             patientname= this.dgv_patientinfo.CurrentRow.Cells["PatientName"].Value.ToString();
            starttime = this.dgv_patientinfo.CurrentRow.Cells["Patientstarttime"].Value.ToString();
             endtime= this.dgv_patientinfo.CurrentRow.Cells["Patientendtime"].Value.ToString();
            if (flag)
            {
                list1 = objPatientBodyInfoService.GetPatientInfoByBednum(getbednum(patientbednum), 1, starttime, endtime);
            }
            else
            {               
                list1 = objPatientBodyInfoService.GetPatientInfoByBednum(getbednum(patientbednum), 0, starttime,"9999-12-29 00:00:00");
            }
            this.dgv_bodyinfo.DataSource = null;
            if (list1.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
           
            this.dgv_bodyinfo.AutoGenerateColumns = false;//禁止生成不需要的列
            this.dgv_bodyinfo.DataSource = list1;
            this.label3.Text = list1.Count.ToString();
        }
        /// <summary>
        /// 导出所有病人详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string strSaveFileLocation = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName =  "所有住院病人基本信息";//设置默认文件名
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
            DataTable  dt = objPatientService.GetPabientInfo();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有任何数据！","系统提示！");
                return;
            }
            NPOI.AllPatientBasicInfoToExcel(dt, strSaveFileLocation);
           
        }
        /// <summary>
        /// 查询历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_selecthistory_Click(object sender, EventArgs e)
        {
            flag = true;
            int bednum=0;
            this.dgv_patientinfo.DataSource = null;
            this.dgv_bodyinfo.DataSource = null;
            string   str = this.txt_get.Text.Trim();
            if (this.txt_get.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入查询条件！", "系统提示");
                this.txt_get.Focus();
                return;
            }

            if (this.rad_bednum.Checked == true)
            {
                if (this.cbxadd.Checked == true)
                {
                    try
                    {
                        bednum = (Convert.ToInt16(str) + 256);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("输入信息有误！", "系统提示");
                        return;
                    }
                   
                }
                else
                {
                    try
                    {
                        bednum = Convert.ToInt16(str);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("输入信息有误！", "系统提示");
                        return;
                    }
                    
                }
                try
                {
                    list = objPatientService.GetPatientInfoByBednum(bednum, 1);
                }
                catch (Exception)
                {
                    MessageBox.Show("输入信息有误！","系统提示");
                    return;
                }
              
                if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                this.dgv_patientinfo.DataSource = null;
                this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
                this.dgv_patientinfo.DataSource = list;

            }
            else if (this.rad_name.Checked == true)
            {
                try
                {
                    list = objPatientService.GetPatientInfoByPatientname(str.ToString(), 1);
                }
                catch (Exception)
                {
                    MessageBox.Show("输入信息有误！", "系统提示");
                    return;
                }
               
                if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                this.dgv_patientinfo.DataSource = null;
                this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
                this.dgv_patientinfo.DataSource = list;
            }
            else
            {
                try
                {
                    list = objPatientService.GetPatientInfoByPatientNum(str.ToString(), 1);
                }
                catch (Exception)
                {
                    MessageBox.Show("输入信息有误！", "系统提示");
                    return;
                }
                
                if (list.Count == 0) { MessageBox.Show("没有任何记录！", "系统提示"); }
                this.dgv_patientinfo.DataSource = null;
                this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
                this.dgv_patientinfo.DataSource = list;
            }
        }

        private void btn_exporthistory_Click(object sender, EventArgs e)
        {
            string strSaveFileLocation = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName = "所有历史病人基本信息";//设置默认文件名
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
            DataTable ds = objPatientService.GetPabienthisInfo();
            if (ds.Rows.Count == 0)
            {
                MessageBox.Show("没有任何数据！", "系统提示！");
                return;
            }
            NPOI.HisPatientBasicInfoToExcel(ds, strSaveFileLocation);
        }

        private void btn_delhistory_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除所有的历史数据？", "系统提示!",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            int a= objPatientService.DeletePatientHisInfo();
            int b= objPatientBodyInfoService.DeletePatientHisBodyInfo();
            if (a > 0)
            {
                MessageBox.Show("删除成功！", "系统提示");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)//备份文件
        {
            String dir = "C:\\HZ";
             //创建备份文件夹，按时间命名  
            String bakDir = dir + "\\back\\" + DateTime.Now.ToString("yyyy-MM-dd");

            if (Directory.Exists(bakDir) == false)
            {
                Directory.CreateDirectory(bakDir);
            }
            try
            {
                File.Copy(PatientInfo.conn + "\\HOSPITAL.db", bakDir + "\\" + "hospital.db");
            }
            catch (Exception ex)
            {
                SQLiteHelper.WriteLog("  private void button1_Click_1(object sender, EventArgs e)//备份文件",ex.Message);               
            }
            MessageBox.Show("备份成功！备份文件位置为："+ bakDir,"系统提示！");        
        }                                                     

        public bool usbisexited()
        {
            if (this.usbhid3.SpecifiedDevice == null)
            {
                MessageBox.Show("请先连接设备！", "系统提示");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnreadsave_Click(object sender, EventArgs e)
        {
            if (usbisexited())
            {              
                return;
            }
            DataHelper.Flag = 14;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            for (int i = 0; i < DataHelper.CommandReadRegisterstate.Length; i++)
            {
                data[2 + i] = DataHelper.CommandReadRegisterstate[i];
            }
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
               
                SQLiteHelper.WriteLog(" private void btnreadsave_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }

            
            

        }
        public void ShowRegisterData()
        {
           
            list2 = objPatirntSaveDataService.GetPatientInfoByBednum();
            this.dgv_patientinfo.AutoGenerateColumns = false;//禁止生成不需要的列
            this.dgv_bodyinfo.DataSource = null;
            this.dgv_bodyinfo.DataSource = list2;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (usbisexited())
            {                
                return;
            }
            DataHelper.Flag = 16;
            byte[] data = new byte[33];
            data[0] = 0; data[1] = 13;
            
            for (int i = 0; i < DataHelper.CommandReadRegisterclear.Length; i++)
            {
                data[2 + i] = DataHelper.CommandReadRegisterclear[i];
            }
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
                SQLiteHelper.WriteLog(" private void btn_clear_Click(object sender, EventArgs e)",ex.Message);
                MessageBox.Show(ex.ToString());
            }
            this.dgv_bodyinfo.DataSource = null;
            if (objPatirntSaveDataService.Clear() > 0)
            {
                MessageBox.Show("清除成功！","系统提示");
            }
        }

        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void btnexperthistoryinfo_Click(object sender, EventArgs e)
        {
            int count = 4;
            if (this.dgv_patientinfo.Rows.Count == 0)
            {
                MessageBox.Show("未选择导出病人！","系统提示");
                return;
            }
            string patientbednum = this.dgv_patientinfo.CurrentRow.Cells["PatientBednum"].Value.ToString();
            string patientbedname= this.dgv_patientinfo.CurrentRow.Cells["PatientName"].Value.ToString();

            PatientInfo patientInfo = objPatientService.GetPatientInfoBybednum(Convert.ToInt16(patientbednum));
            HospitalInfo hospitalInfo = new HospitalInfoService().GetHospitalInfo();
            if (hospitalInfo == null)
            {
                hospitalInfo = new HospitalInfo()
                {
                    HospitalName = "医院名称",
                    Department="科室名称",
                };
            }
            dic.Add("name", patientInfo.PatientName);
            dic.Add("age", patientInfo.PatientAge);
            dic.Add("bednum", patientInfo.PatientBednum);
            dic.Add("patientnum", patientInfo.PatientNum);
            dic.Add("hospital", hospitalInfo.HospitalName);
            dic.Add("depart", hospitalInfo.Department);
            dic.Add("gender", patientInfo.PatientGender);

            string strSaveFileLocation = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName = patientbednum+"床病人"+"详细信息";//设置默认文件名
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
            DataTable ds = GetDgvToTable(this.dgv_bodyinfo);
            //string a = this.dgv_patientinfo.CurrentRow.Cells["PatientBednum"].Value.ToString();
            //DataTable ds = objPatientBodyInfoService.GetPatientInfoBybednum(Convert.ToInt16(a), starttime, endtime);
            if (ds.Rows.Count ==0 )
            {
                MessageBox.Show("没有任何数据！", "系统提示！");
                return;
            }
            dic.Add("stime", ds.Rows[0][0].ToString());
            dic.Add("etime", ds.Rows[ds.Rows.Count - 1][0].ToString());
            if ((checkBox_30.Checked = true) && (checkBox_60.Checked == true))
            {
                MessageBox.Show("不能同时选中两种导出设置！","系统提示");
            }
            if (checkBox_30.Checked == true)
                count = 2;
            if (checkBox_60.Checked == true)
                count = 1;
            // NPOI.NowPatientInfoToExcel(ds, strSaveFileLocation,count);
            try
            {
                NPOI.ExcelPrint("导出数据格式.xls", ds, dic, strSaveFileLocation,count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dic.Clear();
        }


        private void btnexpertsavedata_Click(object sender, EventArgs e)
        {
            if (usbisexited())
            {
                
                return;
            }
            string strSaveFileLocation = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName = "监护仪记录信息";//设置默认文件名
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
            DataTable ds = objPatirntSaveDataService.GetPatientHisInfo();
            if (ds.Rows.Count == 0)
            {
                MessageBox.Show("没有任何数据！", "系统提示！");
                return;
            }

            NPOI.MachinePatientInfoToExcel(ds, strSaveFileLocation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //NPOI.ExcelPrint( "导出数据格式.xls");
        }

        private void checkBox_60_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_60.Checked == true)
            {
                checkBox_30.Checked = false;
            }
        }

        private void checkBox_30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_30.Checked == true)
            {
                checkBox_60.Checked = false;
            }
        }
    }
}
