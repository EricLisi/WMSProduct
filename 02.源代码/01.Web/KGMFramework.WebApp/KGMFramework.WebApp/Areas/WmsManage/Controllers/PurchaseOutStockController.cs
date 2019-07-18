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
using System.Collections;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{

    public class PurchaseOutStockController : BusinessController<SO_Head, SO_HeadInfo>
    {
        /// <summary>
        /// 存储批次号
        /// </summary>
        public static string keyValueManages = "";


        public ActionResult AssetForm()
        {
            return View();
        }


        /// <summary>
        /// 获取批次号以及加载页面
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult OutStockForm(string keyValue)
        {
            keyValueManages = keyValue;
            return View();
        }


        /// <summary>
        /// 获取单据审核信息
        /// </summary>
        /// <param name="keyValue">产品编号</param>
        /// <returns></returns>
        public ActionResult StatusManges(string keyValue)
        {
            int BoolManges = BLLFactory<SO_Head>.Instance.FindByID(keyValue).F_Status;
            return Content(BoolManges.ToString());
        }


            
        public ActionResult Status(string keyValue)
        {
            int State = BLLFactory<SO_Head>.Instance.FindByID(keyValue).F_Status;
            return Content(State.ToString());

        }

        /// <summary>
        /// 审核单据并出库
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>

        public ActionResult VerifyList1(string orderUser, string orderId)
        {
            string Mess = BLLFactory<SO_Head>.Instance.Audit(orderId, orderUser);
            if (Mess == "单据审核成功")
            {
                return Success(Mess);
            }
            else
            {
                return Error(Mess);
            }


        }



        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult NoVerifyList(string orderId)
        {
            string Massage = BLLFactory<SO_Head>.Instance.NoAudit(DateTime.Now.ToShortDateString(), CurrentUser.F_Account, orderId);
            if (Massage == "弃审成功")
            {
                return Success(Massage);
            }
            else
            {
                return Error(Massage);
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
            BLLFactory<SO_Head>.Instance.DeleteAll(keyValue, bLogicDelete);
            return Success("删除成功");
        }
        /// <summary>
        /// 获取表头
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public override ActionResult GetFormJson(string keyValue)
        { 
            SO_HeadInfo list = BLLFactory<SO_Head>.Instance.FindByID(keyValue);
            return Content(JsonAppHelper.ToJson(list));
        }
         /// <summary>
        /// 获取表体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public  ActionResult GetFormJson1(string keyValue)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_HId", keyValue, SqlOperator.Equal);
            List<SO_BodyInfo> list = BLLFactory<SO_Body>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            return Content(JsonAppHelper.ToJson(list));
        }
        /// <summary>
        /// 获取审核信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFormJson2()
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", keyValueManages, SqlOperator.Equal);
            List<SO_BodyInfo> info = BLLFactory<SO_Body>.Instance.Find(GetConditionStr(condition));
            SO_BodyInfo Info = BLLFactory<SO_Body>.Instance.FindByID(keyValueManages);
            return Content(JsonAppHelper.ToJson(Info));
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
        //public override ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sortFiled = " F_EnCode")
        //{
        //    PagerInfo pager = GetPageInfo(pagination);//分页对象
        //    //获取condition
        //    SearchCondition condition = GetKeywordConditionObj(keyword, searchFiled);
        //    //加上默认条件,只可见单据所属机构与当前登录人一致的单据
        //    condition.AddCondition("F_Orgnization", CurrentUser.F_OrganizeId, SqlOperator.Equal);
        //    List<SO_HeadInfo> rlist = baseBLL.FindWithPager(GetConditionStr(condition), pager, sortFiled);//返回的列表信息
        //    return GetPagerContent(rlist, pager);
        //}


        public override ActionResult GetTreeSelectJson(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", "0", SqlOperator.NotEqual);
            var list = BLLFactory<Mst_Goods>.Instance.Find(GetConditionStr(condition));
            return Content(GetTreeSelectJsonStr(list));
        }

        public string GetTreeSelectJsonStr(List<Mst_GoodsInfo> data)
        {
            var treeList = new List<TreeSelectModel>();
            foreach (Mst_GoodsInfo item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = "0";
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }
        /// <summary>
        /// 根据下拉框获取信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GoodsById(string keyValue)
        {
            Mst_GoodsInfo goodsInfo = BLLFactory<Mst_Goods>.Instance.FindByID(keyValue);
            return Content(JsonAppHelper.ToJson(goodsInfo));
        }

        /// <summary>
        /// 获取仓位信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetCarGoFrom(string keyValue)
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_WarehouseId", keyValue, SqlOperator.Equal);
            search.AddCondition("F_EnabledMark", "True", SqlOperator.Equal);
            List<Mst_CargoPositionInfo> info = BLLFactory<Mst_CargoPosition>.Instance.Find(GetConditionStr(search));
            List<object> list = new List<object>();
            foreach (Mst_CargoPositionInfo item in info)
            {
                list.Add(new { id = item.F_Id, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));
        }

 
        /// <summary>
        /// 查询产品批次
        /// </summary>
        /// <param name="GoodsId">产品id</param>
        /// <param name="WarId">仓库Id</param>
        /// <param name="CarGoid">货位id</param>
        /// <returns></returns>
        public ActionResult GetBatch(string GoodsId,  string CarGoid)
        {
            SearchCondition conditon = new SearchCondition();
            conditon.AddCondition("F_CargoPositionId", CarGoid, SqlOperator.Equal);
            conditon.AddCondition("F_GoodsId", GoodsId, SqlOperator.Equal);
            List<Sys_StockInfo> info = BLLFactory<Sys_Stock>.Instance.Find(GetConditionStr(conditon));
            HashSet<string> list = new HashSet<string>();
            foreach (Sys_StockInfo item in info)
            {
                list.Add(item.F_Batch);
            }

            return Content(JsonAppHelper.ToJson(list));
        }
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWarSelectJson()
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_EnabledMark", "True", SqlOperator.Equal);
            List<Mst_WarehouseInfo> info = BLLFactory<Mst_Warehouse>.Instance.Find(GetConditionStr(search));
            List<object> list = new List<object>();
            foreach (Mst_WarehouseInfo item in info)
            {
                list.Add(new { id = item.F_Id, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));

        }

        /// <summary>
        /// 获取货位信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCarSelectJson()
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_EnabledMark", "True", SqlOperator.Equal);
            List<Mst_CargoPositionInfo> info = BLLFactory<Mst_CargoPosition>.Instance.Find(GetConditionStr(search));
            List<object> list = new List<object>();
            foreach (Mst_CargoPositionInfo item in info)
            {
                list.Add(new { id = item.F_Id, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));

        }


        /// <summary>
        /// 获取批次信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBatchSelectJson()
        {
            List<Sys_StockInfo> info = BLLFactory<Sys_Stock>.Instance.GetAll();
            HashSet<string> list = new HashSet<string>();
            foreach (Sys_StockInfo item in info)
            {
             list.Add(item.F_Batch);
            }

            return Content(JsonAppHelper.ToJson(list));

        }


        /// <summary>
        /// 获取产品数量
        /// </summary>
        /// <param name="Batch">批次</param>
        /// <param name="WarId">仓库ID</param>
        /// <param name="CarId">货位Id</param>
        /// <param name="GoodsId">产品Id</param>
        /// <returns></returns>
        public ActionResult GetNum(string Batch,string WarId,string CarId,string GoodsId) {
           //判断是否有值，没有直接返回0
            if (Batch==null || WarId==null || CarId==null)
            {
                return Content("0");
            }
            //条件查询
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_WarehouseId", WarId, SqlOperator.Equal);
            search.AddCondition("F_CargoPositionId", CarId, SqlOperator.Equal);
            search.AddCondition("F_GoodsId", GoodsId, SqlOperator.Equal);
            search.AddCondition("F_Batch", Batch, SqlOperator.Equal);
            List<Sys_StockInfo> stockInfo = BLLFactory<Sys_Stock>.Instance.Find(GetConditionStr(search));
            if (stockInfo.Count==0)
            {
                return Content("0");
            }
            else
            {
                return Content(stockInfo[0].F_Number+"");
            }

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public ActionResult submitFormMuti(SO_HeadInfo info, List<SO_BodyInfo> dInfo)
        {
            try
            {
                if (!string.IsNullOrEmpty(info.F_EnCode))
                {
                    //info = BLLFactory<SO_Head>.Instance.FindByID(info.F_Id);
                    info.F_LastModifyTime = DateTime.Now;
                    info.F_LastModifyUserId = CurrentUser.F_Account;
                }
                else
                {
                    info.F_CreatorTime = DateTime.Now;
                    info.F_CreatorUserId = CurrentUser.F_Account;
                    info.F_Id = Guid.NewGuid().ToString();
                }
                var result = BLLFactory<SO_Head>.Instance.Save(info, dInfo);

                return Success("操作成功", result);
            }
            catch (Exception )
            {
                return Error("操作失败");
            }
        }
    }
}