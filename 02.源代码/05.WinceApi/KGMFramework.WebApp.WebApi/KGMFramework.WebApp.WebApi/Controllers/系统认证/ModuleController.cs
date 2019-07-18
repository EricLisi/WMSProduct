using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.WebApi.Models;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using KGM.Framework.Commons;
using System.Linq;
using System.Text;

namespace KGMFramework.WebApp.WebApi.Controllers
{
    /// <summary>
    /// 获取树菜单
    /// </summary> 
    [RoutePrefix("api/Module")]
    public class ModuleController : BaseController<Sys_User, Sys_UserInfo>
    {



        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetModuleTree")]
        public async Task<string> GetModuleTree()
        {
            return await Task.Run(() =>
            {
                SearchCondition search = new SearchCondition();
                search.AddCondition("F_IsApp", true, SqlOperator.Equal);
                KgmApiResultEntity result = new KgmApiResultEntity();
                List<GetModel> getModels = new List<GetModel>();
                var moduleList = BLLFactory<Sys_Module>.Instance.Find(BuilderConditionStr(search));
                for (int i = 0; i < moduleList.Count(); i++)
                {
                    GetModel model = new GetModel();
                    model.icon = moduleList[i].F_Icon;
                    model.src= moduleList[i].F_UrlAddress;
                    model.title = moduleList[i].F_FullName;
                    model.parent = "inStock";
                    getModels.Add(model);
                }
                return JsonAppHelper.ToJson(new {result=true,message= getModels });

            });
        }

       

        /// <summary>
        /// 获取当前用户可操作菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCurrentUserMenu")]
        public async Task<KgmApiResultEntity> GetCurrentUserMenu()
        {
            return await Task.Run(() =>
            {
                KgmApiResultEntity result = new KgmApiResultEntity();
                result.result = true;
                result.message = JsonAppHelper.ToJson(BLLFactory<Sys_RoleAuthorize>.Instance.GetUserMenu(currentUserId));

                return result;
            });
        }

        /// <summary>
        /// 获取树形结构JSon
        /// </summary>
        /// <param name="data">数据对象集合</param>
        /// <returns></returns>
        protected virtual string GetTreeJsonStr(List<Sys_ModuleInfo> data)
        {
            var treeList = new List<GetTreeModel>();
            foreach (Sys_ModuleInfo item in data)
            {
                GetTreeModel tree = new GetTreeModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_UrlAddress;
                tree.hasChildren = hasChildren;
                tree.parentId = item.F_ParentId;
                tree.img = item.F_Icon;
                tree.isexpand = true;
                tree.showcheck = true;
                tree.complete = true;
                treeList.Add(tree);
            }
            return TreeViewJson(treeList);
        }


        #region 树结构
        /// <summary>
        /// 转化为json格式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        protected override string TreeViewJson(List<GetTreeModel> data, string parentId = "0")
        {
            StringBuilder strJson = new StringBuilder();
            List<GetTreeModel> item = data.FindAll(t => t.parentId == parentId);
            strJson.Append("[");
            if (item.Count > 0)
            {
                foreach (GetTreeModel entity in item)
                {
                    strJson.Append("{");

                    strJson.Append("\"title\":\"" + entity.text.Replace("&nbsp;", "") + "\",");
                    strJson.Append("\"src\":\"" + entity.value + "\",");
                    strJson.Append("\"icon\":\"" + entity.img + "\",");
                    strJson.Append("\"parent\":\"inStock,");
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
