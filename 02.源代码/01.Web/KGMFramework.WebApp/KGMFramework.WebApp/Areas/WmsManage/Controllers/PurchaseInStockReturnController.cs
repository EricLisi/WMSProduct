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
    public class PurchaseInStockReturnController : BusinessController<PI_ReturnHead, PI_ReturnHeadInfo>
    {
        public static string keyvalue = "";
        public ActionResult InstockForm()
        {
            //keyValueManages = keyValue;
            return View();
        }

        public ActionResult Index1(string keyValue)
        {
            keyvalue = keyValue;
            return View();
        }

        /// <summary>
        /// 入库单
        /// </summary>
        /// <returns></returns>
        public ActionResult AssetForm()
        {
            return View();
        }
        /// <summary>
        /// 获取待审核的登记单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPreVerify()
        {
            var dt = BLLFactory<AppCommon>.Instance.GetPreVerify(CurrentUser.F_OrganizeId);
            return Content(JsonAppHelper.ToJson(dt));

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public ActionResult submitFormMuti(PI_ReturnHeadInfo info, List<PI_ReturnBodyInfo> dInfo)
        {
            try
            {
                if (!string.IsNullOrEmpty(info.F_EnCode))
                {
                    //info = BLLFactory<PI_ReturnHead>.Instance.FindByID(info.F_Id);
                    info.F_LastModifyTime = DateTime.Now;
                    info.F_LastModifyUserId = CurrentUser.F_Account;
                }
                else
                {
                    info.F_CreatorTime = DateTime.Now;
                    info.F_CreatorUserId = CurrentUser.F_Account;
                    info.F_Id = Guid.NewGuid().ToString();
                }
                var result = BLLFactory<PI_ReturnHead>.Instance.Save(info, dInfo);

                return Success("操作成功", result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }


        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult VerifyList1(string F_VeriDate, string F_Verify, string orderId, List<PI_ReturnBodyInfo> dInfo)
        {
            try
            {
                F_VeriDate = DateTime.Now.ToShortDateString();
                F_Verify = CurrentUser.F_Account;
                string aduit = BLLFactory<PI_ReturnHead>.Instance.Audit(F_VeriDate, F_Verify, orderId, dInfo);
                if (aduit == "单据审核成功")
                {
                    return Success("单据审核成功");
                }
                else
                {
                    return Error(aduit);
                }
            }
            catch (Exception)
            {

                return Error("操作失败");
            }
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult NoVerifyList(string F_VeriDate, string F_Verify, string orderId)
        {
            string Massage = BLLFactory<PI_ReturnHead>.Instance.NoAudit(F_VeriDate, F_Verify, orderId);
            return Content(Massage);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        /// <returns></returns>
        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            BLLFactory<PI_ReturnHead>.Instance.DeleteAll(keyValue, bLogicDelete);
            return Success("删除成功");
        }
        /// <summary>
        /// 获取表体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFormJson1(string keyValue)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", keyValue, SqlOperator.Equal);
            List<PI_BodyInfo> list = BLLFactory<PI_Body>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            return Content(JsonAppHelper.ToJson(list));
        }


        /// <summary>
        /// 获取表体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFormJson2(string keyValue)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
            List<PI_ReturnBodyInfo> list = BLLFactory<PI_ReturnBody>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            return Content(JsonAppHelper.ToJson(list));
        }


        /// <summary>
        /// 出库退回单据数据源
        /// </summary>
        /// <returns></returns>
        public ActionResult GetJonForm()
        {
            DataTable dt = BLLFactory<PI_ReturnBody>.Instance.SelReturnStock();
            return Content(JsonAppHelper.ToJson(dt));
        }

        
        /// <summary>
        /// 获取单据信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="searchFiled"></param>
        /// <param name="list"></param>
        /// <param name="pagination"></param>
        /// <param name="sortFiled"></param>
        /// <returns></returns>
        public override ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sortFiled = " F_EnCode")
        {
            PagerInfo pager = GetPageInfo(pagination);//分页对象
            //获取condition
            SearchCondition condition = GetKeywordConditionObj(keyword, searchFiled);
            //加上默认条件,只可见单据所属机构与当前登录人一致的单据
            condition.AddCondition("F_Orgnization", CurrentUser.F_OrganizeId, SqlOperator.Equal);
            List<PI_ReturnHeadInfo> rlist = baseBLL.FindWithPager(GetConditionStr(condition), pager, sortFiled);//返回的列表信息
            return GetPagerContent(rlist, pager);
        }


        //public ActionResult GetCarGoByWhId(string WarehouseId)
        //{

        //}
    }
}