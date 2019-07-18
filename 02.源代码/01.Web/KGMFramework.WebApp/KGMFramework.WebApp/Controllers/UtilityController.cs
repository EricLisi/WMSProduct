using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Controllers
{ 
    /// </summary>
    public class UtilityController : Controller
    {

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UploadifyForm()
        {
            return View();
        }


        [HttpGet]
        public ActionResult UploadifyForm1()
        {
            return View();
        }
        #endregion

        #region 导出Excel
        /// <summary>
        /// 请选择要导出的字段页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExportForm()
        {
            return View();
        }
        #endregion

        #region grid查找
        /// <summary>
        /// 表格查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GridSearch()
        {
            return View();
        }
        #endregion

        #region 退货列表
        public ActionResult ReturnItemSelect()
        {
            return View();
        }
        #endregion
    }
}
