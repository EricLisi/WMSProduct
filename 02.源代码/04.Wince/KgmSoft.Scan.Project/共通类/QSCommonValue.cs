using System;
using System.Data;
/*
 * 全局变量类
 */
namespace KgmSoft.Scan.Project
{
    public class QSCommonValue
    {
        /// <summary>
        /// com口
        /// </summary>
        public static string COM;
        /// <summary>
        /// 继续操作表
        /// </summary>
        public static DataTable ContinueTable;
        /// <summary>
        /// api的路径
        /// </summary>
        public static Uri WebAPIUri;
        /// <summary>
        /// token
        /// </summary>
        public static string token;
        /// <summary>
        /// 当前登录人
        /// </summary>
        public static SYS_USERSInfo CurrentUser;
        /// <summary>
        /// 操作模块
        /// </summary>
        public static string operModule = string.Empty;
        /// <summary>
        /// 操作模块
        /// </summary>
        public static string operModuleName = string.Empty;
        /// <summary>
        /// 单据号
        /// </summary>
        public static SO_HeadInfo head;
        /// <summary>
        /// 单据明细
        /// </summary>
        public static DataTable operData;

        public static DataTable Body;
        public static DataTable ListHead;

        /// <summary>
        /// 扫描明细
        /// </summary>
        public static DataTable ScanBody;
    }
}
