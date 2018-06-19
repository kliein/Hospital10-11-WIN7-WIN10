namespace Hospital
{
    partial class FrmDataExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataExport));
            this.btn_patient = new System.Windows.Forms.Button();
            this.btn_patientbodyinfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_bednum = new System.Windows.Forms.TextBox();
            this.checkBox_30 = new System.Windows.Forms.CheckBox();
            this.checkBox_60 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_patient
            // 
            this.btn_patient.BackColor = System.Drawing.Color.Pink;
            this.btn_patient.FlatAppearance.BorderSize = 0;
            this.btn_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_patient.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_patient.ForeColor = System.Drawing.Color.Black;
            this.btn_patient.Location = new System.Drawing.Point(46, 91);
            this.btn_patient.Name = "btn_patient";
            this.btn_patient.Size = new System.Drawing.Size(176, 50);
            this.btn_patient.TabIndex = 0;
            this.btn_patient.Text = "导出病人资料";
            this.btn_patient.UseVisualStyleBackColor = false;
            this.btn_patient.Click += new System.EventHandler(this.btn_patient_Click);
            // 
            // btn_patientbodyinfo
            // 
            this.btn_patientbodyinfo.BackColor = System.Drawing.Color.Pink;
            this.btn_patientbodyinfo.FlatAppearance.BorderSize = 0;
            this.btn_patientbodyinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_patientbodyinfo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_patientbodyinfo.Location = new System.Drawing.Point(46, 170);
            this.btn_patientbodyinfo.Name = "btn_patientbodyinfo";
            this.btn_patientbodyinfo.Size = new System.Drawing.Size(176, 50);
            this.btn_patientbodyinfo.TabIndex = 0;
            this.btn_patientbodyinfo.Text = "导出病人详细信息";
            this.btn_patientbodyinfo.UseVisualStyleBackColor = false;
            this.btn_patientbodyinfo.Click += new System.EventHandler(this.btn_patientbodyinfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "[床号]";
            // 
            // txt_bednum
            // 
            this.txt_bednum.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_bednum.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_bednum.Location = new System.Drawing.Point(85, 18);
            this.txt_bednum.Multiline = true;
            this.txt_bednum.Name = "txt_bednum";
            this.txt_bednum.ReadOnly = true;
            this.txt_bednum.Size = new System.Drawing.Size(85, 33);
            this.txt_bednum.TabIndex = 2;
            this.txt_bednum.Text = "1";
            // 
            // checkBox_30
            // 
            this.checkBox_30.AutoSize = true;
            this.checkBox_30.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_30.Location = new System.Drawing.Point(96, 14);
            this.checkBox_30.Name = "checkBox_30";
            this.checkBox_30.Size = new System.Drawing.Size(65, 21);
            this.checkBox_30.TabIndex = 4;
            this.checkBox_30.Text = "30分钟";
            this.checkBox_30.UseVisualStyleBackColor = true;
            this.checkBox_30.CheckedChanged += new System.EventHandler(this.checkBox_30_CheckedChanged);
            // 
            // checkBox_60
            // 
            this.checkBox_60.AutoSize = true;
            this.checkBox_60.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_60.Location = new System.Drawing.Point(25, 14);
            this.checkBox_60.Name = "checkBox_60";
            this.checkBox_60.Size = new System.Drawing.Size(65, 21);
            this.checkBox_60.TabIndex = 4;
            this.checkBox_60.Text = "15分钟";
            this.checkBox_60.UseVisualStyleBackColor = true;
            this.checkBox_60.CheckedChanged += new System.EventHandler(this.checkBox_60_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_30);
            this.panel1.Controls.Add(this.checkBox_60);
            this.panel1.Location = new System.Drawing.Point(34, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 47);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FrmDataExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(264, 295);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_bednum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_patientbodyinfo);
            this.Controls.Add(this.btn_patient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmDataExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[数据导出]";
            this.Load += new System.EventHandler(this.FrmDataExport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_patient;
        private System.Windows.Forms.Button btn_patientbodyinfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bednum;
        private System.Windows.Forms.CheckBox checkBox_30;
        private System.Windows.Forms.CheckBox checkBox_60;
        private System.Windows.Forms.Panel panel1;
    }
}