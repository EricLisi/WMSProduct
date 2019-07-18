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
    /// 条码规则设置
    /// </summary>
    public class BarCodeRuleController : Base.AppBaseController
    {
        #region 依赖注入
        IBarCodeRuleMainService _service;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">模块服务</param> 
        public BarCodeRuleController(IBarCodeRuleMainService service)
        {
            this._service = service;
        }
        #endregion 

        #region Get 请求
        /// <summary>
        /// 根据Id获取条码规则信息和他的子表信息
        /// </summary>
        /// <param name="Id">条码规则Id</param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            return Ok(await _service.QueryByIdAsync<BarCodeRuleMainSingleDto>(Id));
        }

        ///// <summary>
        ///// 获取条码规则属性结构
        ///// </summary> 
        ///// <returns></returns>
        //[HttpGet, Route("GetBarCodeRuleTree")]
        //public async Task<IActionResult> GetModuleTreeAsync()
        //{
        //    var list = await _service.QueryAsync<BarCodeRuleGridDto>();

        //    if (list == null || list.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    //将数据变成属性结构
        //    var treelist = new List<TreeNode>();
        //    var tree = new List<TreeNode>();
        //    foreach (var d in list)
        //    {
        //        treelist.Add(new TreeNode
        //        {
        //            Id = d.Id,
        //            Text = d.FullName,
        //            ParentId = d.ParentId,
        //            HasChildren = list.Find(it => it.ParentId.Equals(d.Id)) != null,
        //            Complete = true//指定点开节点不需要再次加载数据
        //        });
        //    }
        //    ListToTreeJson(tree, "0", treelist);
        //    return Ok(tree);
        //}

        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetBarCodeRuleByPages")]
        public async Task<IActionResult> GetBarCodeRuleByPagesAsync([FromQuery]BarCodeRuleIndexCondition condition)
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
            var entity = await _service.QueryBarCodeRuleByPagesAsync(pager, condList);
            //返回分页结果
            return PagerListAction(pager, entity);
        }
        #endregion

        #region Post请求
        /// <summary>
        /// 新增模块
        /// </summary>
        /// <param name="entity">模块对象</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]BarCodeRuleMainSingleDto entity)
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
        /// 更新模块
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="entity">模块对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update(string Id, [FromBody]BarCodeRuleMainSingleDto entity)
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
        /// 删除模块
        /// </summary>
        /// <param name="Id">模块Id</param>
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