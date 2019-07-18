using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGM.Framework.Commons;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Models;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace KGMFramework.WebApp.Controllers
{
    public class BusinessController<B, T> : BaseController
        where B : class
        where T : AppBaseEntity, new()
    {
        #region 构造函数及常用

        /// <summary>
        /// 业务对象所在程序集的文件名，不包括其扩展名，如: KgmSoft.Security.Core
        /// </summary>
        protected string bllAssemblyName = null;

        /// <summary>
        /// 基础业务对象
        /// </summary>
        protected BaseBLL<T> baseBLL = null;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BusinessController()
        {
            this.bllAssemblyName = System.Reflection.Assembly.GetAssembly(typeof(B)).GetName().Name;
            this.baseBLL = Reflect<BaseBLL<T>>.Create(typeof(B).FullName, bllAssemblyName);//构造对应的 BaseBLL<T> 业务访问层的对象类

            //调用前检查baseBLL是否为空引用
            if (baseBLL == null)
            {
                throw new ArgumentNullException("baseBLL", "未能成功创建对应的BaseBLL<T> 业务访问层的对象。");
            }
        }

        /// <summary>
        /// 默认的视图控制方法
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Form()
        {
            ViewBag.UserName = CurrentUser.F_RealName;
            return View();
        }

        protected virtual ActionResult Success(string message)
        {
            return Content(JsonAppHelper.ToJson(new AjaxResult { state = ResultType.success.ToString(), message = message }));
        }
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(JsonAppHelper.ToJson(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }));
        }
        protected virtual ActionResult Error(string message)
        {
            return Content(JsonAppHelper.ToJson(new AjaxResult { state = ResultType.error.ToString(), message = message }));
        }

        #endregion

        #region 导入导出方法
        /// <summary>
        /// 上传完文件后处理
        /// </summary>
        /// <param name="fullFileName"></param>
        protected virtual ResultModel DoAfterUploadFile(string fullFileName)
        {
            return null;
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="Filedata">文件对象</param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult UploadifyFile(HttpPostedFileBase Filedata)
        {
            try
            {
                Thread.Sleep(500);////延迟500毫秒
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                string userId = CurrentUser.F_Account;
                string fileGuid = Guid.NewGuid().ToString();
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    Filedata.SaveAs(fullFileName);
                    //保存完文件后执行
                    ResultModel result = DoAfterUploadFile(fullFileName);
                    if (result == null || result.bSuccess)
                    {
                        return Success("上传成功!" + result.message);
                    }
                    else
                    {
                        return Error(result.message);
                    }
                }
                return Error("未能获取上传文件信息。");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

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
        /// 设置导出数据源
        /// </summary>
        /// <returns></returns>
        protected virtual DataTable SetRowData(string condition)
        {
            SearchCondition cond = SetExportConditionToObj(condition).Condition;
            return baseBLL.FindToDataTable(GetConditionStr(cond));
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="columnJson">列对象</param>
        /// <param name="rowJson">行信息</param>
        /// <param name="exportField">导出字段</param>
        /// <param name="filename">文件名</param>
        [ValidateInput(false)]
        [HttpPost]
        public virtual void ExecuteExportExcel(string columnJson, string rowJson, string exportField, string filename)
        {
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = Server.UrlDecode(filename);
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 15;
            excelconfig.FileName = Server.UrlDecode(filename) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnEntity>();
            //表头
            //处理formoptions,将所有的formoptions 值全部变成null
            List<GridColumnModel> columnData = columnJson.ToList<GridColumnModel>();
            //行数据
            DataTable rowData = SetRowData(rowJson);
            //写入Excel表头
            string[] fieldInfo = exportField.Split(',');
            foreach (string item in fieldInfo)
            {
                var list = columnData.FindAll(t => t.name == item);
                foreach (GridColumnModel gridcolumnmodel in list)
                {
                    if (gridcolumnmodel.hidden.ToLower() == "false" && gridcolumnmodel.label != null)
                    {
                        string align = gridcolumnmodel.align;
                        excelconfig.ColumnEntity.Add(new ColumnEntity()
                        {
                            Column = gridcolumnmodel.name,
                            ExcelColumn = gridcolumnmodel.label,
                            //Width = gridcolumnmodel.width,
                            Alignment = gridcolumnmodel.align,
                        });
                    }
                }
            }
            KGMFramework.WebApp.Library.ExcelHelper.ExcelDownload(rowData, excelconfig);
            //return Success("导出成功!");
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="exportTable">导出的dt</param>
        /// <param name="listColumnEntity">导出的列对象</param>
        /// <param name="excelconfig"></param>
        [ValidateInput(false)]
        [HttpPost]
        public virtual void ExecuteExportExcelFixed(DataTable exportTable, List<ColumnEntity> listColumnEntity, ExcelConfig excelconfig = null)
        {
            //取出数据源 
            //设置导出格式
            if (excelconfig == null)
            {
                excelconfig = new ExcelConfig();
                excelconfig.Title = "导出Excel";
                excelconfig.TitleFont = "微软雅黑";
                excelconfig.TitlePoint = 25;
                excelconfig.FileName = "Excel文件.xls";
                excelconfig.IsAllSizeColumn = true;
            }

            //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出 
            excelconfig.ColumnEntity = listColumnEntity;

            //调用导出方法
            KGMFramework.WebApp.Library.ExcelHelper.ExcelDownload(exportTable, excelconfig);
        }
        #endregion

        #region 对象添加、修改、查询接口

        /// <summary>
        /// 在插入数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual ResultModel OnBeforeSubmitForm(T info)
        {
            //留给子类对参数对象进行修改
            return null;
        }

        /// <summary>
        /// 在插入数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual ResultModel OnBeforeUpSubmitForm(T info,string KeyValue)
        {
            //留给子类对参数对象进行修改
            return null;
        }
        /// <summary>
        /// 在获取窗体权限前做的事件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual ResultModel OnBeforeGetFormJson(T info)
        {
            //留给子类对参数对象进行修改
            return null;
        }


        /// <summary>
        /// 在获取窗体权限前做的事件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual ResultModel OnBeforeDelete(string[] arry)
        {
            //留给子类对参数对象进行修改
            return null;
        }

        /// <summary>
        /// 获取窗体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetFormJson(string keyValue)
        {
            var data = baseBLL.FindByID(keyValue);
            ResultModel result = OnBeforeGetFormJson(data);
            if (result != null && result.bSuccess == false)
            {
                return Content("");
            }
            return Content(JsonAppHelper.ToJson(data));
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="info">对象</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult SubmitForm(T info, string keyValue)
        {
            ResultModel result = OnBeforeSubmitForm(info);
           
            if (result != null && result.bSuccess == false)
            {
                return Error("操作失败!原因:" + result.message);
            }
            if (!string.IsNullOrEmpty(keyValue))
            {
                info.F_Id = keyValue;
                info.F_LastModifyTime = DateTime.Now;
                info.F_LastModifyUserId = CurrentUser.F_Account;
            }
            else
            {
                info.F_CreatorTime = DateTime.Now;
                info.F_CreatorUserId = CurrentUser.F_Account;
                info.F_Id = Guid.NewGuid().ToString();
            }
            baseBLL.InsertUpdate(info, keyValue);
            return Success("操作成功", info);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="bLogicDelete">是否逻辑删除 默认false</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {
            string[] arry = keyValue.Split(',');

            ResultModel result = OnBeforeDelete(arry);
            if (result != null && result.bSuccess == false)
            {
                return Error(result.message);
            }

            if (bLogicDelete)
            {
                for (int i = 0; i < arry.Length; i++)
                {
                    T info = baseBLL.FindByID(arry[i]);

                    info.F_DeleteMark = true;
                    info.F_DeleteTime = DateTime.Now;
                    info.F_DeleteUserId = CurrentUser.F_Account;
                    baseBLL.Update(info, info.F_Id);
                }

            }
            else
            {
                for (int i = 0; i < arry.Length; i++)
                {
                    baseBLL.Delete(arry[i]);
                    //T info = baseBLL.FindByID(arry[i]);
                }
            }

            return Success("删除成功");
        }

        /// <summary>
        /// 获取grid显示信息,如果keyword为null 则不查询数据 不分页
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="pagination">分页默认是null</param>
        /// <param name="sidx">排序字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetGridJsonEmptyIfNull(string keyword, string searchFiled, string sidx = " F_SortCode ", string sord = "asc")
        {
            if (keyword == null)
            {
                return Content("[]");
            }

            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_SortCode ";
            }

            SearchCondition condition = new SearchCondition();
            var data = baseBLL.Find(GetKeywordCondition(keyword, searchFiled), " ORDER BY " + sidx + sord);
            return Content(JsonAppHelper.ToJson(data));

        }

        /// <summary>
        /// 获取grid显示信息 不分页
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="pagination">分页默认是null</param>
        /// <param name="sidx">排序字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetGridJson(string keyword, string searchFiled, string sidx = " F_SortCode ", string sord = " asc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_SortCode ";
            }
            SearchCondition condition = new SearchCondition();
            var data = baseBLL.Find(GetKeywordCondition(keyword, searchFiled), " ORDER BY " + sidx + " " + sord);
            return Content(JsonAppHelper.ToJson(data));

        }

        /// <summary>
        /// 获取grid显示信息 分页
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="pagination">分页默认是null</param>
        /// <param name="sidx">排序字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sidx = " F_SortCode ", string sord = "asc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_SortCode ";
            }
            List<T> lista;
            PagerInfo pager = GetPageInfo(pagination);
            if (string.IsNullOrEmpty(list))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition(keyword, searchFiled), pager, sidx, sord.ToLower() == "desc");
            }
            else
            {
                List<AdvSearchEntity> a = JsonConvert.DeserializeObject<List<AdvSearchEntity>>(list);
                lista = baseBLL.FindWithPager(GetAdvCondition(a), pager, sidx);
            }
            return GetPagerContent(lista, pager);
        }


        [HttpGet]
        public virtual ActionResult GetSelectJson(string keyword, string searchFiled, string sidx = " Order By F_SortCode ", string sord = "asc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " Order By F_SortCode ";
            }
            var data = baseBLL.Find(GetKeywordCondition(keyword, searchFiled), sidx + sord);
            List<object> list = new List<object>();
            foreach (T item in data)
            {
                list.Add(new { id = item.F_Id, text = string.Format("[{0}] {1}", item.F_EnCode, item.F_FullName) });
            }
            return Content(JsonAppHelper.ToJson(list));
        }

        /// <summary>
        /// 获取treegrid的JSON
        /// </summary>
        /// <param name="keyword">查询值</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="orderBy">排序条件 格式 Order By 字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetTreeGridJson(string keyword, string searchFiled, string list, string orderBy = " ORDER BY F_SortCode ")
        {
            string[] classnameList = typeof(T).ToString().Split('.');
            string condition = "";
            if (string.IsNullOrEmpty(list))
            {
                condition = GetKeywordCondition(keyword, searchFiled);
            }
            else
            {
                condition = GetAdvCondition(JsonConvert.DeserializeObject<List<AdvSearchEntity>>(list));
            }
            TreeInfoEntity entity = new TreeInfoEntity();
            entity.F_Condition = string.IsNullOrEmpty(condition) ? string.Empty : " AND " + condition;
            entity.F_CType = 1;
            entity.F_KeyFiled = "F_Id";
            entity.F_ParentFiled = "F_ParentId";
            entity.F_SortCode = orderBy;
            entity.F_TableName = classnameList[classnameList.Length - 1].Replace("Info", string.Empty);
            var dt = BLLFactory<AppCommon>.Instance.GetTreeInfo(entity);  //baseBLL.Find(condition, orderBy); 
            string dataStr = JsonAppHelper.ToJson(dt);
            var data = JsonAppHelper.ToList<T>(dataStr);
            return Content(GetTreeGridJsonStr(data));
        }

        /// <summary>
        /// 获取所有数据 按树形排列
        /// </summary>
        /// <param name="orderBy">排序条件 格式 Order By 字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetTreeSelectJson(string orderBy = " ORDER BY F_SortCode ")
        {
            var data = baseBLL.GetAll(orderBy);
            return Content(GetTreeSelectJsonStr(data));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBy">排序条件 格式 Order By 字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GetTreeJson(string orderBy = " ORDER BY F_SortCode ")
        {
            var data = baseBLL.GetAll(orderBy);
            return Content(GetTreeJsonStr(data));
        }



        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="info">对象</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult VerifyList(string orderId, string orderNo, string orderType)
        {
            return Content("");
            //VerifyListEntity entity = new VerifyListEntity();
            //entity.orderId = orderId;
            //entity.orderNo = orderNo;
            //entity.orderType = orderType;
            //entity.userId = CurrentUser.F_RealName;
            //entity.corpId = CurrentUser.F_OrganizeId;
            //var result = null;// BLLFactory<AppCommon>.Instance.VerifyList(entity);

            //if (Convert.ToInt32(result.Rows[0][0]) == 1)
            //{
            //    return Success("操作成功");
            //}
            //else
            //{
            //    return Error(result.Rows[0][1].ToString());
            //}
        }

        #endregion

        #region 通用方法

        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="pager">分页对象</param>
        /// <returns></returns>
        protected virtual ActionResult GetPagerContent(DataTable dt, PagerInfo pager)
        {
            int total = pager.RecordCount / pager.PageSize == 0 ? 1 : (pager.RecordCount % pager.PageSize == 0 ? pager.RecordCount / pager.PageSize : pager.RecordCount / pager.PageSize + 1);
            var data = new
            {
                rows = dt,
                total = total,
                page = pager.CurrenetPageIndex,
                records = pager.RecordCount
            };

            return Content(JsonAppHelper.ToJson(data));
        }


        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="pager">分页对象</param>
        /// <returns></returns>
        protected virtual ActionResult GetPagerContent(List<T> list, PagerInfo pager)
        {
            int total = pager.RecordCount / pager.PageSize == 0 ? 1 : (pager.RecordCount % pager.PageSize == 0 ? pager.RecordCount / pager.PageSize : pager.RecordCount / pager.PageSize + 1);
            var data = new
            {
                rows = list,
                total = total,
                page = pager.CurrenetPageIndex,
                records = pager.RecordCount
            };

            return Content(JsonAppHelper.ToJson(data));
        }


        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="pager">分页对象</param>
        /// <returns></returns>
        protected virtual ActionResult GetPagerContent<ST>(List<ST> list, PagerInfo pager)
        {
            int total = pager.RecordCount / pager.PageSize == 0 ? 1 : (pager.RecordCount % pager.PageSize == 0 ? pager.RecordCount / pager.PageSize : pager.RecordCount / pager.PageSize + 1);
            var data = new
            {
                rows = list,
                total = total,
                page = pager.CurrenetPageIndex,
                records = pager.RecordCount
            };

            return Content(JsonAppHelper.ToJson(data));
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
        /// 获取treegridjson的字符串
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeGridJsonStr<ST>(List<ST> data) where ST : AppBaseEntity
        {
            var treeList = new List<TreeGridModel>();
            foreach (ST item in data)
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
                treeModel.text = string.Format("[{0}] {1}", item.F_EnCode, item.F_FullName);
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }

        /// <summary>
        /// 获取treegridjson的字符串
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeSelectJsonStr<ST>(List<ST> data) where ST : AppBaseEntity
        {
            var treeList = new List<TreeSelectModel>();
            foreach (ST item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }

        /// <summary>
        /// 获取树形结构JSon
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
        /// 获取树形结构JSon
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeJsonStr<ST>(List<ST> data) where ST : AppBaseEntity
        {
            var treeList = new List<TreeViewModel>();
            foreach (ST item in data)
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
        /// 获取关键字查询条件
        /// </summary>
        /// <param name="keyword">查询值</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="mutiConditionSplitChar">查询字段多条件分隔符 默认|</param>
        /// <param name="filedSplitChar">查询字段分隔符 默认/</param>
        /// <returns></returns>
        protected virtual string GetKeywordCondition(string keyword, string searchFiled, char mutiConditionSplitChar = '|', char filedSplitChar = '/')
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
                    foreach (string str in fileds)
                    {
                        if (str.Equals("undefined"))
                        {
                            continue;
                        }
                        condition.AddCondition(str, strKeyword[i], SqlOperator.Like, true, "g" + i.ToString());
                    }
                }
                return condition;
            }
            return new SearchCondition();
        }

        /// <summary>
        /// 获取关键字查询条件
        /// </summary>
        /// <param name="keyword">查询值</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="mutiConditionSplitChar">查询字段多条件分隔符 默认|</param>
        /// <param name="filedSplitChar">查询字段分隔符 默认/</param>
        /// <returns></returns>
        protected virtual string GetAdvCondition(List<AdvSearchEntity> list)
        {
            string sql = "";
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
            sql += condition.BuildConditionSql();
            return sql.Replace("Where (1=1)  AND ", string.Empty);
        }


        /// <summary>
        /// 获取关键字查询条件
        /// </summary>
        /// <param name="keyword">查询值</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="mutiConditionSplitChar">查询字段多条件分隔符 默认|</param>
        /// <param name="filedSplitChar">查询字段分隔符 默认/</param>
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


        #endregion
    }
}