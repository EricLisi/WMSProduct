using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KgmSoft.Scan.COMMON;
using KgmSoft.Scan.BLL;
using KgmSoft.Scan.MODEL;
using Resco.Controls.SmartGrid;
using KgmSoft.DeviceFrameworkControl.WinCtrl;
using KgmSoft.DeviceFramework.Utility;

namespace KgmSoft.Scan.Project
{
    public class MyBaseView : KgmSoft.DeviceFrameworkControl.WinGui.BaseView
    {
        private KgmSoft.Scan.MODEL.Kgm_FilterModel m_FilterModel;//过滤条件对象
        private string m_returnValue;//返回的值
        private string m_returnText;//返回的名称
        private Resco.Controls.SmartGrid.Row m_ReturnDr;//返回的选择行
        private string m_filter;//字符串过滤条件
        private string m_bizType;
        private string m_pk_calbody;
        private bool bU8Sys = true;
        public DataTable dttray;
        protected BasicUtil bll = new BasicUtil();
        protected TrayUtil tbll = new TrayUtil();
        protected ScanUtil sbll = new ScanUtil();

        public string Pk_calbody
        {
            get { return m_pk_calbody; }
            set { m_pk_calbody = value; }
        }
        public string BizType
        {
            get { return m_bizType; }
            set { m_bizType = value; }
        }
        public bool BU8Sys
        {
            get { return bU8Sys; }
            set { bU8Sys = value; }
        }
        /// <summary>
        /// 过滤对象
        /// </summary>
        public KgmSoft.Scan.MODEL.Kgm_FilterModel FilterModel
        {
            get { return m_FilterModel; }
            set { m_FilterModel = value; }
        }

        /// <summary>
        /// 返回的行信息
        /// </summary>
        public Resco.Controls.SmartGrid.Row ReturnDr
        {
            get { return m_ReturnDr; }
            set { m_ReturnDr = value; }
        }

        /// <summary>
        /// 返回值
        /// </summary>
        public string returnValue
        {
            get { return m_returnValue; }
            set { m_returnValue = value; }
        }

        /// <summary>
        /// 返回名
        /// </summary>
        public string returnText
        {
            get { return m_returnText; }
            set { m_returnText = value; }
        }

        /// <summary>
        /// 字符串过滤条件
        /// </summary>
        public string Filter
        {
            get { return m_filter; }
            set { m_filter = value; }
        }

        #region 画面数据处理
        /// <summary>
        ///  新建单据在选择业务单据号后的处理
        /// </summary>
        /// <param name="dtSource">数据源</param>f
        /// <param name=QSConstValue.VALUEMEMBER>实际输入的值</param>
        /// <param name="errorInfo">错误信息</param>
        /// <returns>True False</returns>
        protected bool DoAfterSelOrderNo(KgmGrid grid, EditControlInterface con, string inputvalue, out string errorInfo)
        {
            errorInfo = string.Empty;
            string biztype = string.Empty;
            try
            {
                biztype = grid.GetRowCellData("CVOUCHID", QSConstValue.VALUEMEMBER).ToString();
                if (string.IsNullOrEmpty(biztype))
                {
                    errorInfo = "业务类型不能为空!";
                    return false;
                }
            }
            catch
            {

            }
            //设置过滤条件
            string rowfilter = string.Format(" AND ORDERNO = '{0}' ", inputvalue);
            //根据过滤条件读取单据信息
            //ADO
            //DataTable dtorderList = bll.GetSourceList(rowfilter, bU8Sys);

            //API
            SYS_SourceList model = new SYS_SourceList();
            model.Condition = rowfilter;
            model.Bu8sys = bU8Sys;
            string jsonData = WebAPIUtil.ConvertObjToJson(model);
            DataTable dtorderList = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basic/GetSourceList", jsonData);

            if (dtorderList == null || dtorderList.Rows.Count == 0)
            {
                errorInfo = "未能获取到单据信息,请确认单据是否正确!";
                return false;
            }

            //循环赋值
            if (!AppUtil.SetValueToGirdSource(grid, dtorderList.Rows[0], false))
            {
                return false;
            }

            con.EditValue = dtorderList.Rows[0]["ORDERID"].ToString();
            con.EditText = dtorderList.Rows[0]["ORDERNO"].ToString();


            //列表内的客户设置为不可用
            //grid.SetRowCellData("CCUSCODE", new string[] { QSConstValue.BEDIT }, new object[] { false });

            return true;
        }

        /// <summary>
        ///  新建单据在选择业务单据号后的处理
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name=QSConstValue.VALUEMEMBER>实际输入的值</param>
        /// <param name="errorInfo">错误信息</param>
        /// <returns>True False</returns>
        protected bool DoAfterSelVouchType(KgmGrid grid, EditControlInterface con, string inputvalue, out string errorInfo)
        {
            errorInfo = string.Empty;
            //设置过滤条件
            string rowfilter = string.Format(" AND A.MODULEID = '{0}' AND (CVOUCHID = '{1}' OR CVOUCHNAME = '{1}' OR CSOURCE = '{1}')", QSCommonValue.OP_Module.ModuleId, inputvalue);
            //根据过滤条件读取单据信息
            //ADO
            //DataTable dtVouchType = bll.GetVouchModel(rowfilter);

            //API
            VouchModel model = new VouchModel();
            model.Condition = rowfilter;
            model.DBNAME = QSCommonValue.BarDbConfigInfo.U8DatabaseName;
            string jsonData = WebAPIUtil.ConvertObjToJson(model);
            DataTable dtVouchType = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basic/GetVouchModel", jsonData);


            if (dtVouchType == null || dtVouchType.Rows.Count == 0)
            {
                errorInfo = "未能获取到业务类型信息,请确认编码是否正确!";
                return false;
            }

            con.EditText = dtVouchType.Rows[0]["CSOURCE"].ToString();
            con.EditValue = dtVouchType.Rows[0]["CVOUCHID"].ToString();
            //循环赋值
            if (!AppUtil.SetValueToGirdSource(grid, dtVouchType.Rows[0], false))
            {
                return false;
            }

            QSCommonValue.KgmVouchType = dtVouchType.Rows[0];


            return true;
        }

        /// <summary>
        /// 选取基础档案后的处理
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="currentrow"></param>
        /// <param name="con"></param>
        /// <param name="inputValue"></param>
        /// <param name="errorInfo"></param>
        /// <returns></returns>
        protected bool DoAfterSelBasicDoc(KgmGrid grid, Resco.Controls.SmartGrid.CustomEditEventArgs e, EditControlInterface con, string inputValue, out string errorInfo)
        {
            errorInfo = string.Empty;
            //判断是否是buttonclick将信息带出来 如果是则直接取editvalue

            string shineValue = e.Cell.Row[QSConstValue.ROWSHINEVALUE].ToString();
            string shineText = e.Cell.Row[QSConstValue.ROWSHINETEXT].ToString();

            //根据填写的信息，读取档案信息带出值
            //ADO方式
            //Kgm_FilterModel filter = AppUtil.InitFilterModel(e, string.Format(" AND ({0} = '{1}' OR {2} = '{1}') ", shineValue, inputValue, shineText));
            //DataTable dtBasic = bll.GetSingleTableInfo(filter);

            //改用调用API方式
            SYS_SingleTableInfo filter = AppUtil.InitFilterModelAPI(e, string.Format(" AND ({0} = '{1}' OR {2} = '{1}') ", shineValue, inputValue, shineText));
            string jsonData = WebAPIUtil.ConvertObjToJson(filter);
            DataTable dtBasic = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basicdocument/GetSingleTableInfo", jsonData);

            if (dtBasic == null || dtBasic.Rows.Count == 0)
            {
                errorInfo = "未能获取信息,请输入正确的编码!";
                e.Cell.Row[QSConstValue.VALUEMEMBER] = e.Cell.Row[QSConstValue.DISPLAYMEMBER] = string.Empty;
                return false;
            }

            con.EditValue = dtBasic.Rows[0][QSConstValue.VALUEMEMBER].ToString();
            con.EditText = dtBasic.Rows[0][QSConstValue.DISPLAYMEMBER].ToString();

            return true;
        }

        /// <summary>
        ///  扫描条码后处理
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name=QSConstValue.VALUEMEMBER>实际输入的值</param>
        /// <param name="errorInfo">错误信息</param>
        /// <returns>True False</returns>
        protected bool DoAfterScanBarcode(KgmGrid grid, Resco.Controls.SmartGrid.CustomEditEventArgs e, EditControlInterface con, string inputValue, out string errorInfo)
        {
            errorInfo = string.Empty;

            con.EditValue = con.EditText = inputValue;
            return true;
        }

        /// <summary>
        /// 出库校验
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="currentrow"></param>
        /// <param name="con"></param>
        /// <param name="inputValue"></param>
        /// <param name="errorInfo"></param>
        /// <returns></returns>
        protected bool DoAfterSelOutCheck(KgmGrid grid, Resco.Controls.SmartGrid.CustomEditEventArgs e, EditControlInterface con, string inputValue, out string errorInfo)
        {
            errorInfo = string.Empty;
            //判断是否是buttonclick将信息带出来 如果是则直接取editvalue

            string shineValue = e.Cell.Row[QSConstValue.ROWSHINEVALUE].ToString();
            string shineText = e.Cell.Row[QSConstValue.ROWSHINETEXT].ToString();

            //改用调用API方式
            SYS_SingleTableInfo filter = AppUtil.InitFilterModelAPI(e, string.Format(" AND ({0} = '{1}') ", shineValue, inputValue, shineText));
            string jsonData = WebAPIUtil.ConvertObjToJson(filter);
            DataTable dtBasic = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basicdocument/GetSingleTableInfo", jsonData);

            if (dtBasic == null || dtBasic.Rows.Count == 0)
            {
                errorInfo = "未能获取信息,请输入正确的编码!";
                e.Cell.Row[QSConstValue.VALUEMEMBER] = e.Cell.Row[QSConstValue.DISPLAYMEMBER] = string.Empty;
                return false;
            }

            con.EditValue = dtBasic.Rows[0][QSConstValue.VALUEMEMBER].ToString();
            con.EditText = dtBasic.Rows[0][QSConstValue.DISPLAYMEMBER].ToString();

            return true;
        }

        /// <summary>
        ///  称重后处理
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name=QSConstValue.VALUEMEMBER>实际输入的值</param>
        /// <param name="errorInfo">错误信息</param>
        /// <returns>True False</returns>
        protected bool DoAfterWeight(KgmGrid grid, Resco.Controls.SmartGrid.CustomEditEventArgs e, EditControlInterface con, string inputValue, out string errorInfo)
        {
            errorInfo = string.Empty;

            //重量如果是IP地址，则读取SOCKET
            string patten = @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))";
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(patten);
            if (r.Match(inputValue).Success)
            {
                //读取socket
                OpenWifi(inputValue);
            }
            else
            {
                con.EditValue = con.EditText = inputValue;
            }
            return true;
        }

        /// <summary>
        ///  称重后处理
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name=QSConstValue.VALUEMEMBER>实际输入的值</param>
        /// <param name="errorInfo">错误信息</param>
        /// <returns>True False</returns>
        protected bool DoAfterWeightTest(string inputValue)
        {
            //重量如果是IP地址，则读取SOCKET
            string patten = @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))";
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(patten);
            if (r.Match(inputValue).Success)
            {
                //读取socket
                OpenWifi(inputValue);
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion


        #region 称重
        private WifiClient m_ClientSocket = null;
        private delegate void UpdateTextBox(string strBuffer);
        private delegate void UpdateTextWeight(string strBuffer);


        /// <summary>
        /// 打开socket
        /// </summary>
        /// <param name="ipAddress"></param>
        private void OpenWifi(string ipAddress)
        {
            if (this.m_ClientSocket != null && this.m_ClientSocket.IsConnected())
                return;
            this.m_ClientSocket = new WifiClient(ipAddress, "60000");
            this.m_ClientSocket.Connect();
            this.m_ClientSocket.ReceiveData += new MessaegeHandler(this.ReceiveWeightData);
        }

        /// <summary>
        /// 关闭socket
        /// </summary>
        protected void CloseWifi()
        {
            if (this.m_ClientSocket != null)
            {
                this.m_ClientSocket.Disconnect();
                this.m_ClientSocket.ReceiveData -= new MessaegeHandler(this.ReceiveWeightData);
                this.m_ClientSocket = (WifiClient)null;
            }
        }

        //返回数据信息
        private void ReceiveWeightData(string strBuffer)
        {
            this.BeginInvoke((Delegate)new UpdateTextWeight(this.UpdateReceiveTextBox), new object[1]
      {
        (object) strBuffer
      });
        }


        public virtual void UpdateReceiveTextBox(string strBuffer) { }



        #endregion


        /// <summary>
        /// 初始化过滤信息
        /// </summary>
        public SYS_SingleTableInfo InitFilterModel(KgmGrid grid)
        {
            string rowMappingValue = grid.SelectedCell.Row[QSConstValue.ROWMAPPINGVALUE].ToString().ToUpper();
            string where = string.Empty;
            return AppUtil.InitFilterModelAPI(grid, where);
        }
    }
}
