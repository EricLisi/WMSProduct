using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using KGM.Framework.WebApi.Model.Common;
using KGM.Framework.WebApi.Model.Condition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGM.Framework.WebApi.Controllers
{
    /// <summary>
    /// 公司管理接口
    /// </summary>

    public class CompanyController : Base.AppBaseController
    {
        #region 依赖注入
        ICompanyService _service;
          
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public CompanyController(ICompanyService service)
        {
            this._service = service;
        }
        #endregion


        #region Get 请求
        /// <summary>
        /// 根据Id获取菜单信息和他的按钮信息
        /// </summary>
        /// <param name="Id">模块Id</param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var entity = await _service.QueryByIdAsync<CompanySingleDto>(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }


        ///// <summary>
        ///// 获取全部信息
        ///// </summary> 
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var list = await _service.QueryAsync<ModuleSingleDto>();

        //    if (list == null || list.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(list);
        //}

        /// <summary>
        /// 获取模块属性结构
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetTreeJson")]
        public async Task<IActionResult> GetCompanyhTreeAsync()
        {
            var list = await _service.QueryAsync<CompanySingleDto>();

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
        ///// <summary>
        ///// 公司树菜单
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("GetTreeJson/{Id}")]
        //public async Task<IActionResult> GetTreeJson(string Id)
        //{
        //    UserGetDto user = await _userService.QueryByIdAsync(Id);//获取用户信息
        //    List<CompanyGetDto> RdList = new List<CompanyGetDto>();
        //    RoleGetDto role = await _roleService.QueryByIdAsync(user.RoleId);
        //    if (role.IsAdmin)
        //    {
        //        RdList = await _service.QueryAsync();
        //    }
        //    else
        //    {
        //        //根据用户ID找到用户所分配的公司权限
        //        List<UserCompanyGetDto> getDtos = await _userCompanyService.QueryAsync(u => u.UserId == Id);
        //        foreach (UserCompanyGetDto item in getDtos)
        //        {
        //            CompanyGetDto company = await _service.QueryByIdAsync(item.CompanyId);
        //            if (company != null)
        //            {
        //                RdList.Add(company);
        //            }
        //        }
        //        //返回信息


        //    }
        //    return Ok(GetTreeJsonStr(RdList));
        //}
        /// <summary>
        /// 分页条件查询(公司)
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetByPagesAsync")]
        public async Task<IActionResult> GetByPagesAsync([FromQuery]CompanyIndexCondition condition)
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
            var list = await _service.QueryCompanyByPagesAsync(pager, condList);
            //返回分页结果
            return PagerListAction(pager, list);
        }
        /// <summary>
        /// 分页条件查询(部门)
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetDepartmentByPagesAsync")]
        public async Task<IActionResult> GetDepartmentByPagesAsync([FromQuery]CompanyIndexCondition condition)
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
            var list = await _service.QueryDepartmentByPagesAsync(pager, condList);
            //返回分页结果
            return PagerListAction(pager, list);
        }
        #endregion

        #region Post请求
        /// <summary>
        /// 新增模块
        /// </summary>
        /// <param name="entity">模块对象</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]CompanySingleDto entity)
        {
            try
            {
                var companys = await _service.QueryAsync<CompanySingleDto>();
                if (companys.Find(it => it.EnCode == entity.EnCode) != null)
                {
                    return Ok(new { Status = false, Message = "此编码已存在，请重新输入" });
                }
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
        public async Task<IActionResult> Update(string Id, [FromBody]CompanySingleDto entity)
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