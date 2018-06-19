namespace Hospital
{
    partial class FrmShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShow));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btncnncel = new System.Windows.Forms.Button();
            this.userControl21 = new WindowsFormsShow.UserControl2();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(844, 64);
            this.listBox1.TabIndex = 0;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(12, 284);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(118, 30);
            this.btnclear.TabIndex = 1;
            this.btnclear.Text = "清除窗口";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncnncel
            // 
            this.btncnncel.Location = new System.Drawing.Point(146, 284);
            this.btncnncel.Name = "btncnncel";
            this.btncnncel.Size = new System.Drawing.Size(118, 30);
            this.btncnncel.TabIndex = 1;
            this.btncnncel.Text = "退出";
            this.btncnncel.UseVisualStyleBackColor = true;
            this.btncnncel.Click += new System.EventHandler(this.btncnncel_Click);
            // 
            // userControl21
            // 
            this.userControl21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userControl21.Battery = "";
            this.userControl21.Bednum = null;
            this.userControl21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userControl21.Bpm = "";
            this.userControl21.Btnexporttag = 0;
            this.userControl21.Btnpipeitag = 0;
            this.userControl21.Btnselecttag = 0;
            this.userControl21.Btnstarttag = 0;
            this.userControl21.EndToolStripMenuItemtag = 0;
            this.userControl21.Falg = false;
            this.userControl21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControl21.GetToolStripMenuItemtag = 0;
            this.userControl21.Location = new System.Drawing.Point(313, 101);
            this.userControl21.Name = "userControl21";
            this.userControl21.O2 = "";
            this.userControl21.O2flow = "";
            this.userControl21.Peoplename = "";
            this.userControl21.Size = new System.Drawing.Size(216, 250);
            this.userControl21.State = "";
            this.userControl21.TabIndex = 2;
            this.userControl21.Time = "";
            this.userControl21.WriteToolStripMenuItemtag = 0;
            // 
            // FrmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(849, 403);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.btncnncel);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.listBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[调试窗口]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmShow_FormClosing);
            this.Load += new System.EventHandler(this.FrmShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btncnncel;
        private WindowsFormsShow.UserControl2 userControl21;
    }
}