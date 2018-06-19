using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsShow
{
    public delegate void selectBtn();
    public delegate void exportBtn();
    public delegate void connectBtn();
    public delegate void openBtn();

    public partial class UserControl2 : UserControl
    {
        public selectBtn objselectBtn;
        public exportBtn objexportBtn;
        public connectBtn objconnectBtn;
        public openBtn objopenBtn;

        public event EventHandler selectBtnClick;
        public event EventHandler exportBtnClick;
        public event EventHandler connectBtnClick;
        public event EventHandler openBtnClick;
        public event EventHandler getBtnClick;
        public event EventHandler writeBtnClick;
        public event EventHandler endBtnClick;
        private Pen TablePen = new Pen(Color.FromArgb(0xff, 0x00, 0x00));
        public UserControl2()
        {


            InitializeComponent();
            //设置文本框只读属性
            this.txt_name.ReadOnly = true;
            this.txt_liuliang.ReadOnly = true;
            this.txt_bednum.ReadOnly = true;
            this.txt_bpm.ReadOnly = true;
            this.txt_O2.ReadOnly = true;
            this.txt_time.ReadOnly = true;

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            //this.pic_battery.Parent = this.tToolStripMenuItem;
        }
        private System.Drawing.Image batteryimage;     //字段
        public System.Drawing.Image Batteryimage      //属性
        {
            set
            {
                batteryimage = value;
                this.menuStrip1.BackgroundImage = batteryimage;
            }
        }

        private System.Drawing.Color  backColor;     //字段
        public System.Drawing.Color myBackColor      //属性
        {
            set
            {
                backColor = value;
                this.menuStrip1.BackColor = backColor;
            }
        }

        private System.Drawing.Color lblbackcolor;     //字段
        public System.Drawing.Color Lblbackcolor      //属性
        {
            set
            {
                lblbackcolor = value;
                this.lblbattery.ForeColor = lblbackcolor;
            }
        }
        /// <summary>
        /// 录入信息按钮使能
        /// </summary>
        private bool  flag;     //字段
        public bool  Falg      //属性
        {
            get
            {
                flag = this.录入信息ToolStripMenuItem.Enabled;
                return flag;
            }
            set
            {
                flag = value;
                this.录入信息ToolStripMenuItem.Enabled = flag;

            }
        }
        /// <summary>
        /// 数据查询按钮tag
        /// </summary>
        private int  btnselecttag;     //字段
        public int  Btnselecttag      //属性
        {
            get
            {
                btnselecttag =Convert.ToInt32( this.btnselectdata.Tag);
                return btnselecttag;
            }
            set
            {
                btnselecttag = value;
                this.btnselectdata.Tag = btnselecttag;

            }
        }
        /// <summary>
        /// 数据导出tag
        /// </summary>
        private int  btnexporttag;     //字段
        public int  Btnexporttag      //属性
        {
            get
            {
                btnexporttag =Convert.ToInt32( this.btnsavedata.Tag);
                return btnexporttag;
            }
            set
            {
                btnexporttag = value;
                this.btnsavedata.Tag = btnexporttag;

            }
        }
        /// <summary>
        /// 人机匹配tag
        /// </summary>
        private int btnpipeitag;     //字段
        public int Btnpipeitag      //属性
        {
            get
            {
                btnpipeitag = Convert.ToInt32( this.btnpipei.Tag);
                return btnpipeitag;
            }
            set
            {
                btnpipeitag = value;
                this.btnpipei.Tag = btnpipeitag;

            }
        }
        /// <summary>
        /// 开启监控tag
        /// </summary>
        private int btnstarttag;     //字段
        public int Btnstarttag      //属性
        {
            get
            {
                btnstarttag =Convert.ToInt32( this.btnstart.Tag);
                return btnstarttag;
            }
            set
            {
                btnstarttag = value;
                this.btnstart.Tag = btnstarttag;

            }
        }
        /// <summary>
        /// 录入信息tag
        /// </summary>
        private int getToolStripMenuItemtag;     //字段
        public int GetToolStripMenuItemtag      //属性
        {
            get
            {
                getToolStripMenuItemtag =Convert.ToInt32( this.录入信息ToolStripMenuItem.Tag);
                return getToolStripMenuItemtag;
            }
            set
            {
                getToolStripMenuItemtag = value;
                this.录入信息ToolStripMenuItem.Tag = getToolStripMenuItemtag;
               
            }
        }
        /// <summary>
        /// 修改信息tag
        /// </summary>
        private int writeToolStripMenuItemtag;     //字段
        public int WriteToolStripMenuItemtag      //属性
        {
            get
            {
                writeToolStripMenuItemtag =Convert.ToInt32( this.修改信息ToolStripMenuItem.Tag);
                return writeToolStripMenuItemtag;
            }
            set
            {
                writeToolStripMenuItemtag = value;
                this.修改信息ToolStripMenuItem.Tag = writeToolStripMenuItemtag;

            }
        }
        /// <summary>
        /// 病人出院
        /// </summary>
        private int endToolStripMenuItemtag;     //字段
        public int EndToolStripMenuItemtag      //属性
        {
            get
            {
                endToolStripMenuItemtag =Convert.ToInt32( this.病人出院ToolStripMenuItem.Tag);
                return endToolStripMenuItemtag;
            }
            set
            {
                endToolStripMenuItemtag = value;
                this.病人出院ToolStripMenuItem.Tag = endToolStripMenuItemtag;

            }
        }
        private string state;     //字段
        public string State      //属性
        {
            get
            {
                state = this.lblbattery.Text.Trim();
                return state;
            }
            set
            {
               
                state = value;
                this.lblbattery.Text=state;

            }
        }
        /// <summary>
        /// 床号
        /// </summary>
        private string bednum;     //字段
        public string Bednum      //属性
        {
            get
            {
                string str = this.txt_bednum.Text.Trim();             
                    if (str[0] == 35)
                    {
                        string subString2 = str.Substring(1, str.Length - 1);
                        bednum=( Convert.ToInt16(subString2) + 256).ToString();
                        return bednum;
                    }
                    else
                    {
                        return str;
                    }   
            }
            set
            {
                // this.txt_bednum.Text = "";
                bednum = value;
                if (Convert.ToInt32(bednum) > 255)
                {
                    this.txt_bednum.Text = ("#" + (Convert.ToInt32(bednum) - 256)).ToString();
                }
                else
                {
                    this.txt_bednum.Text = bednum;
                }
              

            }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        private string peoplename;     //字段
        public string Peoplename      //属性
        {
            get
            {
                peoplename = this.txt_name.Text.Trim();
                return peoplename;
            }
            set
            {
                peoplename = value;
                this.txt_name.Text = peoplename;

            }
        }
        private string battery;     //字段
        public string Battery      //属性
        {
            get
            {
                battery = this.lblbattery.Text.Trim();
                return battery;
            }
            set
            {
                battery = value;
                this.lblbattery.Text = battery;

            }
        }
        /// <summary>
        /// 血氧
        /// </summary>
        private string o2;     //字段
        public string O2      //属性
        {
            get
            {
                o2 = this.txt_O2.Text.Trim();
                return o2;
            }
            set
            {
                o2 = value;
                this.txt_O2.Text = o2;

            }
        }
        /// <summary>
        /// 脉率
        /// </summary>
        private string bpm;     //字段
        public string Bpm      //属性
        {
            get
            {
                bpm = this.txt_bpm.Text.Trim();
                return bpm;
            }
            set
            {
                bpm = value;
                this.txt_bpm.Text = bpm;

            }
        }
        /// <summary>
        /// 氧流量
        /// </summary>
        private string o2flow;     //字段
        public string O2flow      //属性
        {
            get
            {
                o2flow = this.txt_liuliang.Text.Trim();
                return o2flow;
            }
            set
            {
                o2flow = value;
                this.txt_liuliang.Text = o2flow;

            }
        }
        /// <summary>
        /// 吸氧时间
        /// </summary>
        private string time;     //字段
        public string Time      //属性
        {
            get
            {
                time = this.txt_time.Text.Trim();
                return time;
            }
            set
            {
                time = value;
                this.txt_time.Text = time;

            }
        }


        private Color backcolor;
        public Color Textbackcolor
        {
            get
            {
                backcolor = this.txt_bednum.BackColor;
                return backcolor;
            }
            set
            {
                backcolor = value;
                this.txt_bednum.BackColor = backcolor;
                this.txt_bpm.BackColor = backcolor;
                this.txt_O2.BackColor = backcolor;
                this.txt_name.BackColor = backcolor;
                this.txt_liuliang.BackColor = backcolor;
                this.txt_time.BackColor = backcolor;
            }
        }
        private void btnselectdata_Click(object sender, EventArgs e)
        {
            this.selectBtnClick(sender, e);
        }

        private void dtnsavedata_Click(object sender, EventArgs e)
        {
            this.exportBtnClick(sender, e);
        }

        private void btnpipei_Click(object sender, EventArgs e)
        {
            this.connectBtnClick(sender, e);
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            this.openBtnClick(sender, e);
        }

        private void 录入信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.getBtnClick(sender, e);
        }

        private void 修改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writeBtnClick(sender, e);
        }

        private void 病人出院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.endBtnClick(sender, e);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UserControl2_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //GraphicsPath gp = new GraphicsPath();
            //e.Graphics.FillRectangle(Brushes.White, e.Graphics.ClipBounds);
            //FontFamily family = new FontFamily("Arial");
            //int fontstyle = (int)FontStyle.Italic;
            //e.Graphics.DrawRectangle(TablePen, 5, 5, 30, 20);
            


        }

        private void txt_bednum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
