using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Drawing; 
using System.Reflection;
using System.Xml;
using KgmSoft.DeviceFrameworkControl.WinCtrl; 
using System.IO.Compression;

/*
 * 系统基础类(包括通用格式等)
 */
namespace KgmSoft.Scan.Project
{
    public class AppUtil : KgmSoft.DeviceFramework.Utility.KgmUtil
    {
        #region 私有成员 
        #endregion

        #region 获取服务器时间

        /// <summary>
        /// 服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            return DateTime.Now;
        }

        #endregion

        #region 消息框
        /// <summary>
        /// 非空提示
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public static bool AlertMust(TextBox textbox, string strMessage)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                ShowWarning(strMessage + "不能为空!");
                textbox.Focus();

                return true;
            }
            return false;
        }

        /// <summary>
        /// 非空提示
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public static bool AlertMust(ComboBox combbox, string strMessage)
        {
            if (string.IsNullOrEmpty(AppUtil.GetSelectValue(ref combbox)))
            {
                ShowWarning(strMessage);
                combbox.Focus();

                return true;
            }
            return false;
        }
        #endregion

        #region 数据加密
        //************************************************************************
        /// <summary> 
        /// 加密字符串 
        /// </summary> 
        /// <param name="inputStr">输入字符串</param> 
        /// <param name="keyStr">密码，可以为“”</param> 
        /// <returns>输出加密后字符串</returns>
        //************************************************************************
        static private string key = "1234567890"; //默认密钥 
        static private byte[] skey;
        static private byte[] siv;
        static public string EncryptString(string inputStr, string keyStr)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                if (keyStr == "") keyStr = key;

                byte[] inputByteArray = Encoding.Default.GetBytes(inputStr);
                byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);

                SHA1 ha = new SHA1Managed();
                byte[] hb = ha.ComputeHash(keyByteArray);

                skey = new byte[8];
                siv = new byte[8];

                for (int i = 0; i < 8; i++) skey[i] = hb[i];
                for (int i = 8; i < 16; i++) siv[i - 8] = hb[i];

                des.Key = skey;
                des.IV = siv;

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat(null, "{0:x2}", b);
                }

                cs.Close();
                ms.Close();

                return ret.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //************************************************************************
        /// <summary> 
        /// 解密字符串 
        /// </summary> 
        /// <param name="inputStr">要解密的字符串</param> 
        /// <param name="keyStr">密钥</param> 
        /// <returns>解密后的结果</returns>
        //************************************************************************
        static public string DecryptString(string inputStr, string keyStr)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                if (keyStr == "") keyStr = key;

                byte[] inputByteArray = new byte[inputStr.Length / 2];

                for (int x = 0; x < inputStr.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(inputStr.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);

                SHA1 ha = new SHA1Managed();

                byte[] hb = ha.ComputeHash(keyByteArray);

                skey = new byte[8];
                siv = new byte[8];

                for (int i = 0; i < 8; i++) skey[i] = hb[i];
                for (int i = 8; i < 16; i++) siv[i - 8] = hb[i];

                des.Key = skey;
                des.IV = siv;

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder ret = new StringBuilder();
                return System.Text.Encoding.Default.GetString(ms.ToArray(), 0, ms.ToArray().Length);
            }
            catch (Exception ex)
            {
                throw ex;
                //return "";
            }
        }
        #endregion

        #region 将二进制转换成image对象
        /// <summary>
        /// 将二进制转换成image对象
        /// </summary>
        /// <param name="bytes"></param>
        public static Image ChangeImg(Byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes); // MemoryStream创建其支持存储区为内存的流。
            try
            {
                //MemoryStream属于System.IO类
                ms.Position = 0;
                Bitmap map = new Bitmap(ms);

                return (Image)map;
            }
            finally
            {
                ms.Close();
            }

        }
        #endregion

        #region 绑定下拉框
        public static void BindCombBox(ref EditCombox comboBox, DataTable dataSource, string valueMember, string DisplayMember)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                return;
            }
            DataRow dr = dataSource.NewRow();
            dataSource.Rows.InsertAt(dr, 0);
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = DisplayMember;
            comboBox.ValueMember = valueMember;
        }

        public static void BindCombBox(ref EditCombox comboBox, DataTable dataSource, string valueMember, string DisplayMember, bool isNeedEmptyRow)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                return;
            }
            if (isNeedEmptyRow)
            {
                DataRow dr = dataSource.NewRow();
                dataSource.Rows.InsertAt(dr, 0);
            }
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = DisplayMember;
            comboBox.ValueMember = valueMember;
        }



        public static void BindCombBox(ref ComboBox comboBox, DataTable dataSource, string valueMember, string DisplayMember)
        {
            if (dataSource != null)
            {
                DataRow dr = dataSource.NewRow();
                dataSource.Rows.InsertAt(dr, 0);
            }

            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = DisplayMember;
            comboBox.ValueMember = valueMember;
        }

        public static void BindCombBox(ref ComboBox comboBox, DataTable dataSource, string valueMember, string DisplayMember, bool isNeedEmptyRow)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                return;
            }
            if (isNeedEmptyRow)
            {
                DataRow dr = dataSource.NewRow();
                dataSource.Rows.InsertAt(dr, 0);
            }
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = DisplayMember;
            comboBox.ValueMember = valueMember;
        }
        #endregion

        /// <summary>
        /// 初始化imagelist
        /// </summary>
        public static ImageList InitImgList(Size size)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = size;
            string[] filenames = Directory.GetFiles(QSConstValue.IMAGE_PATH);
            foreach (string filename in filenames)
            {
                FileStream fs = new FileStream(Path.GetFullPath(filename), FileMode.Open);
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);
                Image img = AppUtil.ChangeImg(buffur);
                imgList.Images.Add(img);
                fs.Close();
                fs.Dispose();//释放资源
            }

            return imgList;
        }
 
        #region 读取配置文件信息
        /// <summary>
        /// 获取节点值
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static string GetXmlNodeValue(string nodeName)
        {
            try
            {
                string pathGun = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).ToString();
                string path = pathGun + "\\" + QSConstValue.CONFIG_FILENAME;

                XmlDocument xd = new XmlDocument();
                xd.Load(path);

                string xpath = "/" + QSConstValue.PARENT_NODE + "/" + nodeName + "";
                XmlNode root = xd.SelectSingleNode(xpath);
                return root.InnerText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static void SetXmlNodeValue(string nodeName, string Value)
        {
            try
            {
                string pathGun = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).ToString();
                string path = pathGun + "\\" + QSConstValue.CONFIG_FILENAME;

                XmlDocument xd = new XmlDocument();
                xd.Load(path);

                string xpath = "/" + QSConstValue.PARENT_NODE + "/" + nodeName + "";
                XmlNode root = xd.SelectSingleNode(xpath);
                root.InnerText = Value;
                xd.Save(path);
            }
            catch (Exception)
            {
                throw new Exception("保存配置文件失败");
            }
        }
        #endregion

        #region 画面处理
        /// <summary>
        /// 判断当前grid中的控件是否可以编辑
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static bool KgmGridCanEdit(Resco.Controls.SmartGrid.CustomEditEventArgs e)
        {
            EditControlInterface con = e.Control as EditControlInterface;

            if (string.IsNullOrEmpty(con.EditText) && string.IsNullOrEmpty(con.EditValue == null ? "" : con.EditValue.ToString()))
            {
                return false;
            }
            if (!string.IsNullOrEmpty(con.EditValue.ToString())
                && con.EditValue.ToString().ToLower() == e.Cell.Row[QSConstValue.VALUEMEMBER].ToString().ToLower()
                && con.EditText.ToString().ToLower() == e.Cell.Row[QSConstValue.DISPLAYMEMBER].ToString().ToLower())
            {
                return false;
            }
            if (string.IsNullOrEmpty(con.EditText.ToString().ToLower()))
            {
                con.EditValue = con.EditText = string.Empty;
                return false;
            }

            return true;

        }

        /// <summary>
        /// 判断列表Button_Click时，是否需要弹窗体
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>返回弹窗窗体</returns>
        public static FrmBaseSelForm KgmGridButtonShowForm(KgmGrid grid)
        {
            //判断当前shinetable是否为空，不为空，弹出基础档案选择画面
            DataTable dtSource = grid.DataSource as DataTable;
            if (dtSource == null || !Convert.ToBoolean(grid.SelectedCell.Row[QSConstValue.BDOCUMENT]) ||
                grid.SelectedCell.Row[QSConstValue.ROWSHINETABLE].ToString() == string.Empty)
            {
                return null;
            }
            FrmBaseSelForm frm = null;
            //switch (grid.SelectedCell.Row[QSConstValue.ROWSHINETABLE].ToString())
            //{
            //    case QSConstValue.LIST_HEAD:
            //        frm = new FrmListFilter();
            //        break;
            //    default:
            //        frm = new FrmDocument();
            //        break;
            //}
            return frm;
        }


        /// <summary>
        /// 初始化业务类型信息
        /// </summary>
        public static void InitBusInfo(KgmGrid grid, DataTable dtVouchType)
        {
            #region 赋默认值
            //如果画面为空，则不赋值
            DataTable dt = grid.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }

            //判断画面上是否存在下拉框,如果存在则绑定来源类型
            EditCombox cmb = grid.GetComboBoxCtrl();
            if (cmb != null)
            {
                cmb.DataSourceID = QSConstValue.CVOUCHID;
                AppUtil.BindCombBox(ref cmb, dtVouchType, QSConstValue.CVOUCHID, QSConstValue.CSOURCE, false);
            }

            //判断当前模块是否存在默认业务类型,如果存在,则初始化业务类型
            DataView dvVouchType = new DataView(dtVouchType);
            dvVouchType.RowFilter = " ISCREATE = 1 ";
            if (dvVouchType.Count == 0)
            {
                return;
            }

            InitVouchInfo(grid, dvVouchType.ToTable());
            #endregion
        }

        /// <summary>
        /// 初始化来源类型信息
        /// </summary>
        public static void InitVouchInfo(KgmGrid grid, DataTable dtVouch)
        {
            ////初始化来源类型对象
            //QSCommonValue.KgmVouchType = dtVouch.Rows[0];
            ////初始化来源类型默认信息
            //foreach (Resco.Controls.SmartGrid.Row row in grid.Rows)
            //{
            //    string rowValue = row[QSConstValue.ROWMAPPINGVALUE].ToString(); //映射值
            //    string rowText = row[QSConstValue.ROWMAPPINGTEXT].ToString();//影射现实信息

            //    //给画面信息赋值
            //    if (dtVouch.Columns.Contains(rowValue))
            //    {
            //        row[QSConstValue.VALUEMEMBER] = dtVouch.Rows[0][rowValue].ToString();
            //    }
            //    if (dtVouch.Columns.Contains(rowText))
            //    {
            //        row[QSConstValue.DISPLAYMEMBER] = dtVouch.Rows[0][rowText].ToString();
            //    }

            //    bool bEdit = false;

            //    //如果来源类型为底层单据rdrecord则所有选项不可编辑
            //    if (QSCommonValue.KgmVouchType[QSConstValue.CSOURCETABLE].ToString() == QSConstValue.RDRECORD)
            //    {
            //        if (rowValue != QSConstValue.KGM_VOUCHTYPE && rowValue != QSConstValue.KGM_BUSCODE)
            //        {
            //            row[QSConstValue.BNOTNULL] = row[QSConstValue.BEDIT] = bEdit;
            //        }
            //    }
            //    else
            //    {
            //        bEdit = !(QSCommonValue.KgmVouchType[QSConstValue.CSOURCETABLE].ToString() == string.Empty);

            //        //判断当前业务类型信息
            //        switch (row[QSConstValue.ROWSHINETABLE].ToString().ToUpper())
            //        {
            //            case QSConstValue.KGM_BUSCODE: //单据号
            //                //设置单据号是否可编辑
            //                row[QSConstValue.BNOTNULL] = row[QSConstValue.BEDIT] = bEdit;
            //                break;
            //            case QSConstValue.PURCHASETYPE: //采购类型
            //                row[QSConstValue.BEDIT] = bEdit;
            //                break;
            //            case QSConstValue.SALETYPE: //销售类型
            //                row[QSConstValue.BEDIT] = bEdit;
            //                break;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 绑定下拉框信息
        /// </summary>
        /// <param name="cVouchName"></param>
        public static void BindEditCombo(KgmGrid grid, DataTable dtSource)
        {
            EditCombox cmb = grid.GetComboBoxCtrl();
            if (cmb.DataSourceID != grid.SelectedCell.Row[QSConstValue.ROWMAPPINGVALUE].ToString())
            {
                cmb.DataSourceID = grid.SelectedCell.Row[QSConstValue.ROWMAPPINGVALUE].ToString();
                //绑定ComboBox
                AppUtil.BindCombBox(ref cmb, dtSource, grid.SelectedCell.Row[QSConstValue.ROWMAPPINGVALUE].ToString(),
                    grid.SelectedCell.Row[QSConstValue.ROWMAPPINGTEXT].ToString(), false);
            }
        }

        /// <summary>
        /// 清除grid文本
        /// </summary>
        /// <param name="grid"></param>
        public static void ClearGrid(KgmGrid grid)
        {
            foreach (Resco.Controls.SmartGrid.Row row in grid.Rows)
            {
                row[QSConstValue.VALUEMEMBER] = row[QSConstValue.DISPLAYMEMBER] = string.Empty;
            }

            EditCombox cmb = grid.GetComboBoxCtrl();
            if (grid != null)
            {
                cmb.DataSource = null;
                cmb.DataSourceID = string.Empty;
            }
        }
        #endregion

        #region KgmGrid
        /// <summary>
        /// 初始化grid控件
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dtColumn"></param>
        /// <param name="dtRow"></param>
        public static void InitKgmGrid(ref KgmGrid grid, DataTable dtColumn, DataTable dtRow)
        {
            if (dtColumn.Rows.Count > 0)
            {

                grid.KgmGridType = dtColumn.Rows[0][QSConstValue.EDITMODE].ToString() == "1" ? KgmGrid.GridType.RowEdit : KgmGrid.GridType.ColumnEdit;
                grid.ColumnHeadersVisible = dtColumn.Rows[0][QSConstValue.EDITMODE].ToString() != "1";
                grid.RowHeadersVisible = false;
                grid.initGridData(dtColumn, dtRow);
            }
        }

        /// <summary>
        /// 初始化grid控件
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dtColumn"></param>
        /// <param name="dtRow"></param>
        public static void InitKgmGrid(ref KgmGrid grid, string formName, string orderType, string cVouchID)
        {
            //DataTable dtColumn = sysbll.GetGridColumn(formName, grid.Name, orderType, cVouchID);
            //DataTable dtRow = sysbll.GetGridRow(formName, grid.Name, orderType, cVouchID);
            //if (dtColumn.Rows.Count > 0)
            //{
            //    grid.KgmGridType = dtColumn.Rows[0][QSConstValue.EDITMODE].ToString() == "1" ? KgmGrid.GridType.RowEdit : KgmGrid.GridType.ColumnEdit;
            //    grid.ColumnHeadersVisible = dtColumn.Rows[0][QSConstValue.EDITMODE].ToString() != "1";
            //    grid.RowHeadersVisible = false;
            //    grid.initGridData(dtColumn, dtRow);
            //}

        }

        /// <summary>
        /// 给Grid数据源赋值 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dt"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool SetValueFromGirdSource(KgmGrid grid, DataRow dr, bool bCheck)
        {
            foreach (Resco.Controls.SmartGrid.Row row in grid.Rows)
            {
                try
                {
                    if (dr.Table.Columns.Contains(row[QSConstValue.ROWMAPPINGVALUE].ToString()))
                    {
                        dr[row[QSConstValue.ROWMAPPINGVALUE].ToString()] = row[QSConstValue.VALUEMEMBER];
                    }
                    if (dr.Table.Columns.Contains(row[QSConstValue.ROWMAPPINGTEXT].ToString()))
                    {
                        dr[row[QSConstValue.ROWMAPPINGTEXT].ToString()] = row[QSConstValue.DISPLAYMEMBER];
                    }

                    if (bCheck && Convert.ToBoolean(row[QSConstValue.BNOTNULL]) && string.IsNullOrEmpty(row[QSConstValue.VALUEMEMBER].ToString()))
                    {
                        AppUtil.ShowWarning(row[QSConstValue.ROWTITLE].ToString() + "不允许为空");
                        grid.SetEditCellFocus(row[QSConstValue.ROWMAPPINGVALUE].ToString());
                        return false;
                    }
                }
                catch
                {

                }

            }

            return true;
        }


        /// <summary>
        /// 给Grid数据源赋值 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dt"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool SetValueToGirdSource(KgmGrid grid, DataRow dr, bool bCheck)
        {
            foreach (Resco.Controls.SmartGrid.Row row in grid.Rows)
            {
                string mappingValue = row[QSConstValue.ROWMAPPINGVALUE].ToString().ToUpper();
                string mappingText = row[QSConstValue.ROWMAPPINGTEXT].ToString().ToUpper();

                if (dr.Table.Columns.Contains(mappingValue) && !string.IsNullOrEmpty(dr[mappingValue].ToString()))
                {
                    row[QSConstValue.VALUEMEMBER] = dr[mappingValue];
                }
                if (dr.Table.Columns.Contains(mappingText) && !string.IsNullOrEmpty(dr[mappingText].ToString()))
                {
                    row[QSConstValue.DISPLAYMEMBER] = dr[mappingText].ToString();
                }

                if (dr.Table.Columns.Contains("CSOURCE") && mappingValue == "CSOURCECODE")
                {
                    if (dr["CSOURCE"].ToString() == "无来源" || dr["CSOURCE"].ToString() == "无来源")
                    {
                        row[QSConstValue.BEDIT] = false;
                        row[QSConstValue.BNOTNULL] = false;
                    }
                    else
                    {
                        row[QSConstValue.BEDIT] = true;
                        row[QSConstValue.BNOTNULL] = true;
                    }
                }
                if (bCheck && Convert.ToBoolean(row[QSConstValue.BNOTNULL]) && string.IsNullOrEmpty(row[QSConstValue.VALUEMEMBER].ToString()))
                {
                    AppUtil.ShowWarning(row[QSConstValue.ROWTITLE].ToString() + "不允许为空");
                    grid.SetEditCellFocus(row[QSConstValue.ROWMAPPINGVALUE].ToString());
                    return false;
                }
            }

            return true;
        }




        /// <summary>
        /// 给Grid数据源赋值 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dt"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool VlidateGrid(KgmGrid grid)
        {
            foreach (Resco.Controls.SmartGrid.Row row in grid.Rows)
            {
                if (Convert.ToBoolean(row[QSConstValue.BNOTNULL]) && string.IsNullOrEmpty(row[QSConstValue.VALUEMEMBER].ToString()))
                {
                    AppUtil.ShowWarning(row[QSConstValue.ROWTITLE].ToString() + "不允许为空");
                    grid.SetEditCellFocus(row[QSConstValue.ROWMAPPINGVALUE].ToString());
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 实例化Kgm_FilterModel
        ///// <summary>
        ///// 初始化表过滤对象
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="where"></param>
        ///// <returns></returns>
        //public static Kgm_FilterModel InitFilterModel(KgmGrid grid, string where)
        //{
        //    Kgm_FilterModel model = new Kgm_FilterModel();
        //    model.tableName = grid.SelectedCell.Row[QSConstValue.ROWSHINETABLE].ToString();
        //    model.dbName = grid.SelectedCell.Row[QSConstValue.BOUTTABLE].ToString() != string.Empty && Convert.ToBoolean(grid.SelectedCell.Row[QSConstValue.BOUTTABLE]) ? QSCommonValue.BarDbConfigInfo.U8DatabaseName : string.Empty;
        //    model.where = grid.SelectedCell.Row[QSConstValue.ROWFILTER].ToString() + where;
        //    model.valueMember = grid.SelectedCell.Row[QSConstValue.ROWSHINEVALUE].ToString();
        //    model.displayMember = grid.SelectedCell.Row[QSConstValue.ROWSHINETEXT].ToString();

        //    return model;
        //}

        ///// <summary>
        ///// 初始化表过滤对象
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="where"></param>
        ///// <returns></returns>
        //public static Kgm_FilterModel InitFilterModel(Resco.Controls.SmartGrid.CustomEditEventArgs e, string where)
        //{
        //    Kgm_FilterModel model = new Kgm_FilterModel();
        //    model.tableName = e.Cell.Row[QSConstValue.ROWSHINETABLE].ToString();
        //    model.dbName = e.Cell.Row[QSConstValue.BOUTTABLE].ToString() != string.Empty && Convert.ToBoolean(e.Cell.Row[QSConstValue.BOUTTABLE]) ? QSCommonValue.BarDbConfigInfo.U8DatabaseName : string.Empty;
        //    model.where = e.Cell.Row[QSConstValue.ROWFILTER].ToString() + where;
        //    model.valueMember = e.Cell.Row[QSConstValue.ROWSHINEVALUE].ToString();
        //    model.displayMember = e.Cell.Row[QSConstValue.ROWSHINETEXT].ToString();

        //    if (QSCommonValue.TempScanHead != null)
        //    {
        //        string cWhCode = string.IsNullOrEmpty(QSCommonValue.TempScanHead["COWHCODE"].ToString()) ?
        //            QSCommonValue.TempScanHead["CIWHCODE"].ToString() :
        //            QSCommonValue.TempScanHead["COWHCODE"].ToString();
        //        if (!string.IsNullOrEmpty(cWhCode))
        //        {
        //            model.where = model.where.Replace("@CWHCODE", string.Format(" '{0}' ", cWhCode));
        //        }
        //    }
        //    if (QSCommonValue.OP_Module != null)
        //    {
        //        model.where = model.where.Replace("@MODULEID", string.Format(" '{0}' ", QSCommonValue.OP_Module.ModuleId));
        //    }

        //    return model;
        //}

        #endregion 

        #region API相关

        #region 实例化Kgm_FilterModel
        ///// <summary>
        ///// 初始化表过滤对象
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="where"></param>
        ///// <returns></returns>
        //public static SYS_SingleTableInfo InitFilterModelAPI(KgmGrid grid, string where)
        //{
        //    SYS_SingleTableInfo model = new SYS_SingleTableInfo();
        //    model.Table = grid.SelectedCell.Row[QSConstValue.ROWSHINETABLE].ToString();
        //    model.DbName = grid.SelectedCell.Row[QSConstValue.BOUTTABLE].ToString() != string.Empty && Convert.ToBoolean(grid.SelectedCell.Row[QSConstValue.BOUTTABLE]) ? QSCommonValue.BarDbConfigInfo.U8DatabaseName : string.Empty;
        //    model.Where = grid.SelectedCell.Row[QSConstValue.ROWFILTER].ToString() + where;
        //    model.ValueMember = grid.SelectedCell.Row[QSConstValue.ROWSHINEVALUE].ToString();
        //    model.DisplayMember = grid.SelectedCell.Row[QSConstValue.ROWSHINETEXT].ToString();

        //    return model;
        //}

        ///// <summary>
        ///// 初始化表过滤对象
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="where"></param>
        ///// <returns></returns>
        //public static SYS_SingleTableInfo InitFilterModelAPI(Resco.Controls.SmartGrid.CustomEditEventArgs e, string where)
        //{
        //    SYS_SingleTableInfo model = new SYS_SingleTableInfo();
        //    model.Table = e.Cell.Row[QSConstValue.ROWSHINETABLE].ToString();
        //    model.DbName = e.Cell.Row[QSConstValue.BOUTTABLE].ToString() != string.Empty && Convert.ToBoolean(e.Cell.Row[QSConstValue.BOUTTABLE]) ? QSCommonValue.BarDbConfigInfo.U8DatabaseName : string.Empty;
        //    model.Where = e.Cell.Row[QSConstValue.ROWFILTER].ToString() + where;
        //    model.ValueMember = e.Cell.Row[QSConstValue.ROWSHINEVALUE].ToString();
        //    model.DisplayMember = e.Cell.Row[QSConstValue.ROWSHINETEXT].ToString();

        //    if (QSCommonValue.TempScanHead != null)
        //    {
        //        string cWhCode = string.IsNullOrEmpty(QSCommonValue.TempScanHead["COWHCODE"].ToString()) ?
        //            QSCommonValue.TempScanHead["CIWHCODE"].ToString() :
        //            QSCommonValue.TempScanHead["COWHCODE"].ToString();
        //        if (!string.IsNullOrEmpty(cWhCode))
        //        {
        //            model.Where = model.Where.Replace("@CWHCODE", string.Format(" '{0}' ", cWhCode));
        //        }
        //    }
        //    if (QSCommonValue.OP_Module != null)
        //    {
        //        model.Where = model.Where.Replace("@MODULEID", string.Format(" '{0}' ", QSCommonValue.OP_Module.ModuleId));
        //    }

        //    return model;
        //}

        #endregion


        #endregion


        #region 字符串压缩
        /// <summary>  
        /// 字符串压缩  
        /// </summary>  
        /// <param name="strSource"></param>  
        /// <returns></returns>  
        public static byte[] Compress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                byte[] buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>  
        /// 字符串解压缩  
        /// </summary>  
        /// <param name="strSource"></param>  
        /// <returns></returns>  
        public static byte[] Decompress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                GZipStream zip = new GZipStream(ms, CompressionMode.Decompress, true);
                MemoryStream msreader = new MemoryStream();
                byte[] buffer = new byte[0x1000];
                while (true)
                {
                    int reader = zip.Read(buffer, 0, buffer.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    msreader.Write(buffer, 0, reader);
                }
                zip.Close();
                ms.Close();
                msreader.Position = 0;
                buffer = msreader.ToArray();
                msreader.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 字符串压缩
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressString(string str)
        {
            string compressString = "";
            byte[] compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);
            byte[] compressAfterByte = Compress(compressBeforeByte);
            //compressString = Encoding.GetEncoding("UTF-8").GetString(compressAfterByte);    
            compressString = Convert.ToBase64String(compressAfterByte);
            return compressString;
        }

        /// <summary>
        /// 字符串解压缩
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecompressString(string str)
        {
            string compressString = "";
            //byte[] compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);    
            byte[] compressBeforeByte = Convert.FromBase64String(str);
            byte[] compressAfterByte = Decompress(compressBeforeByte);
            compressString = Encoding.GetEncoding("UTF-8").GetString(compressAfterByte, 0, compressAfterByte.Length);
            return compressString;
        }

        #endregion

    }
}
