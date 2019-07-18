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
    /// 快递接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExpCompanyController : ControllerBase
    {
        #region 依赖注入
        IExpCompanyService _service;
        IUserService _userservice;
        IRoleService _roleservice;
        IItemsDetailService _itemsDetailService;
        IWarehouseService _warehouseService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userService"></param>
        /// <param name="roleService"></param>
        /// <param name="itemsDetailService"></param>
        /// <param name="warehouseService"></param>
        public ExpCompanyController(IExpCompanyService service, IUserService userService, IRoleService roleService,IItemsDetailService itemsDetailService,IWarehouseService warehouseService)
        {
            this._itemsDetailService = itemsDetailService;
            this._userservice = userService;
            this._roleservice = roleService;
            this._service = service;
            this._warehouseService = warehouseService;
        }
        #endregion

        #region Post

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="GetDto">新增对象</param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> Add([FromBody]ExpCompanyGetDto GetDto)
        {
            try
            {
                var customers = await _service.QueryAsync();
                var customer = customers.Find(u => u.EnCode == GetDto.EnCode);
                if (customer != null)
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
        /// 修改快递
        /// </summary>
        /// <param name="Id">快递Id</param>
        /// <param name="GetDto">快递对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update([FromBody]ExpCompanyGetDto GetDto, string Id)
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
        /// 删除快递
        /// </summary>
        /// <param name="Id">快递Id</param> 
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
        /// 根据Id获取快递信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return Ok(await _service.QueryByIdAsync(Id));
        }

        /// <summary>
        /// 快递下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetSelectGrid")]
        public async Task<IActionResult> GetSelectGrid(string Id)
        {
            List<ExpCompanyGetDto> RdList = new List<ExpCompanyGetDto>();
            //返回信息  获取仓库列表
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
            //UserGetDto user = await _userservice.QueryByIdAsync(Id);
            //RoleGetDto role = await _roleservice.QueryByIdAsync(user.RoleId);
            //PagerEntity<ExpCompanyGetDto> entity = new PagerEntity<ExpCompanyGetDto>();
            //if (role.IsAdmin)
            //{
            PagerEntity<ExpCompanyGetDto> entity = await _service.QueryByPagesAsync(rows, page,
                      t => t.EnCode.Contains((keyword ?? t.EnCode)) ||
                      t.FullName.Contains(keyword ?? t.FullName),
                      _service.Expression(sidx), sord.ToUpper().Equals("ASC"));
            // }
            //  else
            //{
            //    entity = await _service.QueryByPagesAsync(rows, page,
            //         t => t.EnCode.Contains((keyword ?? t.EnCode)) ||
            //         t.FullName.Contains(keyword ?? t.FullName) &&
            //         t.UserId.Contains(Id ?? t.UserId),
            //         _service.Expression(sidx), sord.ToUpper().Equals("ASC"));
            //}

            if (entity.Entity!=null)
            {
                foreach (var item in entity.Entity)
                {
                    if (item.KDAccout!="")
                    {
                        ItemsDetailGetDto dto = await _itemsDetailService.QueryByIdAsync(item.KDAccout);
                        WarehouseGetDto warehouse = await _warehouseService.QueryByIdAsync(item.WarehouseCode);
                        item.KDAccoutName = dto == null ? "" : dto.ItemName;
                        item.WarehouseName = warehouse == null ? "" : warehouse.FullName;
                    }
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


    }
}