using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KGM.Pager.Entity;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Controllers;
using KGMFramework.WebApp.Library;
using System.Data;
using KGMFramework.WebApp.Models;
using Newtonsoft.Json;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class ReturnedStockController : BusinessController<SO_ReturnedStockHead, SO_ReturnedStockHeadInfo>
    {

  
        public ActionResult OutStockForm()
        {
            return View();
        }
        public ActionResult Index1() {
            return View();
        }

        public ActionResult OutStockList(string KeyValue) {
 
            return View();
        }

  
        /// <summary>
        /// 获取出库信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFromList(string keyValue)
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_Hid", keyValue, SqlOperator.Equal);
            List<SO_BodyInfo> list = BLLFactory<SO_Body>.Instance.Find(GetConditionStr(search));
            SO_HeadInfo head = BLLFactory<SO_Head>.Instance.FindByID(keyValue);
            ReturendStockModel model = new ReturendStockModel();
            model.HeadInfo = head;
            model.BodyList = list;
            return Content(JsonAppHelper.ToJson(model));
        }

        /// <summary>
        /// 单据保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public ActionResult SubmitFormMuti(SO_ReturnedStockHeadInfo info, List<SO_ReturnedStockBodyInfo> dInfo)
        {
            if (!string.IsNullOrEmpty(info.F_EnCode))
            {
                string desc = info.F_Description;
                info = BLLFactory<SO_ReturnedStockHead>.Instance.FindByID(info.F_Id);
                info.F_LastModifyTime = DateTime.Now;
                info.F_Description = desc;
                info.F_LastModifyUserId = CurrentUser.F_Account;
            }
            else
            {
                info.F_CreatorTime = DateTime.Now;
                info.F_CreatorUserId = CurrentUser.F_Account;
                info.F_Id = Guid.NewGuid().ToString();
            }


            var result = BLLFactory<SO_ReturnedStockHead>.Instance.Save(info, dInfo);
            if (result!=null)
            {
                return Success("操作成功",result);
            }
            else
            {
                return Error("操作失败");
            }

        }
        /// <summary>
        /// 查询表体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFormJson1(string keyValue)
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_Hid", keyValue, SqlOperator.Equal);
            List<SO_ReturnedStockBodyInfo> list = BLLFactory<SO_ReturnedStockBody>.Instance.Find(GetConditionStr(search));
            return Content(JsonAppHelper.ToJson(list));
        }

        /// <summary>
        /// 查询表体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public override ActionResult GetFormJson(string keyValue)
        {
            SO_ReturnedStockHeadInfo list = BLLFactory<SO_ReturnedStockHead>.Instance.FindByID(keyValue);
            return Content(JsonAppHelper.ToJson(list));
        }

        /// <summary>
        /// 审核单据并退回产品
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>

        public ActionResult VerifyList1(string orderNo, string orderId)
        {

            string Mess = BLLFactory<SO_ReturnedStockHead>.Instance.VerifyReturnGoods(orderId, orderNo);

            if (Mess == "操作成功")
            {
                return Success("操作成功");
            }
            else
            {
                return Error(Mess);
            }


        }

   

        public ActionResult GetFromJson(string keyValue) {
            SO_HeadInfo info = BLLFactory<SO_Head>.Instance.FindByID(keyValue);
            return Content(JsonAppHelper.ToJson(info));
        
        }

        public ActionResult GetGridJsonList()
        {
            List<SO_HeadInfo> headInfo = BLLFactory<SO_Head>.Instance.GetAll();
            List<SO_ReturnedStockHeadInfo> StockInfo = BLLFactory<SO_ReturnedStockHead>.Instance.GetAll();
            List<SO_HeadInfo> list = new List<SO_HeadInfo>();
            foreach (SO_HeadInfo item in headInfo)
            {
                SO_ReturnedStockHeadInfo info = StockInfo.Find(u => u.F_EnCode == item.F_EnCode);
                if (info == null)
                {
                    list.Add(item);
                }
            }
            return Content(JsonAppHelper.ToJson(list));
        }
    }
}