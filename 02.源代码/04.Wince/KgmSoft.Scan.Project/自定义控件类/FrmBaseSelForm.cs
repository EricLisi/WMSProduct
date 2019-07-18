using System;
using System.Data;
using KgmSoft.DeviceFrameworkControl.WinCtrl;

namespace KgmSoft.Scan.Project
{
    public class FrmBaseSelForm : KgmSoft.DeviceFrameworkControl.WinGui.FrmBase
    {
        //private KgmSoft.Scan.MODEL.SYS_SingleTableInfo m_FilterModel;//过滤条件对象
        private string m_returnValue;//返回的值
        private string m_returnText;//返回的名称
        private Resco.Controls.SmartGrid.Row m_ReturnDr;//返回的选择行
        private string m_filter;//字符串过滤条件
        public DataTable dttray;
        private DataTable m_Seldt; 

        /// <summary>
        /// 返回的结果集
        /// </summary>
        public DataTable Seldt
        {
            get { return m_Seldt; }
            set { m_Seldt = value; }
        }

        ///// <summary>
        ///// 过滤对象
        ///// </summary>
        //public KgmSoft.Scan.MODEL.SYS_SingleTableInfo FilterModel
        //{
        //    get { return m_FilterModel; }
        //    set { m_FilterModel = value; }
        //}

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
        /// <param name="dtSource">数据源</param>
        /// <param name=QSConstValue.VALUEMEMBER>实际输入的值</param>
        /// <param name="errorInfo">错误信息</param>
        /// <returns>True False</returns>
        protected bool DoAfterSelOrderNo(KgmGrid grid, EditControlInterface con, string inputvalue, out string errorInfo)
        {
            errorInfo = string.Empty;
            var biztype = string.Empty;
            try
            {
                biztype = grid.GetRowCellData("CVOUCHID", QSConstValue.VALUEMEMBER).ToString();
                if (string.IsNullOrEmpty(biztype))
                {
                    errorInfo = "业务类型不能为空!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                AppUtil.ShowError(ex.ToString());
            }
            //设置过滤条件
            string rowfilter = string.Format(" AND ORDERNO = '{0}' ", inputvalue);
            //根据过滤条件读取单据信息
            //DataTable dtorderList = tbll.GetTVInfo(rowfilter);
            string jsonData = WebAPIUtil.ConvertObjToJson(rowfilter);

            DataTable dtorderList = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/tray/GetTVInfo", jsonData);
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
            ////设置过滤条件
            //string rowfilter = string.Format(" AND A.MODULEID = '{0}' AND (CVOUCHID = '{1}' OR CVOUCHNAME = '{1}' OR CSOURCE = '{1}')", QSCommonValue.OP_Module.ModuleId, inputvalue);
            ////根据过滤条件读取单据信息
            ////ADO
            ////DataTable dtVouchType = bll.GetVouchModel(rowfilter);

            ////API
            //VouchModel model = new VouchModel();
            //model.Condition = rowfilter;
            //model.DBNAME = QSCommonValue.BarDbConfigInfo.U8DatabaseName;
            //string jsonData = WebAPIUtil.ConvertObjToJson(model);
            //DataTable dtVouchType = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basic/GetVouchModel", jsonData);

            //if (dtVouchType == null || dtVouchType.Rows.Count == 0)
            //{
            //    errorInfo = "未能获取到业务类型信息,请确认编码是否正确!";
            //    return false;
            //}

            ////循环赋值
            //if (!AppUtil.SetValueToGirdSource(grid, dtVouchType.Rows[0], false))
            //{
            //    return false;
            //}

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
            ////判断是否是buttonclick将信息带出来 如果是则直接取editvalue
            //string value = con.EditValue.ToString().ToUpper() == e.Cell.Row[QSConstValue.VALUEMEMBER].ToString().ToUpper() ? value = con.EditText : con.EditValue.ToString();
            //string shineValue = e.Cell.Row[QSConstValue.ROWSHINEVALUE].ToString();


            //if (e.Cell.Row[QSConstValue.ROWMAPPINGVALUE].ToString().ToUpper() == "CPOSCODE" || e.Cell.Row[QSConstValue.ROWMAPPINGVALUE].ToString().ToUpper() == "CIPOSCODE")
            //{
            //    if (value.Length != 6)
            //    {
            //        value = QSCommonValue.TempScanHead["CWHCODE"].ToString() + value;
            //    }
            //}

            ////根据填写的信息，读取档案信息带出值
            //Kgm_FilterModel filter = AppUtil.InitFilterModel(e, string.Format(" AND {0} = '{1}' ", shineValue, value));
            //if (filter.tableName.ToLower() == "list_main")
            //{
            //    string ordertype = QSCommonValue.OP_Module.ModuleMenu == "扫描入库" ? "入库通知" : "出库通知";
            //    filter.where += string.Format(" AND ORDERTYPE = '{0}'", ordertype);
            //}

            ////ADO
            ////DataTable dtBasic = bll.GetSingleTableInfo(filter);

            ////API
            //string jsonData = WebAPIUtil.ConvertObjToJson(filter);
            //DataTable dtBasic = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basic/GetSingleTableInfo", jsonData);

            //if (dtBasic == null || dtBasic.Rows.Count == 0)
            //{
            //    errorInfo = "未能获取信息,请输入正确的编码!";
            //    e.Cell.Row[QSConstValue.VALUEMEMBER] = e.Cell.Row[QSConstValue.DISPLAYMEMBER] = string.Empty;
            //    return false;
            //}

            //con.EditValue = dtBasic.Rows[0][QSConstValue.VALUEMEMBER].ToString();
            //con.EditText = dtBasic.Rows[0][QSConstValue.DISPLAYMEMBER].ToString();

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
            ////ADO
            ////dttray = bll.GetSingleTableInfo("TRAY_INFO", "ID", "TRAYNO", "", string.Format(" AND TRAYNO = '{0}'", inputValue), string.Empty, true, "");

            ////API
            //Kgm_FilterModel model = new Kgm_FilterModel();
            //model.tableName = "TRAY_INFO";
            //model.valueMember = "ID";
            //model.displayMember = "TRAYNO";
            //model.filedName = string.Empty;
            //model.where = string.Format(" AND TRAYNO = '{0}'", inputValue);
            //model.dbName = string.Empty;
            //model.bDistinct = true;
            //model.sortFiled = string.Empty;
            //string jsonData = WebAPIUtil.ConvertObjToJson(model);
            //DataTable dttray = WebAPIUtil.PostAPIByJsonToGeneric<DataTable>("api/basic/GetSingleTableInfo", jsonData);

            //if (dttray == null || dttray.Rows.Count == 0)
            //{
            //    errorInfo = "未能获取到对应的信息,请确认条码是否正确!";
            //    return false;
            //}

            //if (!AppUtil.SetValueToGirdSource(grid, dttray.Rows[0], false))
            //{
            //    errorInfo = "未能获取到对应的信息,请确认条码是否正确!";
            //    return false;
            //}

            //else {
            //    DataTable dtbarcode = bll.BarcodeAnalyze(QSCommonValue.TempScanHead["OPERORDER"].ToString(), inputValue, QSCommonValue.BarDbConfigInfo.BarcodeDatabaseName);
            //    if (dtbarcode == null || dtbarcode.Rows.Count == 0)
            //    {
            //        errorInfo = "未能获取到对应的解析信息,请确认条码是否正确!";
            //        return false;
            //    }

            //    if (dtbarcode.Columns.Count == 1)
            //    {
            //        errorInfo = dtbarcode.Rows[0][0].ToString();
            //        return false;
            //    }

            //    if (!AppUtil.SetValueToGirdSource(grid, dtbarcode.Rows[0], false))
            //    {
            //        return false;
            //    }
            //}
            //con.EditValue = con.EditText = inputValue;
            return true;
        }
        #endregion


        /// <summary>
        /// 初始化过滤信息
        /// </summary>
        //public SYS_SingleTableInfo InitFilterModel(KgmGrid grid)
        //{
        //    string rowMappingValue = grid.SelectedCell.Row[QSConstValue.ROWMAPPINGVALUE].ToString().ToUpper();
        //    string where = string.Empty;
        //    return AppUtil.InitFilterModelAPI(grid, where);
        //}
    }
}
