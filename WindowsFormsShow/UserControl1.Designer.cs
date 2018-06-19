namespace WindowsFormsShow
{
    partial class UserControl1
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
            this.btnstart = new System.Windows.Forms.Button();
            this.btnsavedata = new System.Windows.Forms.Button();
            this.btnpipei = new System.Windows.Forms.Button();
            this.btnselectdata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnstart.Location = new System.Drawing.Point(134, 243);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(116, 28);
            this.btnstart.TabIndex = 73;
            this.btnstart.Tag = "0";
            this.btnstart.Text = "开启监控";
            this.btnstart.UseVisualStyleBackColor = true;
            // 
            // btnsavedata
            // 
            this.btnsavedata.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsavedata.Location = new System.Drawing.Point(134, 209);
            this.btnsavedata.Name = "btnsavedata";
            this.btnsavedata.Size = new System.Drawing.Size(116, 28);
            this.btnsavedata.TabIndex = 72;
            this.btnsavedata.Tag = "0";
            this.btnsavedata.Text = "数据导出";
            this.btnsavedata.UseVisualStyleBackColor = true;
            // 
            // btnpipei
            // 
            this.btnpipei.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnpipei.Location = new System.Drawing.Point(8, 243);
            this.btnpipei.Name = "btnpipei";
            this.btnpipei.Size = new System.Drawing.Size(116, 28);
            this.btnpipei.TabIndex = 71;
            this.btnpipei.Tag = "0";
            this.btnpipei.Text = "人机匹配";
            this.btnpipei.UseVisualStyleBackColor = true;
            // 
            // btnselectdata
            // 
            this.btnselectdata.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnselectdata.Location = new System.Drawing.Point(8, 209);
            this.btnselectdata.Name = "btnselectdata";
            this.btnselectdata.Size = new System.Drawing.Size(116, 28);
            this.btnselectdata.TabIndex = 70;
            this.btnselectdata.Tag = "0";
            this.btnselectdata.Text = "查看数据";
            this.btnselectdata.UseVisualStyleBackColor = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.btnsavedata);
            this.Controls.Add(this.btnpipei);
            this.Controls.Add(this.btnselectdata);
            this.DoubleBuffered = true;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(253, 306);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnsavedata;
        private System.Windows.Forms.Button btnpipei;
        private System.Windows.Forms.Button btnselectdata;
    }
}
