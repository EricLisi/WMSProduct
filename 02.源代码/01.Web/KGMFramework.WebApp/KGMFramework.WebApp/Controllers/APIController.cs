using KGMFramework.WebApp.DALSQL;
using KGMFramework.WebApp.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        Sys_User api = new Sys_User();

        #region BasicUtil

        [HttpGet]
        //读取单表信息
        public async Task<ActionResult> GetSingleTableInfo(string tableName, string valueMember, string displayMember, string filedName, string where, string dbName, bool bDistinct, string sortFiled)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetSingleTableInfo(tableName, valueMember, displayMember, filedName, where, dbName, bDistinct, sortFiled)));
            });
        }

        [HttpGet]
        //条码解析
        public async Task<ActionResult> BarcodeAnalyze(string OPERORDER, string BARCODE, string DBNAME)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.BarcodeAnalyze(OPERORDER, BARCODE, DBNAME)));
            });
        }

        [HttpGet]
        //获取业务模块
        public async Task<ActionResult> GetVouchModel(string condition)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetVouchModel(condition)));
            });
        }

        [HttpGet]
        //条码解析
        public async Task<ActionResult> GetFeedingTips(string orderNo)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetFeedingTips(orderNo)));
            });
        }

        #endregion 

        #region ScanUtil
        [HttpGet]
        //获取扫描列表信息
        public async Task<ActionResult> GetTempScanHead(string condition)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetTempScanHead(condition)));
            });
        }

        [HttpGet]
        //获取扫描列表信息
        public async Task<ActionResult> SaveTempScanHead(DataRow dr,string userid)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.SaveTempScanHead(dr, userid)));
            });
        }

        [HttpGet]
        //获取扫描列表信息
        public async Task<ActionResult> SaveTempScanBody(DataRow dr, bool bDel, string OPERORDER, string CVOUCHID, string CWHCODE, string userid, string baseName)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.SaveTempScanBody(dr, bDel, OPERORDER, CVOUCHID, CWHCODE, userid, baseName)));
            });
        }

        [HttpGet]
        //获取临时扫描记录
        public async Task<ActionResult> GetScanInfo(string operOrder)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetScanInfo(operOrder)));
            });
        }

        [HttpGet]
        //获取临时扫描记录
        public async Task<ActionResult> bFIFO(string BARCODE, string operOrder, string baseName, string CWHCODE)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.bFIFO(BARCODE, operOrder, baseName, CWHCODE)));
            });
        }

        [HttpGet]
        //获取临时扫描记录
        public async Task<ActionResult> GetScanCY(string operOrder)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetScanCY(operOrder)));
            });
        }


        [HttpGet]
        //获取临时扫描记录
        public async Task<ActionResult> ScanFinish(string operOrder, string baseName)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.ScanFinish(operOrder, baseName)));
            });
        }

        [HttpGet]
        //获取临时扫描记录
        public async Task<ActionResult> ClearTempScan(string operOrder)
        {
            return await Task.Run(() =>
            {
                api.ClearTempScan(operOrder);
                return Content("");
            });
        }

        #endregion

        #region SysUtil
        [HttpGet]
        //判断当前系统是否与数据库连通
        public async Task<ActionResult> ConnectDataBase(string DatabaseConnString)
        {
            return await Task.Run(() =>
            {
                api.ConnectDataBase(DatabaseConnString);
                return Content("");
            });
        }

        [HttpGet]
        //判断当前系统是否与数据库连通
        public async Task<ActionResult> ConnectDataBaseU8(string u8DatabaseConnString)
        {
            return await Task.Run(() =>
            {
                api.ConnectDataBaseU8(u8DatabaseConnString);
                return Content("");
            });
        }

        [HttpGet]
        //判断当前系统是否与数据库连通
        public async Task<ActionResult> ConnectSqlite(string Sqlitestr)
        {
            return await Task.Run(() =>
            {
                api.ConnectSqlite(Sqlitestr);
                return Content("");
            });
        }

        [HttpGet]
        //获取系统时间
        public async Task<ActionResult> GetServerTime()
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetServerTime()));
            });
        }

        [HttpGet]
        //获取登录用户权限
        public async Task<ActionResult> GetLoginUserModule(string userid, string ADMINNAME, string userpwd, string ADMINPWD)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetLoginUserModule(userid, ADMINNAME, userpwd, ADMINPWD)));
            });
        }

        [HttpGet]
        //获取当前终端版本
        public async Task<ActionResult> GetTermUIVerson()
        {
            return await Task.Run(() =>
            {
                return Content(api.GetTermUIVerson());
            });
        }

        [HttpGet]
        //判断是否存在更新
        public async Task<ActionResult> GetUIUpdate(string myVersion)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetUIUpdate(myVersion)));
            });
        }

        [HttpGet]
        //同步界面UI
        public async Task<ActionResult> SyncUI(DataSet ds, string myVersion, string connectionString)
        {
            return await Task.Run(() =>
            {
                api.SyncUI(ds, myVersion, connectionString);
                return Content("");
            });
        }

        [HttpGet]
        //获取grid列信息
        public async Task<ActionResult> GetGridColumn(string formName, string gridName, string orderType, string cVouchID)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetGridColumn(formName, gridName, orderType, cVouchID)));
            });
        }

        [HttpGet]
        //获取grid行信息
        public async Task<ActionResult> GetGridRow(string formName, string gridName, string orderType, string cVouchID)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetGridRow(formName, gridName, orderType, cVouchID)));
            });
        }

        [HttpGet]
        //获取登录用户权限
        public async Task<ActionResult> Login(string userID, string userPwd, string DatabaseConnString)
        {
            return await Task.Run(() =>
            {
                string errorInfo = string.Empty;
                return Content(JsonAppHelper.ToJson(api.Login(userID, userPwd, out errorInfo, DatabaseConnString)));
            });
        }


        #endregion

        #region TrayUtil

        [HttpGet]
        // 根据托盘号 获取托盘表头信息
        public async Task<ActionResult> GetTrayInfo(string trayNo, bool bGetHead, bool bGetBody, string U8DatabaseName)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.GetTrayInfo(trayNo, bGetHead, bGetBody, U8DatabaseName)));
            });
        }

        [HttpGet]
        // 保存托盘信息
        public async Task<ActionResult> SaveTrayHead(string trayNo)
        {
            return await Task.Run(() =>
            {
                api.SaveTrayHead(trayNo);
                return Content("");
            });
        }

        [HttpGet]
        // 保存托盘表体信息
        public async Task<ActionResult> SaveTrayBody(string trayNo, string barcode, string qty, string iNum, bool bInTray, DataRow dr, string BarcodeDatabaseName, string BarcodeDatabaseConnString)
        {
            return await Task.Run(() =>
            {
                return Content(JsonAppHelper.ToJson(api.SaveTrayBody(trayNo, barcode, qty, iNum, bInTray, dr, BarcodeDatabaseName, BarcodeDatabaseConnString)));
            });
        }

        [HttpGet]
        // 完成
        public async Task<ActionResult> TrayFinish(string trayNo)
        {
            return await Task.Run(() =>
            {
                api.TrayFinish(trayNo);
                return Content("");
            });
        }

        [HttpGet]
        // 完成
        public async Task<ActionResult> TrayClear(string trayNo)
        {
            return await Task.Run(() =>
            {
                api.TrayClear(trayNo);
                return Content("");
            });
        }


        #endregion
    }
}