using System;
using System.Data;
using System.Windows.Forms;

namespace KgmSoft.Scan.Project
{
    public partial class FrmLogin : KgmSoft.DeviceFrameworkControl.WinGui.BaseView
    {
        #region 构造函数
        public FrmLogin()
        {
            InitializeComponent();
            //设置窗体不可扫描
            this.acceptScan = true;


        }
        #endregion

        #region 私有成员
        #endregion

        #region 窗体事件
        //等同于LOAD事件
        public override void OnVisibleChanged()
        {
            try
            {
                new StatusLable(lblLoadingInfo).UpdateMessage("准备就绪...");
                Initialize();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmLogin:OnVisibleChanged：" + ex.Message, ex);
            }
            finally
            {
                txtUserId.Focus();
            }
        }

        /// <summary>
        /// 扫描事件
        /// </summary>
        /// <param name="scanStr"></param>
        public override void OnGetBarcode(string scanStr)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                txtUserId.Text = scanStr;
                txtUserPwd.Focus();
            }
            catch (Exception ex)
            {
                AppUtil.ShowError("扫描失败！详细信息请查看日志！");
                logger.ErrorException("FrmLogin窗体OnGetBarcode事件：" + ex.ToString(), ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string errorInfo = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StatusLable lblstatus = new StatusLable(lblLoadingInfo);

                if (!Login(lblstatus, out errorInfo))
                {
                    AppUtil.ShowInformation(errorInfo);
                    txtUserPwd.Text = string.Empty;
                    txtUserId.Focus();
                    txtUserId.SelectAll();
                    return;
                }
                lblstatus.UpdateMessage("正在读取用户信息...");
                //读取用户信息
                InitUserInfo();

                lblstatus.UpdateMessage("正在读取用户界面...");
                this.ParentForm.LoadView(typeof(FrmMenu), false, true);
                this.Dispose();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmLogin:btnLogin_Click：" + ex.Message, ex);
                AppUtil.ShowError("QuickScanner登录失败，原因：" + ex.Message + "!");
            }
            finally
            {
                if (lblLoadingInfo != null)
                {
                    new StatusLable(lblLoadingInfo).UpdateMessage("准备就绪...");
                }
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 取消事件
        /// 如果用户名或者密码有值,则清空文本,否则退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtUserId.Text.Trim() == string.Empty && txtUserPwd.Text.Trim() == string.Empty &&
                    AppUtil.ShowQuestion("是否确认要退出系统?") == DialogResult.Yes)
                {
                    this.ParentForm.Close();
                }
                else
                {
                    Initialize();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmLogin:btnCancel_Click：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FrmPwd frm = new FrmPwd();
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                this.ParentForm.LoadView(typeof(FrmConnSetting), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmLogin:btnConnect_Click：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                this.txtUserPwd.SelectAll();
                this.txtUserPwd.Focus();
            }
        }

        private void txtUserPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.txtUserId.SelectAll();
                this.txtUserId.Focus();
            }
        }

        private void dtpLoginDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            //设置窗体标题
            txtUserId.Text = txtUserPwd.Text = string.Empty;
            txtUserId.Focus();
        }

        #region 登录相关
        /// <summary>
        /// 系统登录初始化
        /// </summary>
        private bool initLogtin(StatusLable lblstatus, out string strErrorMsg)
        {
            strErrorMsg = string.Empty;

            string COM = string.Empty;
            string APIServer = string.Empty;//API服务器IP
            string APIService = string.Empty;//API服务
            try
            {
                //COM = AppUtil.DecryptString(AppUtil.GetXmlNodeValue(QSConstValue.COM_NODE), "");
                APIServer = AppUtil.DecryptString(AppUtil.GetXmlNodeValue(QSConstValue.API_SERVERIP_NODE), "");
                APIService = AppUtil.DecryptString(AppUtil.GetXmlNodeValue(QSConstValue.API_SERVICE_NODE), "");

            }
            catch
            {
                //COM = AppUtil.GetXmlNodeValue(QSConstValue.COM_NODE);
                APIServer = AppUtil.GetXmlNodeValue(QSConstValue.API_SERVERIP_NODE);
                APIService = AppUtil.GetXmlNodeValue(QSConstValue.API_SERVICE_NODE);
            }



            lblstatus.UpdateMessage("正在连接远程服务...");

            #region 读取API信息
            if (string.IsNullOrEmpty(APIService))
            {
                QSCommonValue.WebAPIUri = new Uri(string.Format("http://{0}", APIServer));
            }
            else
            {
                QSCommonValue.WebAPIUri = new Uri(string.Format("http://{0}/{1}", APIServer, APIService));
            }
            #endregion

            return true;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        private bool Login(StatusLable lblstatus, out string strErrorMsg)
        {
            strErrorMsg = string.Empty;

            if (txtUserId.Text == string.Empty)
            {
                strErrorMsg = "请输入用户代码！";
                return false;
            }

            //只在第一次登陆执行
            if (!initLogtin(lblstatus, out strErrorMsg))
            {
                return false;
            }

            lblstatus.UpdateMessage("正在登录系统...");
            QSCommonValue.token = string.Empty;

            LoginSystemModel LogModel = new LoginSystemModel();
            LogModel.Account = txtUserId.Text;
            LogModel.Password = txtUserPwd.Text;
            LogModel.LoginSystem = LoginSystemModel.LoginSystemEnum.移动端系统;

            string jsonData = WebAPIUtil.ConvertObjToJson(LogModel);
            //KgmApiResultEntity result = WebAPIUtil.PostAPIByJsonToAPIResult("/api/Auth/GetUserToken", jsonData);
            KgmApiResultEntity result = WebAPIUtil.PostAPIByJsonToAPIResult("api/Auth/GetUserToken", jsonData);
            if (!result.result)
            {
                strErrorMsg = result.message;
                return false;
            }
            else
            {
                QSCommonValue.token = result.message;
            }

            return true;
        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void InitUserInfo()
        {
            QSCommonValue.CurrentUser = new SYS_USERSInfo();
            QSCommonValue.CurrentUser.Userid = txtUserId.Text;
            QSCommonValue.CurrentUser.Username = txtUserId.Text;
            //WebAPIUtil.GetAPIByJsonToGeneric<SYS_USERSInfo>("api/User/GetCurrentUser"); 
        }
        #endregion

        #region 自动更新相关
        /// <summary>
        /// 自动更新
        /// </summary>
        /// <returns></returns>
        private bool AutoUpdate(out string strErrorMsg)
        {
            strErrorMsg = string.Empty;
            bool returnValue = true;
            //try
            //{
            //    //启用自动更新 
            //    AutoUpdate update = new AutoUpdate();
            //    update.GetUpdateVerisonEvent += new GetUpdateVerisonXmlDelegate(GetUpdateVerisonXml);
            //    update.DownloadEvent += new DownloadDelegate(download);
            //    if (update.Update())
            //    {
            //        AppUtil.ShowInformation("程序需要重新启动才能应用更新，请点击确定重新启动程序。");
            //        this.Dispose();
            //        this.ParentForm.Close();
            //        Process.Start(QSConstValue.APP_PATH, string.Empty);
            //        Process.GetCurrentProcess().Kill();
            //        returnValue = false;
            //    }
            //}
            //catch (WebException exp)
            //{
            //    strErrorMsg = String.Format("无法找到指定资源\n\n{0}", exp.Message);
            //    returnValue = false;
            //}
            //catch (XmlException exp)
            //{
            //    strErrorMsg = String.Format("下载的升级文件有错误\n\n{0}", exp.Message);
            //    returnValue = false;
            //}
            //catch (NotSupportedException exp)
            //{
            //    strErrorMsg = String.Format("升级地址配置错误\n\n{0}", exp.Message);
            //    returnValue = false;
            //}
            //catch (ArgumentException exp)
            //{
            //    strErrorMsg = String.Format("下载的升级文件有错误\n\n{0}", exp.Message);
            //    returnValue = false;
            //}
            //catch (Exception exp)
            //{
            //    strErrorMsg = String.Format("升级过程中发生错误\n\n{0}", exp.Message);
            //    returnValue = false;
            //}


            return returnValue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        //private byte[] download(string filename, int offset, int bufferSize)
        //{
        //    return new KgmSoft.DeviceFramework.Utility.CompressionHelper(CompressionLevel.BestSpeed).DecompressToBytes(
        //        KgmSingleWebservice.GetKgmSingleWebservice().KgmDownTermialWithBlock(QSConstValue.INVOKE_NAME, filename, offset, bufferSize));
        //}

        //private string GetUpdateVerisonXml()
        //{
        //    return KgmSingleWebservice.GetKgmSingleWebservice().KgmGetTermialUpdateXml(QSConstValue.INVOKE_NAME);
        //}
        #endregion


        #endregion
    }
}