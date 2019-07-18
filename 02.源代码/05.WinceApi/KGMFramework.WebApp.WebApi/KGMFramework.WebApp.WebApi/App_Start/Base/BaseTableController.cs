using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGM.Pager.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 单表基本控制器
    /// </summary>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="T"></typeparam>
    //[Route, RoutePrefix("api/{Controller}")]
    public class BaseTableController<B, T> : BaseController<B, T>
        where B : BaseBLL<T>
        where T : AppBaseEntity, new()
    {
        #region 公开接口

        /// <summary>
        /// 返回实体对象
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<List<T>> GetEntity()
        {
            return await FindAsync(null);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IHttpActionResult> GetEntity(string keyValue)
        {
            var entity = await FindByIdAsync(keyValue);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                return Content<T>(System.Net.HttpStatusCode.OK, entity);
            }
        }

        /// <summary>
        /// 插入一个对象
        /// </summary>
        /// <param name="entity">对象</param>
        /// <returns>对象</returns>
        [HttpPost, Route("SubmitForm")]
        public virtual async Task<IHttpActionResult> SubmitForm([FromBody]T entity)
        {
            entity.F_Id = Guid.NewGuid().ToString();
            entity.F_CreatorTime = DateTime.Now;
            entity.F_CreatorUserId = currentUserId;
            if (entity as Sys_UserInfo != null)
            {
                (entity as Sys_UserInfo).F_UserPassword = DESEncrypt.Encrypt((entity as Sys_UserInfo).F_UserPassword);
            }
            return await Task.Run(() =>
            {
                BLLFactory<B>.Instance.Insert(entity);
                return Content(System.Net.HttpStatusCode.Created, new AjaxResult { state = ResultType.success.ToString(), message = "添加成功", data = entity });
            });
        }

        ///// <summary>
        ///// 提交信息
        ///// </summary>
        ///// <param name="info">表实体</param>
        ///// <param name="keyValue">主键</param>
        ///// <returns></returns>
        //[HttpPost]
        //public virtual async Task<IHttpActionResult> SubmitForm(T info, string keyValue)
        //{
        //    if (keyValue != null)
        //    {
        //        //修改保存
        //        var entity = await FindByIdAsync(keyValue);
        //        if (entity == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            info.F_Id = keyValue;
        //            info.F_LastModifyTime = DateTime.Now;
        //            info.F_LastModifyUserId = currentUserId;
        //            BLLFactory<B>.Instance.Delete(keyValue);
        //            BLLFactory<B>.Instance.InsertUpdate(info, keyValue);
        //            return Content(System.Net.HttpStatusCode.OK, info);
        //        }
        //    }
        //    else
        //    {
        //        //新增保存
        //        info.F_Id = System.Guid.NewGuid().ToString();
        //        info.F_CreatorTime = DateTime.Now;
        //        info.F_CreatorUserId = currentUserId;
        //        BLLFactory<B>.Instance.Insert(info);
        //        return Content(System.Net.HttpStatusCode.Created, info);
        //    }
        //}

        /// <summary>
        /// 根据ID修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPut, Route("SubmitForm")]
        public virtual async Task<IHttpActionResult> SubmitForm(string keyValue, [FromBody] T entity)
        {
            var model = await FindByIdAsync(keyValue);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                entity.F_Id = keyValue;
                entity.F_CreatorTime = DateTime.Now;
                entity.F_CreatorUserId = currentUserId;

                if (entity as Sys_UserInfo != null)
                {
                    (entity as Sys_UserInfo).F_UserPassword = DESEncrypt.Encrypt((entity as Sys_UserInfo).F_UserPassword);
                }

                return await Task.Run(() =>
                {
                    BLLFactory<B>.Instance.InsertUpdate(entity, keyValue);
                    return Content(System.Net.HttpStatusCode.OK, entity);
                });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns>主键</returns>
        [HttpDelete]
        public virtual async Task<bool> Delete(string keyValue)
        {
            
            return await DeleteByIdAsync(keyValue);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="searchFiled"></param>
        /// <param name="list"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet, Route("GetGridJsonPagination")]
        public virtual async Task<IHttpActionResult> GetGridJsonPagination(string keyword, string searchFiled, string list=null,string page = "1", string rows = "50")
        {
            SearchCondition condition=new SearchCondition();
            //过滤条件
            if (string.IsNullOrEmpty(list))
            {
                condition = GetKeywordConditionObj(keyword, searchFiled);
            }
            else
            {
                List<AdvSearchEntity> a = JsonConvert.DeserializeObject<List<AdvSearchEntity>>(list);
                condition = GetAdvCondition(a);
            }
            PagerInfo pager = null;
            if (!string.IsNullOrEmpty(page))
            {
                pager = new PagerInfo();
                pager.PageSize = string.IsNullOrEmpty(rows) ? 50 : Convert.ToInt32(rows);
                pager.CurrenetPageIndex = string.IsNullOrEmpty(page) ? 1 : Convert.ToInt32(page);
            }
            var list1 = await base.GetPagerDataAsync(condition, pager);
            return Content(HttpStatusCode.OK, list1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected SearchCondition GetAdvCondition(List<AdvSearchEntity> list)
        {
            SearchCondition condition = new SearchCondition();
            foreach (AdvSearchEntity entity in list)
            {
                switch (entity.F_type)
                {
                    case "0":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.Equal);
                        break;//等于
                    case "1":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.NotEqual);
                        break;//不等于
                    case "2":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.Like);
                        break;//包含
                    case "3":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.NotLike);
                        break;//不包含
                    case "4":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.MoreThan);
                        break;//大于
                    case "5":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.MoreThanOrEqual);
                        break;//大于等于
                    case "6":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.LessThan);
                        break;//小于
                    case "7":
                        condition.AddCondition(entity.F_searchFiled, entity.F_fvalue, SqlOperator.LessThanOrEqual);
                        break;//小于等于
                }
            }
            return condition;
        }
        #endregion
    }
}
