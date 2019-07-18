using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KGM.Pager.Entity;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Controllers;
using KGMFramework.WebApp.Library;

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class RoleController : BusinessController<Sys_Role, Sys_RoleInfo>
    {
        /// <summary>
        /// 获取权限树
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult GetPermissionTree(string roleId)
        {
            var moduledata = BLLFactory<Sys_Module>.Instance.GetAll(" Order By F_SortCode ");
            var buttondata = BLLFactory<Sys_ModuleButton>.Instance.GetAll(" Order By F_SortCode ");
            var authorizedata = new List<Sys_RoleAuthorizeInfo>();
            if (!string.IsNullOrEmpty(roleId))
            {
                SearchCondition condition = new SearchCondition();
                condition.AddCondition("F_ObjectId", roleId, SqlOperator.Equal);
                authorizedata = BLLFactory<Sys_RoleAuthorize>.Instance.Find(GetConditionStr(condition));
            }
            var treeList = new List<TreeViewModel>();
            foreach (Sys_ModuleInfo item in moduledata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduledata.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.F_ItemId == item.F_Id);
                tree.hasChildren = true;
                tree.img = item.F_Icon == "" ? "" : item.F_Icon;
                treeList.Add(tree);
            }
            foreach (Sys_ModuleButtonInfo item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId == "0" ? item.F_ModuleId : item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.F_ItemId == item.F_Id);
                tree.hasChildren = hasChildren;
                tree.img = item.F_Icon == "" ? "" : item.F_Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormMuti(Sys_RoleInfo info, string permissionIds, string keyValue)
        {
            //增加角色
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
            }

            var moduledata = BLLFactory<Sys_Module>.Instance.GetAll();
            var buttondata = BLLFactory<Sys_ModuleButton>.Instance.GetAll();

            //增加角色权限
            List<Sys_RoleAuthorizeInfo> roleAuthorizeEntitys = new List<Sys_RoleAuthorizeInfo>();
            foreach (var itemId in permissionIds.Split(','))
            {
                Sys_RoleAuthorizeInfo roleAuthorizeEntity = new Sys_RoleAuthorizeInfo();
                roleAuthorizeEntity.F_Id = Common.GuId();
                roleAuthorizeEntity.F_ObjectType = 1;
                roleAuthorizeEntity.F_ObjectId = info.F_Id;
                roleAuthorizeEntity.F_ItemId = itemId;
                if (moduledata.Find(t => t.F_Id == itemId) != null)
                {
                    roleAuthorizeEntity.F_ItemType = 1;
                }
                if (buttondata.Find(t => t.F_Id == itemId) != null)
                {
                    roleAuthorizeEntity.F_ItemType = 2;
                }
                roleAuthorizeEntity.F_CreatorTime = DateTime.Now;
                roleAuthorizeEntity.F_CreatorUserId = CurrentUser.F_Account;
                roleAuthorizeEntitys.Add(roleAuthorizeEntity);
            }

            BLLFactory<Sys_Role>.Instance.Save(info, roleAuthorizeEntitys, keyValue);

            return Success("操作成功");
        }
    }
}