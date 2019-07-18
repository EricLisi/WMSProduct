namespace KgmSoft.Scan.Project
{
    partial class FrmScan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.btnFinish = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.stUser = new System.Windows.Forms.StatusBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.dgScan = new KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid(this.components);
            this.lblCount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgHead = new KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid(this.components);
            this.txtcPosCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.chkDel);
            this.panel1.Controls.Add(this.checkAll);
            this.panel1.Controls.Add(this.btnFinish);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 35);
            // 
            // chkDel
            // 
            this.chkDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.chkDel.Location = new System.Drawing.Point(76, 0);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(55, 35);
            this.chkDel.TabIndex = 1;
            this.chkDel.Text = "删除";
            // 
            // checkAll
            // 
            this.checkAll.Checked = true;
            this.checkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkAll.Enabled = false;
            this.checkAll.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.checkAll.Location = new System.Drawing.Point(0, 0);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(76, 35);
            this.checkAll.TabIndex = 0;
            this.checkAll.Text = "整箱/盒";
            this.checkAll.Visible = false;
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFinish.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnFinish.Location = new System.Drawing.Point(139, 0);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(45, 35);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "完成";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(184, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 35);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(194, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(46, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // stUser
            // 
            this.stUser.Location = new System.Drawing.Point(0, 256);
            this.stUser.Name = "stUser";
            this.stUser.Size = new System.Drawing.Size(240, 24);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.txtcPosCode);
            this.panel2.Controls.Add(this.txtbarcode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 83);
            // 
            // txtbarcode
            // 
            this.txtbarcode.Location = new System.Drawing.Point(38, 55);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(197, 23);
            this.txtbarcode.TabIndex = 2;
            this.txtbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtorderNo_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(3, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.Text = "条码";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(0, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 138);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.chkStatus);
            this.tabPage1.Controls.Add(this.dgScan);
            this.tabPage1.Controls.Add(this.lblCount);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 111);
            this.tabPage1.Text = "扫描信息";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(0, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 10);
            // 
            // chkStatus
            // 
            this.chkStatus.BackColor = System.Drawing.Color.White;
            this.chkStatus.Enabled = false;
            this.chkStatus.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.chkStatus.Location = new System.Drawing.Point(168, 143);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(61, 20);
            this.chkStatus.TabIndex = 63;
            this.chkStatus.Text = "不良";
            this.chkStatus.Visible = false;
            // 
            // dgScan
            // 
            this.dgScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.dgScan.Location = new System.Drawing.Point(0, 0);
            this.dgScan.Name = "dgScan";
            this.dgScan.Size = new System.Drawing.Size(232, 91);
            this.dgScan.TabIndex = 72;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.White;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(0, 91);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(232, 20);
            this.lblCount.Text = "合计行数:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgHead);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 165);
            this.tabPage2.Text = "差异信息";
            // 
            // dgHead
            // 
            this.dgHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHead.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.dgHead.Location = new System.Drawing.Point(0, 0);
            this.dgHead.Name = "dgHead";
            this.dgHead.Size = new System.Drawing.Size(232, 165);
            this.dgHead.TabIndex = 72;
            // 
            // txtcPosCode
            // 
            this.txtcPosCode.Location = new System.Drawing.Point(38, 3);
            this.txtcPosCode.Name = "txtcPosCode";
            this.txtcPosCode.Size = new System.Drawing.Size(197, 23);
            this.txtcPosCode.TabIndex = 0;
            this.txtcPosCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcPosCode_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.Text = "货位";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(38, 29);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(197, 23);
            this.txtQty.TabIndex = 1;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.Text = "数量";
            // 
            // FrmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stUser);
            this.Name = "FrmScan";
            this.Size = new System.Drawing.Size(240, 280);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnFinish;
        private System.Windows.Forms.Label label1;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusBar stUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid dgScan;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid dgHead;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.CheckBox chkDel;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.TextBox txtcPosCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label4;




    }
}