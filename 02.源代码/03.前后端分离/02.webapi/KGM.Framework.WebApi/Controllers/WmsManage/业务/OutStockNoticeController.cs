using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers
{
    /// <summary>
    /// 产品到货单接口
    /// </summary>
    [Route("api/[controller]")]
    //[ApiController]
    public class OutStockNoticeController : ControllerBase
    {
        #region 依赖注入
        IOutStockNoticeHeadService _service;
        IOutStockNoticeBodyService _outStockNoticeBodyService;
        ICustomerService _customerService;
        IWarehouseService _warehouseService;
        IOwnerService _ownerService;
        IReceiveTypeService _receivetypeService;
        IInventoryService _productService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        /// <param name="outStockNoticeBodyService"></param>
        /// <param name="customerService"></param>
        /// <param name="warehouseService"></param>
        /// <param name="productService"></param>
        /// <param name="ownerService"></param>
        /// <param name="strtypeService"></param>
        public OutStockNoticeController(IOutStockNoticeHeadService service, IOutStockNoticeBodyService outStockNoticeBodyService, ICustomerService customerService, IWarehouseService warehouseService, IInventoryService productService, IOwnerService ownerService, IReceiveTypeService strtypeService)
        {
            this._warehouseService = warehouseService;
            this._customerService = customerService;
            this._service = service;
            this._outStockNoticeBodyService = outStockNoticeBodyService;
            this._productService = productService;
            this._ownerService = ownerService;
            this._receivetypeService = strtypeService;
        }
        #endregion

        #region Post

        /// <summary>
        /// 新增产品到货单
        /// </summary>
        /// <param name="model">新增对象</param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> Add([FromBody]GetOutStockNoticeModel model)
        {
            return await Task.Run(() =>
            {
                var Message = _service.InsUpdateOutStockNotice(GetTableData(model));
                ReturnModel @return = Message as ReturnModel;


                if (@return.r == 1)
                {
                    return Ok(new { Status = true, Message = "添加成功" });
                }
                return Ok(new { Status = false, Message = @return.msg });
            });

        }

        

        #endregion
        #region Put
        /// <summary>
        /// 修改产品到货单
        /// </summary>
        /// <param name="Id">产品到货单Id</param>
        /// <param name="model">产品到货单对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update([FromBody]GetOutStockNoticeModel model, string Id)
        {
            return await Task.Run(() =>
            {
                model.info.Id = Id;
                var Message = _service.InsUpdateOutStockNotice(GetTableData(model));
                ReturnModel @return = Message as ReturnModel;

                if (@return.r == 1)
                {
                    return Ok(new { Status = true, Message = "修改成功" });
                }
                return Ok(new { Status = false, Message = @return.msg });
            });
        }



        #endregion
        #region Delete
        /// <summary>
        /// 删除产品到货单
        /// </summary>
        /// <param name="Id">产品到货单Id</param> 
        /// <returns></returns>
        [HttpDelete, Route("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            return await Task.Run(() =>
            {
                ReturnModel model = _service.DeleteOutStockNotice(Id);

                try
                {
                    if (model.r == 1)
                    {
                        return Ok(new { Status = true, Message = "删除成功" });
                    }
                    else
                    {
                        return Ok(new { Status = false, Message = model.msg });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new { Status = false, Message = ex.Message.ToString() });


                }
            });
        }

        #endregion
        #region Get


        /// <summary>
        /// 审核弃审
        /// </summary>
        /// <param name="Id">单据Id</param>
        /// <param name="User">当前登录用户</param>
        /// <param name="orderType">0 审核 1 弃审</param>
        /// <returns></returns>
        [HttpGet, Route("VerifyList/{Id}")]
        public async Task<IActionResult> VerifyList(string Id, string User, int orderType)
        {
            return await Task.Run(() =>
            {

                var Message = _service.VerifyList(Id, User, orderType);
                ReturnModel @return = Message as ReturnModel;

                if (@return.r == 1 && orderType == 0)
                {
                    return Ok(new { Status = true, Message = "审核成功" });
                }
                if (@return.r == 1 && orderType == 1)
                {
                    return Ok(new { Status = true, Message = "弃审成功" });
                }
                return Ok(new { Status = false, Message = @return.msg });
            });

        }
        

        /// <summary>
        /// 根据Id获取产品到货单信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            //var data = await _service.GetInStockNoticeById(Id);
            var Info = await _service.QueryByIdAsync(Id);
            var Dinfo = await _outStockNoticeBodyService.QueryAsync(u => u.OrderNo == Info.OrderNo);
            if (Dinfo != null && Dinfo.Count > 0)
            {
                foreach (var item in Dinfo)
                {
                    var product = await _productService.QueryAsync(u => u.Id == item.ProductId);
                    //if (product != null && product.Count == 1)
                    //{
                    //    item.ProductName = product[0].FullName;
                    //    item.InvSKU= product[0].InvSKU;
                    //    item.CustomerCode = product[0].CustomerCode;
                    //    item.ProductCode = product[0].EnCode;
                    //}
                }
            }
            return Ok(new { info = Info, dInfo = Dinfo });
        }








        /// <summary>
        /// 分页查询 + 条件查询
        /// </summary>
        /// <param name="keyword">查询内容</param>
        /// <param name="rows">行数</param>
        /// <param name="page">页码</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">升序降序</param>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        [HttpGet("GatPagerListByWhere/{Id}")]
        public async Task<IActionResult> GatPagerListByWhere(string keyword, int rows, int page, string sidx, string sord, string Id)
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = "SortCode";
            }
            if (string.IsNullOrEmpty(sord))
            {
                sord = "ASC";
            }

            PagerEntity<OutStockNoticeHeadGetDto> entity = await _service.QueryByPagesAsync(rows, page,
                      t => t.OrderNo.Contains((keyword ?? t.OrderNo)) ,
                      _service.Expression(sidx), sord.ToUpper().Equals("ASC"));

            List<OutStockNoticeHeadGetDto> list = await _service.QueryAsync();


            if (entity.Entity != null && entity.Entity.Count() > 0)
            {
                foreach (var item in entity.Entity)
                {

                    var customer = await _customerService.QueryByIdAsync(item.CustomerId);
                    var warehouse = await _warehouseService.QueryByIdAsync(item.WarehouseId);
                    var owner = await _ownerService.QueryByIdAsync(item.OwnerId);
                    var receivetype = await _receivetypeService.QueryByIdAsync(item.SrTypeId);
                    //item.WarehouseCode = warehouse == null ? "" : warehouse.EnCode;
                    //item.WarehouseName = warehouse == null ? "" : warehouse.FullName;
                    //item.CustomerCode = customer == null ? "" : customer.EnCode;
                    //item.CustomerName = customer == null ? "" : customer.FullName;
                    //item.OwnnerCode = owner == null ? "" : owner.EnCode;
                    //item.OwnnerName = owner == null ? "" : owner.FullName;
                    //item.StrTypeCode = receivetype == null ? "" : receivetype.EnCode;
                    //item.StrTypeName = receivetype == null ? "" : receivetype.FullName;
                }
            }

            //设置返回格式
            ReturnEntity RtEntity = new ReturnEntity();
            RtEntity.rows = entity.Entity;
            RtEntity.page = page;
            RtEntity.records = entity.Total;
            int Count = entity.Total / rows;//获取除数
            int yu = entity.Total % rows;//获取余数
            if (yu > 0)//如果余数大于0则加一页，否则不加
            {
                RtEntity.total = Count + 1;
            }
            else
            {
                RtEntity.total = Count + 0;
            }
            return Ok(Extensions.ToJson(RtEntity));
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetData()
        {
            DataTable info = new DataTable();
            info.Columns.Add("OrderNo", typeof(string));
            info.Columns.Add("CustomerId", typeof(string));
            info.Columns.Add("WarehouseId", typeof(string));
            info.Columns.Add("SrTypeId", typeof(string));
            info.Columns.Add("OwnerId", typeof(string));
            info.Columns.Add("Type", typeof(string));
            info.Columns.Add("Maker", typeof(string));
            info.Columns.Add("Date", typeof(string));
            info.Columns.Add("Status", typeof(string));
            info.Columns.Add("AllPrice", typeof(string)); 
            info.Columns.Add("Define1", typeof(string));
            info.Columns.Add("Define2", typeof(string));
            info.Columns.Add("Define3", typeof(string));
            info.Columns.Add("Define4", typeof(string));
            info.Columns.Add("Define5", typeof(string));
            info.Columns.Add("Define6", typeof(string));
            info.Columns.Add("Define7", typeof(string));
            info.Columns.Add("Define8", typeof(string));
            info.Columns.Add("Define9", typeof(string));
            info.Columns.Add("Define10", typeof(string));
            info.Columns.Add("SendType", typeof(string));
            info.Columns.Add("ExpCompanyId", typeof(string));
            info.Columns.Add("ExpNo", typeof(string));
            info.Columns.Add("ReceivePerson", typeof(string));
            info.Columns.Add("ReceivePersonTel", typeof(string));
            info.Columns.Add("ReceiveAddress", typeof(string));
            info.Columns.Add("IsPick", typeof(bool));
            info.Columns.Add("Description", typeof(string));


            DataTable dInfo = new DataTable();
            dInfo.Columns.Add("RowNo", typeof(string));
            dInfo.Columns.Add("HeadId", typeof(string));
            dInfo.Columns.Add("OrderNo", typeof(string));
            dInfo.Columns.Add("WarehouseId", typeof(string));
            dInfo.Columns.Add("PositionId", typeof(string));
            dInfo.Columns.Add("ProductId", typeof(string));
            dInfo.Columns.Add("Batch", typeof(string));
            dInfo.Columns.Add("MadeDate", typeof(string));
            dInfo.Columns.Add("ExpiryDate", typeof(string));
            dInfo.Columns.Add("Quantity", typeof(string));
            dInfo.Columns.Add("Price", typeof(string));
            dInfo.Columns.Add("Define1", typeof(string));
            dInfo.Columns.Add("Define2", typeof(string));
            dInfo.Columns.Add("Define3", typeof(string));
            dInfo.Columns.Add("Define4", typeof(string));
            dInfo.Columns.Add("Define5", typeof(string));
            dInfo.Columns.Add("Define6", typeof(string));
            dInfo.Columns.Add("Define7", typeof(string));
            dInfo.Columns.Add("Define8", typeof(string));
            dInfo.Columns.Add("Define9", typeof(string));
            dInfo.Columns.Add("Define10", typeof(string));
            dInfo.Columns.Add("BoxNo", typeof(string));
            dInfo.Columns.Add("Description", typeof(string));
            DataSet ds = new DataSet();
            ds.Tables.Add(info);
            ds.Tables.Add(dInfo);

            return ds;
        }


        /// <summary>
        /// 添加或修改到货单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DataSet GetTableData(GetOutStockNoticeModel model)
        {
            DataSet ds = GetData();
            DataRow dr = ds.Tables[0].NewRow();
            var info = model.info;
            dr["OrderNo"] = string.IsNullOrEmpty(info.OrderNo) ? string.Empty : info.OrderNo;
            dr["CustomerId"] = info.CustomerId;
            dr["WarehouseId"] = info.WarehouseId;
            dr["SrTypeId"] = info.SrTypeId;
            dr["OwnerId"] = info.OwnerId;
            dr["Type"] = info.Type;
            dr["Maker"] = info.Maker;
            dr["Date"] = info.Date.ToString();
            dr["Status"] = info.Status;
            dr["AllPrice"] = info.AllPrice;
            dr["Define1"] = info.Define1;
            dr["Define2"] = info.Define2;
            dr["Define3"] = info.Define3;
            dr["Define4"] = info.Define4;
            dr["Define5"] = info.Define5;
            dr["Define6"] = info.Define6;
            dr["Define7"] = info.Define7;
            dr["Define8"] = info.Define8;
            dr["Define9"] = info.Define9;
            dr["Define10"] = info.Define10;
            dr["SendType"] = info.SendType;
            dr["ExpCompanyId"] = info.ExpCompanyId;
            dr["ExpNo"] = info.ExpNo;
            dr["ReceivePerson"] = info.ReceivePerson;
            dr["ReceivePersonTel"] = info.ReceivePersonTel;
            dr["ReceiveAddress"] = info.ReceiveAddress;
            dr["IsPick"] = info.IsPick;
            dr["Description"] = info.Description;
            ds.Tables[0].Rows.Add(dr);
            var order = ds.Tables[0].Rows[0]["ORDERNO"].ToString();
            for (int i = 0; i < model.dInfo.Count; i++)
            {
                dr = ds.Tables[1].NewRow();
                var dInfo = model.dInfo[i];
                dr["RowNo"] = (i + 1).ToString();
                dr["HeadId"] = info.Id;
                dr["OrderNo"] = order;
                dr["WarehouseId"] = info.WarehouseId;
                dr["PositionId"] = dInfo.PositionId;
                dr["ProductId"] = dInfo.ProductId;
                dr["Batch"] = dInfo.Batch;
                dr["MadeDate"] = dInfo.MadeDate.ToString()== "0001/1/1 0:00:00"?"": dInfo.MadeDate.ToString();
                dr["ExpiryDate"] = dInfo.ExpiryDate.ToString() == "0001/1/1 0:00:00" ? "" : dInfo.ExpiryDate.ToString();
                dr["Quantity"] = dInfo.Quantity;
                dr["Price"] = dInfo.Price;
                dr["Define1"] = dInfo.Define1;
                dr["Define2"] = dInfo.Define2;
                dr["Define3"] = dInfo.Define3;
                dr["Define4"] = dInfo.Define4;
                dr["Define5"] = dInfo.Define5;
                dr["Define6"] = dInfo.Define6;
                dr["Define7"] = dInfo.Define7;
                dr["Define8"] = dInfo.Define8;
                dr["Define9"] = dInfo.Define9;
                dr["Define10"] = dInfo.Define10;
                dr["BoxNo"] = dInfo.BoxNo;
                dr["Description"] = dInfo.Description;
                ds.Tables[1].Rows.Add(dr);

            }
            return ds;

        }
        #endregion
    }
}