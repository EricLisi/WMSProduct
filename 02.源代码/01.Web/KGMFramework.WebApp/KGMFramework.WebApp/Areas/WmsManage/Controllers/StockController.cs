using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGM.Framework.Commons;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Models;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using KGMFramework.WebApp.Controllers;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class StockController : BusinessController<V_STOCK_SHOW, V_STOCK_SHOWINFO>
    {
        public ActionResult transferSaves(Sys_TransferInfo info, string F_Id)
        {
            info.F_Id = System.Guid.NewGuid().ToString();
            info.F_StockId = F_Id;
            info.F_CreatorUserId = CurrentUser.F_Account;
            string Message = BLLFactory<Sys_Transfer>.Instance.SaveTra(info);
            return Content(Message);

        }
        //protected override ActionResult GetPagerContent(List<V_STOCK_SHOWINFO> list, PagerInfo pager)
        //{
        //    if (list!=null && list.Count>0)
        //    {
        //        foreach (var item in list)
        //        {
        //            var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindByID(item.F_WarehouseId);
        //            var position = BLLFactory<Mst_CargoPosition>.Instance.FindByID(item.F_CargoPositionId);
        //            var good = BLLFactory<Mst_Goods>.Instance.FindByID(item.F_GoodsId);
        //            item.F_WarehouseName = warehouse == null ? "" : warehouse.F_FullName;
        //            item.F_CargoPositionName = position == null ? "" : position.F_FullName;
        //            item.F_GoodsName = good == null ? "" : good.F_FullName;
        //            item.F_Unit= good == null ? "" : good.F_Unit;
        //            item.F_SpecifModel = good == null ? "" : good.F_SpecifModel;
        //            item.F_SellingPrice= good == null ? "" : good.F_SellingPrice;
        //        }
        //    }

        //    return base.GetPagerContent(list, pager);
        //}
    }
}