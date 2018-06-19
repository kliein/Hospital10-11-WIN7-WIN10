namespace WindowsFormsShow
{
    partial class UserControl2
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_bednum = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.btnsavedata = new System.Windows.Forms.Button();
            this.btnpipei = new System.Windows.Forms.Button();
            this.btnselectdata = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.txt_liuliang = new System.Windows.Forms.TextBox();
            this.txt_bpm = new System.Windows.Forms.TextBox();
            this.txt_O2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.病人出院ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_zhuangtai = new System.Windows.Forms.Label();
            this.lblbattery = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_bednum
            // 
            this.txt_bednum.BackColor = System.Drawing.Color.White;
            this.txt_bednum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_bednum.Location = new System.Drawing.Point(44, 31);
            this.txt_bednum.Multiline = true;
            this.txt_bednum.Name = "txt_bednum";
            this.txt_bednum.Size = new System.Drawing.Size(52, 25);
            this.txt_bednum.TabIndex = 71;
            this.txt_bednum.TextChanged += new System.EventHandler(this.txt_bednum_TextChanged);
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.White;
            this.txt_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_name.ForeColor = System.Drawing.Color.Black;
            this.txt_name.Location = new System.Drawing.Point(139, 31);
            this.txt_name.Multiline = true;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(73, 25);
            this.txt_name.TabIndex = 70;
            // 
            // btnstart
            // 
            this.btnstart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnstart.Location = new System.Drawing.Point(104, 263);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(101, 28);
            this.btnstart.TabIndex = 69;
            this.btnstart.Tag = "0";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnsavedata
            // 
            this.btnsavedata.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsavedata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsavedata.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsavedata.Location = new System.Drawing.Point(108, 179);
            this.btnsavedata.Name = "btnsavedata";
            this.btnsavedata.Size = new System.Drawing.Size(101, 28);
            this.btnsavedata.TabIndex = 68;
            this.btnsavedata.Tag = "0";
            this.btnsavedata.Text = "数据导出";
            this.btnsavedata.UseVisualStyleBackColor = true;
            this.btnsavedata.Click += new System.EventHandler(this.dtnsavedata_Click);
            // 
            // btnpipei
            // 
            this.btnpipei.Enabled = false;
            this.btnpipei.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnpipei.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpipei.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnpipei.Location = new System.Drawing.Point(-1, 263);
            this.btnpipei.Name = "btnpipei";
            this.btnpipei.Size = new System.Drawing.Size(103, 28);
            this.btnpipei.TabIndex = 67;
            this.btnpipei.Tag = "0";
            this.btnpipei.UseVisualStyleBackColor = true;
            this.btnpipei.Click += new System.EventHandler(this.btnpipei_Click);
            // 
            // btnselectdata
            // 
            this.btnselectdata.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnselectdata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselectdata.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnselectdata.Location = new System.Drawing.Point(3, 179);
            this.btnselectdata.Name = "btnselectdata";
            this.btnselectdata.Size = new System.Drawing.Size(103, 28);
            this.btnselectdata.TabIndex = 66;
            this.btnselectdata.Tag = "0";
            this.btnselectdata.Text = "查看数据";
            this.btnselectdata.UseVisualStyleBackColor = true;
            this.btnselectdata.Click += new System.EventHandler(this.btnselectdata_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(173, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 21);
            this.label10.TabIndex = 64;
            this.label10.Text = "时";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(173, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 21);
            this.label9.TabIndex = 65;
            this.label9.Text = "升";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(170, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 21);
            this.label8.TabIndex = 63;
            this.label8.Text = "bpm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(173, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 21);
            this.label7.TabIndex = 62;
            this.label7.Text = "%";
            // 
            // txt_time
            // 
            this.txt_time.BackColor = System.Drawing.Color.White;
            this.txt_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_time.Location = new System.Drawing.Point(91, 145);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(79, 29);
            this.txt_time.TabIndex = 58;
            // 
            // txt_liuliang
            // 
            this.txt_liuliang.BackColor = System.Drawing.Color.White;
            this.txt_liuliang.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_liuliang.Location = new System.Drawing.Point(91, 116);
            this.txt_liuliang.Name = "txt_liuliang";
            this.txt_liuliang.Size = new System.Drawing.Size(79, 29);
            this.txt_liuliang.TabIndex = 59;
            // 
            // txt_bpm
            // 
            this.txt_bpm.BackColor = System.Drawing.Color.White;
            this.txt_bpm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_bpm.Location = new System.Drawing.Point(91, 87);
            this.txt_bpm.Name = "txt_bpm";
            this.txt_bpm.Size = new System.Drawing.Size(79, 29);
            this.txt_bpm.TabIndex = 60;
            // 
            // txt_O2
            // 
            this.txt_O2.BackColor = System.Drawing.Color.White;
            this.txt_O2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_O2.Location = new System.Drawing.Point(91, 59);
            this.txt_O2.Name = "txt_O2";
            this.txt_O2.Size = new System.Drawing.Size(79, 29);
            this.txt_O2.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(2, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 54;
            this.label6.Text = "吸氧时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(2, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 55;
            this.label5.Text = "氧流量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(2, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "脉率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 57;
            this.label2.Text = "血氧：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(97, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 52;
            this.label3.Text = "姓名";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 53;
            this.label1.Text = "床位：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LightCyan;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(-2, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(220, 28);
            this.menuStrip1.TabIndex = 72;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // tToolStripMenuItem
            // 
            this.tToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.录入信息ToolStripMenuItem,
            this.修改信息ToolStripMenuItem,
            this.病人出院ToolStripMenuItem});
            this.tToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tToolStripMenuItem.Name = "tToolStripMenuItem";
            this.tToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.tToolStripMenuItem.Text = "管理";
            // 
            // 录入信息ToolStripMenuItem
            // 
            this.录入信息ToolStripMenuItem.Enabled = false;
            this.录入信息ToolStripMenuItem.Name = "录入信息ToolStripMenuItem";
            this.录入信息ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.录入信息ToolStripMenuItem.Tag = "0";
            this.录入信息ToolStripMenuItem.Text = "待设置";
            this.录入信息ToolStripMenuItem.Click += new System.EventHandler(this.录入信息ToolStripMenuItem_Click);
            // 
            // 修改信息ToolStripMenuItem
            // 
            this.修改信息ToolStripMenuItem.Name = "修改信息ToolStripMenuItem";
            this.修改信息ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.修改信息ToolStripMenuItem.Tag = "0";
            this.修改信息ToolStripMenuItem.Text = "修改信息";
            this.修改信息ToolStripMenuItem.Click += new System.EventHandler(this.修改信息ToolStripMenuItem_Click);
            // 
            // 病人出院ToolStripMenuItem
            // 
            this.病人出院ToolStripMenuItem.Name = "病人出院ToolStripMenuItem";
            this.病人出院ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.病人出院ToolStripMenuItem.Tag = "0";
            this.病人出院ToolStripMenuItem.Text = "病人出院";
            this.病人出院ToolStripMenuItem.Click += new System.EventHandler(this.病人出院ToolStripMenuItem_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(2, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 73;
            this.label11.Text = "状态：";
            // 
            // lbl_zhuangtai
            // 
            this.lbl_zhuangtai.AutoSize = true;
            this.lbl_zhuangtai.BackColor = System.Drawing.Color.LightCyan;
            this.lbl_zhuangtai.Location = new System.Drawing.Point(68, 6);
            this.lbl_zhuangtai.Name = "lbl_zhuangtai";
            this.lbl_zhuangtai.Size = new System.Drawing.Size(0, 17);
            this.lbl_zhuangtai.TabIndex = 75;
            // 
            // lblbattery
            // 
            this.lblbattery.BackColor = System.Drawing.Color.LightGray;
            this.lblbattery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbattery.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblbattery.Location = new System.Drawing.Point(58, 217);
            this.lblbattery.Name = "lblbattery";
            this.lblbattery.Size = new System.Drawing.Size(149, 23);
            this.lblbattery.TabIndex = 76;
            this.lblbattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblbattery);
            this.Controls.Add(this.lbl_zhuangtai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_bednum);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.btnsavedata);
            this.Controls.Add(this.btnpipei);
            this.Controls.Add(this.btnselectdata);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.txt_liuliang);
            this.Controls.Add(this.txt_bpm);
            this.Controls.Add(this.txt_O2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(216, 250);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl2_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_bednum;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnsavedata;
        private System.Windows.Forms.Button btnpipei;
        private System.Windows.Forms.Button btnselectdata;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.TextBox txt_liuliang;
        private System.Windows.Forms.TextBox txt_bpm;
        private System.Windows.Forms.TextBox txt_O2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 病人出院ToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_zhuangtai;
        private System.Windows.Forms.Label lblbattery;
    }
}
