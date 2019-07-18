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


            if (string.IsNullOrEmpty(fileName))
            {
                return Content("未能获取到打印格式信息!");
            }
            DataTable dt = new DataTable();

            if (sourceName == "goods")
            {
                dt = BLLFactory<Mst_Goods>.Instance.GetPrint(sourceData);//
            }
            if (sourceName == "printInStock")
            {
                dt = BLLFactory<PI_Head>.Instance.GetPrint(sourceData);
            }
            if (sourceName == "printOutstock")
            {
                dt = BLLFactory<SO_Head>.Instance.GetPrint(sourceData);
            }

            if (sourceName == "PrintMask")
            {
                //将object类强转list集合
                List<SO_StockMakeBodyInfo> list = Session["MaskList"] as List<SO_StockMakeBodyInfo>;
                //实例化dataTable
                dt = new DataTable();
                //给datatable添加列
                dt.Columns.Add("F_GoodsName");
                dt.Columns.Add("F_SellingPrice");
                dt.Columns.Add("F_RealNumber");
                dt.Columns.Add("F_Unit");
                dt.Columns.Add("F_CargoPositionName");
                dt.Columns.Add("F_WarehouseName");
                //添加数据
                foreach (SO_StockMakeBodyInfo item in list)
                {
                    DataRow dr =dt.NewRow();
                    dr["F_GoodsName"] = item.F_GoodsName;
                    dr["F_SellingPrice"] = item.F_SellingPrice;
                    dr["F_RealNumber"] = item.F_RealNumber;
                    dr["F_Unit"] = item.F_Unit;
                    dr["F_RealNumber"] = item.F_RealNumber;
                    dr["F_CargoPositionName"] = item.F_CargoPositionName;
                    dr["F_WarehouseName"] = item.F_WarehouseName;
                    dt.Rows.Add(dr);
                }

  
            }

            PrintModel model = new PrintModel();
            model.fileName = fileName;
            model.sourceName = "Source";
            model.sourceData = dt;

            // 创建报表对象
            Stimulsoft.Report.StiReport report1 = new Stimulsoft.Report.StiReport();
            //读取文件
            report1.Load(Server.MapPath(string.Format("~/Content/reports/{0}.mrt", model.fileName)));
            //截止读取
            report1.Compile();
            if (!string.IsNullOrEmpty(model.sourceName) && model.sourceData != null)
            {
                //注册数据源P
                report1.RegData(model.sourceName, model.sourceData);
            }

            //返回报表
            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(report1);
        }

        //打印盘点单
        public virtual ActionResult PrintMask(List<SO_StockMakeBodyInfo> MaskkList)
        {
            var i = 1;
            return Content("");
        }

        public ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult();
        }

    }
}