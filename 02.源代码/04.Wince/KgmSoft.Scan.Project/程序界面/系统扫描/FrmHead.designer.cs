namespace KgmSoft.Scan.Project
{
    partial class FrmHead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHead));
            this.dgHead = new KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinish = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContinue = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.btnClose = new KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.stUser = new System.Windows.Forms.StatusBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtorderNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHead
            // 
            this.dgHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHead.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.dgHead.Location = new System.Drawing.Point(0, 89);
            this.dgHead.Name = "dgHead";
            this.dgHead.Size = new System.Drawing.Size(240, 132);
            this.dgHead.TabIndex = 71;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnFinish);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 35);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFinish.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnFinish.Location = new System.Drawing.Point(110, 0);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(60, 35);
            this.btnFinish.TabIndex = 59;
            this.btnFinish.Text = "确定";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(170, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 35);
            // 
            // btnContinue
            // 
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnContinue.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnContinue.Location = new System.Drawing.Point(0, 0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(77, 35);
            this.btnContinue.TabIndex = 60;
            this.btnContinue.Text = "已操作单据";
            this.btnContinue.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(180, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 35);
            this.btnClose.TabIndex = 59;
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
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(0, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 5);
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHead
            // 
            this.lblHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHead.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lblHead.Location = new System.Drawing.Point(0, 12);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(240, 36);
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
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(0, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 2);
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.txtorderNo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 29);
            // 
            // txtorderNo
            // 
            this.txtorderNo.Location = new System.Drawing.Point(60, 0);
            this.txtorderNo.Name = "txtorderNo";
            this.txtorderNo.Size = new System.Drawing.Size(175, 23);
            this.txtorderNo.TabIndex = 62;
            this.txtorderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtorderNo_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.Text = "单据号";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(0, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 5);
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.dgHead);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "FrmHead";
            this.Size = new System.Drawing.Size(240, 280);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid dgHead;
        private System.Windows.Forms.Panel panel1;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnFinish;
        private System.Windows.Forms.Label label1;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnContinue;
        private KgmSoft.DeviceFrameworkControl.WinCtrl.GradientButton btnClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusBar stUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtorderNo;




    }
}