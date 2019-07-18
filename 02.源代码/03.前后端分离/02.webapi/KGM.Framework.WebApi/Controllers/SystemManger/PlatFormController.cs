﻿using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using KGM.Framework.WebApi.Model.Condition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers.SystemManger
{
    /// <summary>
    /// 平台控制器
    /// </summary>
    public class PlatFormController : Base.AppBaseController
    {
        #region 依赖注入
        IPlatFormService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">模块服务</param> 
        public PlatFormController(IPlatFormService service)
        {
            this._service = service;
        }
        #endregion 


        #region Get 请求
        /// <summary>
        /// 根据Id获取菜单信息和他的按钮信息
        /// </summary>
        /// <param name="Id">平台Id</param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var entity = await _service.QueryByIdAsync<PlatFormSingleDto>(Id);
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
            var list = await _service.QueryAsync<PlatFormSingleDto>();

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
        [HttpGet, Route("GetByPages")]
        public async Task<IActionResult> GetByPagesAsync([FromQuery]PlatFormIndexCondition condition)
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
            var list = await _service.QueryByPagesAsync<PlatFormSingleDto>(pager, condList);

            if (list == null || list.Entity == null || list.Entity.Count() == 0)
            {
                return NotFound();
            }
            //返回分页结果
            return PagerListAction(pager, list);
        }
        #endregion

        #region Post请求
        /// <summary>
        /// 新增平台
        /// </summary>
        /// <param name="entity">平台对象</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]PlatFormInsertDto entity)
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
        /// 更新平台
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="entity">平台对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update(string Id, [FromBody]PlatFormInsertDto entity)
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
        /// 删除平台
        /// </summary>
        /// <param name="Id">平台Id</param>
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