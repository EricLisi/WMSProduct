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
using System.Collections;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    public class CargoPositionController : BusinessController<Mst_CargoPosition, Mst_CargoPositionInfo>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="searchFiled"></param>
        /// <param name="list"></param>
        /// <param name="pagination"></param>
        /// <param name="sortFiled"></param>
        /// <returns></returns>
        public override ActionResult GetGridJsonPagination(string keyword, string searchFiled, string list, Pagination pagination, string sortFiled = " F_SortCode ")
        {
            List<Mst_CargoPositionInfo> CarInfo = null;
            PagerInfo pager = GetPageInfo(pagination);
            if (string.IsNullOrEmpty(list))
            {
                CarInfo = BLLFactory<Mst_CargoPosition>.Instance.FindWithPager(GetKeywordCondition(keyword, searchFiled), pager, sortFiled);
            }
            else
            {
                CarInfo = BLLFactory<Mst_CargoPosition>.Instance.FindWithPager(GetKeywordCondition(keyword, searchFiled), pager, sortFiled);
            }
            List<Mst_WarehouseInfo> WarInfo = BLLFactory<Mst_Warehouse>.Instance.GetAll();
            foreach (Mst_CargoPositionInfo item in CarInfo)
            {
                item.F_WarehouseName = WarInfo.Find(u => u.F_Id == item.F_WarehouseId).F_FullName;
            }
            return GetPagerContent(CarInfo, pager);
        }



        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="info">对象</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public ActionResult SubmitForm1(Mst_CargoPositionInfo Info, int F_BenginNum, int F_EndNum, string F_Prefix)
        {
            //拼接编号
            List<Mst_CargoPositionInfo> list = new List<Mst_CargoPositionInfo>();
            //循环添加
            for (int i = F_BenginNum; i <= F_EndNum; i++)
            {
                Mst_CargoPositionInfo info = new Mst_CargoPositionInfo();
                info.F_FullName = Info.F_FullName;
                info.F_WarehouseId = Info.F_WarehouseId;
                info.F_Unit = Info.F_Unit;
                info.F_Description = Info.F_Description;
                string Num = i + "";
                while (Num.Length < 4)
                {
                    Num = "0" + Num;
                }
                info.F_EnCode = F_Prefix + Num;
                //info.F_FullName += Num;
                list.Add(info);
            }
            try
            {
                BLLFactory<Mst_CargoPosition>.Instance.InsertRange(list);
                return Success(JsonAppHelper.ToJson(list));
            }
            catch (Exception ex)
            {
                return Error("货位编码已存在，请重新输入");
            }

        }
        /// <summary>
        /// 更改货位标识
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult UpMark(string keyValue, bool state)
        {
            Mst_CargoPositionInfo info = BLLFactory<Mst_CargoPosition>.Instance.FindByID(keyValue);
            Hashtable hash = new Hashtable();
            hash.Add("F_EnabledMark", state);
            BLLFactory<Mst_CargoPosition>.Instance.Update(info.F_Id, hash);
            return Success("操作成功");
        }
        /// <summary>
        /// 查询货位上是否存在产品
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult WarStatus(string keyValue)
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_CargoPositionId", keyValue, SqlOperator.Equal);
            int count = BLLFactory<Sys_Stock>.Instance.Find(GetConditionStr(search)).Count;
            if (count > 0)
            {
                return Content("False");
            }
            else
            {
                return Content("True");
            }


        }
        public ActionResult Form1()
        {
            return View();
        }
    }


}