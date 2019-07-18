using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using KGM.Framework.Commons;
using KGM.Pager.Entity;
using System.Data;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Library;
using System;
using System.IO;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 业务模块
    /// </summary>
    [RoutePrefix("api/app")]
    public class AppController : ApiController
    {
        // GET: App1


        /// <summary>
        /// 保存扫描记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost, Route("SaveTempScan")]
        public async Task<KgmApiResultEntity> SaveTempScan([FromBody]SaveTempScanModel dto)
        {
            string[] str = dto.Barcode.Split('|');
            KgmApiResultEntity result = new KgmApiResultEntity();
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_EnCode", dto.Warehouse, SqlOperator.Equal);



            var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
            if (warehouse == null)
            {
                result.result = false;
                result.message = "仓库编码错误";
                return result;
            };
            dto.Warehouse = warehouse.F_Id;
            search = new SearchCondition();
            search.AddCondition("F_EnCode",str[0], SqlOperator.Equal);
            search = new SearchCondition();
            search.AddCondition("F_EnCode", dto.Position, SqlOperator.Equal);
            var position = BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
            if (position == null)
            {
                result.result = false;
                result.message = "货位编码错误";
                return result;
            }
            dto.Position = position.F_Id;
            if (!String.IsNullOrEmpty(dto.DesPosition))
            {
                search = new SearchCondition();
                search.AddCondition("F_EnCode", dto.DesPosition, SqlOperator.Equal);
                var DesPosition = BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
                if (DesPosition == null)
                {
                    result.result = false;
                    result.message = "目标仓库编码错误";


                    return result;
                }

            }
            if (!string.IsNullOrEmpty(dto.DesWarehouse))
            {
                search = new SearchCondition();
                search.AddCondition("F_EnCode", dto.DesWarehouse, SqlOperator.Equal);
                var DesWarehouse = BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
                if (DesWarehouse == null)
                {
                    result.result = false;
                    result.message = "目标货位编码错误";
                    return result;
                }

            }
           
            result.result = true;
            return await Task.Run(() =>
            {
                var dt = BLLFactory<AppCommon>.Instance.SaveTempScan(dto);
                if (!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                {
                    result.result = false;
                }
            
                result.message = result.result == true ? "操作成功" : dt.Rows[0][0].ToString();
                if (dto.DeleteMark)
                {
                    result.message = result.result == true ? "删除成功" : dt.Rows[0][0].ToString();
                }
                return result;
            });
        }
        /// <summary>
        /// 判断货位是否存在
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <param name="PositionCode">货位编码</param>
        /// <returns></returns>
        [HttpPost, Route("SaveTempScan")]
        public async Task<KgmApiResultEntity> GetBoolPostion(string orderNo, string orderType, string PositionCode )
        {
            return await Task.Run(() =>
            {
                KgmApiResultEntity entity = new KgmApiResultEntity()
                {
                    result = true
                };
                SearchCondition search = new SearchCondition();
                search.AddCondition("F_EnCode", orderNo, SqlOperator.Equal);
                switch (orderType.ToUpper())
                {
                    case "PI":
                        var PIdata = BLLFactory<PI_Head>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
                        search = new SearchCondition();
                        search.AddCondition("F_EnCode", PositionCode, SqlOperator.Equal);
                        search.AddCondition("F_WarehouseId", PIdata.F_WarehouseId, SqlOperator.Equal);
                        if (BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty)) == null)
                        {
                            var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindByID(PIdata.F_WarehouseId);
                            entity.result = false;
                            entity.message = "货位编码错误或货位不属于仓库"+ warehouse.F_Id;
                            return entity;
                        }
                        break;
                    case "SO":
                        var SOdata = BLLFactory<SO_Head>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
                        search = new SearchCondition();
                        search.AddCondition("F_EnCode", PositionCode, SqlOperator.Equal);
                        search.AddCondition("F_WarehouseId", SOdata.F_WarehouseId, SqlOperator.Equal);
                        if (BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty)) == null)
                        {
                            var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindByID(SOdata.F_WarehouseId);
                            entity.result = false;
                            entity.message = "货位编码错误或货位不属于仓库" + warehouse.F_Id;
                            return entity;
                        }
                        break;
                    case "CW":
                        var CWdata = BLLFactory<SO_Head>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
                        search = new SearchCondition();
                        search.AddCondition("F_EnCode", PositionCode, SqlOperator.Equal);
                        search.AddCondition("F_WarehouseId", CWdata.F_WarehouseId, SqlOperator.Equal);
                        if (BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty)) == null)
                        {
                            var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindByID(CWdata.F_WarehouseId);
                            entity.result = false;
                            entity.message = "货位编码错误或货位不属于仓库" + warehouse.F_Id;
                            return entity;
                        }
                        break;
                    //case "MP":
                    //    var CWdata = BLLFactory<SO_Head>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
                    //    search = new SearchCondition();
                    //    search.AddCondition("F_EnCode", PositionCode, SqlOperator.Equal);
                    //    search.AddCondition("F_WarehouseId", CWdata.F_WarehouseId, SqlOperator.Equal);
                    //    if (BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty)) == null)
                    //    {
                    //        var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindByID(CWdata.F_WarehouseId);
                    //        entity.result = false;
                    //        entity.message = "货位编码错误或货位不属于仓库" + warehouse.F_Id;
                    //        return entity;
                    //    }
                    //    break;
                }

                return entity;
            });
        }


        /// <summary>
        /// 获取扫描列表
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型PI 入库，S0 出库，CW盘点</param> 
        /// <returns></returns>
        [HttpGet, Route("GetTempScanList/{orderType}")]
        public async Task<KgmApiResultEntity> GetTempScanList(string orderNo, string orderType)
        {
            return await Task.Run(() =>
            {
                KgmApiResultEntity resultEntity = new KgmApiResultEntity()
                {
                    result = true,
                    message = JsonAppHelper.ToJson(BLLFactory<AppCommon>.Instance.GetTempScanList(orderNo, orderType))

                };
                return resultEntity;
            });
        }


        /// <summary>
        /// 获取差异列表
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型PI 入库，S0 出库，CW盘点</param> 
        /// <returns></returns>
        [HttpGet, Route("GetScanCyList/{orderNo}/{orderType}")]
        public async Task<KgmApiResultEntity> GetScanCyList(string orderNo, string orderType)
        {
            return await Task.Run(() =>
            {
                KgmApiResultEntity resultEntity = new KgmApiResultEntity()
                {
                    result = true,
                    message = JsonAppHelper.ToJson(BLLFactory<AppCommon>.Instance.GetScanCyList(orderNo, orderType))
                };
                return resultEntity;
            });
        }


        /// <summary>
        /// 完成扫描记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost, Route("TempScanFinish")]
        public async Task<KgmApiResultEntity> TempScanFinish(FinishTempScanDto dto)
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_EnCode", dto.CMCWHCode, SqlOperator.Equal);
            var warehouse = BLLFactory<Mst_Warehouse>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
            search = new SearchCondition();
            search.AddCondition("F_EnCode", dto.CMPosCode, SqlOperator.Equal);
            var position = BLLFactory<Mst_CargoPosition>.Instance.FindSingle(search.BuildConditionSql().Replace("Where", string.Empty));
            dto.CMCWHCode = warehouse == null ? "" : warehouse.F_Id;
            dto.CMPosCode = position == null ? "" : position.F_Id;
            KgmApiResultEntity result = new KgmApiResultEntity();
            result.result = true;
            return await Task.Run(() =>
            {
                var dt = BLLFactory<AppCommon>.Instance.TempScanFinish(dto);
                if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                {
                    result.result = false;
                }
                result.message = result.result == true ? "操作成功" : dt.Rows[0][1].ToString();

                return result;
            });
        }
    }
}