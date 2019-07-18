using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers
{
    /// <summary>
    /// 库存管理接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        #region 依赖注入
        IStockService _service;
        IInventoryService _productService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        /// <param name="productService"></param>
        public StockController(IStockService service,IInventoryService productService)
        {
            this._productService = productService;
            this._service = service;

        }
        #endregion
 

        #region Get



        /// <summary>
        /// 分页查询 + 条件查询
        /// </summary>
        /// <param name="keyword">查询内容</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">升序降序</param>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        [HttpGet("GetListByWhere/{Id}")]
        public async Task<IActionResult> GetListByWhere(string keyword, string sidx, string sord, string Id)
        {

            if (string.IsNullOrEmpty(sidx))
            {
                sidx = "SortCode";
            }
            if (string.IsNullOrEmpty(sord))
            {
                sord = "ASC";
            }


            PagerEntity<StockGetDto> entity = new PagerEntity<StockGetDto>();

            entity = await _service.QueryByPagesAsync(
                  t => t.ProductSKU.Contains((keyword ?? t.ProductSKU)) ||
                  t.CustomerId.Contains(keyword ?? t.CustomerId),
                  _service.Expression(sidx), sord.ToUpper().Equals("ASC"));
            if (entity.Entity!=null && entity.Entity.Count()>0)
            {
                foreach (var item in entity.Entity)
                {
                    var product =await _productService.QueryByIdAsync(item.ProductId);
                    item.ProductName = product == null ? "" : product.FullName;
                }
            }

            return Ok(Extensions.ToJson(entity.Entity));

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
                sord = "asc";
            }
            PagerEntity<StockGetDto> entity = new PagerEntity<StockGetDto>();

             entity = await _service.QueryByPagesAsync(rows, page,
                      t => t.CustomerId.Contains((keyword ?? t.CustomerId)) ||
                      t.ProductSKU.Contains(keyword ?? t.ProductSKU),
                      _service.Expression(sidx), sord.ToUpper().Equals("ASC"));
            //设置返回格式
            ReturnEntity RtEntity = new ReturnEntity();
            RtEntity.rows = entity.Entity;
            RtEntity.page = page;
            RtEntity.records = entity.Total;
            int Count = entity.Total / rows;//获取除数
            int yu = entity.Total % rows;//获取余数
            if (yu > 0)//如q果余数大于0则加一页，否则不加
            {
                RtEntity.total = Count + 1;
            }
            else
            {
                RtEntity.total = Count + 0;
            }
            if (entity.Entity != null && entity.Entity.Count() > 0)
            {
                foreach (var item in entity.Entity)
                {
                    var product = await _productService.QueryByIdAsync(item.ProductId);
                    item.ProductName = product == null ? "" : product.FullName;
                }
            }
            return Ok(Extensions.ToJson(RtEntity));
        }


        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static string TreeViewJson(List<TreeViewModel> data, string parentId = "0")
        {
            StringBuilder strJson = new StringBuilder();
            List<TreeViewModel> item = data.FindAll(t => t.parentId == parentId);
            strJson.Append("[");
            if (item.Count > 0)
            {
                foreach (TreeViewModel entity in item)
                {

                    strJson.Append("{");
                    strJson.Append("\"id\":\"" + entity.id + "\",");
                    strJson.Append("\"text\":\"" + entity.text.Replace("&nbsp;", "") + "\",");
                    strJson.Append("\"value\":\"" + entity.value + "\",");
                    strJson.Append("\"parentId\":\"" + entity.parentId + "\",");
                    strJson.Append("\"isexpand\":" + entity.isexpand + ",");
                    strJson.Append("\"complete\":" + entity.complete + ",");
                    strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");
                    strJson.Append("\"ChildNodes\":" + TreeViewJson(data, entity.id) + "");
                    strJson.Append("},");
                }
                strJson = strJson.Remove(strJson.Length - 1, 1);
            }
            strJson.Append("]");
            return strJson.ToString();
        }
    }
}