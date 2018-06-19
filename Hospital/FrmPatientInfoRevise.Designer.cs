namespace Hospital
{
    partial class FrmPatientInfoRevise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatientInfoRevise));
            this.btn_cacel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.dtp_time = new System.Windows.Forms.DateTimePicker();
            this.rad_woman = new System.Windows.Forms.RadioButton();
            this.rad_man = new System.Windows.Forms.RadioButton();
            this.txt_zhuyuannum = new System.Windows.Forms.TextBox();
            this.txt_keshi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bedbum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cacel
            // 
            this.btn_cacel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cacel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cacel.Location = new System.Drawing.Point(178, 365);
            this.btn_cacel.Name = "btn_cacel";
            this.btn_cacel.Size = new System.Drawing.Size(94, 39);
            this.btn_cacel.TabIndex = 33;
            this.btn_cacel.Text = "取消";
            this.btn_cacel.UseVisualStyleBackColor = true;
            this.btn_cacel.Click += new System.EventHandler(this.btn_cacel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(39, 365);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(94, 39);
            this.btn_ok.TabIndex = 32;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // dtp_time
            // 
            this.dtp_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_time.Location = new System.Drawing.Point(103, 326);
            this.dtp_time.Name = "dtp_time";
            this.dtp_time.Size = new System.Drawing.Size(181, 21);
            this.dtp_time.TabIndex = 31;
            this.dtp_time.ValueChanged += new System.EventHandler(this.dtp_time_ValueChanged);
            // 
            // rad_woman
            // 
            this.rad_woman.AutoSize = true;
            this.rad_woman.Location = new System.Drawing.Point(199, 268);
            this.rad_woman.Name = "rad_woman";
            this.rad_woman.Size = new System.Drawing.Size(35, 16);
            this.rad_woman.TabIndex = 30;
            this.rad_woman.TabStop = true;
            this.rad_woman.Text = "女";
            this.rad_woman.UseVisualStyleBackColor = true;
            // 
            // rad_man
            // 
            this.rad_man.AutoSize = true;
            this.rad_man.Location = new System.Drawing.Point(124, 267);
            this.rad_man.Name = "rad_man";
            this.rad_man.Size = new System.Drawing.Size(35, 16);
            this.rad_man.TabIndex = 29;
            this.rad_man.TabStop = true;
            this.rad_man.Text = "男";
            this.rad_man.UseVisualStyleBackColor = true;
            // 
            // txt_zhuyuannum
            // 
            this.txt_zhuyuannum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_zhuyuannum.Location = new System.Drawing.Point(81, 211);
            this.txt_zhuyuannum.Multiline = true;
            this.txt_zhuyuannum.Name = "txt_zhuyuannum";
            this.txt_zhuyuannum.Size = new System.Drawing.Size(214, 31);
            this.txt_zhuyuannum.TabIndex = 28;
            this.txt_zhuyuannum.Text = "未录入";
            // 
            // txt_keshi
            // 
            this.txt_keshi.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_keshi.Location = new System.Drawing.Point(81, 160);
            this.txt_keshi.Multiline = true;
            this.txt_keshi.Name = "txt_keshi";
            this.txt_keshi.Size = new System.Drawing.Size(214, 31);
            this.txt_keshi.TabIndex = 27;
            this.txt_keshi.Text = "未录入";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(12, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "住院时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "性别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "住院号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "科室：";
            // 
            // txt_age
            // 
            this.txt_age.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_age.Location = new System.Drawing.Point(81, 109);
            this.txt_age.Multiline = true;
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(214, 31);
            this.txt_age.TabIndex = 22;
            this.txt_age.Text = "未录入";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "年龄：";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_name.Location = new System.Drawing.Point(81, 58);
            this.txt_name.Multiline = true;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(214, 31);
            this.txt_name.TabIndex = 20;
            this.txt_name.Text = "未录入";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "姓名：";
            // 
            // txt_bedbum
            // 
            this.txt_bedbum.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_bedbum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_bedbum.Location = new System.Drawing.Point(66, 5);
            this.txt_bedbum.Multiline = true;
            this.txt_bedbum.Name = "txt_bedbum";
            this.txt_bedbum.Size = new System.Drawing.Size(93, 28);
            this.txt_bedbum.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "床号：";
            // 
            // FrmPatientInfoRevise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 415);
            this.Controls.Add(this.btn_cacel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.dtp_time);
            this.Controls.Add(this.rad_woman);
            this.Controls.Add(this.rad_man);
            this.Controls.Add(this.txt_zhuyuannum);
            this.Controls.Add(this.txt_keshi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_age);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_bedbum);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPatientInfoRevise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[修改信息]";
            this.Load += new System.EventHandler(this.FrmPatientInfoRevise_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cacel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DateTimePicker dtp_time;
        private System.Windows.Forms.RadioButton rad_woman;
        private System.Windows.Forms.RadioButton rad_man;
        private System.Windows.Forms.TextBox txt_zhuyuannum;
        private System.Windows.Forms.TextBox txt_keshi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bedbum;
        private System.Windows.Forms.Label label1;
    }
}