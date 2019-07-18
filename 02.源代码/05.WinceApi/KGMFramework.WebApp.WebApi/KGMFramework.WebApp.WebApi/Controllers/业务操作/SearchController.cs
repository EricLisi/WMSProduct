using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.WebApi.Models;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using KGM.Framework.Commons;
using System.Data;
using System.Reflection;
using KGM.Pager.Entity;
using Newtonsoft.Json;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 查询列表
    /// </summary> 
    [RoutePrefix("api/Search")]
    public class SearchController : BaseController<SO_Head, SO_HeadInfo>
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        [HttpPost, Route("GetList")]
        public async Task<KgmApiResultEntity> GetList([FromBody]SearchModel model)
        {
            return await Task.Run(() =>
            {
                KgmApiResultEntity result = new KgmApiResultEntity();
                var message = string.Empty;
                if (string.IsNullOrEmpty(model.orderNo))
                {
                    result.result = false;
                    result.message = "未获取到单据号";
                    return result;
                }
                var user = BLLFactory<Sys_User>.Instance.FindByID(model.UserId);
                SearchCondition search = new SearchCondition();
                search.AddCondition("F_EnCode", model.orderNo, SqlOperator.Equal);
                switch (model.orderType.ToLower())
                {
                    case "pi":
                        PI_HeadInfo PIhead = BLLFactory<PI_Head>.Instance.FindSingle(BuilderConditionStr(search));
                        var warehosue = BLLFactory<Mst_Warehouse>.Instance.FindByID(PIhead.F_WarehouseId);
                        if (PIhead == null)
                        {
                            result.result = false;
                            result.message = "未获取到单据信息，请输入正确的单据号！";
                            return result;
                        }
                        if (PIhead.F_Status == 0)
                        {
                            result.result = false;
                            result.message = "单据未审核，请先审核！";
                            return result;
                        }
                        if (PIhead.F_Status > 1)
                        {
                            result.result = false;
                            result.message = "单据已经完成,不允许扫描！";
                            return result;
                        }
                        if (user.F_IsAdministrator==false && PIhead.F_WarehouseId !=user.F_WarehouseId)
                        {
                            result.result = false;
                            result.message = "用户"+user.F_FullName+"不允许操作仓库为"+warehosue.F_FullName+"的数据";
                            return result;
                        }
                        else
                        {
                            search = new SearchCondition();
                            search.AddCondition("F_Hid", PIhead.F_Id, SqlOperator.Equal);
                            var data = BLLFactory<PI_Body>.Instance.Find(BuilderConditionStr(search));
                            if (data!=null && data.Count>0)
                            {
                                foreach (var item in data)
                                {
                               
                                  //  var position = BLLFactory<Mst_CargoPosition>.Instance.FindByID(item.F_CargoPositionId);
                                    var goods = BLLFactory<Mst_Goods>.Instance.FindByID(item.F_GoodsId);
                           
                                    item.F_WarehouseName = warehosue == null ? "" : warehosue.F_FullName;
                                    item.F_WarehouseCode = warehosue == null ? "" : warehosue.F_EnCode;
                                    //item.F_CargoPositionName = position == null ? "" : position.F_FullName;
                                    //item.F_CargoPositionCode = position == null ? "" : position.F_EnCode;
                                    item.F_GoodsId = goods == null ? "" : goods.F_FullName;
                                    item.F_BarCode = goods == null ? "|" : goods.F_EnCode + "|";
                                    item.F_QTY = item.F_InStockNum;
                                }
                            }
                            result.result = true;
                          result.message = JsonAppHelper.ToJson(data);
                            
                        }

                        break;
                    case "so":

                        SO_HeadInfo SOhead = BLLFactory<SO_Head>.Instance.FindSingle(BuilderConditionStr(search));
                        var SOwarehosue = BLLFactory<Mst_Warehouse>.Instance.FindByID(SOhead.F_WarehouseId);
                        if (SOhead == null)
                        {
                            result.result = false;
                            result.message = "未获取到单据信息，请输入正确的单据号！";
                            return result;
                            // return JsonAppHelper.ToJson(new { result = false, message = "未获取到单据信息，请输入正确的单据号！" });
                        }
                        if (int.Parse(SOhead.F_Status) == 0)
                        {
                            result.result = false;
                            result.message = "未审核，请先审核！";
                            return result;
                            // return JsonAppHelper.ToJson(new { result = false, message = "单据未审核，请先审核！" });
                        }
                        if (int.Parse(SOhead.F_Status) > 1)
                        {
                            result.result = false;
                            result.message = "单据已经完成,不允许扫描！";
                            return result;
                            // return JsonAppHelper.ToJson(new { result = false, message = "单据已经完成,不允许扫描！" });
                        }
                        if (user.F_IsAdministrator == false && SOhead.F_WarehouseId != user.F_WarehouseId)
                        {
                            result.result = false;
                            result.message = "用户" + user.F_FullName + "不允许操作仓库为" + SOwarehosue.F_FullName + "的数据";
                            return result;
                        }
                        else
                        {
                            search = new SearchCondition();
                            search.AddCondition("F_Hid", SOhead.F_Id, SqlOperator.Equal);


                            var data = BLLFactory<SO_Body>.Instance.Find(BuilderConditionStr(search));
                            if (data != null && data.Count > 0)
                            {
                                foreach (var item in data)
                                {
                                   
                                   // var position = BLLFactory<Mst_CargoPosition>.Instance.FindByID(item.F_CargoPositionId);
                                    var goods = BLLFactory<Mst_Goods>.Instance.FindByID(item.F_GoodsId);
                                    item.F_WarehouseName = SOwarehosue == null ? "" : SOwarehosue.F_FullName;
                                    item.F_WarehouseCode = SOwarehosue == null ? "" : SOwarehosue.F_EnCode;
                                    //item.F_CargoPositionName = position == null ? "" : position.F_FullName;
                                    //item.F_CargoPositionCode = position == null ? "" : position.F_EnCode;
                                    item.F_GoodsId = goods == null ? "" : goods.F_FullName;
                                    item.F_BarCode = goods == null ? "|" : goods.F_EnCode + "|" + item.F_Batch;
                                    item.F_QTY = item.F_OutStockNum;
                                }
                            }
                           result.result = true;
                           result.message = JsonAppHelper.ToJson(data);
                        }
                        break;
                    case "cw":
                        SO_StockMakeHeadInfo CWhead = BLLFactory<SO_StockMakeHead>.Instance.FindSingle(BuilderConditionStr(search));
                        var Cwwarehosue = BLLFactory<Mst_Warehouse>.Instance.FindByID(CWhead.F_WarehouseId);
                        if (CWhead == null)
                        {
                            result.result = false;
                            result.message = "未获取到单据信息，请输入正确的单据号！";
                            return result;
                          //  return JsonAppHelper.ToJson(new { result = false, message = "未获取到单据信息，请输入正确的单据号！" });
                        }
                        if (CWhead.F_Status == 0)
                        {
                            result.result = false;
                            result.message = "单据未审核，请先审核！";
                            return result;
                            //return JsonAppHelper.ToJson(new { result = false, message = "单据未审核，请先审核！" });
                        }
                        if (CWhead.F_Status > 1)
                        {
                            result.result = false;
                            result.message = "单据已经完成,不允许扫描！";
                            return result;
                            //return JsonAppHelper.ToJson(new { result = false, message = "单据已经完成,不允许扫描！" });
                        }
                        if (user.F_IsAdministrator == false && CWhead.F_WarehouseId != user.F_WarehouseId)
                        {
                            result.result = false;
                            result.message = "用户" + user.F_FullName + "不允许操作仓库为" + Cwwarehosue.F_FullName + "的数据";
                            return result;
                        }
                        else
                        {
                            search = new SearchCondition();
                            search.AddCondition("F_Hid", CWhead.F_Id, SqlOperator.Equal);



                            var data = BLLFactory<SO_StockMakeBody>.Instance.Find(BuilderConditionStr(search));
                            if (data != null && data.Count > 0)
                            {
                                foreach (var item in data)
                                {
                                    var position = BLLFactory<Mst_CargoPosition>.Instance.FindByID(item.F_CargoPositionId);
                                    var goods = BLLFactory<Mst_Goods>.Instance.FindByID(item.F_GoodsId);

                                    item.F_WarehouseName = Cwwarehosue == null ? "" : Cwwarehosue.F_FullName;
                                    item.F_WarehouseCode = Cwwarehosue == null ? "" : Cwwarehosue.F_EnCode;
                                     item.F_CargoPositionName = position == null ? "" : position.F_FullName;
                                     item.F_CargoPositionCode = position == null ? "" : position.F_EnCode;
                                    item.F_GoodsId = goods == null ? "" : goods.F_FullName;
                                    item.F_BarCode = goods == null ? "|" : goods.F_EnCode + "|" + item.F_Batch;
                                    item.F_QTY = int.Parse(item.F_RealNumber);
                                }
                            }
                            result.result = true;

                            result.message = JsonAppHelper.ToJson(data);
                        }
                        break;
                    default:
                       result.message = "[]";
                        break;
                }
                return result;
                //return JsonAppHelper.ToJson(new { result = t, message = "单据未审核，请先审核！" });
            });
        }
        /// <summary>
        ///获取仓库下拉框列表
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetWarSelectList")]
        public async Task<KgmApiResultEntity> GetWarSelectList() {

            return await Task.Run(()=>{

                KgmApiResultEntity result = new KgmApiResultEntity(); 
                List<Mst_WarehouseInfo> wList = BLLFactory<Mst_Warehouse>.Instance.GetAll();
                List<SelectModel> list = new List<SelectModel>();
                if (wList!=null && wList.Count>0)
                {
                    foreach (var item in wList)
                    {
                        SelectModel select = new SelectModel() {
                            id = item.F_EnCode,
                            text="["+item.F_EnCode+"]"+item.F_FullName
                        };
                        
                        list.Add(select);

                    }
                }
                result.message = JsonAppHelper.ToJson(list);
                return result;
            });

        }
    }
}
