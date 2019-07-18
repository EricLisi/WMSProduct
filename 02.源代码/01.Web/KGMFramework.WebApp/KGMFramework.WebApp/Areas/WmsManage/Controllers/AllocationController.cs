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
    public class AllocationController : BusinessController<Allocation_Head, Allocation_HeadInfo>
    {

        public ActionResult InstockForm() {
            //keyValueManages = keyValue;
            return View();
        }

        /// <summary>
        /// 调拨单
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
        public ActionResult submitFormMuti(Allocation_HeadInfo info, List<Allocation_BodyInfo> dInfo)
        {
            try
            {
                if (!string.IsNullOrEmpty(info.F_EnCode))
                {
                    info = BLLFactory<Allocation_Head>.Instance.FindByID(info.F_Id);
                    info.F_LastModifyTime = DateTime.Now;
                    info.F_LastModifyUserId = CurrentUser.F_Account;
                }
                else
                {
                    info.F_CreatorTime = DateTime.Now;
                    info.F_CreatorUserId = CurrentUser.F_Account;
                    info.F_Id = Guid.NewGuid().ToString();
                }
                var result = BLLFactory<Allocation_Head>.Instance.Save(info, dInfo);

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
        public ActionResult VerifyList1(string F_AccountDate, string F_Verify, string orderId, List<Allocation_BodyInfo> dInfo)
        {
            try
            {
                F_AccountDate = DateTime.Now.ToShortDateString();
                F_Verify = CurrentUser.F_Account;
                string aduit = BLLFactory<Allocation_Head>.Instance.Audit(F_AccountDate, F_Verify, orderId,dInfo);
                if (aduit=="单据审核成功")
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
            string Massage = BLLFactory<Allocation_Head>.Instance.NoAudit(F_VeriDate, F_Verify, orderId);
            return Content(Massage);
        }


        /// <summary>
        /// 出库操作
        /// </summary>
        /// <param name="F_Batch">批次</param>
        /// <param name="dInfo">调拨单的表体</param>
        /// <returns></returns>
        public ActionResult outStock(string F_Batch, string selectId)
        {
            try
            {
                string result = BLLFactory<Allocation_Body>.Instance.OutStock(F_Batch, selectId);
                if (result == "操作成功")
                {
                    return Success("操作成功");
                }
                else
                {
                    return Error(result);
                }
            }
            catch (Exception)
            {
                return Error("操作失败");
            }
        } 


        /// <summary>
        /// 入库操作
        /// </summary>
        /// <param name="F_Batch">批次</param>
        /// <param name="dInfo">调拨单的表体</param>
        /// <returns></returns>
        public ActionResult inStock(string F_Batch, string selectId)
        {
            try
            {
                string result = BLLFactory<Allocation_Body>.Instance.InStock(F_Batch, selectId);
                if (result=="操作成功")
                {
                    return Success("操作成功");
                }
                else
                {
                    return Error(result);
                }
            }
            catch (Exception)
            {
                return Error("操作失败");
            }
        } 

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        /// <returns></returns>
        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            BLLFactory<Allocation_Head>.Instance.DeleteAll(keyValue, bLogicDelete);
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
            condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
            List<Allocation_BodyInfo> list = BLLFactory<Allocation_Body>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            return Content(JsonAppHelper.ToJson(list));
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
            List<Allocation_HeadInfo> rlist = baseBLL.FindWithPager(GetConditionStr(condition), pager, sortFiled);//返回的列表信息
            return GetPagerContent(rlist, pager);
        }

    }
}