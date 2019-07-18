using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

/*
 * 常量类
 */
namespace KgmSoft.Scan.Project
{
    public class QSConstValue : KgmSoft.DeviceFramework.Utility.ConstValue
    {
        public const string ADMIN_NAME = "kgmAdmin";
        public const string ADMIN_PWD = "51029010";
        public const string ASSBLEM_NAME = "KgmSoft.Scan.Project.";

        #region 配置文件
        /// <summary>
        /// 自动升级配置文件路径
        /// </summary>
        public static string UPDATE_CONFIG_PATH = System.IO.Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).ToString() + @"\update.config";
        /// <summary>
        /// 主程序路径
        /// </summary>
        public static string APP_PATH = System.IO.Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).ToString() + @"\KgmSoft.Scan.Project.exe";
        /// <summary>
        /// 配置文件名
        /// </summary>
        public const string CONFIG_FILENAME = "ConnSettings.xml";
        /// <summary>
        /// 自动升级配置文件路径
        /// </summary>
        public static string SQLITE_PATH = System.IO.Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).ToString() + @"\UIINFO.db";

        /// <summary>
        /// 图像文件夹
        /// </summary>
        public static string IMAGE_PATH = System.IO.Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).ToString() + @"\img\";

        /// <summary>
        /// 配置文件主节点
        /// </summary>
        public const string PARENT_NODE = "Config";
        /// <summary>
        /// 服务器地址节点
        /// </summary>
        public const string SERVERIP_NODE = "SERVERIP";
        /// <summary>
        /// 服务名称节点
        /// </summary>
        public const string SERVERNAME_NODE = "SERVERNAME";
        /// <summary>
        /// 数据库名称节点
        /// </summary>
        public const string DBNAME_NODE = "DBNAME";
        /// <summary>
        /// 数据库登录用户
        /// </summary>
        public const string DBUSER_NODE = "DBUSER";
        /// <summary>
        /// 数据库登录密码
        /// </summary>
        public const string DBPWD_NODE = "DBPWD";
        /// <summary>
        /// 打印机COM口
        /// </summary>
        public const string COM_NODE = "COM";
        /// <summary>
        /// 本地SQLITE路径
        /// </summary>
        public const string SQLITE_NODE = "SQLITE";
        /// <summary>
        /// 终端类型 0 I60 1 MC3000 2 HONYWELL
        /// </summary>
        public const string TERMINAL_NODE = "TERMINAL";
        /// <summary>
        /// 是否加密
        /// </summary>
        public const string SERIALNO_NODE = "SerialNo";

        public const string UPDATESERVER_NODE = "AutoUpdateServer";
        public const string SERVICE_NODE = "ServiceName";
        #endregion

        #region 基础档案表名
        /// <summary>
        /// 仓库档案
        /// </summary>
        public const string WAREHOUSE = "MST_WAREHOUSE";
        /// <summary>
        /// 仓库档案
        /// </summary>
        public const string WAREHOUSE_DOC = "仓库档案";
        /// <summary>
        /// 存货档案
        /// </summary>
        public const string INVENTORY = "MST_MANUAL";
        /// <summary>
        /// 存货档案
        /// </summary>
        public const string INVENTORY_DOC = "说明书档案";
        /// <summary>
        /// 货位档案
        /// </summary>
        public const string POSITION = "MST_POSITION";
        /// <summary>
        /// 货位档案
        /// </summary>
        public const string POSITION_DOC = "货位档案";
        /// <summary>
        /// 供应商档案
        /// </summary>
        public const string VENDOR = "MST_VENDOR";
        /// <summary>
        /// 供应商档案
        /// </summary>
        public const string VENDOR_DOC = "供应商档案";
        /// <summary>
        /// 库存档案
        /// </summary>
        public const string STOCK = "SM_STOCK";
        /// <summary>
        /// 库存档案
        /// </summary>
        public const string STOCK_DOC = "库存档案";
        /// <summary>
        /// 用户档案
        /// </summary>
        public const string USER = "SYS_USERS";
        /// <summary>
        /// 用户档案
        /// </summary>
        public const string USER_DOC = "用户档案";
        /// <summary>
        /// 部门档案
        /// </summary>
        public const string DEPARTMENT = "DEPARTMENT";
        /// <summary>
        /// 客户档案
        /// </summary>
        public const string CUSTOMER = "MST_CUSTOMER";
        /// <summary>
        /// 收发记录
        /// </summary>
        public const string RDSTYLE = "RD_STYLE";
        /// <summary>
        /// 采购类型档案
        /// </summary>
        public const string PURCHASETYPE = "PURCHASETYPE";
        /// <summary>
        /// 销售类型档案
        /// </summary>
        public const string SALETYPE = "SALETYPE";
        /// <summary>
        /// 业务类型
        /// </summary>
        public const string KGM_VOUCHTYPE = "KGM_VOUCHTYPE";
        /// <summary>
        /// 业务处理单号,业务类型对应的单号
        /// </summary>
        public const string KGM_BUSCODE = "KGM_BUSCODE";
        /// <summary>
        /// 业务处理单号,业务类型对应的单号
        /// </summary>
        public const string LIST_HEAD = "KGM_BUSCODE";
        /// <summary>
        /// 业务员表
        /// </summary>
        public const string PERSON = "PERSON";
        /// <summary>
        /// 底层单据
        /// </summary>
        public const string RDRECORD = "RDRECORD";
        #endregion

        #region 列表节点名
        public const string CPTCODE = "CPTCODE";
        public const string CPTNAME = "CPTNAME";
        public const string CSTCODE = "CSTCODE";
        public const string CSTNAME = "CSTNAME";
        public const string CRDCODE = "CRDCODE";
        public const string CRDNAME = "CRDNAME";
        public const string CDEPCODE = "CDEPCODE";
        public const string CDEPNAME = "CDEPNAME";
        public const string CIRDCODE = "CIRDCODE";
        public const string CORDCODE = "CORDNAME";
        public const string COWHCODE = "COWHCODE";
        public const string CIWHCODE = "CIWHCODE";
        public const string CVOUCHID = "CVOUCHID";
        public const string CCUSCODE = "CCUSCODE";
        /// <summary>
        /// 条码
        /// </summary>
        public const string BARCODE = "BARCODE";
        /// <summary>
        /// 来源单据号
        /// </summary>
        public const string CSOURCECODE = "CSOURCECODE";

        /// <summary>
        /// 批号
        /// </summary>
        public const string CBATCH = "CBATCH";
        /// <summary>
        /// 序列号
        /// </summary>
        public const string SNNO = "SNNO";
        /// <summary>
        /// 数量
        /// </summary>
        public const string IQUANTITY = "QTY";
        /// <summary>
        /// 件数
        /// </summary>
        public const string INUM = "INUM";
        /// <summary>
        /// 入库货位
        /// </summary>
        public const string CIPOSITION = "CIPOSCODE";
        /// <summary>
        /// 出库货位
        /// </summary>
        public const string COPOSITION = "COPOSCODE";
        /// <summary>
        /// 业务员
        /// </summary>
        public const string CPERSONCODE = "CPERSONCODE";
        public const string CIPERSONCODE = "CIPERSONCODE";
        public const string COPERSONCODE = "COPERSONCODE";
        /// <summary>
        /// 来源类型
        /// </summary>
        public const string CSOURCE = "CSOURCE";
        /// <summary>
        /// 入库部门
        /// </summary>
        public const string CIDEPCODE = "CIDEPCODE";
        /// <summary>
        /// 出库部门
        /// </summary>
        public const string CODEPCODE = "CODEPCODE";
        /// <summary>
        /// 开始日期
        /// </summary>
        public const string DSDATE = "DSDATE";
        /// <summary>
        /// 结束日期
        /// </summary>
        public const string DEDATE = "DEDATE";
        /// <summary>
        /// 日期
        /// </summary>
        public const string DDATE = "DDATE";

        public const string TRAYNO = "TRAYNO";
        public const string ITRAYNO = "ITRAYNO";
        public const string WEIGHT = "CDEFINE23";
        #endregion

        #region U8业务类型编码
        public const string CW_TYPE_U8 = "18";
        public const string TV_TYPE_U8 = "12";
        public const string SE_TYPE_U8 = "32";
        #endregion

        #region 列表显示映射
        public const string EDITMODE = "EDITMODE";
        public const string ROWSHINETABLE = "ROWSHINETABLE";
        public const string BOUTTABLE = "BOUTTABLE";
        public const string ROWFILTER = "ROWFILTER";
        public const string ROWSHINEVALUE = "ROWSHINEVALUE";
        public const string ROWSHINETEXT = "ROWSHINETEXT";
        public const string VALUEMEMBER = "VALUEMEMBER";
        public const string DISPLAYMEMBER = "DISPLAYMEMBER";
        public const string ROWMAPPINGVALUE = "ROWMAPPINGVALUE";
        public const string ROWMAPPINGTEXT = "ROWMAPPINGTEXT";
        public const string BDOCUMENT = "BDOCUMENT";
        public const string BEDIT = "BEDIT";
        public const string BNOTNULL = "BNOTNULL";
        public const string ROWTITLE = "ROWTITLE";
        public const string ORDERNO = "ORDERNO";
        public const string ORDERID = "ORDERID";
        #endregion

        #region 业务类型相关
        public const string CSOURCETABLE = "CSOURCETABLE";
        public const string CVOUCHCODEU8 = "CVOUCHCODEU8";
        public const string INOUTTYPE = "INOUTTYPE";
        #endregion

        #region WEBAPI相关
        /// <summary>
        /// 服务器地址节点
        /// </summary>
        public const string API_SERVERIP_NODE = "APISERVERIP";
        /// <summary>
        /// 服务名称节点
        /// </summary>
        public const string API_SERVICE_NODE = "APISERVICE";
        /// <summary>
        /// 默认ContentType
        /// </summary>
        public const string DEFALUT_CONTENTTYPE = "application/json";


        #endregion
    }
}
