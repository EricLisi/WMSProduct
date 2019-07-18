using KGM.Framework.Application.Dtos;
using KGM.Framework.Application.Services;
using KGM.Framework.Infrastructure;
using KGM.Framework.WebApi.Model.Common;
using KGM.Framework.WebApi.Model.Condition;
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
    /// 部门管理接口
    /// </summary>
    public class DepartmentController : Base.AppBaseController
    {
        #region 依赖注入
        ICompanyService _companyService;
        IDepartmentService _service;
        IUserService _userservice;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userservice"></param>
        /// /// <param name="companyService"></param>
        public DepartmentController(IDepartmentService service,IUserService userservice, ICompanyService companyService)
        {
            this._service = service;
            this._userservice = userservice;
            this._companyService = companyService;
        }
        #endregion
        #region Post
        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="GetDto">部门对象</param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> Add([FromBody]DepartmentSingleDto GetDto)
        {
            try
            {
                GetDto.ParentId = "0";
                var result = await _service.Insert(GetDto);
                if (result > 0)
                {
                    return Ok(new { Status = true, Message = "添加成功" });
                }
                return Ok(new { Status = false, Message = "添加失败，请刷新后重试" });


            }
            catch (Exception ex)
            {
                return OKAction(false, $"创建失败!原因:{ex.Message}");
            }
        }
        #endregion
        #region Put
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="Id">部门对象</param>
        /// <param name="SingleDto">部门对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update([FromBody]DepartmentSingleDto SingleDto, string Id)
        {
            try
            {
                var Departments = await _service.QueryAsync<DepartmentSingleDto>();
                var Department = Departments.Find(u=>u.EnCode==SingleDto.EnCode);
                if (Department!=null&&Department.EnCode!=SingleDto.EnCode)
                {
                    return Ok(new { Status = false, Message = "此编码已存在，请重新修改" });
                }

                SingleDto.Id = Id;
                var result = await _service.Update(SingleDto);
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
        /// 删除部门
        /// </summary>
        /// <param name="Id">部门Id</param> 
        /// <returns></returns>
        [HttpDelete, Route("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var result = await _service.DeleteByKey(Id);
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
        /// 获取模块属性结构
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetTreeJson")]
        public async Task<IActionResult> GetDepartmentTreeAsync()
        {
            var list = await _service.QueryAsync<DepartmentSingleDto>();

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
            if (!string.IsNullOrEmpty(condition.CompanyId))
            {
                condList.Add(new SearchCondition
                {
                    Filed = "CompanyId",
                    Value = condition.CompanyId,
                    Operation = CommonEnum.ConditionOperation.Equal
                });
            }

            //数据库查询
            var list = await _service.QueryDepartmentByPagesAsync(pager, condList);

            //返回分页结果
            return PagerListAction(pager, list);
        }
        /// <summary>
        /// 根据Id获取部门信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var entity = await _service.QueryByIdAsync<DepartmentSingleDto>(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        ///// <summary>
        ///// 部门树菜单
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("GetTreeJson/{Id}")]
        //public async Task<IActionResult> GetTreeJson(string Id)
        //{
        //    UserGetDto user = await _userservice.QueryByIdAsync(Id);//获取用户信息
        //    //List<WarehouseGetDto> RdList = new List<WarehouseGetDto>();
        //    RoleGetDto role = await _roleservice.QueryByIdAsync(user.RoleId);


        //    List<DepartmentGetDto> dtos = new List<DepartmentGetDto>();
        //    if (role.IsAdmin)
        //    {
        //        dtos = await _service.QueryAsync();//获取所有部门信息
        //    }
        //    else
        //    {
        //        List<UserDepartmentGetDto> dList = await _userDepartmentService.QueryAsync(u => u.UserId == Id);
        //        foreach (var item in dList)
        //        {
        //            DepartmentGetDto getDto = await _service.QueryByIdAsync(item.DepartmentId);
        //            dtos.Add(getDto);

        //        }


        //    }

        //    return Ok(GetTreeJsonStr(dtos));
        //}


        ///// <summary>
        ///// 获取下拉框部门信息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("GetSelectGrid/{Id}")]
        //public async Task<IActionResult> GetSelectGrid(string Id)
        //{
        //    UserGetDto user = await _userservice.QueryByIdAsync(Id);//获取用户信息
        //    List<DepartmentGetDto> RdList = new List<DepartmentGetDto>();
        //    RoleGetDto role = await _roleservice.QueryByIdAsync(user.RoleId);
        //    if (role.IsAdmin)
        //    {
        //        RdList = await _service.QueryAsync();//获取所有部门信息
        //    }
        //    else
        //    {
        //        List<UserDepartmentGetDto> dList = await _userDepartmentService.QueryAsync(u => u.UserId == Id);
        //        foreach (var item in dList)
        //        {
        //            DepartmentGetDto getDto = await _service.QueryByIdAsync(item.DepartmentId);
        //            RdList.Add(getDto);

        //        }


        //    }
        //    List<SelectModel> selectModels = new List<SelectModel>();
        //    for (int i = 0; i < RdList.Count; i++)
        //    {
        //        SelectModel select = new SelectModel
        //        {
        //            Id = RdList[i].Id,
        //            Text = RdList[i].FullName
        //        };
        //        selectModels.Add(select);
        //    }



        //    return Ok(selectModels);
        //}



        ///// <summary>
        ///// 分页查询 + 条件查询
        ///// </summary>
        ///// <param name="rows">每页大小</param>
        ///// <param name="page">当前页码</param>
        ///// <param name="EnCode">编码</param> 
        ///// <param name="FullName">名称</param> 
        ///// <param name="sord">是否升序</param> 
        ///// <param name="Id">登陆用户ID</param> 
        ///// <param name="CompanyId">登陆用户ID</param> 
        ///// <param name="sidx">排序字段</param> 
        //[HttpGet("GatPagerListByWhere/{Id}")]
        //public async Task<IActionResult> GatPagerListByWhere(string EnCode = "",string sidx="", string FullName = "",string CompanyId="",int rows = 20, int page = 1, string sord = "ASC", string Id = "")
        //{
        //    bool isAsc = false;

        //    if (sord.ToUpper() == "ASC")
        //    {
        //        isAsc = true;
        //    }
        //    UserGetDto user = await _userservice.QueryByIdAsync(Id);//获取用户信息
        //    RoleGetDto role = await _roleservice.QueryByIdAsync(user.RoleId);//获取当前登录用户
        //    PagerEntity<DepartmentGetDto> entity = new PagerEntity<DepartmentGetDto>();
        //    List<CompanyGetDto> list = null;
        //    if (!string.IsNullOrEmpty(CompanyId))
        //    {
        //        list = await _companyService.QueryAsync(u => u.Id == CompanyId || u.ParentId == CompanyId);
        //    }
        //    if (string.IsNullOrEmpty(sidx))
        //    {
        //        sidx = "SordCode";
        //    }
        //    if (role.IsAdmin)
        //    {
        //        entity = await _service.QueryByPagesAsync(rows, page,
        //        t => t.EnCode.Contains((EnCode ?? t.EnCode)) &&
        //        t.FullName.Contains(FullName ?? t.FullName) &&
        //        list == null ? true:list.Find(u=>u.Id==t.CompanyId)!=null
        //        , _service.Expression(sidx), isAsc);
        //    }
        //    else
        //    {
        //        List<UserDepartmentGetDto> dList = await _userDepartmentService.QueryAsync(u => u.UserId == Id);
        //        entity = await _service.QueryByPagesAsync(rows, page,
        //        t => t.EnCode.Contains((EnCode ?? t.EnCode)) &&
        //        t.FullName.Contains(FullName ?? t.FullName) &&
        //        dList.Find(u=>u.DepartmentId==t.Id)!=null, _service.Expression(sidx), isAsc);

        //    }
        //    //设置返回格式
        //    ReturnEntity RtEntity = new ReturnEntity();
        //    RtEntity.rows = entity.Entity;
        //    RtEntity.page = page;
        //    RtEntity.records = entity.Total;
        //    int Count = entity.Total / rows;//获取除数
        //    int yu = entity.Total % rows;//获取余数
        //    if (yu > 0)//如果余数大于0则加一页，否则不加
        //    {
        //        yu = 1;
        //    }
        //    else
        //    {
        //        yu = 0;
        //    }
        //    RtEntity.total = Count + yu;


        //    return Ok(Extensions.ToJson(RtEntity));
        //}


        #endregion
        //#region 私人方法
        ///// <summary>
        ///// 获取树形结构JSon
        ///// </summary>
        ///// <param name="data">数据对象集合</param>
        ///// <returns></returns>
        //protected virtual string GetTreeJsonStr(List<DepartmentGetDto> data)
        //{
        //    var treeList = new List<TreeViewModel>();
        //    foreach (DepartmentGetDto item in data)
        //    {
        //        TreeViewModel tree = new TreeViewModel();
        //        bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
        //        tree.id = item.Id;
        //        tree.text = item.FullName;
        //        tree.value = item.EnCode;
        //        tree.parentId = item.ParentId;
        //        tree.isexpand = true;
        //        tree.complete = true;
        //        tree.showcheck = item.Showcheck;
        //        tree.img = item.Icon;
        //        tree.hasChildren = hasChildren;
        //        treeList.Add(tree);
        //    }
        //    return TreeViewJson(treeList);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="parentId"></param>
        ///// <returns></returns>
        //public static string TreeViewJson(List<TreeViewModel> data, string parentId = "0")
        //{
        //    StringBuilder strJson = new StringBuilder();
        //    List<TreeViewModel> item = data.FindAll(t => t.parentId == parentId);
        //    strJson.Append("[");
        //    if (item.Count > 0)
        //    {
        //        foreach (TreeViewModel entity in item)
        //        {
        //            strJson.Append("{");
        //            strJson.Append("\"id\":\"" + entity.id + "\",");
        //            strJson.Append("\"text\":\"" + entity.text.Replace("&nbsp;", "") + "\",");
        //            strJson.Append("\"value\":\"" + entity.value + "\",");
        //            strJson.Append("\"parentId\":\"" + entity.parentId + "\",");
        //            if (entity.title != null && !string.IsNullOrEmpty(entity.title.Replace("&nbsp;", "")))
        //            {
        //                strJson.Append("\"title\":\"" + entity.title.Replace("&nbsp;", "") + "\",");
        //            }
        //            if (entity.img != null && !string.IsNullOrEmpty(entity.img.Replace("&nbsp;", "")))
        //            {
        //                strJson.Append("\"icon\":\"" + entity.img.Replace("&nbsp;", "") + "\",");
        //            }
        //            if (entity.checkstate != null)
        //            {
        //                strJson.Append("\"checkstate\":" + entity.checkstate + ",");
        //            }
        //            if (entity.parentId != null)
        //            {
        //                strJson.Append("\"parentnodes\":\"" + entity.parentId + "\",");
        //            }
        //            strJson.Append("\"showcheck\":" + entity.showcheck.ToString().ToLower() + ",");
        //            strJson.Append("\"isexpand\":" + entity.isexpand.ToString().ToLower() + ",");
        //            if (entity.complete == true)
        //            {
        //                strJson.Append("\"complete\":" + entity.complete.ToString().ToLower() + ",");
        //            }
        //            strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");
        //            strJson.Append("\"ChildNodes\":" + TreeViewJson(data, entity.id) + "");
        //            strJson.Append("},");
        //        }
        //        strJson = strJson.Remove(strJson.Length - 1, 1);
        //    }
        //    strJson.Append("]");
        //    return strJson.ToString();
        //}
        //#endregion
    }
}