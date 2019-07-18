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
    /// 地区管理接口
    /// </summary>
    public class AreaController : Base.AppBaseController
    {
        #region 依赖注入
        IAreaService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>

        public AreaController(IAreaService service)
        {

            this._service = service;

        }
        #endregion


        #region Post

        /// <summary>
        /// 新增地区
        /// </summary>
        /// <param name="SingleDto">地区对象</param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> Add([FromBody]AreaSingleDto SingleDto)
        {
            try
            {
                var areas = await _service.QueryAsync<AreaSingleDto>();
                var area = areas.Find(u => u.EnCode == SingleDto.EnCode);
                if (area != null)
                {
                    return Ok(new { Status = true, Message = "此编码已存在，请重新输入" });
                }

                var result = await _service.Insert(SingleDto);
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
        /// 更新地区
        /// </summary>
        /// <param name="Id">地区Id</param>
        /// <param name="SingleDto">地区对象</param>
        /// <returns></returns>
        [HttpPut, Route("{Id}")]
        public async Task<IActionResult> Update([FromBody]AreaSingleDto SingleDto, string Id)
        {
            try
            {
                var areas = await _service.QueryAsync<AreaSingleDto>();
                var area =  areas.Find(u => u.EnCode == SingleDto.EnCode);
                if (areas.Count > 0 && area.EnCode != SingleDto.EnCode)
                {
                    return Ok(new { Status = true, Message = "此编码已存在，请重新修改" });
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
        /// 删除地区
        /// </summary>
        /// <param name="Id">地区Id</param> 
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
        ///  获取所有地区信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetAllArea")]
        public async Task<IActionResult> GetAllArea([FromQuery]ModuleIndexCondition condition)
        {
            //设置分页对象
            var pager = SetPager(1, 99999, "EnCode", "ASC");
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
            var list = await _service.QueryAreaByPagesAsync(pager, condList);

            if (list == null || list.Entity == null || list.Entity.Count() == 0)
            {
                return NotFound();
            }
            //返回分页结果
            return PagerListAction(pager, list);
            //var entity = await _service.QueryAll();
            //if (entity == null)
            //{
            //    return NotFound();
            //}
            //return Ok(entity);
        }
        /// <summary>
        ///  根据根据Id获取地区信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var entity = await _service.QueryByIdAsync<AreaSingleDto>(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }
        /// <summary>
        /// 根据省份获取城市信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetCityByProvince/{Id}")]
        public async Task<IActionResult> GetCityByProvince(string Id)
        {
            var entity = await _service.QueryCityByProvinceAsync(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        [HttpGet, Route("GetByPagesAsync")]
        public async Task<IActionResult> GetByPagesAsync([FromQuery]ModuleIndexCondition condition)
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
            var list = await _service.QueryAreaByPagesAsync(pager, condList);

            if (list == null || list.Entity == null || list.Entity.Count() == 0)
            {
                return NotFound();
            }
            //返回分页结果
            return PagerListAction(pager, list);
        }
        #endregion

        ///// <summary>
        /////  根据ParentId获取部门信息
        ///// </summary>
        ///// <param name="parentId"></param>
        ///// <returns></returns>
        //[HttpGet, Route("Getlist")]
        //public async Task<IActionResult> Getlist(string parentId = "0")
        //{
        //    if (string.IsNullOrEmpty(parentId))
        //    {
        //        parentId = "0";
        //    }
        //    return Ok(await _service.QueryAsync(u => u.ParentId == parentId));

        //}

        ///// <summary>
        ///// 根据ParentId获取内容,如果为空则获取Tree类型的树
        ///// </summary>
        ///// <param name="Id">用户ID</param>
        ///// <param name="ParentId">节点Id</param>
        ///// <returns></returns>
        //[HttpGet, Route("GetTreeJson/{Id}")]
        //public async Task<IActionResult> GetTreeJson(string Id, string ParentId)
        //{
        //    List<AreaGetDto> RdList = null;
        //    if (!string.IsNullOrEmpty(ParentId))
        //    {
        //        RdList = await _service.QueryAsync(u => u.ParentId == ParentId);
        //        return Ok(RdList);
        //    }
        //    RdList = await _service.QueryAsync();
        //    return Ok(GetTreeJsonStr(RdList));
        //}

        ///// <summary>
        ///// 地区省树菜单
        ///// </summary>
        ///// <param name="Id">用户Id</param>
        ///// <returns></returns>
        //[HttpGet, Route("GetProvinceTreeJson/{Id}")]
        //public async Task<IActionResult> GetProvinceTreeJson(string Id)
        //{

        //    List<AreaGetDto> RdList = await _service.QueryAsync(u => u.ParentId.Equals("0"));
        //    return Ok(RdList);
        //}

        ///// <summary>
        ///// 地区市树菜单
        ///// </summary>
        ///// <param name="Id">用户Id</param>
        ///// <returns></returns>
        //[HttpGet, Route("GetCityTreeJson/{Id}")]
        //public async Task<IActionResult> GetCityTreeJson(string Id)
        //{
        //    List<AreaGetDto> RdList = await _service.QueryAsync<AreaGetDto>(u => u.ParentId != "0");
        //    return Ok(RdList);
        //}


        /// <summary>
        /// 获取模块属性结构
        /// </summary> 
        /// <returns></returns>
        [HttpGet, Route("GetTreeJson")]
        public async Task<IActionResult> GetAreahTreeAsync()
        {
            var list = await _service.QueryAsync<AreaSingleDto>();

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
        ///// 获取树形结构JSon
        ///// </summary>
        ///// <param name="data">数据对象集合</param>
        ///// <returns></returns>
        //protected virtual string GetTreeJsonStr(List<AreaGetDto> data)
        //{
        //    var treeList = new List<TreeViewModel>();
        //    foreach (AreaGetDto item in data)
        //    {
        //        var count = data.Count(t => t.ParentId == item.Id);
        //        var count1 = data.FindAll(t => t.ParentId == item.Id).Count();
        //        if (count > 0 || count1 > 0)
        //        {
        //            var a = count1;
        //        }
        //        TreeViewModel tree = new TreeViewModel();
        //        tree.hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
        //        tree.id = item.Id;
        //        tree.isexpand = true;
        //        tree.complete = true;
        //        tree.text = item.FullName;
        //        tree.value = item.EnCode;
        //        tree.parentId = item.ParentId;
        //        treeList.Add(tree);
        //    }
        //    return TreeViewJson(treeList);
        //}

        ///// <summary>
        ///// 不分页查询 + 条件查询
        ///// </summary>
        ///// <param name="keyword">查询内容</param>
        ///// <param name="sidx">排序字段</param>
        ///// <param name="sord">升序降序</param>
        ///// <param name="Id">用户Id</param>
        ///// <returns></returns>
        //[HttpGet("GetListByWhere/{Id}")]
        //public async Task<IActionResult> GetListByWhere(string keyword, string sidx, string sord, string Id)
        //{

        //    if (string.IsNullOrEmpty(sidx))
        //    {
        //        sidx = "SortCode";
        //    }
        //    if (string.IsNullOrEmpty(sord))
        //    {
        //        sord = "ASC";
        //    }

        //    PagerEntity<AreaGetDto> entity = new PagerEntity<AreaGetDto>();

        //    entity = await _service.QueryByPagesAsync(
        //          t => t.EnCode.Contains((keyword ?? t.EnCode)) ||
        //          t.FullName.Contains(keyword ?? t.FullName),
        //          _service.Expression(sidx), sord.ToUpper().Equals("ASC"));


        //    return Ok(Extensions.ToJson(entity.Entity));

        //}

        ///// <summary>
        ///// 分页查询 + 条件查询
        ///// </summary>
        ///// <param name="keyword">查询内容</param>
        ///// <param name="rows">行数</param>
        ///// <param name="page">页码</param>
        ///// <param name="sidx">排序字段</param>
        ///// <param name="sord">升序降序</param>
        ///// <param name="Id">用户Id</param>
        ///// <returns></returns>
        //[HttpGet("GatPagerListByWhere/{Id}")]
        //public async Task<IActionResult> GatPagerListByWhere(string keyword, int rows, int page, string sidx, string sord, string Id)
        //{

        //    if (string.IsNullOrEmpty(sidx))
        //    {
        //        sidx = "SortCode";
        //    }

        //    PagerEntity<AreaGetDto> entity = new PagerEntity<AreaGetDto>();

        //    entity = await _service.QueryByPagesAsync(rows, page,
        //          t => t.EnCode.Contains((keyword ?? t.EnCode)) ||
        //          t.FullName.Contains(keyword ?? t.FullName),
        //          _service.Expression(sidx), sord.ToUpper().Equals("ASC"));

        //    //设置返回格式
        //    ReturnEntity RtEntity = new ReturnEntity();
        //    RtEntity.rows = entity.Entity;
        //    RtEntity.page = page;
        //    RtEntity.records = entity.Total;
        //    int Count = entity.Total / rows;//获取除数
        //    int yu = entity.Total % rows;//获取余数
        //    if (yu > 0)//如果余数大于0则加一页，否则不加
        //    {
        //        RtEntity.total = Count + 1;
        //    }
        //    else
        //    {
        //        RtEntity.total = Count + 0;
        //    }
        //    return Ok(Extensions.ToJson(RtEntity));
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
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
        //            strJson.Append("\"isexpand\":" + entity.isexpand + ",");
        //            strJson.Append("\"complete\":" + entity.complete + ",");
        //            strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");
        //            strJson.Append("\"ChildNodes\":" + TreeViewJson(data, entity.id) + "");
        //            strJson.Append("},");
        //        }
        //        strJson = strJson.Remove(strJson.Length - 1, 1);
        //    }
        //    strJson.Append("]");
        //    return strJson.ToString();
        //}
    }
}