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
    public partial class FrmScan : KgmSoft.DeviceFrameworkControl.WinGui.BaseView
    {
        public FrmScan()
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
                logger.ErrorException("FrmScan窗体OnVisibleChanged事件：" + ex.Message, ex);
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
                if (txtcPosCode.Focused)
                {
                    txtcPosCode.Text = scanStr;
                }
                else
                {
                    txtbarcode.Text = scanStr;
                    txtbarcode.Focus();
                }
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
                logger.ErrorException("FrmScan窗体btnReturn_Click事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void txtorderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (AppUtil.AlertMust(txtcPosCode, "货位不允许为空") || AppUtil.AlertMust(txtbarcode, "条码不允许为空")
                    || AppUtil.AlertMust(txtQty, "数量不允许为空"))
                {
                    return;
                }

                SaveScan s = new SaveScan();
                s.BARCODE = txtbarcode.Text;
                s.BDEL = chkDel.Checked;
                s.CPOSCODE = txtcPosCode.Text;
                s.CWHCODE = QSCommonValue.ListHead.Rows[0]["F_WarehouseId"].ToString();
                s.OPERUSER = QSCommonValue.CurrentUser.Userid;
                s.ORDERNO = QSCommonValue.ListHead.Rows[0]["F_EnCode"].ToString();
                s.ORDERTYPE = QSCommonValue.operModule;

                try
                {
                    s.QTY = decimal.Parse(txtQty.Text);
                }
                catch
                {
                    AppUtil.ShowError("输入的数量格式不正确!");
                    return;
                }



                string jsonData = WebAPIUtil.ConvertObjToJson(s);
                KgmApiResultEntity result = WebAPIUtil.PostAPIByJsonToAPIResult("/api/scan/SaveTempScan", jsonData);
                if (result.result)
                {
                    BindScanList();
                    txtbarcode.Focus();
                    txtbarcode.Text = string.Empty;
                    txtQty.Text = "1";
                    chkDel.Checked = chkStatus.Checked = false;
                }
                else
                {
                    AppUtil.ShowError(result.message);
                }

            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmScan窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
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
                DataTable dt = dgScan.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    AppUtil.ShowError("请至少扫描一条记录!");
                    return;
                }
 
                dt = WebAPIUtil.GetAPIByJsonToGeneric<DataTable>(string.Format("/api/scan/GetTempScanCy/{0}/{1}", QSCommonValue.ListHead.Rows[0]["F_EnCode"].ToString(), QSCommonValue.operModule));
            
                DataView dv = new DataView(dt);
                dv.RowFilter = "CYQTY <> 0";
                if (dv.Count > 0 && AppUtil.ShowQuestion("仍有货品未扫描完毕,是否确认完成?") != DialogResult.Yes)
                {
                    return;
                }
                WebAPIUtil.GetToAPIByJsonToAPIResult(string.Format("/api/scan/TempScanFinish/{0}/{1}", QSCommonValue.ListHead.Rows[0]["F_EnCode"].ToString(), QSCommonValue.operModule));
                AppUtil.ShowInformation("操作完成!");
                this.ParentForm.LoadView(typeof(FrmHead), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmScan窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败!原因:" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                txtbarcode.Focus();
                txtbarcode.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ParentForm.LoadView(typeof(FrmHead), false, true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmScan窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    BindScanCyList();
                }
                catch (Exception ex)
                {
                    logger.ErrorException("FrmScan窗体tabControl1_SelectedIndexChanged事件：" + ex.Message, ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    txtbarcode.Focus();
                }
            }
        }


        private void txtcPosCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (AppUtil.AlertMust(txtcPosCode, "货位不允许为空"))
                {
                    return;
                }
                txtQty.Focus();
                txtQty.SelectAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmScan窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败!原因:" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (AppUtil.AlertMust(txtQty, "数量不允许为空"))
                {
                    return;
                }
                txtbarcode.Focus();
                txtbarcode.SelectAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("FrmScan窗体txtorderNo_KeyDown事件：" + ex.Message, ex);
                AppUtil.ShowError("操作失败!原因:" + ex.Message);
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
            InitGrid();
            InitGrid1();
            BindScanList();
            chkDel.Checked = chkStatus.Checked = false;
            chkStatus.Visible = false;
            txtcPosCode.Focus();
            txtcPosCode.Text = txtbarcode.Text = string.Empty;
            txtQty.Text = "1";
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
            drCol["COLMAPPING"] = "F_FullName";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "差异";
            drCol["COLMAPPING"] = "CYQTY";
            drCol["COLWIDTH"] = "60";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "单据数量";
            drCol["COLMAPPING"] = "LISTQTY";
            drCol["COLWIDTH"] = "60";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "扫描数量";
            drCol["COLMAPPING"] = "SCANQTY";
            drCol["COLWIDTH"] = "60";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            AppUtil.InitKgmGrid(ref dgHead, dtColumn, null);
        }


        /// <summary>
        /// 初始化方法
        /// </summary>
        public void InitGrid1()
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
            drCol["COLMAPPING"] = "CINVNAME";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "数量";
            drCol["COLMAPPING"] = "QTY";
            drCol["COLWIDTH"] = "60";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "货位";
            drCol["COLMAPPING"] = "CPOSCODE";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);


            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "批次";
            drCol["COLMAPPING"] = "CBATCH";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "操作员";
            drCol["COLMAPPING"] = "OPERUSER";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            drCol = dtColumn.NewRow();
            drCol["COLTITLE"] = "条码";
            drCol["COLMAPPING"] = "BARCODE";
            drCol["COLWIDTH"] = "150";
            drCol["CUSTOMEREDIT"] = Convert.ToInt32(Resco.Controls.SmartGrid.CellEditType.None);
            drCol["CONTROLEDIT"] = Convert.ToInt32(KgmSoft.DeviceFrameworkControl.WinCtrl.KgmGrid.GridControlEditType.None);
            drCol["TEXTAGLIN"] = Convert.ToInt32(Resco.Controls.SmartGrid.Alignment.MiddleLeft);
            drCol["EDITMODE"] = 0;
            dtColumn.Rows.Add(drCol);

            AppUtil.InitKgmGrid(ref dgScan, dtColumn, null);
        }


        private void BindScanList()
        {
            DataTable dtScan = WebAPIUtil.GetAPIByJsonToGeneric<DataTable>(string.Format("/api/scan/GetTempScan/{0}/{1}", QSCommonValue.ListHead.Rows[0]["F_EnCode"].ToString(), QSCommonValue.CurrentUser.Userid));
            QSCommonValue.ScanBody = dtScan;
            dgScan.DataSource = dtScan;
            lblCount.Text = "合计件数:" + dtScan.Rows.Count.ToString();
        }

        private void BindScanCyList()
        {
            DataTable dtScan = WebAPIUtil.GetAPIByJsonToGeneric<DataTable>(string.Format("/api/scan/GetTempScanCy/{0}/{1}", QSCommonValue.ListHead.Rows[0]["F_EnCode"].ToString(), QSCommonValue.operModule));
            dgHead.DataSource = dtScan;
        }

        #endregion



    }
}