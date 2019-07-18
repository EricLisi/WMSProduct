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
using System.Collections;
using KGMFramework.WebApp.Models;
using System.Data;
using Stimulsoft.Base.Json;

namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class UserController : BusinessController<Sys_User, Sys_UserInfo>
    {
        public ActionResult RevisePassword()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }


        public ActionResult ChangeDep()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetSelectJsonByDept(string deptId, string sortFiled = " Order By F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_DepartmentId", deptId, SqlOperator.Equal);
            var data = baseBLL.Find(GetConditionStr(condition), sortFiled);
            List<object> list = new List<object>();
            foreach (Sys_UserInfo item in data)
            {
                list.Add(new { id = item.F_Id, text = item.F_RealName });
            }
            return Content(JsonAppHelper.ToJson(list));
        }


        /// <summary>
        /// 在插入数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override ResultModel OnBeforeSubmitForm(Sys_UserInfo info)
        {
            ResultModel result = new ResultModel();
            result.bSuccess = true;
            result.message = string.Empty;
            if (info == null)
            {
                result.bSuccess = false;
                result.message = "未能找到用户信息!";
            }
            info.F_UserPassword = DESEncrypt.Encrypt(info.F_UserPassword);
            return result;
        }

        /// <summary>
        /// 在获取窗体权限前做的事件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override ResultModel OnBeforeGetFormJson(Sys_UserInfo info)
        {
            ResultModel result = new ResultModel();
            result.bSuccess = true;
            result.message = string.Empty;
            if (info == null)
            {
                result.bSuccess = false;
                result.message = "未能找到用户信息!";
            }
            info.F_UserPassword = DESEncrypt.Decrypt(info.F_UserPassword);
            return result;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            Hashtable hash = new Hashtable();
            hash.Add("F_UserPassword", DESEncrypt.Encrypt(userPassword));
            baseBLL.Update(keyValue, hash);
            return Success("重置密码成功");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisabledAccount(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("请先选择需要禁用的账户");
            }
            Hashtable hash = new Hashtable();
            hash.Add("F_EnabledMark", false);
            baseBLL.Update(keyValue, hash);
            return Success("账户禁用成功");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnabledAccount(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("请先选择需要启用的账户");
            }
            Hashtable hash = new Hashtable();
            hash.Add("F_EnabledMark", true);
            baseBLL.Update(keyValue, hash);
            return Success("账户启用成功");
        }


        protected override ResultModel DoAfterUploadFile(string fullFileName)
        {
            ResultModel result = new ResultModel();
            result.message = "";
            //读取文件 excel
            DataTable dt = KGMFramework.WebApp.Library.ExcelHelper.ExcelImport(fullFileName, 0);
            if (dt == null || dt.Rows.Count == 0)
            {
                result.bSuccess = false;
                result.message = "未读取到文件";

                return result;
            }
            List<Sys_UserInfo> userlist = BLLFactory<Sys_User>.Instance.GetAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_UserInfo uinfo = new Sys_UserInfo();
                string cname = dt.Rows[i]["公司主体"].ToString();
                SearchCondition condition0 = new SearchCondition();
                condition0.AddCondition("F_FullName", cname, SqlOperator.Equal);
                condition0.AddCondition("F_CategoryId", "Company", SqlOperator.Equal);
                Sys_OrganizeInfo coinfo = BLLFactory<Sys_Organize>.Instance.FindSingle(GetConditionStr(condition0));
                if (coinfo == null)
                {
                    result.message += "第" + (i + 1) + "行员工公司不存在,该条数据导入失败,";
                    continue;
                }
                uinfo.F_OrganizeId = coinfo.F_Id;
                uinfo.F_Account = dt.Rows[i]["工号"].ToString();
                uinfo.F_RealName = dt.Rows[i]["姓名"].ToString();
                string oid = dt.Rows[i]["BU"].ToString();
                SearchCondition condition = new SearchCondition();
                condition.AddCondition("F_Id", oid, SqlOperator.Equal);
                Sys_OrganizeInfo oinfo = BLLFactory<Sys_Organize>.Instance.FindSingle(GetConditionStr(condition));
                if (oinfo == null)
                {
                    result.message += "第" + (i + 1) + "行员工部门不存在,该条数据导入失败,";
                    continue;
                }
                uinfo.F_DepartmentId = oid;
                uinfo.F_EnabledMark = true;
                uinfo.F_UserPassword = "123456";
                uinfo.F_UserPassword = DESEncrypt.Encrypt(uinfo.F_UserPassword);
                uinfo.F_RoleId = "fb5873ff-58ca-4d97-859d-945bedc52866";
                SearchCondition condition1 = new SearchCondition();
                condition1.AddCondition("F_Account", uinfo.F_Account, SqlOperator.Equal);
                Sys_UserInfo oooinfo = BLLFactory<Sys_User>.Instance.FindSingle(GetConditionStr(condition1));
                if (oooinfo == null)
                {
                    BLLFactory<Sys_User>.Instance.Insert(uinfo);
                }
                else
                {
                    BLLFactory<Sys_User>.Instance.Update(uinfo, oooinfo.F_Id);
                }
            }
            result.bSuccess = true;
            return result;
        }
        public override ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sidx = " F_SortCode ", string sord = "asc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_SortCode ";
            }
            List<Sys_UserInfo> lista;
            PagerInfo pager = GetPageInfo(pagination);
            if (string.IsNullOrEmpty(list))
            {
                var condition = GetKeywordConditionObj(keyword, searchFiled);
                condition.AddCondition("F_OrganizeId", CurrentUser.F_OrganizeId, SqlOperator.Equal);

                lista = baseBLL.FindWithPager(GetConditionStr(condition), pager, sidx, sord.ToLower() == "desc");
            }
            else
            {
                List<AdvSearchEntity> a = JsonConvert.DeserializeObject<List<AdvSearchEntity>>(list);
                var condition = GetAdvConditionObj(a);
                condition.AddCondition("F_OrganizeId", CurrentUser.F_OrganizeId, SqlOperator.Equal);

                lista = baseBLL.FindWithPager(GetConditionStr(condition), pager, sidx, sord.ToLower() == "desc");
            }

            List<Sys_OrganizeInfo> orglist = BLLFactory<Sys_Organize>.Instance.GetAll();

            for (int i = 0; i < lista.Count; i++)
            {
                var corp = orglist.Find(t => t.F_Id == lista[i].F_OrganizeId);
                lista[i].F_CompanyName = corp == null ? "" : corp.F_FullName;
                var dep = orglist.Find(t => t.F_Id == lista[i].F_DepartmentId);
                lista[i].F_DepartmentName = dep == null ? "" : dep.F_FullName;
            }
            return GetPagerContent(lista, pager);
        }


        public ActionResult ChangeDepartment(List<string> list, string deptId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("USERID", typeof(string));

            foreach (string str in list)
            {
                DataRow dr = dt.NewRow();
                dr["USERID"] = str;
                dt.Rows.Add(dr);
            }


            BLLFactory<Sys_User>.Instance.ChangeDepartment(CurrentUser.F_RealName, deptId, dt);
            return Success("操作成功!");
        }
    }
}