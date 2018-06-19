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
    public delegate void adddata(string data);
    public partial class FrmShow : Form
    {
     
        public FrmShow()
        {
            InitializeComponent();
          //  this.userControl11.Bednum = "1";
        }

        private void FrmShow_Load(object sender, EventArgs e)
        {
            this.userControl21.Bednum = "269";
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        public void ADDDATA(string data)
        {
            this.listBox1.Items.Insert(0, data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void btncnncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
