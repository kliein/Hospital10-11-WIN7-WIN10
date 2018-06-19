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
    public partial class UserControl1 : UserControl
    {

      //  Graphics gra = CreateGraphics();
        Font font = new Font("华为宋体", 16);
        Pen pen = new Pen(Color.Black);
        public UserControl1()
        {
            InitializeComponent();

        }
        public void drawstring(int x,int y,string str)
        {
            Graphics gra = this.CreateGraphics();
            Font font = new Font("华为宋体", 16);
            Pen pen = new Pen(Color.Black);
            gra.DrawString(str, font, Brushes.Black, x, y);
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        private string bednum;     //字段
        public string Bednum      //属性
        {

        get
            {
               return "";
            }
            set
            {
                bednum = value;

                Graphics gra = this.CreateGraphics();
                Font font = new Font("华为宋体", 16);
                Pen pen = new Pen(Color.Black);
                gra.DrawString(bednum, font, Brushes.Black, 70, 10);
                // drawstring(70,10,bednum);
                //     this.txt_bednum.Text = bednum;

            }
        }






        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gra = this.CreateGraphics();
            Font font = new Font("华为宋体", 16);

            Pen pen = new Pen(Color.Black);
            gra.DrawRectangle(pen, 60, 10, 50, 30);
            gra.DrawRectangle(pen, 170, 10, 70, 30);
            gra.DrawRectangle(pen, 110, 50, 90, 30);
            gra.DrawRectangle(pen, 110, 90, 90, 30);
            gra.DrawRectangle(pen, 110, 130, 90, 30);
            gra.DrawRectangle(pen, 110, 170, 90, 30);
            gra.DrawString("床号：", font, Brushes.Black, 0,12);
            gra.DrawString("姓名：", font, Brushes.Black, 110,12);
            gra.DrawString("血氧：", font, Brushes.Black, 0, 52);
            gra.DrawString("%", font, Brushes.Black, 200, 52);
            gra.DrawString("脉率：", font, Brushes.Black, 0, 90);
            gra.DrawString("bpm", font, Brushes.Black, 200, 90);
            gra.DrawString("氧流量：", font, Brushes.Black, 0, 130);
            gra.DrawString("升", font, Brushes.Black, 200, 130);
            gra.DrawString("吸氧时间：", font, Brushes.Black, 0, 170);
            gra.DrawString("时", font, Brushes.Black, 200, 170);
            pen.Dispose();
            gra.Dispose();
        }
    }
}
