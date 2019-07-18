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
    /// 数据字典管理接口
    /// </summary>  
    public class DictionaryController : Base.AppBaseController
    {
        #region 依赖注入
        IDictionaryService _service;
        


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">数据字典服务</param> 
        public DictionaryController(IDictionaryService service)
        {
            this._service = service;
        }
        #endregion 

        #region Get 请求
        /// <summary>
        /// 根据Id获取菜单信息和他的按钮信息
        /// </summary>
        /// <param name="Id">数据字典Id</param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            return Ok(await _service.QueryByIdAsync<DictionarySingleDto>(Id));
        }

        /// <summary>
        /// 获取数据字典属性结构
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetDictionaryTree")]
        public async Task<IActionResult> GetDictionaryTreeAsync()
        {
            var list = await _service.QueryAsync<DictionaryGridDto>();

            if (list == null || list.Count == 0)
            {
                return NotFound();
            }

            //将数据变成属性结构
            var treelist = new List<TreeNode>();
            var tree = new List<TreeNode>();
            foreach (var d in list)
            {
                treelist.Add(new TreeNode
                {
                    Id = d.Id,
                    Text = d.FullName,
                    ParentId = d.ParentId,
                    HasChildren = list.Find(it => it.ParentId.Equals(d.Id)) != null,
                    Complete = true//指定点开节点不需要再次加载数据
                });
            }
            ListToTreeJson(tree, "0", treelist);
            return Ok(tree);
        }

        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetDictionaryItemByPages")]
        public async Task<IActionResult> GetDictionaryItemByPagesAsync([FromQuery]DictionaryItemIndexCondition condition)
        {
            //设置分页对象
            var pager = SetPager(condition.Page, condition.Rows, condition.SIdx, condition.Sord);
            //设置过滤条件
            var condList = new List<SearchCondition>();
            if (!string.IsNullOrEmpty(condition.ItemCode))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "ItemCode",
                    Value = condition.ItemCode,
                    Operation = CommonEnum.ConditionOperation.Like
                });
            }
            if (!string.IsNullOrEmpty(condition.ItemName))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "ItemName",
                    Value = condition.ItemName,
                    Operation = CommonEnum.ConditionOperation.Like
                });
            }

            if (!string.IsNullOrEmpty(condition.ItemId))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "ItemId",
                    Value = condition.ItemId,
                    Operation = CommonEnum.ConditionOperation.Equal
                });
            }
            //数据库查询
            var entity = await _service.QueryItemByPagesAsync(pager, condList);
            //返回分页结果
            return PagerListAction(pager, entity);
        }



        /// <summary>
        /// 分页条件查询 主表
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetDictionaryByPages")]
        public async Task<IActionResult> GetDictionaryByPagesAsync([FromQuery]DictionaryIndexCondition condition)
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

            //if (!string.IsNullOrEmpty(condition.ItemId))
            //{
            //    condList.Add(new SearchCondition
            //    {
            //        Filed = "ItemId",
            //        Value = condition.ItemId,
            //        Operation = CommonEnum.ConditionOperation.Equal
            //    });
            //}
            //数据库查询
            var entity = await _service.QueryDictionaryByPagers(pager, condList);
            //返回分页结果
            return PagerListAction(pager, entity);
        }
        #endregion

        #region Post请求
        /// <summary>
        /// 新增数据字典
        /// </summary>
        /// <param name="entity">数据字典对象</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]DictionarySingleDto entity)
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
        /// 更新数据字典分类
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="entity">数据字典对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update(string Id, [FromBody]DictionarySingleDto entity)
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


        ///// <summary>
        ///// 更新数据字典
        ///// </summary>
        ///// <param name="Id">主键</param>
        ///// <param name="entity">数据字典对象</param>
        ///// <returns></returns>
        //[HttpPut, Route("{Id}")]
        //public async Task<IActionResult> UpdateDetail(string Id, [FromBody]DictionaryDetailSingleDto entity)
        //{
        //    try
        //    {
        //        entity.Id = Id;
        //        int rows = await _service.UpdateDetail(entity);//得到影响行数
        //        if (rows > 0)
        //        {
        //            return OKAction(true, "更新成功");
        //        }

        //        return NotFoundAction(false, "更新失败!原因:影响行数为0");
        //    }
        //    catch (Exception ex)
        //    {
        //        return OKAction(false, $"更新失败!原因:{ex.Message}");
        //    }
        //}

        #endregion

        #region Delete请求
        /// <summary>
        /// 删除数据字典分类
        /// </summary>
        /// <param name="Id">数据字典Id</param>
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

        ///// <summary>
        ///// 删除子表
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //[HttpDelete, Route("DeleteDetail/{Id}")]
        //public async Task<IActionResult> DeleteDetail(string Id)
        //{
        //    try
        //    {
        //        int rows = await _service.DeleteDetail(Id);//得到影响行数
        //        if (rows > 0)
        //        {
        //            return NoContentAction();
        //        }

        //        return NotFoundAction(false, "删除失败!原因:影响行数为0");
        //    }
        //    catch (Exception ex)
        //    {
        //        return OKAction(false, $"删除失败!原因:{ex.Message}");
        //    }
        //}
        #endregion
    }
}