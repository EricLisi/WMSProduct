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
using KGMFramework.WebApp.Controllers;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class SuppliersController : BusinessController<Mst_Suppliers, Mst_SuppliersInfo>
    {
        [HttpGet]
        public virtual ActionResult GetSelectJsonByType(string type, string orderBy = " Order By F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_EnCode", type, SqlOperator.Equal);
            Mst_SperCategoryInfo typeInfo = BLLFactory<Mst_SperCategory>.Instance.FindSingle(GetConditionStr(condition));
            List<object> list = new List<object>();
            if (type == null)
            {
                return Content(JsonAppHelper.ToJson(list));
            }

            condition = new SearchCondition();
            condition.AddCondition("F_CategoryID", typeInfo.F_Id, SqlOperator.Equal);
            var data = baseBLL.Find(GetConditionStr(condition), orderBy);
            foreach (Mst_SuppliersInfo item in data)
            {
                list.Add(new { id = item.F_EnCode, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));
        }


        protected override ResultModel DoAfterUploadFile(string fullFileName)
        {
            try
            {
                ResultModel result = new ResultModel();
                result.message = "";
                //读取文件 excel
                DataTable dt = KGMFramework.WebApp.Library.ExcelHelper.ExcelImport(fullFileName, 0);
                if (dt == null || dt.Rows.Count == 0)
                {
                    result.bSuccess = false;
                    result.message = "获取文件信息失败";
                    return result;
                }

                List<Mst_SuppliersInfo> SuppliersList = new List<Mst_SuppliersInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Mst_SuppliersInfo info = new Mst_SuppliersInfo();
                    info.F_EnCode = dt.Rows[i]["供应商编码"].ToString();
                    info.F_FullName = dt.Rows[i]["供应商名称"].ToString();
                    info.F_Contacts = dt.Rows[i]["联系人"].ToString();
                    info.F_TelePhone = dt.Rows[i]["电话"].ToString();
                    info.F_WeChat = dt.Rows[i]["微信"].ToString();
                    info.F_Fax = dt.Rows[i]["传真"].ToString();
                    info.F_Address = dt.Rows[i]["地址"].ToString();
                    info.F_Description = dt.Rows[i]["备注"].ToString();
                    SearchCondition search = new SearchCondition();
                    search.AddCondition("F_EnCode", dt.Rows[i]["供应商编码"].ToString(), SqlOperator.Equal);
                    search.AddCondition("F_FullName", dt.Rows[i]["供应商名称"].ToString(), SqlOperator.Equal);
                    List<Mst_GoodsInfo> infoList = BLLFactory<Mst_Goods>.Instance.Find(GetConditionStr(search));
                    if (infoList.Count > 0)
                    {
                        info.F_Id = infoList[0].F_Id;
                    }
                    SuppliersList.Add(info);

                }
                BLLFactory<Mst_Suppliers>.Instance.InsertRange(SuppliersList);
                result.bSuccess = true;
                result.message = "导入成功";


                return result;
            }
            catch (Exception)
            {
                ResultModel result = new ResultModel();
                result.bSuccess = true;
                result.message = "导入失败";
                return result;
            }
        }

    }
}