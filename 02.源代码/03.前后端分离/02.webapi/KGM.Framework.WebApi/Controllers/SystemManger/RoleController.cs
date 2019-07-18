using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using KGM.Framework.WebApi.Model.Common;
using KGM.Framework.WebApi.Model.Condition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers
{
    /// <summary>
    /// 角色管理接口
    /// </summary> 
    public class RoleController : Base.AppBaseController
    {
        #region 依赖注入
        IRoleService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">模块服务</param> 
        public RoleController(IRoleService service)
        {
            this._service = service;
        }
        #endregion

        #region Get 请求
        /// <summary>
        /// 绑定角色下拉框
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetSelectJson")]
        public async Task<IActionResult> GetSelectJson()
        {
            var list = await _service.QueryAsync<RoleSingleDto>();

            if (list == null || list.Count == 0)
            {
                return NotFound();
            }

            List<object> data = new List<object>();
            foreach (RoleSingleDto item in list)
            {
                data.Add(new { id = item.Id, text = item.FullName });
            }
            return Ok(data);
        }
        /// <summary>
        /// 根据Id获取菜单信息和他的按钮信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var entity = await _service.QueryByIdAsync<RoleSingleDto>(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }


        /// <summary>
        /// 获取全部信息
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = await _service.QueryAsync<RoleSingleDto>();

            if (list == null || list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetByPagesAsync")]
        public async Task<IActionResult> GetByPagesAsync([FromQuery]RoleIndexCondition condition)
        {
            //设置分页对象
            var pager = SetPager(condition.Page, condition.Rows, condition.SIdx, condition.Sord);
            //设置过滤条件
            var condList = new List<SearchCondition>();
            if (!string.IsNullOrEmpty(condition.EnCode))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "EnCode",
                    Value = condition.EnCode,
                    Operation = CommonEnum.ConditionOperation.Like
                });
            }
            if (!string.IsNullOrEmpty(condition.FullName))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "FullName",
                    Value = condition.FullName,
                    Operation = CommonEnum.ConditionOperation.Like
                });
            }

            //数据库查询
            var entity = await _service.QueryRoleByPagesAsync(pager, condList);

            //返回分页结果
            return PagerListAction(pager, entity);
        }
        #endregion

        #region Post请求
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="entity">角色对象</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]RoleSingleDto entity)
        {
            try
            {
                int rows = await _service.Insert(entity);//得到影响行数
                if (rows > 0)
                {
                    return CreateAction();
                }

                return OKAction(false, "创建失败!原因:影响行数为0");
            }
            catch (Exception ex)
            {
                return OKAction(false, $"创建失败!原因:{ex.Message}");
            }
        }
        #endregion

        #region Put请求
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="entity">角色对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update(string Id, [FromBody]RoleSingleDto entity)
        {
            try
            {
                entity.Id = Id;
                int rows = await _service.Update(entity);//得到影响行数
                if (rows > 0)
                {
                    return OKAction(true, "更新成功");
                }

                return NotFoundAction(false, "更新失败!原因:影响行数为0");
            }
            catch (Exception ex)
            {
                return OKAction(false, $"更新失败!原因:{ex.Message}");
            }
        }
        #endregion

        #region Delete请求
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns></returns>
        [HttpDelete, Route("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                int rows = await _service.DeleteByKey(Id);//得到影响行数
                if (rows > 0)
                {
                    return NoContentAction();
                }

                return NotFoundAction(false, "删除失败!原因:影响行数为0");
            }
            catch (Exception ex)
            {
                return OKAction(false, $"删除失败!原因:{ex.Message}");
            }
        }
        #endregion

    }
}