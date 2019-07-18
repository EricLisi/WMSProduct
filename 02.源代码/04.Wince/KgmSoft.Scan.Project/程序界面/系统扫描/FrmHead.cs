using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

/*
 * 程序系统主画面：程序入口
 * 包含功能：采购管理、销售管理、调拨管理、生产管理、形态转换、库存盘点、系统设置
 */
namespace KgmSoft.Scan.Project
{
    public partial class FrmHead : KgmSoft.DeviceFrameworkControl.WinGui.BaseView
    {
        public FrmHead()
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
                logger.ErrorException("FrmHead窗体OnVisibleChanged事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败！详细信息请检查日志!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public override void OnGetBarcode(string scanStr)
        {
            try
            {
                txtorderNo.Text = scanStr;
                txtorderNo.Focus();
                KgmSoft.DeviceFramework.Utility.Win32.keybd_event(
                       (byte)KgmSoft.DeviceFramework.Utility.Win32.VK_RETURN, 0,
                       (int)KgmSoft.DeviceFramework.Utility.Win32.WM_KEYDOWN, 0);
            }
            catch
            {

            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ParentForm.LoadView(typeof(FrmMenu), false, false);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmHead窗体btnReturn_Click事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void txtorderNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                DataSet ds = WebAPIUtil.GetAPIByJsonToGeneric<DataSet>(string.Format("api/scan/GetList/{0}/{1}", txtorderNo.Text, QSCommonValue.operModule));
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    txtorderNo.Focus();
                    txtorderNo.SelectAll();
                    AppUtil.ShowError("未能找到单据信息,请确认单号是否正确!");
                    return;
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["F_Status"]) > 1)
                {
                    txtorderNo.Focus();
                    txtorderNo.SelectAll();
                    AppUtil.ShowError("单据已经完成!");
                    return;
                }

                if (QSCommonValue.operModule == "PD")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["F_Status"]) > 0)
                    {
                        txtorderNo.Focus();
                        txtorderNo.SelectAll();
                        AppUtil.ShowError("单据已经完成!");
                        return;
                    }
                }
                else
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["F_Status"]) == 0)
                    {
                        txtorderNo.Focus();
                        txtorderNo.SelectAll();
                        AppUtil.ShowError("单据尚未审核!");
                        return;
                    }
                }

                QSCommonValue.ListHead = ds.Tables[0];
                QSCommonValue.Body = ds.Tables[1];
                dgHead.DataSource = QSCommonValue.Body; 
                 
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmHead窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败!原因:" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = dgHead.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    AppUtil.ShowWarning("请先选择单据号!");
                    return;
                }

                QSCommonValue.operData = dt;

                this.ParentForm.LoadView(typeof(FrmScan), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmHead窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败!原因:" + ex.Message);
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
                Cursor.Current = Cursors.WaitCursor;
                this.ParentForm.LoadView(typeof(FrmMenu), false, false);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmHead窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
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
            lblHead.Text = QSCommonValue.operModuleName;
            InitGrid();
            txtorderNo.Text = string.Empty;
            txtorderNo.Focus();
        }


        /// <summary>
        /// 初始化方法
        /// </summary>
        public void InitGrid()
        {
            //初始化Grid
            DataTable dtColumn = new DataTable();
            dtColumn.Columns.Add("COLTITLE");
            dtColumn.Columns.Add("COLMAPPING");
            dtColumn.Columns.Add("COLWIDTH");
            dtColumn.Columns.Add("CUSTOMEREDIT");
            dtColumn.Columns.Add("CONTROLEDIT");
            dtColumn.Columns.Add("TEXTAGLIN");
            dtColumn.Columns.Add("EDITMODE");


            DataRow drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "商品名称";
            drCol["COLMAPPING"] = "F_GoodsName";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "数量";
            drCol["COLMAPPING"] = "F_InStockNum";
            drCol["COLWIDTH"] = "80";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            AppUtil.InitKgmGrid(ref dgHead, dtColumn, null);
        }

        #endregion

    }
}