namespace KgmSoft.Scan.Project
{
    partial class FrmMenu
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
            this.stUser = new System.Windows.Forms.StatusBar();
            this.btnOut = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnReturn = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnLogout = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnExit = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientButton1 = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.SuspendLayout();
            // 
            // stUser
            // 
            this.stUser.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.stUser.Location = new System.Drawing.Point(0, 261);
            this.stUser.Name = "stUser";
            this.stUser.Size = new System.Drawing.Size(240, 19);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnOut.Location = new System.Drawing.Point(33, 61);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(174, 42);
            this.btnOut.TabIndex = 6;
            this.btnOut.Text = "扫描入库";
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(33, 109);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(174, 42);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "扫描出库";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnLogout.Location = new System.Drawing.Point(33, 205);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 42);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "用户注销";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnExit.Location = new System.Drawing.Point(124, 205);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 42);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出系统";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(0, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 5);
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(0, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 2);
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHead
            // 
            this.lblHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHead.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lblHead.Location = new System.Drawing.Point(0, 12);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(240, 36);
            this.lblHead.Text = "仓库管理系统";
            this.lblHead.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(0, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 5);
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(0, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 2);
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 5);
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gradientButton1
            // 
            this.gradientButton1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.gradientButton1.Location = new System.Drawing.Point(33, 157);
            this.gradientButton1.Name = "gradientButton1";
            this.gradientButton1.Size = new System.Drawing.Size(174, 42);
            this.gradientButton1.TabIndex = 11;
            this.gradientButton1.Text = "库存盘点";
            this.gradientButton1.Click += new System.EventHandler(this.gradientButton1_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.gradientButton1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.stUser);
            this.Name = "FrmMenu";
            this.Size = new System.Drawing.Size(240, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar stUser;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnOut;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnReturn;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnLogout;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton gradientButton1;



    }
}