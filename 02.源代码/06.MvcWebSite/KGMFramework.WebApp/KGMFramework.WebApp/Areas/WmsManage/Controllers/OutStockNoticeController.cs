using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGM.Pager.Entity;
using KGMFramework.WebApp.Areas.WmsManage.Model;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Controllers;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using Stimulsoft.Base.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    /// <summary>
    /// 入库通知单控制器
    /// </summary>
    public class OutStockNoticeController : BusinessController<OutStockNotice_Head, OutStockNotice_HeadInfo>
    {
        /// <summary>
        /// 入库通知单查询
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="pagination">分页信息</param>
        /// <param name="sortFiled">排序字段</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListGridJsonPagination(string filterStr, Pagination pagination, string sidx = " F_EnCode ", string sord = "desc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_EnCode ";
            }
            PagerInfo pager = GetPageInfo(pagination);
            List<AdvSearchEntity> advSearchList = new List<AdvSearchEntity>();
            if (string.IsNullOrEmpty(filterStr))
            {

                advSearchList.Add(new AdvSearchEntity
                {
                    F_condition = "And",
                    F_fvalue = DateTime.Now.ToString("yyyy-MM") + "-01",
                    F_searchFiled = "F_Date",
                    F_type = "5"
                });

                advSearchList.Add(new AdvSearchEntity
                {
                    F_condition = "And",
                    F_fvalue = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                    F_searchFiled = "F_Date",
                    F_type = "6"
                });

            }
            else
            {

                OutStockFilter filter = JsonAppHelper.ToObject<OutStockFilter>(filterStr);

                if (!string.IsNullOrEmpty(filter.F_EnCode))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnCode,
                        F_searchFiled = "F_EnCode",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Customer))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Customer,
                        F_searchFiled = "F_CustomerId",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_Status))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_Status,
                        F_searchFiled = "F_Status",
                        F_type = "0"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_SDate))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = Convert.ToDateTime(filter.F_SDate).ToString("yyyy-MM-dd"),
                        F_searchFiled = "F_Date",
                        F_type = "5"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_EDate))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = Convert.ToDateTime(filter.F_EDate).AddDays(1).ToString("yyyy-MM-dd"),
                        F_searchFiled = "F_Date",
                        F_type = "6"
                    });
                }
            }

            List<V_OutStockNoticeHeadInfo> list = BLLFactory<V_OutStockNoticeHead>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));
            return GetPagerContent<V_OutStockNoticeHeadInfo>(list, pager);
        }



        /// <summary>
        /// 获取入库单表体行信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListGridJson(string keyValue, string sidx = " F_EnCode ", string sord = "desc")
        {
            //此处需要新建一张表体视图,暂时使用表代替
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_HeadId", keyValue, SqlOperator.Equal);
            List<OutStockNotice_BodyInfo> bodylist = BLLFactory<OutStockNotice_Body>.Instance.Find(GetConditionStr(condition));
            for (int i = 0; i < bodylist.Count; i++)
            {
                Mst_ProductInfo p = BLLFactory<Mst_Product>.Instance.FindByID(bodylist[i].F_ProductId);
                bodylist[i].F_ProductCode = p.F_EnCode;
                bodylist[i].F_ProductName = p.F_FullName;
                bodylist[i].F_ProductStandard = p.F_Standard;
            }
            return Content(JsonAppHelper.ToJson(bodylist));
        }


        /// <summary>
        /// 保存单据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Binfo"></param>
        /// <returns></returns>
        public ActionResult SubmitForm1(OutStockNotice_HeadInfo info, List<OutStockNotice_BodyInfo> Binfo)
        {
            try
            {
                if (!string.IsNullOrEmpty(info.F_EnCode))
                {
                    info.F_LastModifyTime = DateTime.Now;
                    info.F_LastModifyUserId = CurrentUser.F_Account;
                }
                else
                {
                    info.F_CreatorTime = DateTime.Now;
                    info.F_CreatorUserId = CurrentUser.F_Account;
                    info.F_Maker = CurrentUser.F_Account;
                    info.F_Id = Guid.NewGuid().ToString();
                }
                var result = BLLFactory<OutStockNotice_Head>.Instance.Save(info, Binfo);

                return Success("保存单据成功", result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }


        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_HeadId", keyValue, SqlOperator.Equal);
            BLLFactory<OutStockNotice_Body>.Instance.DeleteByCondition(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            BLLFactory<OutStockNotice_Head>.Instance.Delete(keyValue);
            return Success("删除成功");
        }




        public ActionResult Verify(string KeyValue)
        {
            try
            {
                OutStockNotice_HeadInfo info = BLLFactory<OutStockNotice_Head>.Instance.FindByID(KeyValue);
                if (info.F_Status == 1)
                {
                    return Error("单据已审核");
                }
                else if (info.F_Status == 2)
                {
                    return Error("单据已关闭");
                }
                else if (info.F_Status == 3)
                {
                    return Error("单据已弃审");
                }
                info.F_Status = 1;
                info.F_Verifier = CurrentUser.F_Account;
                info.F_Veridate = DateTime.Now;
                BLLFactory<OutStockNotice_Head>.Instance.Update(info, info.F_Id);

                return Success("审核成功");
            }
            catch (Exception)
            {

                return Error("操作失败");
            }
        }

        public ActionResult DenyVerify(string KeyValue)
        {
            try
            {
                OutStockNotice_HeadInfo info = BLLFactory<OutStockNotice_Head>.Instance.FindByID(KeyValue);
                if (info.F_Status != 1)
                {
                    return Error("单据未审核");
                }
                info.F_Status = 3;
                BLLFactory<OutStockNotice_Head>.Instance.Update(info, info.F_Id);

                return Success("弃审成功");
            }
            catch (Exception)
            {

                return Error("操作失败");
            }
        }
    }
}