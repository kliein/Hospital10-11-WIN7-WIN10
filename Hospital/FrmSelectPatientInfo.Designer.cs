namespace Hospital
{
    partial class FrmSelectPatientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectPatientInfo));
            this.dgv_info = new System.Windows.Forms.DataGridView();
            this.Patienttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pluse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloodO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetO2time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetO2totaltime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_gender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_patientnum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Department = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_bednum = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_info)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_info
            // 
            this.dgv_info.AllowUserToAddRows = false;
            this.dgv_info.AllowUserToDeleteRows = false;
            this.dgv_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_info.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patienttime,
            this.Column1,
            this.Column3,
            this.Pluse,
            this.BloodO2,
            this.Flux,
            this.GetO2time,
            this.GetO2totaltime});
            this.dgv_info.GridColor = System.Drawing.Color.Aqua;
            this.dgv_info.Location = new System.Drawing.Point(12, 172);
            this.dgv_info.Name = "dgv_info";
            this.dgv_info.ReadOnly = true;
            this.dgv_info.RowHeadersVisible = false;
            this.dgv_info.RowTemplate.Height = 23;
            this.dgv_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_info.Size = new System.Drawing.Size(907, 351);
            this.dgv_info.TabIndex = 0;
            this.dgv_info.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_info_CellMouseClick);
            // 
            // Patienttime
            // 
            this.Patienttime.DataPropertyName = "PatientBodyInfotime";
            this.Patienttime.FillWeight = 98.22335F;
            this.Patienttime.HeaderText = "记录时间";
            this.Patienttime.Name = "Patienttime";
            this.Patienttime.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Model";
            this.Column1.FillWeight = 98.22335F;
            this.Column1.HeaderText = "模式";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Error";
            this.Column3.FillWeight = 98.22335F;
            this.Column3.HeaderText = "报警";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Pluse
            // 
            this.Pluse.DataPropertyName = "Pluse";
            this.Pluse.FillWeight = 98.22335F;
            this.Pluse.HeaderText = "脉率(bpm)";
            this.Pluse.Name = "Pluse";
            this.Pluse.ReadOnly = true;
            // 
            // BloodO2
            // 
            this.BloodO2.DataPropertyName = "BloodO2";
            this.BloodO2.FillWeight = 98.22335F;
            this.BloodO2.HeaderText = "血氧(%)";
            this.BloodO2.Name = "BloodO2";
            this.BloodO2.ReadOnly = true;
            // 
            // Flux
            // 
            this.Flux.DataPropertyName = "Flux";
            this.Flux.FillWeight = 98.22335F;
            this.Flux.HeaderText = "流量(L)";
            this.Flux.Name = "Flux";
            this.Flux.ReadOnly = true;
            // 
            // GetO2time
            // 
            this.GetO2time.DataPropertyName = "GetO2time";
            this.GetO2time.FillWeight = 98.22335F;
            this.GetO2time.HeaderText = "吸氧时间(h)";
            this.GetO2time.Name = "GetO2time";
            this.GetO2time.ReadOnly = true;
            // 
            // GetO2totaltime
            // 
            this.GetO2totaltime.DataPropertyName = "GetO2totaltime";
            this.GetO2totaltime.FillWeight = 114.2132F;
            this.GetO2totaltime.HeaderText = "吸氧总时间(h)";
            this.GetO2totaltime.Name = "GetO2totaltime";
            this.GetO2totaltime.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_select);
            this.groupBox1.Controls.Add(this.txt_time);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_age);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_gender);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_patientnum);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Department);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_bednum);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(907, 133);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[当前病人信息]";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_select
            // 
            this.btn_select.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_select.Location = new System.Drawing.Point(669, 77);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(209, 46);
            this.btn_select.TabIndex = 12;
            this.btn_select.Text = "查 看 详 细 信 息";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // txt_time
            // 
            this.txt_time.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_time.Location = new System.Drawing.Point(669, 31);
            this.txt_time.Multiline = true;
            this.txt_time.Name = "txt_time";
            this.txt_time.ReadOnly = true;
            this.txt_time.Size = new System.Drawing.Size(209, 29);
            this.txt_time.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(569, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "住院时间：";
            // 
            // txt_age
            // 
            this.txt_age.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_age.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_age.Location = new System.Drawing.Point(247, 80);
            this.txt_age.Multiline = true;
            this.txt_age.Name = "txt_age";
            this.txt_age.ReadOnly = true;
            this.txt_age.Size = new System.Drawing.Size(103, 29);
            this.txt_age.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(189, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "年龄：";
            // 
            // txt_gender
            // 
            this.txt_gender.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_gender.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_gender.Location = new System.Drawing.Point(247, 34);
            this.txt_gender.Multiline = true;
            this.txt_gender.Name = "txt_gender";
            this.txt_gender.ReadOnly = true;
            this.txt_gender.Size = new System.Drawing.Size(103, 29);
            this.txt_gender.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(190, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "性别：";
            // 
            // txt_patientnum
            // 
            this.txt_patientnum.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_patientnum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_patientnum.Location = new System.Drawing.Point(443, 80);
            this.txt_patientnum.Multiline = true;
            this.txt_patientnum.Name = "txt_patientnum";
            this.txt_patientnum.ReadOnly = true;
            this.txt_patientnum.Size = new System.Drawing.Size(103, 29);
            this.txt_patientnum.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(363, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "住院号：";
            // 
            // txt_Department
            // 
            this.txt_Department.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_Department.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Department.Location = new System.Drawing.Point(442, 34);
            this.txt_Department.Multiline = true;
            this.txt_Department.Name = "txt_Department";
            this.txt_Department.ReadOnly = true;
            this.txt_Department.Size = new System.Drawing.Size(104, 29);
            this.txt_Department.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(383, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "科室：";
            // 
            // txt_bednum
            // 
            this.txt_bednum.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_bednum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_bednum.Location = new System.Drawing.Point(68, 81);
            this.txt_bednum.Multiline = true;
            this.txt_bednum.Name = "txt_bednum";
            this.txt_bednum.ReadOnly = true;
            this.txt_bednum.Size = new System.Drawing.Size(103, 29);
            this.txt_bednum.TabIndex = 1;
            this.txt_bednum.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_name.Location = new System.Drawing.Point(68, 35);
            this.txt_name.Multiline = true;
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(103, 29);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "床号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "[详细信息]";
            // 
            // FrmSelectPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 535);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSelectPatientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[详细信息]";
            this.Load += new System.EventHandler(this.FrmSelectPatientInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_info)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bednum;
        private System.Windows.Forms.TextBox txt_patientnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Department;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_gender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patienttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pluse;
        private System.Windows.Forms.DataGridViewTextBoxColumn BloodO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flux;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetO2time;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetO2totaltime;
    }
}