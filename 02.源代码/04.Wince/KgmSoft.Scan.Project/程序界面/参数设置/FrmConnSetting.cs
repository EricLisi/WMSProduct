using System;
using System.Windows.Forms;

/*
 * 服务器参数设置
 */
namespace KgmSoft.Scan.Project
{
    public partial class FrmConnSetting : KgmSoft.DeviceFrameworkControl.WinGui.BaseView
    {
        #region 构造函数
        public FrmConnSetting()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmConnSetting窗体构造：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region 私有成员
        #endregion

        #region 公开属性
        #endregion

        #region 私有事件
        public override void OnVisibleChanged()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ParentForm.Text = "系统参数设置";
                Initialize();

            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmConnSetting窗体OnVisibleChanged事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {

                if (AppUtil.ShowQuestion("是否要保存当前设置?") != DialogResult.Yes)
                {
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;

                AppUtil.SetXmlNodeValue(QSConstValue.SERVERIP_NODE, AppUtil.EncryptString(txtserverip.Text, ""));
                AppUtil.SetXmlNodeValue(QSConstValue.SERVERNAME_NODE, AppUtil.EncryptString(txtdbname.Text, "")); 
                AppUtil.SetXmlNodeValue(QSConstValue.COM_NODE, AppUtil.EncryptString(txtCOM.Text, ""));

                AppUtil.ShowInformation("设置成功!");
                CloseView();
            }
            catch (Exception ex)
            {
                AppUtil.ShowWarning("设置失败!原因:" + ex.ToString());
                logger.ErrorException("FrmConnSetting窗体btnFinish_Click事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppUtil.ShowQuestion("是否要放弃当前设置?") != DialogResult.Yes)
                {
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                CloseView();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmConnSetting窗体btnClose_Click事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgConnection_KgmGrid_Keydown_ReceivedEventHandle_End(object sender, KgmSoft.DeviceFrameworkControl.WinCtrl.DataReciveEventArgs e)
        {
            try
            {
                if (e.IsEditEnd)
                {
                    btnFinish_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmConnSetting窗体dgConnection_KgmGrid_Keydown_ReceivedEventHandle_End事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtserverip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            txtdbname.Focus();
            txtdbname.SelectAll();
        } 
       

        private void txtCOM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            btnFinish_Click(null, null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 初始化方法
        /// </summary>
        public void Initialize()
        {
            string serverIP = string.Empty;
            string dbname = string.Empty; 
            string COM = string.Empty;
            try
            {
                serverIP = AppUtil.DecryptString(AppUtil.GetXmlNodeValue(QSConstValue.SERVERIP_NODE), "");
                dbname = AppUtil.DecryptString(AppUtil.GetXmlNodeValue(QSConstValue.SERVERNAME_NODE), ""); 
                //COM = AppUtil.DecryptString(AppUtil.GetXmlNodeValue(QSConstValue.COM_NODE), "");
            }
            catch
            {
                serverIP = AppUtil.GetXmlNodeValue(QSConstValue.SERVERIP_NODE);
                dbname = AppUtil.GetXmlNodeValue(QSConstValue.SERVERNAME_NODE); 
                //COM = AppUtil.GetXmlNodeValue(QSConstValue.COM_NODE);
            }


            txtserverip.Text = serverIP;
            txtdbname.Text = dbname; 
            txtCOM.Text = COM;

        }

        /// <summary>
        /// 关闭当前视图
        /// </summary>
        private void CloseView()
        {
            this.ParentForm.LoadView(typeof(FrmLogin), false, true);
        }
        #endregion




    }
}