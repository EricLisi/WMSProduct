﻿using KGM.Framework.Application.Dtos;
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
    /// 商品接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        #region 依赖注入
        IInventoryService _service;
        ICustomerService _customerService;
        IInventoryClassService _InventoryClassService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        /// <param name="customerService"></param>
        /// <param name="InventoryClassService"></param>
        public InventoryController(IInventoryService service, ICustomerService customerService, IInventoryClassService InventoryClassService)
        {
            this._service = service;
            this._customerService = customerService;
            this._InventoryClassService = InventoryClassService;
        }
        #endregion




        #region Post

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="GetDto">商品对象</param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> Add([FromBody]InventoryGetDto GetDto)
        {
            GetDto.EnCode = _service.GetSkU(4);
            try
            {
                var positions = await _service.QueryAsync();
                var position = positions.Find(u => u.EnCode == GetDto.EnCode);
                if (position != null)
                {
                    return Ok(new { Status = true, Message = "此编码已存在，请重新输入" });
                }

                var result = await _service.Insert(GetDto);
                if (result > 0)
                {
                    return Ok(new { Status = true, Message = "添加成功" });
                }
                return Ok(new { Status = false, Message = "添加失败，请刷新后重试" });


            }
            catch (Exception ex)
            {

                return Ok(new { Status = false, Message = ex.ToString() });
            }

        }

        #endregion

        #region Put
        /// <summary>
        /// 商品
        /// </summary>
        /// <param name="Id">商品Id</param>
        /// <param name="GetDto">商品对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update([FromBody]InventoryGetDto GetDto, string Id)
        {
            try
            {
                var position = await _service.QueryByIdAsync(Id);
                var positions = await _service.QueryAsync(u => u.EnCode == GetDto.EnCode);
                if (positions.Count > 0 && position.EnCode != GetDto.EnCode)
                {
                    return Ok(new { Status = true, Message = "此编码已存在，请重新修改" });
                }

                GetDto.Id = Id;
                var result = await _service.Update(GetDto);
                if (result > 0)
                {
                    return Ok(new { Status = true, Message = "修改成功" });
                }
                return Ok(new { Status = false, Message = "修改失败，请刷新后重试" });
            }
            catch (Exception ex)
            {

                return Ok(new { Status = false, Message = ex.ToString() });
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="Id">商品Id</param> 
        /// <returns></returns>
        [HttpDelete, Route("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var result = await _service.Delete(Id);
                if (result > 0)
                {
                    return Ok(new { Status = true, Message = "删除成功" });
                }
                return Ok(new { Status = false, Message = "删除失败，请刷新后重试" });

            }
            catch (Exception ex)
            {

                return Ok(new { Status = false, Message = ex.ToString() });
            }
        }

        #endregion

        #region Get
        /// <summary>
        /// 根据Id获取商品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return Ok(await _service.QueryByIdAsync(Id));
        }

        /// <summary>
        /// 商品下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetSelectGrid")]
        public async Task<IActionResult> GetSelectGrid(string Id)
        {

            List<InventoryGetDto> RdList = new List<InventoryGetDto>();
            //返回信息  获取商品列表
            RdList = await _service.QueryAsync();
            List<SelectModel> selectModels = new List<SelectModel>();
            for (int i = 0; i < RdList.Count; i++)
            {
                SelectModel select = new SelectModel
                {
                    Id = RdList[i].Id,
                    Text = "[" + RdList[i].EnCode + "]" + RdList[i].FullName
                };
                selectModels.Add(select);
            }
            return Ok(selectModels);
        }

        /// <summary>
        /// 分页查询 + 条件查询
        /// </summary>
        /// <param name="rows">每页大小</param>
        /// <param name="page">当前页码</param>
        /// <param name="keyword">查询内容</param> 
        /// <param name="sord">是否升序</param> 
        /// <param name="Id">登陆用户ID</param> 
        /// <param name="sidx">排序字段</param> 
        /// <param sidx="Id">排序字段</param> 
        ///<returns></returns>
        [HttpGet("GatPagerListByWhere/{Id}")]
        public async Task<IActionResult> GatPagerListByWhere(string keyword, string sidx, int rows = 20, int page = 1, string sord = "ASC", string Id = "")
        {

            bool isAsc = false;
            if (sord.ToUpper() == "ASC")
            {
                isAsc = true;
            }
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = "SordCode";
            }
            //UserGetDto user = await _userService.QueryByIdAsync(Id);
            //RoleGetDto role = await _roleService.QueryByIdAsync(user.RoleId);
            //PagerEntity<CustomerGetDto> entity = null;
            //if (role.IsAdmin)
            //{

            PagerEntity<InventoryGetDto> entity = await _service.QueryByPagesAsync(rows, page,
                      t => t.EnCode.Contains((keyword ?? t.EnCode)) ||
                      t.FullName.Contains(keyword ?? t.FullName) ||
                      t.CusCode.Contains(keyword ?? t.CusCode),
                      _service.Expression(sidx), isAsc);
            //}
            //else
            //{
            //    entity = await _service.QueryByPagesAsync(rows, page,
            //        t => t.EnCode.Contains((keyword ?? t.EnCode)) ||
            //        t.FullName.Contains(keyword ?? t.FullName) &&
            //        t.UserId==Id,
            //        _service.Expression(sidx), isAsc);
            //}
            foreach (var item in entity.Entity)
            {
                if (entity.Entity != null && entity.Entity.Count() > 0)
                {

                    var customerGet = await _customerService.QueryByIdAsync(item.CusCode);
                    InventoryClassGetDto InventoryClassGet = await _InventoryClassService.QueryByIdAsync(item.Type);
                    item.TypeName = InventoryClassGet == null ? "" : InventoryClassGet.FullName;
                    item.CustomerName = customerGet == null ? "" : customerGet.FullName;
                    item.CustomerCode = customerGet == null ? "" : customerGet.EnCode;
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
                yu = 1;
            }
            else
            {
                yu = 0;
            }
            RtEntity.total = Count + yu;
            return Ok(Extensions.ToJson(RtEntity));
        }
        #endregion

        #region 私人方法
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
                    if (entity.title != null && !string.IsNullOrEmpty(entity.title.Replace("&nbsp;", "")))
                    {
                        strJson.Append("\"title\":\"" + entity.title.Replace("&nbsp;", "") + "\",");
                    }
                    if (entity.img != null && !string.IsNullOrEmpty(entity.img.Replace("&nbsp;", "")))
                    {
                        strJson.Append("\"icon\":\"" + entity.img.Replace("&nbsp;", "") + "\",");
                    }
                    if (entity.checkstate != null)
                    {
                        strJson.Append("\"checkstate\":" + entity.checkstate + ",");
                    }
                    if (entity.parentId != null)
                    {
                        strJson.Append("\"parentnodes\":\"" + entity.parentId + "\",");
                    }
                    strJson.Append("\"showcheck\":" + entity.showcheck.ToString().ToLower() + ",");
                    strJson.Append("\"isexpand\":" + entity.isexpand.ToString().ToLower() + ",");
                    if (entity.complete == true)
                    {
                        strJson.Append("\"complete\":" + entity.complete.ToString().ToLower() + ",");
                    }
                    strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");
                    strJson.Append("\"ChildNodes\":" + TreeViewJson(data, entity.id) + "");
                    strJson.Append("},");
                }
                strJson = strJson.Remove(strJson.Length - 1, 1);
            }
            strJson.Append("]");
            return strJson.ToString();
        }
        #endregion
    }
}