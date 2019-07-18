using System;
using System.Windows.Forms;
using System.Collections.Generic;

/*
 * 程序系统主画面：程序入口
 * 包含功能：采购管理、销售管理、调拨管理、生产管理、形态转换、库存盘点、系统设置
 */
namespace KgmSoft.Scan.Project
{
    public partial class FrmMenu : KgmSoft.DeviceFrameworkControl.WinGui.BaseView
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.acceptScan = false;
        }

        #region 私有成员
        #endregion

        #region 私有事件
        public override void OnVisibleChanged()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Initialize();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmMenu窗体OnVisibleChanged事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败！详细信息请检查日志!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                QSCommonValue.operModule = "RK1";
                QSCommonValue.operModuleName = btnOut.Text;
                this.ParentForm.LoadView(typeof(FrmHead), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmMenu窗体btnOut_Click事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败！详细信息请检查日志!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                QSCommonValue.operModule = "CK1";
                QSCommonValue.operModuleName = btnReturn.Text;
                this.ParentForm.LoadView(typeof(FrmHead), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmMenu窗体btnOut_Click事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败！详细信息请检查日志!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (AppUtil.ShowQuestion("你确认要注销吗？") == DialogResult.Yes)
            {
                this.ParentForm.LoadView(typeof(FrmLogin), false, true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (AppUtil.ShowQuestion("你确认要退出吗？") == DialogResult.Yes)
            {
                this.ParentForm.Close();
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            stUser.Text = string.Format("登陆用户：{0}  登录日期:{1}", QSCommonValue.CurrentUser.Username, DateTime.Now.ToString("yyyy-MM-dd"));

            //List<SYS_MODULEInfo> list = WebAPIUtil.GetAPIByJsonToGeneric<List<SYS_MODULEInfo>>("/api/User/GetUserMenu/1");
            //btnOut.Enabled = list.Find(t => t.Moduleid.Equals("A01")) != null;
            //btnReturn.Enabled = list.Find(t => t.Moduleid.Equals("A02")) != null; 
        }

        #endregion

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                QSCommonValue.operModule = "PD";
                QSCommonValue.operModuleName = btnReturn.Text;
                this.ParentForm.LoadView(typeof(FrmHead), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmMenu窗体btnOut_Click事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败！详细信息请检查日志!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


    }
}