namespace Hospital
{
    partial class FrmDataSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataSave));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxadd = new System.Windows.Forms.CheckBox();
            this.btn_selecthistory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_get = new System.Windows.Forms.TextBox();
            this.rad_patienrnum = new System.Windows.Forms.RadioButton();
            this.rad_name = new System.Windows.Forms.RadioButton();
            this.rad_bednum = new System.Windows.Forms.RadioButton();
            this.dgv_patientinfo = new System.Windows.Forms.DataGridView();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientBednum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patientstarttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patientendtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_bodyinfo = new System.Windows.Forms.DataGridView();
            this.PatientBodyInfotime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloodO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pluse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetO2time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetO2totaltime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_exporthistory = new System.Windows.Forms.Button();
            this.btn_delhistory = new System.Windows.Forms.Button();
            this.btnreadsave = new System.Windows.Forms.Button();
            this.btnexpertsavedata = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btnexperthistoryinfo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_60 = new System.Windows.Forms.CheckBox();
            this.checkBox_30 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patientinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bodyinfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxadd);
            this.groupBox2.Controls.Add(this.btn_selecthistory);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_select);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_get);
            this.groupBox2.Controls.Add(this.rad_patienrnum);
            this.groupBox2.Controls.Add(this.rad_name);
            this.groupBox2.Controls.Add(this.rad_bednum);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[查询方式]";
            // 
            // cbxadd
            // 
            this.cbxadd.AutoSize = true;
            this.cbxadd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxadd.Location = new System.Drawing.Point(169, 83);
            this.cbxadd.Name = "cbxadd";
            this.cbxadd.Size = new System.Drawing.Size(77, 25);
            this.cbxadd.TabIndex = 4;
            this.cbxadd.Text = "加床位";
            this.cbxadd.UseVisualStyleBackColor = true;
            // 
            // btn_selecthistory
            // 
            this.btn_selecthistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selecthistory.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selecthistory.Location = new System.Drawing.Point(253, 100);
            this.btn_selecthistory.Name = "btn_selecthistory";
            this.btn_selecthistory.Size = new System.Drawing.Size(101, 28);
            this.btn_selecthistory.TabIndex = 3;
            this.btn_selecthistory.Text = "查询历史";
            this.btn_selecthistory.UseVisualStyleBackColor = true;
            this.btn_selecthistory.Click += new System.EventHandler(this.btn_selecthistory_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(253, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "备份数据";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_select
            // 
            this.btn_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_select.Location = new System.Drawing.Point(253, 60);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(101, 29);
            this.btn_select.TabIndex = 3;
            this.btn_select.Text = "查询当前";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入条件：";
            // 
            // txt_get
            // 
            this.txt_get.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_get.Location = new System.Drawing.Point(83, 78);
            this.txt_get.Multiline = true;
            this.txt_get.Name = "txt_get";
            this.txt_get.Size = new System.Drawing.Size(80, 34);
            this.txt_get.TabIndex = 1;
            // 
            // rad_patienrnum
            // 
            this.rad_patienrnum.AutoSize = true;
            this.rad_patienrnum.Location = new System.Drawing.Point(166, 29);
            this.rad_patienrnum.Name = "rad_patienrnum";
            this.rad_patienrnum.Size = new System.Drawing.Size(62, 21);
            this.rad_patienrnum.TabIndex = 0;
            this.rad_patienrnum.Text = "住院号";
            this.rad_patienrnum.UseVisualStyleBackColor = true;
            this.rad_patienrnum.CheckedChanged += new System.EventHandler(this.rad_datahour_CheckedChanged);
            // 
            // rad_name
            // 
            this.rad_name.AutoSize = true;
            this.rad_name.Location = new System.Drawing.Point(85, 29);
            this.rad_name.Name = "rad_name";
            this.rad_name.Size = new System.Drawing.Size(62, 21);
            this.rad_name.TabIndex = 0;
            this.rad_name.Text = "按姓名";
            this.rad_name.UseVisualStyleBackColor = true;
            this.rad_name.CheckedChanged += new System.EventHandler(this.rad_datahour_CheckedChanged);
            // 
            // rad_bednum
            // 
            this.rad_bednum.AutoSize = true;
            this.rad_bednum.Checked = true;
            this.rad_bednum.Location = new System.Drawing.Point(6, 29);
            this.rad_bednum.Name = "rad_bednum";
            this.rad_bednum.Size = new System.Drawing.Size(62, 21);
            this.rad_bednum.TabIndex = 0;
            this.rad_bednum.TabStop = true;
            this.rad_bednum.Text = "按床号";
            this.rad_bednum.UseVisualStyleBackColor = true;
            this.rad_bednum.CheckedChanged += new System.EventHandler(this.rad_datahour_CheckedChanged);
            // 
            // dgv_patientinfo
            // 
            this.dgv_patientinfo.AllowUserToAddRows = false;
            this.dgv_patientinfo.AllowUserToDeleteRows = false;
            this.dgv_patientinfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_patientinfo.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgv_patientinfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_patientinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_patientinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientName,
            this.PatientNum,
            this.PatientBednum,
            this.Patientstarttime,
            this.Patientendtime});
            this.dgv_patientinfo.GridColor = System.Drawing.Color.DarkTurquoise;
            this.dgv_patientinfo.Location = new System.Drawing.Point(378, 12);
            this.dgv_patientinfo.Name = "dgv_patientinfo";
            this.dgv_patientinfo.ReadOnly = true;
            this.dgv_patientinfo.RowHeadersVisible = false;
            this.dgv_patientinfo.RowTemplate.Height = 23;
            this.dgv_patientinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_patientinfo.Size = new System.Drawing.Size(466, 304);
            this.dgv_patientinfo.TabIndex = 2;
            this.dgv_patientinfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_patientinfo_CellClick);
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "姓名";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // PatientNum
            // 
            this.PatientNum.DataPropertyName = "PatientNum";
            this.PatientNum.HeaderText = "住院号";
            this.PatientNum.Name = "PatientNum";
            this.PatientNum.ReadOnly = true;
            // 
            // PatientBednum
            // 
            this.PatientBednum.DataPropertyName = "PatientBednum";
            this.PatientBednum.HeaderText = "床号";
            this.PatientBednum.Name = "PatientBednum";
            this.PatientBednum.ReadOnly = true;
            // 
            // Patientstarttime
            // 
            this.Patientstarttime.DataPropertyName = "Patientstarttime";
            this.Patientstarttime.HeaderText = "住院时间";
            this.Patientstarttime.Name = "Patientstarttime";
            this.Patientstarttime.ReadOnly = true;
            // 
            // Patientendtime
            // 
            this.Patientendtime.DataPropertyName = "Patientendtime";
            this.Patientendtime.HeaderText = "出院时间";
            this.Patientendtime.Name = "Patientendtime";
            this.Patientendtime.ReadOnly = true;
            // 
            // dgv_bodyinfo
            // 
            this.dgv_bodyinfo.AllowUserToAddRows = false;
            this.dgv_bodyinfo.AllowUserToDeleteRows = false;
            this.dgv_bodyinfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_bodyinfo.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgv_bodyinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bodyinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientBodyInfotime,
            this.BloodO2,
            this.Pluse,
            this.Flux,
            this.Model,
            this.Error,
            this.GetO2time,
            this.GetO2totaltime});
            this.dgv_bodyinfo.GridColor = System.Drawing.Color.DarkTurquoise;
            this.dgv_bodyinfo.Location = new System.Drawing.Point(12, 322);
            this.dgv_bodyinfo.Name = "dgv_bodyinfo";
            this.dgv_bodyinfo.ReadOnly = true;
            this.dgv_bodyinfo.RowHeadersVisible = false;
            this.dgv_bodyinfo.RowTemplate.Height = 23;
            this.dgv_bodyinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_bodyinfo.Size = new System.Drawing.Size(832, 220);
            this.dgv_bodyinfo.TabIndex = 3;
            // 
            // PatientBodyInfotime
            // 
            this.PatientBodyInfotime.DataPropertyName = "PatientBodyInfotime";
            this.PatientBodyInfotime.HeaderText = "时间";
            this.PatientBodyInfotime.Name = "PatientBodyInfotime";
            this.PatientBodyInfotime.ReadOnly = true;
            // 
            // BloodO2
            // 
            this.BloodO2.DataPropertyName = "BloodO2";
            this.BloodO2.HeaderText = "血氧(%)";
            this.BloodO2.Name = "BloodO2";
            this.BloodO2.ReadOnly = true;
            // 
            // Pluse
            // 
            this.Pluse.DataPropertyName = "Pluse";
            this.Pluse.HeaderText = "脉率(bpm)";
            this.Pluse.Name = "Pluse";
            this.Pluse.ReadOnly = true;
            // 
            // Flux
            // 
            this.Flux.DataPropertyName = "Flux";
            this.Flux.HeaderText = "流量(L)";
            this.Flux.Name = "Flux";
            this.Flux.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.DataPropertyName = "Model";
            this.Model.HeaderText = "模式";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // Error
            // 
            this.Error.DataPropertyName = "Error";
            this.Error.HeaderText = "报警";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            // 
            // GetO2time
            // 
            this.GetO2time.DataPropertyName = "GetO2time";
            this.GetO2time.HeaderText = "吸氧时间(h)";
            this.GetO2time.Name = "GetO2time";
            this.GetO2time.ReadOnly = true;
            // 
            // GetO2totaltime
            // 
            this.GetO2totaltime.DataPropertyName = "GetO2totaltime";
            this.GetO2totaltime.HeaderText = "吸氧总时间(h)";
            this.GetO2totaltime.Name = "GetO2totaltime";
            this.GetO2totaltime.ReadOnly = true;
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export.Location = new System.Drawing.Point(12, 148);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(175, 32);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "导出该科室在住病人基本信息";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_exporthistory
            // 
            this.btn_exporthistory.BackColor = System.Drawing.Color.LightPink;
            this.btn_exporthistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exporthistory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exporthistory.Location = new System.Drawing.Point(193, 148);
            this.btn_exporthistory.Name = "btn_exporthistory";
            this.btn_exporthistory.Size = new System.Drawing.Size(179, 32);
            this.btn_exporthistory.TabIndex = 4;
            this.btn_exporthistory.Text = "导出该科室历史病人基本信息";
            this.btn_exporthistory.UseVisualStyleBackColor = false;
            this.btn_exporthistory.Click += new System.EventHandler(this.btn_exporthistory_Click);
            // 
            // btn_delhistory
            // 
            this.btn_delhistory.BackColor = System.Drawing.Color.LightPink;
            this.btn_delhistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delhistory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_delhistory.Location = new System.Drawing.Point(193, 186);
            this.btn_delhistory.Name = "btn_delhistory";
            this.btn_delhistory.Size = new System.Drawing.Size(179, 32);
            this.btn_delhistory.TabIndex = 4;
            this.btn_delhistory.Text = "删除历史病人信息";
            this.btn_delhistory.UseVisualStyleBackColor = false;
            this.btn_delhistory.Click += new System.EventHandler(this.btn_delhistory_Click);
            // 
            // btnreadsave
            // 
            this.btnreadsave.BackColor = System.Drawing.Color.Thistle;
            this.btnreadsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreadsave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnreadsave.Location = new System.Drawing.Point(12, 223);
            this.btnreadsave.Name = "btnreadsave";
            this.btnreadsave.Size = new System.Drawing.Size(103, 29);
            this.btnreadsave.TabIndex = 4;
            this.btnreadsave.Text = "读取监护仪记录";
            this.btnreadsave.UseVisualStyleBackColor = false;
            this.btnreadsave.Click += new System.EventHandler(this.btnreadsave_Click);
            // 
            // btnexpertsavedata
            // 
            this.btnexpertsavedata.BackColor = System.Drawing.Color.Thistle;
            this.btnexpertsavedata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexpertsavedata.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnexpertsavedata.Location = new System.Drawing.Point(121, 223);
            this.btnexpertsavedata.Name = "btnexpertsavedata";
            this.btnexpertsavedata.Size = new System.Drawing.Size(119, 29);
            this.btnexpertsavedata.TabIndex = 4;
            this.btnexpertsavedata.Text = "导出监护仪记录";
            this.btnexpertsavedata.UseVisualStyleBackColor = false;
            this.btnexpertsavedata.Click += new System.EventHandler(this.btnexpertsavedata_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Thistle;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clear.Location = new System.Drawing.Point(247, 223);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(125, 29);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "清除监护仪记录";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btnexperthistoryinfo
            // 
            this.btnexperthistoryinfo.BackColor = System.Drawing.Color.LightPink;
            this.btnexperthistoryinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexperthistoryinfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnexperthistoryinfo.Location = new System.Drawing.Point(12, 186);
            this.btnexperthistoryinfo.Name = "btnexperthistoryinfo";
            this.btnexperthistoryinfo.Size = new System.Drawing.Size(175, 31);
            this.btnexperthistoryinfo.TabIndex = 5;
            this.btnexperthistoryinfo.Text = "导出该病人详细信息";
            this.btnexperthistoryinfo.UseVisualStyleBackColor = false;
            this.btnexperthistoryinfo.Click += new System.EventHandler(this.btnexperthistoryinfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "记录条数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(80, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(139, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "条";
            // 
            // checkBox_60
            // 
            this.checkBox_60.AutoSize = true;
            this.checkBox_60.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_60.Location = new System.Drawing.Point(12, 259);
            this.checkBox_60.Name = "checkBox_60";
            this.checkBox_60.Size = new System.Drawing.Size(65, 21);
            this.checkBox_60.TabIndex = 8;
            this.checkBox_60.Text = "15分钟";
            this.checkBox_60.UseVisualStyleBackColor = true;
            this.checkBox_60.CheckedChanged += new System.EventHandler(this.checkBox_60_CheckedChanged);
            // 
            // checkBox_30
            // 
            this.checkBox_30.AutoSize = true;
            this.checkBox_30.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_30.Location = new System.Drawing.Point(83, 259);
            this.checkBox_30.Name = "checkBox_30";
            this.checkBox_30.Size = new System.Drawing.Size(65, 21);
            this.checkBox_30.TabIndex = 9;
            this.checkBox_30.Text = "30分钟";
            this.checkBox_30.UseVisualStyleBackColor = true;
            this.checkBox_30.CheckedChanged += new System.EventHandler(this.checkBox_30_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmDataSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 545);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox_60);
            this.Controls.Add(this.checkBox_30);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnexperthistoryinfo);
            this.Controls.Add(this.btn_exporthistory);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btnexpertsavedata);
            this.Controls.Add(this.btnreadsave);
            this.Controls.Add(this.btn_delhistory);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.dgv_bodyinfo);
            this.Controls.Add(this.dgv_patientinfo);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDataSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[数据记录]";
            this.Load += new System.EventHandler(this.FrmDataSave_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patientinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bodyinfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rad_patienrnum;
        private System.Windows.Forms.RadioButton rad_name;
        private System.Windows.Forms.RadioButton rad_bednum;
        private System.Windows.Forms.DataGridView dgv_patientinfo;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_selecthistory;
        private System.Windows.Forms.Button btn_exporthistory;
        private System.Windows.Forms.Button btn_delhistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientBednum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patientstarttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patientendtime;
        public System.Windows.Forms.TextBox txt_get;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnreadsave;
        private System.Windows.Forms.Button btnexpertsavedata;
        private System.Windows.Forms.Button btn_clear;
        public System.Windows.Forms.DataGridView dgv_bodyinfo;
        private System.Windows.Forms.Button btnexperthistoryinfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientBodyInfotime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BloodO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pluse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flux;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetO2time;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetO2totaltime;
        private System.Windows.Forms.CheckBox cbxadd;
        private System.Windows.Forms.CheckBox checkBox_60;
        private System.Windows.Forms.CheckBox checkBox_30;
        private System.Windows.Forms.Button button2;
    }
}