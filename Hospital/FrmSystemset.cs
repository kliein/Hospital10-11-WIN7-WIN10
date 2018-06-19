
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsbLibrary;
namespace Hospital
{
 
    public partial class FrmSystemset : Form
    {
        public delegate void addstate(string state);

        public UsbHidPort usbhid1 = null;
        public FrmSystemset()
        {
            InitializeComponent();
            this.panform1.BackgroundImage = Image.FromFile("\\Image\\logo.jpg");
        }
        public void state(string stateinfo)
        {
            this.toolStripStatusLabel1.Text = stateinfo;
        }

        public void states(string stateinfo)
        {
            this.toolStripStatusLabel2.Text = stateinfo;
        }
        public FrmSystemset(bool flag)
        {
            InitializeComponent();
            this.panform1.BackgroundImage = Image.FromFile(PatientInfo.conn + "\\logo.jpg");
            if (flag)
            {
                this.toolStripStatusLabel1.Text = "设备已连接";
            }
            else
            {
                this.toolStripStatusLabel1.Text = "未连接设备";
            }

        }

        private void OpenForm(Form objForm)
        {
            objForm.TopLevel = false;//将当前子窗体设置成非顶级控件
            objForm.WindowState = FormWindowState.Maximized;//设置窗体最大化
            objForm.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            objForm.Parent = this.panform1;//指定当前子窗体显示的容器
            objForm.Show();
        }

        private void CloseForm()
        {
            foreach (Control item in this.panform1.Controls)//遍历容器中是否存在窗体
            {
                if (item is Form)//如果存在窗体
                {
                    Form objControl = (Form)item;//实例化存在的窗体
                    objControl.Close();//关闭存在的窗体
                    this.panform1.Controls.Remove(item);//将该窗体从容器中移除
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.usbhid1.SpecifiedDevice == null)
            {
                MessageBox.Show("当前没有连接任何设备！","系统提示！");
                return;
            }
            if (Commen.stop==1)
            {
                MessageBox.Show("请先关闭监控！", "系统提示！");
                return;
            }
            CloseForm();
            FrmSlave objFrmDataset = new FrmSlave();
            objFrmDataset.addstates = this.states;
            FrmMain.addbodyinfo = objFrmDataset.addbodyinfo;
             FrmMain.getinfo= objFrmDataset.AddReceiveInfo;
            FrmMain.getinfos = objFrmDataset.AddReceiveInfos;
            objFrmDataset.usbhid3 = usbhid1;
            this.OpenForm(objFrmDataset);
        }

        private void FrmSystemset_Load(object sender, EventArgs e)
        {

        }

        private void 数据记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            FrmDataSave objFrmDataSave = new FrmDataSave();
            FrmMain.addRegisterdata = objFrmDataSave.ShowRegisterData;
            objFrmDataSave.usbhid3= usbhid1;
            this.OpenForm(objFrmDataSave);
        }

        private void 接收机参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.usbhid1.SpecifiedDevice == null)
            {
                MessageBox.Show("当前没有连接任何设备！", "系统提示！");
                return;
            }
            if (Commen.stop==1)
            {
                MessageBox.Show("请先关闭监控！", "系统提示！");
                return;
            }
            CloseForm();
            FrmReceiver objFrmReceiver = new FrmReceiver();
            objFrmReceiver.usbhid3 = usbhid1;
            FrmMain.addLRNum = objFrmReceiver.addLRnum;
            FrmMain.addHD = objFrmReceiver.addhD;
            this.OpenForm(objFrmReceiver);
        }

        private void FrmSystemset_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
