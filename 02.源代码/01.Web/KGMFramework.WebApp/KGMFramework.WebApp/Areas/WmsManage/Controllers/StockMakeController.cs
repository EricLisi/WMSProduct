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
using KGMFramework.WebApp.Models;
using Stimulsoft.Base.Json;
using System.Collections;
using System.Data;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class StockMakeController : BusinessController<SO_StockMakeBody, SO_StockMakeBodyInfo>
    {
        public static string selectId = "";
        // GET: AssetManage/AssetInformation
        /// <summary>
        /// 获取grid显示信息 分页
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="pagination">分页默认是null</param>
        /// <param name="sortFiled">排序字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public override ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sortFiled = " F_SortCode ")
        {
            List<SO_StockMakeHeadInfo> lista;
            PagerInfo pager = GetPageInfo(pagination);
            lista = BLLFactory<SO_StockMakeHead>.Instance.GetAll();
            return GetPagerContent(lista, pager);
        }
        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="pager">分页对象</param>
        /// <returns></returns>
        protected ActionResult GetPagerContent(List<SO_StockMakeHeadInfo> list, PagerInfo pager)
        {
            int total = pager.RecordCount / pager.PageSize == 0 ? 1 : (pager.RecordCount % pager.PageSize == 0 ? pager.RecordCount / pager.PageSize : pager.RecordCount / pager.PageSize + 1);
            var data = new
            {
                rows = list,
                total = total,
                page = pager.CurrenetPageIndex,
                records = pager.RecordCount
            };
            return Content(JsonAppHelper.ToJson(data));
        }

        public ActionResult AssetForm(string keyValue)
        {
            selectId = keyValue;
            return View();
        }
        public ActionResult DaoRu()
        {
            return View();
        }
        public ActionResult AddPrintData(List<SO_StockMakeBodyInfo> MaskList)
        {
            Session["MaskList"] = MaskList;

            return Content("");
        }

        /// <summary>
        /// 获取窗体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public override ActionResult GetFormJson(string keyValue)
        {
            SO_StockMakeHeadInfo info = BLLFactory<SO_StockMakeHead>.Instance.FindByID(keyValue);
            return Content(JsonAppHelper.ToJson(info));
        }

        /// <summary>
        /// 文件导入
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        protected override ResultModel DoAfterUploadFile(string fullFileName)
        {
            ResultModel result = new ResultModel();
            result.message = "";
            //读取文件 excel
            DataTable dt = KGMFramework.WebApp.Library.ExcelHelper.ExcelImport(fullFileName, 0);
            if (dt == null || dt.Rows.Count == 0)
            {
                result.bSuccess = false;
                result.message = "获取文件信息失败";
                return result;
            }

            SearchCondition search = new SearchCondition();
            search.AddCondition("F_Hid", selectId, SqlOperator.Equal);
            List<SO_StockMakeBodyInfo> list = BLLFactory<SO_StockMakeBody>.Instance.Find(GetConditionStr(search));

            string Mess = BLLFactory<SO_StockMakeBody>.Instance.UpMaskNum(dt, list);
            if (Mess == "操作失败")
            {
                result.bSuccess = false;
                result.message = "导入失败";
                return result;
            }

            result.bSuccess = true;
            result.message = "导入成功";


            return result;
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public ActionResult submitFormMuti(SO_StockMakeHeadInfo info, List<SO_StockMakeBodyInfo> dInfo, string type)
        {
            if (!string.IsNullOrEmpty(info.F_EnCode))
            {
                info = BLLFactory<SO_StockMakeHead>.Instance.FindByID(info.F_Id);
                info.F_LastModifyTime = DateTime.Now;
                info.F_LastModifyUserId = CurrentUser.F_RealName;
            }
            else
            {
                info.F_CreatorTime = DateTime.Now;
                info.F_CreatorUserId = CurrentUser.F_RealName;
                info.F_Id = Guid.NewGuid().ToString();
            }
            var result = BLLFactory<SO_StockMakeHead>.Instance.Save(info, dInfo);
            if (result != null)
            {
                return Success("操作成功", result);
            }
            else
            {
                return Error("操作失败");
            }

        }



        /// <summary>
        /// 获取表体信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFormJson1(string keyValue)
        {
            DataTable dt = BLLFactory<SO_StockMakeHead>.Instance.GetFormInfo(keyValue);
            return Content(JsonAppHelper.ToJson(dt));
        }
        /// <summary>
        /// 查询库存数量
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNum()
        {
            SO_StockMakeBodyInfo bodyInfo = BLLFactory<SO_StockMakeBody>.Instance.FindByID(selectId);
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_GoodsId", bodyInfo.F_GoodsId, SqlOperator.Equal);
            condition.AddCondition("F_WarehouseId", bodyInfo.F_WarehouseId, SqlOperator.Equal);
            condition.AddCondition("F_CargoPositionId", bodyInfo.F_CargoPositionId, SqlOperator.Equal);
            Sys_StockInfo Info = BLLFactory<Sys_Stock>.Instance.Find(GetConditionStr(condition))[0];
            return Content(JsonAppHelper.ToJson(Info));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        /// <returns></returns>
        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            BLLFactory<SO_StockMakeHead>.Instance.DeleteAll(keyValue, bLogicDelete);
            return Success("删除成功");
        }


        [HttpPost]
        public ActionResult Generate(string cDepCode, List<string> range)
        {
            //将对应的资产信息读取出来
            SearchCondition condition = new SearchCondition();

            condition.AddCondition("F_WarehouseId", cDepCode, SqlOperator.Equal, true, "a");


            foreach (string str in range)
            {
                if (string.IsNullOrEmpty(str)) continue;
                condition.AddCondition("F_CargoPositionId", str, SqlOperator.Equal, true, "b");
            }
            var list = BLLFactory<Sys_Stock>.Instance.Find(GetConditionStr(condition));
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindByID(item.F_WarehouseId);
                    var position = BLLFactory<Mst_CargoPosition>.Instance.FindByID(item.F_CargoPositionId);
                    var goods = BLLFactory<Mst_Goods>.Instance.FindByID(item.F_GoodsId);
                    item.F_WarehouseName = warehouse == null ? "" : warehouse.F_FullName;
                    item.F_CargoPositionName = position == null ? "" : position.F_FullName;
                    item.F_Unit = goods == null ? "" : goods.F_Unit;
                    item.F_GoodsName = goods == null ? "" : goods.F_FullName;
                    item.F_GoodsCode = goods == null ? "" : goods.F_EnCode;
                }
            }

            return Success("", list);
        }




        public ActionResult VerifyList1(string orderId, string orderUserId, List<SO_StockMakeBodyInfo> info)
        {
            BLLFactory<SO_StockMakeHead>.Instance.Status(orderId, orderUserId, info);
            return Success("审核成功");
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult NoVerifyList(string orderId)
        {
            string Massage = BLLFactory<SO_StockMakeHead>.Instance.NoAudit(DateTime.Now.ToShortDateString(), CurrentUser.F_Account, orderId);
            if (Massage == "弃审成功")
            {
                return Success(Massage);
            }
            else
            {
                return Error(Massage);
            }
        }

    }
}