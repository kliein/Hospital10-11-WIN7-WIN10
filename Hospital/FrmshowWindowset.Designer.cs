namespace Hospital
{
    partial class FrmshowWindowset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmshowWindowset));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radpart = new System.Windows.Forms.RadioButton();
            this.btn_setbednum = new System.Windows.Forms.Button();
            this.radall = new System.Windows.Forms.RadioButton();
            this.numdown_rowcount = new System.Windows.Forms.NumericUpDown();
            this.numdown_bedcount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_savehospital = new System.Windows.Forms.Button();
            this.txthospitalname = new System.Windows.Forms.TextBox();
            this.txtdepartment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.lblcolor = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numdown_rowcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdown_bedcount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.radpart);
            this.groupBox1.Controls.Add(this.btn_setbednum);
            this.groupBox1.Controls.Add(this.radall);
            this.groupBox1.Controls.Add(this.numdown_rowcount);
            this.groupBox1.Controls.Add(this.numdown_bedcount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[床位布局]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "[模式]";
            // 
            // radpart
            // 
            this.radpart.AutoSize = true;
            this.radpart.Location = new System.Drawing.Point(168, 47);
            this.radpart.Name = "radpart";
            this.radpart.Size = new System.Drawing.Size(98, 21);
            this.radpart.TabIndex = 6;
            this.radpart.TabStop = true;
            this.radpart.Text = "显示已用床位";
            this.radpart.UseVisualStyleBackColor = true;
            // 
            // btn_setbednum
            // 
            this.btn_setbednum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_setbednum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setbednum.Location = new System.Drawing.Point(13, 80);
            this.btn_setbednum.Name = "btn_setbednum";
            this.btn_setbednum.Size = new System.Drawing.Size(149, 36);
            this.btn_setbednum.TabIndex = 3;
            this.btn_setbednum.Text = "确认修改";
            this.btn_setbednum.UseVisualStyleBackColor = false;
            this.btn_setbednum.Click += new System.EventHandler(this.btn_setbednum_Click);
            // 
            // radall
            // 
            this.radall.AutoSize = true;
            this.radall.Location = new System.Drawing.Point(168, 17);
            this.radall.Name = "radall";
            this.radall.Size = new System.Drawing.Size(98, 21);
            this.radall.TabIndex = 5;
            this.radall.TabStop = true;
            this.radall.Text = "显示所有床位";
            this.radall.UseVisualStyleBackColor = true;
            // 
            // numdown_rowcount
            // 
            this.numdown_rowcount.Location = new System.Drawing.Point(95, 47);
            this.numdown_rowcount.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numdown_rowcount.Name = "numdown_rowcount";
            this.numdown_rowcount.Size = new System.Drawing.Size(67, 23);
            this.numdown_rowcount.TabIndex = 4;
            this.numdown_rowcount.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numdown_bedcount
            // 
            this.numdown_bedcount.Location = new System.Drawing.Point(95, 17);
            this.numdown_bedcount.Name = "numdown_bedcount";
            this.numdown_bedcount.Size = new System.Drawing.Size(67, 23);
            this.numdown_bedcount.TabIndex = 4;
            this.numdown_bedcount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "一行显示数量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "床位总数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblcolor);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(289, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[颜色设置]";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(31, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "确认修改";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_savehospital);
            this.groupBox4.Controls.Add(this.txthospitalname);
            this.groupBox4.Controls.Add(this.txtdepartment);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(12, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(541, 146);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[医院科室信息]";
            // 
            // btn_savehospital
            // 
            this.btn_savehospital.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_savehospital.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_savehospital.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_savehospital.Location = new System.Drawing.Point(438, 31);
            this.btn_savehospital.Name = "btn_savehospital";
            this.btn_savehospital.Size = new System.Drawing.Size(70, 91);
            this.btn_savehospital.TabIndex = 3;
            this.btn_savehospital.Text = "保 存";
            this.btn_savehospital.UseVisualStyleBackColor = false;
            this.btn_savehospital.Click += new System.EventHandler(this.btn_savehospital_Click);
            // 
            // txthospitalname
            // 
            this.txthospitalname.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthospitalname.Location = new System.Drawing.Point(95, 36);
            this.txthospitalname.Multiline = true;
            this.txthospitalname.Name = "txthospitalname";
            this.txthospitalname.Size = new System.Drawing.Size(331, 29);
            this.txthospitalname.TabIndex = 2;
            // 
            // txtdepartment
            // 
            this.txtdepartment.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtdepartment.Location = new System.Drawing.Point(95, 85);
            this.txtdepartment.Multiline = true;
            this.txtdepartment.Name = "txtdepartment";
            this.txtdepartment.Size = new System.Drawing.Size(331, 29);
            this.txtdepartment.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "科室名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "医院名称：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "模块颜色设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblcolor
            // 
            this.lblcolor.BackColor = System.Drawing.SystemColors.Control;
            this.lblcolor.Location = new System.Drawing.Point(148, 26);
            this.lblcolor.Name = "lblcolor";
            this.lblcolor.Size = new System.Drawing.Size(56, 26);
            this.lblcolor.TabIndex = 9;
            // 
            // FrmshowWindowset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 323);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmshowWindowset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监护设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmshowWindowset_FormClosing);
            this.Load += new System.EventHandler(this.FrmshowWindowset_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numdown_rowcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdown_bedcount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_setbednum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_savehospital;
        private System.Windows.Forms.TextBox txthospitalname;
        private System.Windows.Forms.TextBox txtdepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numdown_rowcount;
        private System.Windows.Forms.NumericUpDown numdown_bedcount;
        private System.Windows.Forms.RadioButton radpart;
        private System.Windows.Forms.RadioButton radall;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblcolor;
    }
}