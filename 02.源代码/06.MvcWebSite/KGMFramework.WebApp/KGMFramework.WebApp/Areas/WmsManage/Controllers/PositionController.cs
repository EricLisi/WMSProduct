using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using KGM.Pager.Entity;
using KGMFramework.WebApp.Areas.WmsManage.Model;
using KGMFramework.WebApp.BLL;
using KGMFramework.WebApp.Controllers;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.Library;
using KGMFramework.WebApp.Models;
using Stimulsoft.Base.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KGMFramework.WebApp.Areas.WmsManage.Controllers
{
    /// <summary>
    /// 仓库管理单控制器
    /// </summary>
    public class PositionController : BusinessController<Mst_Position, Mst_PositionInfo>
    {

        public ActionResult Form1()
        {
            return View();
        }

        /// <summary>
        /// 加载列表
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="pagination">分页信息</param>
        /// <param name="sortFiled">排序字段</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetListGridJsonPagination(string filterStr, Pagination pagination, string sidx = " F_EnCode ", string sord = "desc")
        {
            if (string.IsNullOrEmpty(sidx))
            {
                sidx = " F_EnCode ";
            }
            PagerInfo pager = GetPageInfo(pagination);
            List<AdvSearchEntity> advSearchList = new List<AdvSearchEntity>();
            List<Mst_PositionInfo> lista;
            if (string.IsNullOrEmpty(filterStr))
            {
                lista = baseBLL.FindWithPager(GetKeywordCondition("", filterStr), pager, sidx, sord.ToLower() == "desc");

            }
            else
            {

                PositionFilter filter = JsonAppHelper.ToObject<PositionFilter>(filterStr);

                if (!string.IsNullOrEmpty(filter.F_EnCode))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnCode,
                        F_searchFiled = "F_EnCode",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_FullName))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_FullName,
                        F_searchFiled = "F_FullName",
                        F_type = "2"
                    });
                }
                if (!string.IsNullOrEmpty(filter.F_EnabledMark))
                {
                    advSearchList.Add(new AdvSearchEntity
                    {
                        F_condition = "And",
                        F_fvalue = filter.F_EnabledMark,
                        F_searchFiled = "F_EnabledMark",
                        F_type = "0"
                    });
                }
                lista = BLLFactory<Mst_Position>.Instance.FindWithPager(GetAdvCondition(advSearchList), pager, sidx, sord.ToLower().Equals("desc"));

            }

            return GetPagerContent<Mst_PositionInfo>(lista, pager);
        }


        /// <summary>
        /// 获取treegrid的JSON
        /// </summary>
        /// <param name="keyword">查询值</param>
        /// <param name="searchFiled">查询字段</param>
        /// <param name="orderBy">排序条件 格式 Order By 字段 默认F_SortCode</param>
        /// <returns></returns>
        [HttpGet]
        public override ActionResult GetTreeGridJson(string keyword, string searchFiled, string list, string orderBy = " ORDER BY F_SortCode ")
        {
            string[] classnameList = typeof(Mst_PositionInfo).ToString().Split('.');
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
            var data = JsonAppHelper.ToList<Mst_PositionInfo>(dataStr);
            foreach (var item in data)
            {
                string name = BLLFactory<Mst_Warehouse>.Instance.FindByID(item.F_WarehouseId).F_FullName;
                item.F_WarehouseName = string.IsNullOrEmpty(name) ? "" : name;
            }
            return Content(GetTreeGridJsonStr(data));
        }
        /// <summary>
        /// 禁用或启用货位
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult UpEnMark(string Status, string Id)
        {
            Hashtable has = new Hashtable
            {
                { "F_EnabledMark", Status }
            };
            ResultModel result = new ResultModel();
            result.bSuccess = BLLFactory<Mst_Position>.Instance.Update(Id, has);
            result.message = result.bSuccess ? "操作成功" : "操作失败，请刷新后重试";
            return Content(JsonAppHelper.ToJson(result));
        }

        /// <summary>
        /// 添加之前的判断
        /// </summary>
        /// <param name="warehouseInfo"></param>
        /// <returns></returns>
        public override ActionResult SubmitForm(Mst_PositionInfo info, string keyValue)
        {
            SearchCondition search = new SearchCondition();//查找编码
            search.AddCondition("F_EnCode", info.F_EnCode, SqlOperator.Equal);
            List<Mst_PositionInfo> list = BLLFactory<Mst_Position>.Instance.Find(GetConditionStr(search));
            if (string.IsNullOrEmpty(keyValue))//判断是添加还是修改
            {
                if (list.Count > 0)
                    return Error("编码已存在，请重新输入！");
            }
            else
            {
                Mst_PositionInfo positionInfo = BLLFactory<Mst_Position>.Instance.FindByID(keyValue);//获取修改前的信息
                if (list.Count > 0 && positionInfo.F_EnCode !=info.F_EnCode)//如果编码存在且不为以前的编码进行返回
                    return Error("编码已存在，请重新输入！");

            }
            if (string.IsNullOrEmpty(keyValue))
            {
                info.F_CreatorTime = DateTime.Now;
                info.F_CreatorUserId = CurrentUser.F_Account;
                info.F_Id = Guid.NewGuid().ToString();

            }
            else
            {
                info.F_Id = keyValue;
                info.F_LastModifyTime = DateTime.Now;
                info.F_LastModifyUserId = CurrentUser.F_Account;


            }
            BLLFactory<Mst_Position>.Instance.InsertUpdate(info, keyValue);//否则添加或修改

            return Success("操作成功", info);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="F_BenginNum"></param>
        /// <param name="F_EndNum"></param>
        /// <param name="F_Prefix"></param>
        /// <param name="Info"></param>
        /// <returns></returns>
        public ActionResult SubmitForm1(int F_BenginNum, int F_EndNum, string F_Prefix, Mst_PositionInfo Info)
        {
            ResultModel result = new ResultModel();
            //拼接编号
            List<Mst_PositionInfo> list = new List<Mst_PositionInfo>();
            List<Mst_PositionInfo> infoList = BLLFactory<Mst_Position>.Instance.GetAll();

            //循环添加
            for (int i = F_BenginNum; i <= F_EndNum; i++)
            {
                Mst_PositionInfo info = new Mst_PositionInfo();

                info.F_WarehouseId = Info.F_WarehouseId;
                info.F_Property = Info.F_Property;
                info.F_Type = Info.F_Type;
                info.F_EnabledMark = Info.F_EnabledMark;
                info.F_ParentId = Info.F_ParentId;
                info.F_Description = Info.F_Description;
                info.F_EnCode = F_Prefix + i.ToString().PadLeft(F_EndNum.ToString().Length, '0');
                info.F_FullName = Info.F_FullName;
                list.Add(info);
                if (infoList.FindAll(u=>u.F_EnCode==info.F_EnCode).Count>0)
                {
                    result.bSuccess = false;
                    result.message = info.F_EnCode+"已存在，请输入合适序号";
                    return Content(JsonAppHelper.ToJson(result));
                }
            }

           result.bSuccess=   BLLFactory<Mst_Position>.Instance.InsertRange(list);
            result.message = result.bSuccess == true ? "添加成功" : "添加失败，请刷新后重试";
            return Content(JsonAppHelper.ToJson(result));
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="bLogicDelete">是否逻辑删除 默认false</param>
        /// <returns></returns>
        public  ActionResult DeleteForm(string keyValue)
        {
            List<string> ids = new List<string>();
            List<Mst_PositionInfo> infos = BLLFactory<Mst_Position>.Instance.GetAll().FindAll(u => u.F_ParentId == keyValue);
            foreach (var item in infos)
            {
                ids.Add(item.F_Id);
            }

            ids.Add(keyValue);
            foreach (var item in ids)
            {
                BLLFactory<Mst_Position>.Instance.Delete(item);
            }
            ResultModel result = new ResultModel();
            result.bSuccess=true;
            result.message = result.bSuccess ? "删除成功" : "删除失败，请刷新后重试";
            return Content(JsonAppHelper.ToJson(result));
        }

    }
}