using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.WebApi.Models;
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
    /// 
    /// </summary>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="D"></typeparam>
    /// <typeparam name="E"></typeparam>
    public class BaseListController<B, T, D, E> : BaseController<B, T>
        where B : BaseBLL<T>
        where T : AppBaseEntity, new()
        where D : BaseBLL<E>
        where E : AppBaseEntity, new()
    {
        #region 公开接口
        /// <summary>
        /// 查询主表信息 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<T>> GetHeadAll()
        {
            return await Task.Run(() =>
            {
                return BLLFactory<B>.Instance.Find(null);
            });
        }


        /// <summary>
        /// 根据主表ID获取子表信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="head"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetBodyByHeadid(string id, T head, E entity)
        {
            if (head.F_Id != id)
            {
                return NotFound();
            }
            else
            {
                return await Task.Run(() =>
                {
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("'entity'", id, SqlOperator.Equal);
                    var data = BLLFactory<D>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
                    return Content(System.Net.HttpStatusCode.OK, data);
                });
            }
        }


        /// <summary>
        /// 根据ID删除主表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DelHead(string id)
        {
            return await Task.Run(() =>
            {
                return BLLFactory<B>.Instance.Delete(id);
            });
        }

        #endregion

        /// <summary>
        /// 设置主表信息
        /// </summary>
        /// <returns></returns>
        public virtual T SetHeadData(T head)
        {
            return null;
        }
    }
}
