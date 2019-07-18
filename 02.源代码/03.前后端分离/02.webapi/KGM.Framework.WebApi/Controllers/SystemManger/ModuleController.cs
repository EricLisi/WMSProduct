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
    /// 菜单管理接口
    /// </summary>  
    public class ModuleController : Base.AppBaseController
    {
        #region 依赖注入
        IModuleService _service;
        IRoleService _roleService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">模块服务</param> 
        /// <param name="roleService">角色服务</param> 
        public ModuleController(IModuleService service,IRoleService roleService)
        {
            this._service = service;
            this._roleService = roleService;
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
            return Ok(await _service.QueryByIdAsync<ModuleSingleDto>(Id));
        }

        /// <summary>
        /// 获取模块树形结构
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetModuleTree")]
        public async Task<IActionResult> GetModuleTreeAsync()
        {
           
            var list = await _service.QueryAsync<ModuleSingleDto>();

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
        /// 获取模块按钮树形结构
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetModuleBtnTree")]
        public async Task<IActionResult> GetModuleBtnTreeAsync(string Id=null)
        {
            var list = await _service.QueryAllModule();
            var Rolelist = await _roleService.QueryByIdAsync<RoleSingleDto>(Id);
            if (list == null || list.Count == 0)
            {
                return NotFound();
            }
            //将数据变成属性结构
            var treelist = new List<TreeNode>();
            var tree = new List<TreeNode>();
            foreach (var d in list)
            {
                int moduleCheck = 0;
                if (Id != "0")
                {
                    moduleCheck= Rolelist.Modules.Find(it=>it.ModuleId==d.Id)!=null?1:0;
                }
                treelist.Add(new TreeNode
                {                   
                    Id = d.Id,
                    Text = d.FullName,
                    ParentId = d.ParentId,
                    CheckState=moduleCheck,//是否勾选节点
                    HasChildren = list.Find(it => it.ParentId.Equals(d.Id)) != null|| d.ButtonEntities.Find(it => it.ModuleId.Equals(d.Id)) != null,
                    ShowCheck = true,
                    Complete = true//指定点开节点不需要再次加载数据
                });
                if (d.ButtonEntities.Count != 0)
                {
                    foreach (var btn in d.ButtonEntities)
                    {
                        int btnCheck = 0;
                        if (Id != "0")
                        {
                            btnCheck = Rolelist.Buttons.Find(it => it.ModuleButtonId == btn.Id) != null ? 1 : 0;
                        }

                        treelist.Add(new TreeNode
                        {          
                            
                            Id = btn.Id,
                            Text = btn.FullName,
                            ParentId =d.Id,
                            CheckState= btnCheck,//是否勾选节点
                            ShowCheck = true,
                            HasChildren =false,
                            Complete= true//指定点开节点不需要再次加载数据
                        });
                    }
                }
            }
            ListToTreeJson(tree, "0", treelist);
            return Ok(tree);
        }
        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetModuleByPages")]
        public async Task<IActionResult> GetModuleByPagesAsync([FromQuery]ModuleIndexCondition condition)
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

            if (!string.IsNullOrEmpty(condition.ModuleId))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "ParentId",
                    Value = condition.ModuleId,
                    Operation = CommonEnum.ConditionOperation.Equal
                });
            }
            //数据库查询
            var entity = await _service.QueryModuleByPagesAsync(pager, condList);
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
        public async Task<IActionResult> Insert([FromBody]ModuleSingleDto entity)
        {
            try
            { 
                var modules = await _service.QueryAsync<ModuleSingleDto>(); 
                if(modules.Find(it => it.EnCode == entity.EnCode) != null)
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
        public async Task<IActionResult> Update(string Id, [FromBody]ModuleSingleDto entity)
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