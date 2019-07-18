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
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    /// <summary>
    /// 仓库管理单控制器
    /// </summary>
    public class WarehouseController : BusinessController<Mst_Warehouse, Mst_WarehouseInfo>
    {
        /// <summary>
        /// 入库单查询
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
            List<Mst_WarehouseInfo> lista;
            if (string.IsNullOrEmpty(filterStr))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");
            }
            else
            {
                WarehouseFilter filter = JsonAppHelper.ToObject<WarehouseFilter>(filterStr);

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
                if (!string.IsNullOrEmpty(filter.F_FullName))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_FullName,
                        F_searchFiled = "F_FullName",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_EnabledMark))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnabledMark,
                        F_searchFiled = "F_EnabledMark",
                        F_type = "0"
                    });
                }
                lista = BLLFactory<Mst_Warehouse>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));

            }

            return GetPagerContent<Mst_WarehouseInfo>(lista, pager);
        }
        /// <summary>
        /// 重写添加方法
        /// </summary>
        /// <param name="warehouseInfo"></param>
        /// <returns></returns>
        public override ActionResult SubmitForm(Mst_WarehouseInfo info, string keyValue)
        {
            SearchCondition search = new SearchCondition();//判断此编码是否存在
            search.AddCondition("F_EnCode", info.F_EnCode, SqlOperator.Equal);
            List<Mst_WarehouseInfo> list = BLLFactory<Mst_Warehouse>.Instance.Find(GetConditionStr(search));
            if (string.IsNullOrEmpty(keyValue))//判断是新增还是修改
            {
                if (list.Count > 0)//新增如果编号存在则返回
                {
              
                    return Error("编码已存在，请重新输入！");
                }
            }
            else
            {
                Mst_WarehouseInfo warInfo = BLLFactory<Mst_Warehouse>.Instance.FindByID(keyValue);//修改获取修改前信息
                if (list.Count > 0 && warInfo.F_EnCode.Equals(info.F_EnCode) == false)
                {//如果此编号存在切不是原来的编号则返回
                    return Error("编码已存在，请重新输入！");
                }

            }
            if (string.IsNullOrEmpty(keyValue))
            {
                info.F_CreatorTime = DateTime.Now;
                info.F_CreatorUserId = CurrentUser.F_Account;
                info.F_Id = Guid.NewGuid().ToString();

            }
            else
            {
                info.F_Id = keyValue;
                info.F_LastModifyTime = DateTime.Now;
                info.F_LastModifyUserId = CurrentUser.F_Account;
              

            }
           BLLFactory<Mst_Warehouse>.Instance.InsertUpdate(info, keyValue);//否则添加或修改

            return Success("操作成功", info);
        }
        /// <summary>
        /// 删除之前的判断
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        public ActionResult beDeletFrom(string KeyValue)
        {
            ResultModel result = new ResultModel
            {
                bSuccess = true
            };
            SearchCondition search = new SearchCondition();//获取该仓库下面的货位
            search.AddCondition("F_WarehouseId", KeyValue, SqlOperator.Equal);
            List<Mst_PositionInfo> positionInfos = BLLFactory<Mst_Position>.Instance.Find(GetConditionStr(search));
            if (positionInfos.Count > 0)//如果存在货位则返回
            {
                result.bSuccess = false;
                result.message = "此仓库存在货位，请先删此仓库下的货位后在进行删除";
            }



            return Content(JsonAppHelper.ToJson(result));
        }


        /// <summary>
        /// 禁用启用仓库，货位配置
        /// </summary>
        /// <param name="Id">仓库ID</param>
        /// <param name="Type">更改类型</param>
        /// <returns></returns>
        public ActionResult UpEnMark(string Id, int Type)
        {
            //获取当前仓库状态
            Mst_WarehouseInfo warehouseInfo = BLLFactory<Mst_Warehouse>.Instance.FindByID(Id);
            ResultModel result = new ResultModel();
            if (Type == 0)//如果是对仓库进行操作
            {
                result.bSuccess = BLLFactory<Mst_Warehouse>.Instance.UpEnMask(Id);

            }
            if (Type == 1)//对货位配置进行操作
            {
                if (warehouseInfo.F_PositionManagement == true)
                {
                    warehouseInfo.F_PositionManagement = false;
                }
                else
                {
                    warehouseInfo.F_PositionManagement = true;
                }
                result.bSuccess = BLLFactory<Mst_Warehouse>.Instance.Update(warehouseInfo, Id);
            }

            result.message = result.bSuccess ? "操作成功" : "操作失败,请刷新后重试";
            return Content(JsonAppHelper.ToJson(result));

        }

    }
}