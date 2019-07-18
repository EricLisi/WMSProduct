using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGM.Pager.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using KGMFramework.WebApp.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
   // [WebApiAuthorize]
    public class BaseController<B, T> : ApiController
        where B : BaseBLL<T>
        where T : AppBaseEntity, new()
    {
        //#region 属性变量

        ///// <summary>
        ///// 当前登录的用户属性
        ///// </summary>
        //public Sys_UserInfo CurrentUser =null;
        //public DataSet LoginInfo = null;
        //#endregion

        protected string GetTreeSelectJsonStr(List<Sys_UserInfo> data)
        {
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_UserInfo item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Account;
                treeModel.text = string.Format("[{0}]{1}", item.F_Account, item.F_RealName);
                treeModel.parentId = "0";
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }

        #region 私有成员
        /// <summary>
        /// token信息 
        /// </summary>
        private Dictionary<string, object> m_tokenInfo;
        #endregion

        #region 公开属性
        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        protected string currentUserId
        {
            get { return getCurrentUserId(); }
        }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        protected bool bAdmin
        {
            get { return getAdmin(); }
        }

        /// <summary>
        /// 公司
        /// </summary>
        protected string companyId
        {
            get { return getCompanyId(); }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取当前用户id
        /// </summary>
        /// <returns></returns>
        private string getCurrentUserId()
        {
            try
            {
                //获取token解析后的信息
                if (m_tokenInfo == null)
                {
                    m_tokenInfo = this.RequestContext.RouteData.Values[ConstValue.TOKEN_HEADER] as Dictionary<string, object>;
                }

                return m_tokenInfo[ConstValue.SUB_KEY_NODE].ToString();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前用户id
        /// </summary>
        /// <returns></returns>
        private bool getAdmin()
        {
            try
            {
                //获取token解析后的信息
                if (m_tokenInfo == null)
                {
                    m_tokenInfo = this.RequestContext.RouteData.Values[ConstValue.TOKEN_HEADER] as Dictionary<string, object>;
                }

                return Convert.ToBoolean(m_tokenInfo[ConstValue.ADMIN_KEY_NODE]);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取当前公司
        /// </summary>
        /// <returns></returns>
        private string getCompanyId()
        {
            try
            {
                //获取token解析后的信息
                if (m_tokenInfo == null)
                {
                    m_tokenInfo = this.RequestContext.RouteData.Values[ConstValue.TOKEN_HEADER] as Dictionary<string, object>;
                }

                return m_tokenInfo[ConstValue.CORP_KEY_NODE].ToString();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region  通用公开方法
        /// <summary>
        /// 获取关键字查询条件
        /// </summary>
        /// <param name="keyword">查询值</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="mutiConditionSplitChar">查询字段多条件分隔符 默认|</param>
        /// <param name="filedSplitChar">查询字段分隔符 默认/</param>
        /// <returns></returns>
        protected virtual SearchCondition GetKeywordConditionObj(string keyword, string searchFiled, char mutiConditionSplitChar = '|', char filedSplitChar = '/')
        {
            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(searchFiled))
            {
                string[] strKeyword = keyword.Split(mutiConditionSplitChar);
                string[] strSearchFiled = searchFiled.Split(mutiConditionSplitChar);
                SearchCondition condition = new SearchCondition();
                for (int i = 0; i < strKeyword.Length; i++)
                {
                    if (strKeyword[i].Equals("undefined"))
                    {
                        continue;
                    }
                    string[] fileds = strSearchFiled[i].Split(filedSplitChar);

                    if (fileds[0].Equals("F_OrderDate"))
                    {
                        string[] strdate = strKeyword[i].Split('/');
                        if (!string.IsNullOrEmpty(strdate[0]))
                        {
                            condition.AddCondition(fileds[0], Convert.ToDateTime(strdate[0]).ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual);
                        }
                        if (!string.IsNullOrEmpty(strdate[1]))
                        {
                            condition.AddCondition(fileds[0], Convert.ToDateTime(strdate[1]).AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                        }
                    }
                    else
                    {
                        foreach (string str in fileds)
                        {
                            if (str.Equals("undefined"))
                            {
                                continue;
                            }
                            condition.AddCondition(str, strKeyword[i], SqlOperator.Like, true, "g" + i.ToString());
                        }
                    }
                }
                return condition;
            }
            return new SearchCondition();
        }

        /// <summary>
        /// 获取关键字信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="searchFiled"></param>
        /// <param name="mutiConditionSplitChar"></param>
        /// <param name="filedSplitChar"></param>
        /// <returns></returns>
        //protected virtual string GetKeywordConditionStr(string keyword, string searchFiled, char mutiConditionSplitChar = '|', char filedSplitChar = '/')
        //{
        //    SearchCondition condition = GetKeywordCondition(keyword, searchFiled);
        //    return condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty);
        //}

        ///// <summary>
        ///// 获取grid显示信息 分页
        ///// </summary>
        ///// <param name="keyword">查询关键字</param>
        ///// <param name="searchFiled">查询字段</param>
        ///// <param name="pagination">分页默认是null</param>
        ///// <param name="sortFiled">排序字段 默认F_SortCode</param>
        ///// <returns></returns>
        //[HttpGet]
        //public virtual async Task<IHttpActionResult> GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sortFiled = " F_SortCode ")
        //{
        //    List<T> lista;
        //    PagerInfo pager = GetPageInfo(pagination);
        //    if (string.IsNullOrEmpty(list))
        //    {
        //        lista = baseBLL.FindWithPager(GetKeywordCondition(keyword, searchFiled), pager, sortFiled);
        //    }
        //    else
        //    {
        //        List<AdvSearchEntity> a = JsonConvert.DeserializeObject<List<AdvSearchEntity>>(list);
        //        lista = baseBLL.FindWithPager(GetAdvCondition(a), pager, sortFiled);
        //    }
        //    return GetPagerContent(lista, pager);
        //}

        /// <summary>
        /// 获取关键字信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="searchFiled"></param>
        /// <param name="mutiConditionSplitChar"></param>
        /// <param name="filedSplitChar"></param>
        /// <returns></returns>
        protected virtual string GetKeywordCondition(string keyword, string searchFiled, char mutiConditionSplitChar = '|', char filedSplitChar = '/')
        {
            SearchCondition condition = new SearchCondition();
            if ((!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(searchFiled)))
            {
                string[] strKeyword = keyword.Split(mutiConditionSplitChar);
                string[] strSearchFiled = searchFiled.Split(mutiConditionSplitChar);

                for (int i = 0; i < strKeyword.Length; i++)
                {
                    if (strKeyword[i].Equals("undefined"))
                    {
                        continue;
                    }
                    string[] fileds = strSearchFiled[i].Split(filedSplitChar);
                    foreach (string str in fileds)
                    {
                        if (str.Equals("undefined"))
                        {
                            continue;
                        }

                        condition.AddCondition(str, strKeyword[i], SqlOperator.Like, true, "g" + i.ToString());
                    }
                }
                return condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty);
            }
            return string.Empty;
        }


        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <param name="condition">过滤条件对象</param>
        /// <returns>查询字符串</returns>
        protected virtual string BuilderConditionStr(KGM.Framework.Commons.SearchCondition condition)
        {
            if (condition == null)
            {
                return string.Empty;
            }

            return condition.BuildConditionSql().Replace("Where", string.Empty);
        }

        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <typeparam name="E">需要返回的集合泛型</typeparam>
        /// <param name="list">返回的集合</param>
        /// <param name="pager">分页对象 为空时，不分页返回</param>
        /// <returns></returns>
        protected virtual Task<PagerDataEntity<E>> GetPagerDataAsync<E>(List<E> list, PagerInfo pager)
        {
            return Task.Run(() =>
            {
                if (pager == null)
                {
                    var data = new PagerDataEntity<E>
                    {
                        rows = list,
                        total = -1,
                        page = -1,
                        records = list.Count
                    };
                    return data;
                }
                else
                {
                    int total = pager.RecordCount / pager.PageSize == 0 ? 1 : (pager.RecordCount % pager.PageSize == 0 ? pager.RecordCount / pager.PageSize : pager.RecordCount / pager.PageSize + 1);
                    var data = new PagerDataEntity<E>
                    {
                        rows = list,
                        total = total,
                        page = pager.CurrenetPageIndex,
                        records = pager.RecordCount
                    };
                    return data;
                }
            });
        }


        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <typeparam name="E">需要返回的集合泛型</typeparam>
        /// <param name="ds">使用SQL Server分页存储过程后返回的对象</param>
        /// <param name="pager">分页对象 为空时，不分页返回</param>
        /// <returns></returns>
        protected virtual Task<PagerDataEntity<E>> GetPagerDataAsync<E>(DataSet ds, PagerInfo pager)
        {
            return Task.Run(() =>
            {
                int dataIndex = 0;//数据Index
                int total = 0;//总页数 
                int recordCount = 0;//总记录数
                if (pager == null)
                {
                    //不分页处理
                    total = -1;
                    recordCount = ds.Tables[0].Rows.Count;
                }
                else
                {
                    //分页处理
                    dataIndex = 1;
                    total = Convert.ToInt32(ds.Tables[2].Rows[0]["pagecount"]);
                    recordCount = Convert.ToInt32(ds.Tables[2].Rows[0]["recordcount"]);
                }

                var data = new PagerDataEntity<E>
                {
                    rows = JsonAppHelper.ToList<E>(ds.Tables[dataIndex]),
                    total = total,
                    page = -1,
                    records = recordCount
                };
                return data;
            });
        }


        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <typeparam name="E">需要返回的集合泛型</typeparam>
        /// <param name="dt">数据集合datatable</param>
        /// <param name="recordcount">记录总数</param>
        /// <param name="pager">分页对象 为空时，不分页返回</param>
        /// <returns></returns>
        protected virtual Task<PagerDataEntity<E>> GetPagerDataAysnc<E>(DataTable dt, int recordcount, PagerInfo pager)
        {
            return Task.Run(() =>
            {
                int total = 0;//总页数 
                int recordCount = 0;//总记录数
                if (pager == null)
                {
                    //不分页处理
                    total = -1;
                    recordCount = dt.Rows.Count;
                }
                else
                {
                    //分页处理 
                    total = recordcount / pager.PageSize == 0 ? 1 : (recordcount % pager.PageSize == 0 ? recordcount / pager.PageSize : recordcount / pager.PageSize + 1);

                    recordCount = recordcount;
                }

                var data = new PagerDataEntity<E>
                {
                    rows = JsonAppHelper.ToList<E>(dt),
                    total = total,
                    page = -1,
                    records = recordCount
                };


                return data;
            });
        }

        /// <summary>
        /// 获取分页对象
        /// </summary> 
        /// <param name="condition">过滤条件</param>
        /// <param name="pager">分页对象 为空时，不分页返回</param>
        /// <returns></returns>
        protected virtual async Task<PagerDataEntity<T>> GetPagerDataAsync(SearchCondition condition, PagerInfo pager)
        {
            var list = await FindAsync(condition, pager);
            return await GetPagerDataAsync<T>(list, pager);
        }




        /// <summary>
        /// 获取分页对象
        /// </summary> 
        /// <typeparam name="D">BLL类型</typeparam>
        /// <typeparam name="E">实体对象类型</typeparam>
        /// <param name="condition">过滤条件</param>
        /// <param name="pager">分页对象 为空时，不分页返回</param>
        /// <returns></returns>
        protected virtual async Task<PagerDataEntity<E>> GetPagerDataAsync<D, E>(SearchCondition condition, PagerInfo pager)
            where D : BaseBLL<E>
            where E : BaseEntity, new()
        {
            var list = await FindAsync<D, E>(condition, pager);
            return await GetPagerDataAsync<E>(list, pager);
        }

        /// <summary>
        /// 返回查询字符串
        /// </summary>
        /// <param name="list">查询对象集合</param>
        /// <returns>查询字符串</returns>
        protected virtual string GetAdvConditionStr(List<SearchEntity> list)
        {
            return BuilderConditionStr(GetAdvCondition(list));
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="list">list</param>
        /// <returns>查询对象</returns>
        protected virtual SearchCondition GetAdvCondition(List<SearchEntity> list)
        {
            if (list != null && list.Count > 0)
            {
                SearchCondition condition = new SearchCondition();
                foreach (SearchEntity entity in list)
                {
                    condition.AddCondition(entity.filed, entity.value, entity.oper);
                }
                return condition;
            }
            return null;
        }

        /// <summary>
        /// 将searchcondition对象转换为字符串
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        protected virtual string GetConditionStr(SearchCondition condition)
        {
            return condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty).Replace("Where (1=1)", " ( 1 = 1 ) ");
        }

        /// <summary>
        /// 获取treegridjson的字符串
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeGridJsonStr(List<T> data)
        {
            var treeList = new List<TreeGridModel>();
            foreach (T item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                treeModel.id = item.F_Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.F_ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = JsonAppHelper.ToJson(item);
                treeList.Add(treeModel);
            }
            return treeList.TreeGridJson();
        }

        /// <summary>
        /// 获取树形结构Json
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeJsonStr(List<T> data)
        {
            var treeList = new List<TreeViewModel>();
            foreach (T item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return treeList.TreeViewJson();
        }

        /// <summary>
        /// 获取treegridjson的字符串
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeSelectJsonStr(List<T> data)
        {
            var treeList = new List<TreeSelectModel>();
            foreach (T item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }

        ///// <summary>
        ///// 获取分页信息
        ///// </summary>
        ///// <param name="pagination">页面分页信息</param>
        ///// <returns></returns>
        //public virtual PagerInfo GetPageInfo(Pagination pagination)
        //{
        //    PagerInfo pager = new PagerInfo();
        //    pager.PageSize = pagination.rows;
        //    pager.CurrenetPageIndex = pagination.page;

        //    return pager;
        //}
        #endregion

        #region 单表增删改查的方法
        /// <summary>
        /// 异步根据Id获取对象
        /// </summary>  
        /// <param name="id">对象id</param>
        /// <returns></returns>
        protected virtual Task<T> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.FindByID(id);
            });
        }

        /// <summary>
        /// 异步根据Id获取对象
        /// </summary>
        /// <typeparam name="D">BLL类型</typeparam>
        /// <typeparam name="E">实体对象类型</typeparam>
        /// <param name="id">对象id</param>
        /// <returns></returns>

        protected virtual Task<E> FindByIdAsync<D, E>(string id)
            where D : BaseBLL<E>
            where E : BaseEntity, new()
        {
            return Task.Run(() =>
            {
                return BLLFactory<D>.Instance.FindByID(id);
            });
        }

        /// <summary>
        /// 异步根据条件获取对象
        /// </summary>  
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        protected virtual Task<T> FindSingleAsync(SearchCondition condition)
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.FindSingle(BuilderConditionStr(condition));
            });
        }

        /// <summary>
        /// 异步根据条件获取对象
        /// </summary>  
        /// <typeparam name="D">BLL类型</typeparam>
        /// <typeparam name="E">实体对象类型</typeparam>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        protected virtual Task<E> FindSingleAsync<D, E>(SearchCondition condition)
            where D : BaseBLL<E>
            where E : BaseEntity, new()
        {
            return Task.Run(() =>
            {
                return BLLFactory<D>.Instance.FindSingle(BuilderConditionStr(condition));
            });
        }

        /// <summary>
        /// 异步根据条件获取分页后的集合
        /// </summary> 
        /// <param name="condition">过滤条件 对象为空时，则查询全部</param>
        /// <param name="pager">分页对象 对象为空时，则不分页</param>
        /// <returns></returns>
        protected virtual Task<List<T>> FindAsync(SearchCondition condition = null, PagerInfo pager = null)
        {
            return Task.Run(() =>
            {
                List<T> list = null;
                if (pager == null)
                {
                    list = condition == null ? BLLFactory<B>.Instance.GetAll() : BLLFactory<B>.Instance.Find(BuilderConditionStr(condition));
                }
                else
                {
                    list = condition == null ? BLLFactory<B>.Instance.GetAll(pager) : BLLFactory<B>.Instance.FindWithPager(BuilderConditionStr(condition), pager);
                }

                return list;
            });
        }


        /// <summary>
        /// 异步根据条件获取分页后的集合
        /// </summary> 
        /// <typeparam name="D">BLL类型</typeparam>
        /// <typeparam name="E">实体对象类型</typeparam>
        /// <param name="condition">过滤条件 对象为空时，则查询全部</param>
        /// <param name="pager">分页对象 对象为空时，则不分页</param>
        /// <returns></returns>
        protected virtual Task<List<E>> FindAsync<D, E>(SearchCondition condition = null, PagerInfo pager = null)
            where D : BaseBLL<E>
            where E : BaseEntity, new()
        {
            return Task.Run(() =>
            {
                List<E> list = null;
                if (pager == null)
                {
                    list = condition == null ? BLLFactory<D>.Instance.GetAll() : BLLFactory<D>.Instance.Find(BuilderConditionStr(condition));
                }
                else
                {
                    list = condition == null ? BLLFactory<D>.Instance.GetAll(pager) : BLLFactory<D>.Instance.FindWithPager(BuilderConditionStr(condition), pager);
                }

                return list;
            });
        }

        /// <summary>
        /// 异步根据条件获取DataTable
        /// </summary>  
        /// <param name="condition">过滤条件 对象为空时，返回所有集合</param>
        /// <param name="pager">分页对象 对象为空时，则不分页</param>
        /// <returns></returns>
        protected virtual Task<DataTable> FindToDataTableAsync(SearchCondition condition = null, PagerInfo pager = null)
        {
            return Task.Run(() =>
            {
                DataTable dt = null;
                if (pager == null)
                {
                    dt = condition == null ? BLLFactory<B>.Instance.GetAllToDataTable() : BLLFactory<B>.Instance.FindToDataTable(BuilderConditionStr(condition));
                }
                else
                {
                    dt = condition == null ? BLLFactory<B>.Instance.GetAllToDataTable(pager) : BLLFactory<B>.Instance.FindToDataTable(BuilderConditionStr(condition), pager);
                }
                return dt;
            });
        }


        /// <summary>
        /// 异步根据条件获取DataTable
        /// </summary>  
        /// <typeparam name="D">BLL类型</typeparam>
        /// <param name="condition">过滤条件 对象为空时，返回所有集合</param>
        /// <param name="pager">分页对象 对象为空时，则不分页</param>
        /// <returns></returns>
        protected virtual Task<DataTable> FindToDataTableAsync<D>(SearchCondition condition = null, PagerInfo pager = null)
             where D : BaseBLL<BaseEntity>
        {
            return Task.Run(() =>
            {
                DataTable dt = null;
                if (pager == null)
                {
                    dt = condition == null ? BLLFactory<D>.Instance.GetAllToDataTable() : BLLFactory<B>.Instance.FindToDataTable(BuilderConditionStr(condition));
                }
                else
                {
                    dt = condition == null ? BLLFactory<D>.Instance.GetAllToDataTable(pager) : BLLFactory<B>.Instance.FindToDataTable(BuilderConditionStr(condition), pager);
                }

                return dt;
            });
        }

        /// <summary>
        /// 异步根据条件从视图获取DataTable
        /// </summary>  
        /// <typeparam name="D">BLL类型</typeparam>
        /// <param name="condition">过滤条件 对象为空时，返回所有集合</param>
        /// <param name="pager">分页对象 对象为空时，则不分页</param>
        /// <returns></returns>
        protected virtual Task<DataTable> FindToDataTableAsync<D>(string viewName, string sortField, bool isDescending = false, SearchCondition condition = null, PagerInfo pager = null)
             where D : BaseBLL<BaseEntity>
        {
            return Task.Run(() =>
            {
                DataTable dt = null;
                if (pager == null)
                {
                    dt = BLLFactory<D>.Instance.FindByView(viewName, BuilderConditionStr(condition));
                }
                else
                {
                    dt = BLLFactory<D>.Instance.FindByViewWithPager(viewName, BuilderConditionStr(condition), sortField, isDescending, pager);
                }

                return dt;
            });
        }


        /// <summary>
        /// 异步保存对象
        /// </summary> 
        /// <param name="model">实体对象</param>
        /// <param name="id">主键值 为空时 则为新增</param>
        /// <returns></returns>
        protected virtual Task<bool> SaveEntityAsync(T model, string id = null)
        {
            return Task.Run(() =>
            {
                return id == null ? BLLFactory<B>.Instance.Insert(model) : BLLFactory<B>.Instance.InsertUpdate(model, id);
            });
        }

        /// <summary>
        /// 异步保存对象
        /// </summary> 
        /// <typeparam name="D">BLL类型</typeparam>
        /// <typeparam name="E">实体对象类型</typeparam>
        /// <param name="model">实体对象</param>
        /// <param name="id">主键值 为空时 则为新增</param>
        /// <returns></returns>
        protected virtual Task<bool> SaveEntityAsync<D, E>(E model, string id = null)
            where D : BaseBLL<E>
            where E : BaseEntity, new()
        {
            return Task.Run(() =>
            {
                return id == null ? BLLFactory<D>.Instance.Insert(model) : BLLFactory<D>.Instance.InsertUpdate(model, id);
            });
        }


        /// <summary>
        /// 异步根据Id删除对象
        /// </summary> 
        /// <param name="id">主键值</param>
        /// <returns></returns>
        protected virtual Task<bool> DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.Delete(id);
            });
        }


        /// <summary>
        /// 异步根据Id删除对象
        /// </summary> 
        /// <typeparam name="D">BLL类型</typeparam> 
        /// <param name="id">主键值</param>
        /// <returns></returns>
        protected virtual Task<bool> DeleteByIdAsync<D>(string id)
            where D : BaseBLL<BaseEntity>
        {
            return Task.Run(() =>
            {
                return BLLFactory<D>.Instance.Delete(id);
            });
        }

        /// <summary>
        /// 异步根据条件删除对象
        /// </summary> 
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        protected virtual Task<bool> DeleteByConditionAsync(SearchCondition condition)
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.DeleteByCondition(BuilderConditionStr(condition));
            });
        }

        /// <summary>
        /// 异步根据条件删除对象
        /// </summary> 
        /// <typeparam name="D">BLL类型</typeparam> 
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        protected virtual Task<bool> DeleteByConditionAsync<D>(SearchCondition condition)
            where D : BaseBLL<BaseEntity>
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.DeleteByCondition(BuilderConditionStr(condition));
            });
        }

        /// <summary>
        /// 异步根据条件判断是否存在
        /// </summary> 
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        protected virtual Task<bool> IsExistRecordAsync(SearchCondition condition = null)
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.IsExistRecord(BuilderConditionStr(condition));
            });
        }


        /// <summary>
        /// 异步根据条件判断是否存在
        /// </summary> 
        /// <typeparam name="D">BLL类型</typeparam> 
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        protected virtual Task<bool> IsExistRecordAsync<D>(SearchCondition condition = null)
             where D : BaseBLL<BaseEntity>
        {
            return Task.Run(() =>
            {
                return BLLFactory<B>.Instance.IsExistRecord(BuilderConditionStr(condition));
            });
        }
        #endregion



        /// <summary>
        /// 获取列表分页显示扩展
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="searchFiled"></param>
        /// <param name="list"></param>
        /// <param name="pagination"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public virtual IHttpActionResult GetGridJsonPaginationExtend<D, E>(string keyword, string searchFiled, string list,
                Pagination pagination, string sidx = " cPosCode ", string sord = "asc")
            where D : BaseBLL<E>
            where E : BaseEntity, new()
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " cPosCode ";
            }
            List<E> lista;
            PagerInfo pager = GetPageInfo(pagination);
            if (string.IsNullOrEmpty(list))
            {
                lista = BLLFactory<D>.Instance.FindWithPager(GetKeywordCondition(keyword, searchFiled), pager, sidx, sord.ToLower() == "desc");
            }
            else
            {
                lista = BLLFactory<D>.Instance.FindWithPager(list, pager, sidx, sord.ToLower() == "desc");
            }
            return GetPagerContent(lista, pager);
        }



        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pagination">页面分页信息</param>
        /// <returns></returns>
        public virtual PagerInfo GetPageInfo(Pagination pagination)
        {
            PagerInfo pager = new PagerInfo();
            pager.PageSize = pagination.rows;
            pager.CurrenetPageIndex = pagination.page;

            return pager;
        }

        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="pager">分页对象</param>
        /// <returns></returns>
        protected virtual IHttpActionResult GetPagerContent<ST>(List<ST> list, PagerInfo pager)
        {
            int total = pager.RecordCount / pager.PageSize == 0 ? 1 : (pager.RecordCount % pager.PageSize == 0 ? pager.RecordCount / pager.PageSize : pager.RecordCount / pager.PageSize + 1);
            var data = new
            {
                rows = list,
                total = total,
                page = pager.CurrenetPageIndex,
                records = pager.RecordCount
            };

            return Content(System.Net.HttpStatusCode.OK,JsonAppHelper.ToJson(data));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        protected virtual AdvSearchCondtion SetExportConditionToObj(string condition)
        {
            AdvSearchCondtion cond = new AdvSearchCondtion();

            if (string.IsNullOrEmpty(condition) || condition.Equals("null"))
            {
                cond.Condition = new SearchCondition();
                return cond;
            }
            ExportDataConditionModel model = JsonAppHelper.ToObject<ExportDataConditionModel>(condition);
            AdvSearchCondtionEntity condv = JsonAppHelper.ToObject<AdvSearchCondtionEntity>(model.data);

            cond.KeyValueList = condv.KeyValueList;

            switch (model.type)
            {
                case 0:
                    var keyword = JsonAppHelper.ToObject<KeywordValueModel>(condv.Condition);
                    if (keyword == null)
                    {
                        cond.Condition = new SearchCondition();
                    }
                    else
                    {
                        cond.Condition = GetKeywordConditionObj(keyword.keyword, keyword.searchFiled);
                    }
                    break;
                case 1:
                    cond.Condition = GetAdvConditionObj(JsonAppHelper.ToObject<List<AdvSearchEntity>>(condv.Condition));
                    break;
            }
            return cond;
        }


        /// <summary>
        /// 获取关键字查询条件
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected virtual SearchCondition GetAdvConditionObj(List<AdvSearchEntity> list)
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


        #region 树结构
        /// <summary>
        /// 转化为json格式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        protected virtual string TreeViewJson(List<GetTreeModel> data, string parentId = "0")
        {
            StringBuilder strJson = new StringBuilder();
            List<GetTreeModel> item = data.FindAll(t => t.parentId == parentId);
            strJson.Append("[");
            if (item.Count > 0)
            {
                foreach (GetTreeModel entity in item)
                {
                    strJson.Append("{");
                    strJson.Append("\"id\":\"" + entity.id + "\",");
                    strJson.Append("\"text\":\"" + entity.text.Replace("&nbsp;", "") + "\",");
                    strJson.Append("\"value\":\"" + entity.value + "\",");
                    if (entity.title != null && !string.IsNullOrEmpty(entity.title.Replace("&nbsp;", "")))
                    {
                        strJson.Append("\"title\":\"" + entity.title.Replace("&nbsp;", "") + "\",");
                    }
                    if (entity.img != null && !string.IsNullOrEmpty(entity.img.Replace("&nbsp;", "")))
                    {
                        strJson.Append("\"iocn\":\"" + entity.img.Replace("&nbsp;", "") + "\",");
                    }
                    if (entity.checkstate != null)
                    {
                        strJson.Append("\"checkstate\":" + entity.checkstate + ",");
                    }
                    if (entity.parentId != null)
                    {
                        strJson.Append("\"parentnodes\":\"" + entity.parentId + "\",");
                    }
                    strJson.Append("\"showcheck\":" + entity.showcheck.ToString().ToLower() + ",");
                    strJson.Append("\"isexpand\":" + entity.isexpand.ToString().ToLower() + ",");
                    if (entity.complete == true)
                    {
                        strJson.Append("\"complete\":" + entity.complete.ToString().ToLower() + ",");
                    }
                    strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");
                    strJson.Append("\"ChildNodes\":" + TreeViewJson(data, entity.id) + "");
                    strJson.Append("},");
                }
                strJson = strJson.Remove(strJson.Length - 1, 1);
            }
            strJson.Append("]");
            return strJson.ToString();
        }


        #endregion

    }
}
