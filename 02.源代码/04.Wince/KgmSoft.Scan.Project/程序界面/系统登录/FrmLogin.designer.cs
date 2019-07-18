namespace KgmSoft.Scan.Project
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.btnLogin = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnConnect = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnCancel = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserPwd = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoadingInfo = new System.Windows.Forms.Label();
            this.dtpLoginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnLogin.Location = new System.Drawing.Point(121, 228);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(50, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnConnect.Location = new System.Drawing.Point(13, 228);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 35);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "参数设置";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnCancel.Location = new System.Drawing.Point(177, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(172, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.Text = "V 1.0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUserPwd
            // 
            this.lblUserPwd.BackColor = System.Drawing.Color.Transparent;
            this.lblUserPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.lblUserPwd.Location = new System.Drawing.Point(16, 129);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(72, 20);
            this.lblUserPwd.Text = "用户口令：";
            // 
            // lblUserId
            // 
            this.lblUserId.BackColor = System.Drawing.Color.Transparent;
            this.lblUserId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.lblUserId.Location = new System.Drawing.Point(16, 103);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(72, 20);
            this.lblUserId.Text = "用户代码：";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.txtUserPwd.Location = new System.Drawing.Point(87, 126);
            this.txtUserPwd.MaxLength = 100;
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(143, 20);
            this.txtUserPwd.TabIndex = 1;
            this.txtUserPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserPwd_KeyDown);
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUserId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.txtUserId.Location = new System.Drawing.Point(87, 100);
            this.txtUserId.MaxLength = 100;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(143, 20);
            this.txtUserId.TabIndex = 0;
            this.txtUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserId_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(10, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 1);
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLoadingInfo
            // 
            this.lblLoadingInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.lblLoadingInfo.ForeColor = System.Drawing.Color.Silver;
            this.lblLoadingInfo.Location = new System.Drawing.Point(11, 193);
            this.lblLoadingInfo.Name = "lblLoadingInfo";
            this.lblLoadingInfo.Size = new System.Drawing.Size(226, 14);
            this.lblLoadingInfo.Text = "准备就绪";
            // 
            // dtpLoginDate
            // 
            this.dtpLoginDate.CustomFormat = "yyyy-MM-dd";
            this.dtpLoginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLoginDate.Location = new System.Drawing.Point(87, 152);
            this.dtpLoginDate.Name = "dtpLoginDate";
            this.dtpLoginDate.Size = new System.Drawing.Size(143, 24);
            this.dtpLoginDate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(16, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.Text = "登录日期：";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dtpLoginDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblUserPwd);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblLoadingInfo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmLogin";
            this.Size = new System.Drawing.Size(240, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnLogin;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnConnect;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserPwd;
        private System.Windows.Forms.Label lblUserId;
        internal System.Windows.Forms.TextBox txtUserPwd;
        internal System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoadingInfo;
        private System.Windows.Forms.DateTimePicker dtpLoginDate;
        private System.Windows.Forms.Label label2;

    }
}