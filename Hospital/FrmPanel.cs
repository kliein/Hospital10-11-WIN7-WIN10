using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Protocol;
using System.IO;
using System.Management;

namespace Hospital
{


    // class Info
    //{
    //    public string FirstName { get; set; }//省

    //    public string SecondName { get; set; }//市
    //    public string ThirdName { get; set; }//区
    //    public string ID { get; set; }//编号
        
    //}
    public partial class FrmPanel : Form
    {

        //Info[] list = new Info[100];
        
        public FrmPanel()
        {
            //InitializeComponent();
            //list[0].FirstName = "陕西省";
            //list[0].SecondName = "西安市";
            //list[0].ThirdName = "高新区";
            //list[0].ID = "100001";


        }

        private void FrmPanel_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < list.Length; i++)
            //{
            //    if (list[i].FirstName == "传参数")
            //    {
            //        //返回其他属性

            //    }
            //}
        //    this.userControl21.Bednum = "259";
        }


        private void button1_Click(object sender, EventArgs e)//数组合并
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
            this.textBox1.Text = code;

            //byte[] Num1 = { 1 };
            //byte[] Num2 = { 0x00, 0x00, 0x00, 0x30 };
            //byte[] num3 = { 5};
            //byte[] num4 = { 1,2,3,4,5 };
            //byte[] result=SendCommandHelper.AssembleData(Num1, Num2, num3, num4);
            //byte[] result1 = SendCommandHelper.AssembleSendData(result);
            //for (int i = 0; i < result1.Length; i++)
            //{
            //    this.textBox1.AppendText(result1[i].ToString("X2") + " ");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           // saveFileDialog1.InitialDirectory = Path.GetDirectoryName(strPartPath);
            //设置文件类型
            saveFileDialog1.Filter = "Excel 工作簿（*.xlsx）|*.xlsx|Excel 启动宏的工作簿（*.xlsm）|*.xlsm|Excel 97-2003工作簿（*.xls）|*.xls";
            //saveFileDialog1.FilterIndex = 1;//设置文件类型显示
            saveFileDialog1.FileName = "自己取个";//设置默认文件名
            saveFileDialog1.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            saveFileDialog1.CheckPathExists = true;//检查目录
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strSaveFileLocation = saveFileDialog1.FileName;//文件路径
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.label1.Show();
            }
            else
            {
                this.label1.Hide();
            }
        }
    }


}
