namespace KgmSoft.Scan.Project
{
    partial class FrmConnSetting
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnFinish = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtserverip = new System.Windows.Forms.TextBox();
            this.txtdbname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCOM = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(0, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 40);
            this.lblTitle.Text = "服务参数设置";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(151, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 41);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnFinish.Location = new System.Drawing.Point(69, 189);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(76, 41);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "确定";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 22);
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.Text = "服务器地址";
            // 
            // txtserverip
            // 
            this.txtserverip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.txtserverip.Location = new System.Drawing.Point(12, 102);
            this.txtserverip.Name = "txtserverip";
            this.txtserverip.Size = new System.Drawing.Size(215, 20);
            this.txtserverip.TabIndex = 0;
            this.txtserverip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtserverip_KeyDown);
            // 
            // txtdbname
            // 
            this.txtdbname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.txtdbname.Location = new System.Drawing.Point(12, 143);
            this.txtdbname.Name = "txtdbname";
            this.txtdbname.Size = new System.Drawing.Size(215, 20);
            this.txtdbname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.Text = "服务名称";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.Text = "打印机端口";
            this.label6.Visible = false;
            // 
            // txtCOM
            // 
            this.txtCOM.Items.Add("");
            this.txtCOM.Items.Add("COM1");
            this.txtCOM.Items.Add("COM2");
            this.txtCOM.Items.Add("COM3");
            this.txtCOM.Items.Add("COM4");
            this.txtCOM.Items.Add("COM5");
            this.txtCOM.Items.Add("COM6");
            this.txtCOM.Items.Add("COM7");
            this.txtCOM.Items.Add("COM8");
            this.txtCOM.Items.Add("COM9");
            this.txtCOM.Items.Add("COM10");
            this.txtCOM.Items.Add("COM11");
            this.txtCOM.Items.Add("COM12");
            this.txtCOM.Items.Add("COM13");
            this.txtCOM.Items.Add("COM14");
            this.txtCOM.Items.Add("COM15");
            this.txtCOM.Location = new System.Drawing.Point(12, 189);
            this.txtCOM.Name = "txtCOM";
            this.txtCOM.Size = new System.Drawing.Size(215, 23);
            this.txtCOM.TabIndex = 12;
            this.txtCOM.Visible = false;
            // 
            // FrmConnSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.txtdbname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtserverip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCOM);
            this.Controls.Add(this.label6);
            this.Name = "FrmConnSetting";
            this.Size = new System.Drawing.Size(240, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnClose;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnFinish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtserverip;
        private System.Windows.Forms.TextBox txtdbname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtCOM;
    }
}