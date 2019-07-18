using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.BLL;

namespace KGMFramework.WebApp.Controllers
{
    public class ClientsDataController : BaseController
    {
        [HttpGet]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                duty = this.GetDutyList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = this.GetMenuButtonList(),
                //asseyType = this.GetAssetTypeList(),
                //supplierInfo = this.GetSupplierList(),
            };
            return Content(data.ToJson());
        }
        private object GetDataItemList()
        {
            var itemdata = BLLFactory<Sys_ItemsDetail>.Instance.GetAll();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            foreach (var item in BLLFactory<Sys_Items>.Instance.GetAll())
            {
                var dataItemList = itemdata.FindAll(t => t.F_ItemId.Equals(item.F_Id));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.F_ItemCode, itemList.F_ItemName);
                }
                string a = item.F_Id;
                dictionaryItem.Add(item.F_EnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }
        private object GetOrganizeList()
        {
            var data = BLLFactory<Sys_Organize>.Instance.GetAll();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Sys_OrganizeInfo item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        //private object GetAssetTypeList()
        //{
        //    var data = BLLFactory<Asset_Type>.Instance.GetAll();
        //    Dictionary<string, object> dictionary = new Dictionary<string, object>();
        //    foreach (Asset_TypeInfo item in data)
        //    {
        //        var fieldItem = new
        //        {
        //            encode = item.F_Id,
        //            fullname = item.F_FullName,
        //        };
        //        dictionary.Add(item.F_Id, fieldItem);
        //    }
        //    return dictionary;
        //}

        //private object GetSupplierList()
        //{
        //    var data = BLLFactory<MST_SupplierInfo>.Instance.GetAll();
        //    Dictionary<string, object> dictionary = new Dictionary<string, object>();
        //    foreach (MST_SupplierInfoInfo item in data)
        //    {
        //        var fieldItem = new
        //        {
        //            encode = item.F_Id,
        //            fullname = item.F_FullName,
        //        };
        //        dictionary.Add(item.F_Id, fieldItem);
        //    }
        //    return dictionary;
        //}
        private object GetRoleList()
        {
            var data = BLLFactory<Sys_Role>.Instance.GetAll();

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Sys_RoleInfo item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetDutyList()
        {

            //DutyApp dutyApp = new DutyApp();
            //var data = dutyApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            //foreach (RoleEntity item in data)
            //{
            //    var fieldItem = new
            //    {
            //        encode = item.F_EnCode,
            //        fullname = item.F_FullName
            //    };
            //    dictionary.Add(item.F_Id, fieldItem);
            //}
            return dictionary;
        }
        private object GetMenuList()
        {
            return ToMenuJson(BLLFactory<Sys_RoleAuthorize>.Instance.GetUserMenu(CurrentUser.F_Id), "0");
        }
        private string ToMenuJson(List<Sys_ModuleInfo> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<Sys_ModuleInfo> entitys = data.FindAll(t => t.F_ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.F_Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

        private object GetMenuButtonList()
        {
            var data = BLLFactory<Sys_RoleAuthorize>.Instance.GetUserButton(CurrentUser.F_Id);

            List<string> list = new List<string>();
            list = data.Select(t => t.F_ModuleId).ToList();  //只取F_ModuleId字段，重新生成新的List集合 
            var dataModuleId = list.Distinct().ToList(); //去重复，绑定数据后面要加ToList()

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (string F_ModuleId in dataModuleId)
            {
                var buttonList = data.Where(t => t.F_ModuleId.Equals(F_ModuleId));
                dictionary.Add(F_ModuleId, buttonList);
            }
            return dictionary;
        }
    }
}