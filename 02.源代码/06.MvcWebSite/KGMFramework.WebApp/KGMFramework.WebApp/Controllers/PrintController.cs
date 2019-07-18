using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Controllers
{
    public class PrintController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public void GetData()
        {

        }

        public virtual ActionResult GetReportSnapshot(string fileName, string sourceName, string sourceData)
        { 
            PrintModel model = new PrintModel();
            model.fileName = fileName;
            model.sourceName = "Source";
            model.sourceData = null;

            if (fileName=="packListB")
            {
                model.sourceData = BLLFactory<PackList_Head>.Instance.GetPrint(sourceData);
                model.sourceName = sourceName;
                model.fileName = fileName;
            }

            // 创建报表对象
            Stimulsoft.Report.StiReport report = new Stimulsoft.Report.StiReport();
            //读取文件
            report.Load(Server.MapPath(string.Format("~/Content/reports/{0}.mrt", model.fileName)));
            //截止读取
            report.Compile();
            if (!string.IsNullOrEmpty(model.sourceName) && model.sourceData != null)
            {
                //注册数据源P
                report.RegData(model.sourceName, model.sourceData);
            }

            //返回报表
            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(report);
        }
 

        public ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult();
        }

    }
}