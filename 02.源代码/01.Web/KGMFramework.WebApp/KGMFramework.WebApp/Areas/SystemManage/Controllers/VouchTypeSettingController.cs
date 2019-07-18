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
using System.Data;
using KGMFramework.WebApp.Models;
using Stimulsoft.Base.Json;


namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class VouchTypeSettingController : BusinessController<Sys_VouchType, Sys_VouchTypeInfo>
    {
        public override ActionResult GetFormJson(string keyValue)
        {
            Sys_VouchTypeEntity info = new Sys_VouchTypeEntity();
            var mainEntity = BLLFactory<Sys_VouchType>.Instance.FindByID(keyValue);
            info.F_Id = mainEntity.F_Id;  //上级
            info.F_ParentId = mainEntity.F_ParentId;  //上级
            info.F_EnCode = mainEntity.F_EnCode; //编码
            info.F_FullName = mainEntity.F_FullName;//名称
            info.F_InoutType = mainEntity.F_InoutType;//出入库类别
            info.F_Prefix = mainEntity.F_Prefix;//前缀
            info.F_Source = mainEntity.F_Source;//来源类型
            info.F_SourceTable = mainEntity.F_SourceTable;//来源表
            info.F_SortCode = mainEntity.F_SortCode;//排序
            info.F_Bdefalut = mainEntity.F_Bdefalut;//默认来源
            info.F_IsFiFo = mainEntity.F_IsFiFo;//先进先出
            info.F_IsAllMatch = mainEntity.F_IsAllMatch;//完全匹配
            info.F_BrbFlag = mainEntity.F_BrbFlag;//红字
            info.F_Bprint = mainEntity.F_Bprint;//打印
            info.F_IsNeedDverfy = mainEntity.F_IsNeedDverfy;//审核
            info.F_EnabledMark = mainEntity.F_EnabledMark;//有效
            // info.F_Type = "2";

            // 通过主表ID 获取下方所有子表ID
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_VouchId", info.F_Id, SqlOperator.Equal, true, "g");
            var detailList = BLLFactory<Sys_VouchTypeDefault>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            foreach (Sys_VouchTypeDefaultInfo s in detailList)
            {
                //根据字典子表获取对应的字典类型
                string name = BLLFactory<Sys_Items>.Instance.GetNameByCode(s.F_FullName.Trim());

                switch (name)
                {
                    case "角色类型":
                        info.F_Type = s.F_EnCode;
                        break;
                    //case "归属组织":
                    //    info.F_OrganizeId = s.F_EnCode;
                    //    break;
                }

            }

            return Content(JsonAppHelper.ToJson(info));

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 提交业务设置表单信息
        /// </summary>
        /// <param name="entity">业务类型对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult submitFormMuti(Sys_VouchTypeInfo info, List<Sys_VouchTypeDefaultInfo> dInfo, string keyValue)
        {
            ResultModel result = new ResultModel();
            var list = new List<Sys_VouchTypeDefaultInfo>();
            try
            {
                //根据Key值，判断新增还是编辑
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
                //保存子表
                foreach (var vd in dInfo)
                {
                    Sys_VouchTypeDefaultInfo vds = new Sys_VouchTypeDefaultInfo();
                    vds.F_Id = Guid.NewGuid().ToString();
                    vds.F_EnCode = vd.F_EnCode;
                    vds.F_FullName = vd.F_FullName;
                    vds.F_VouchId = info.F_Id;
                    list.Add(vds);
                }
                BLLFactory<Sys_VouchType>.Instance.Save(info, list, keyValue);
            }
            catch (Exception ex)
            {
                result.bSuccess = false;
                result.message = ex.Message;
            }
            return Success("操作成功");
        }

        /// <summary>
        /// 删除主子表
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        /// <returns></returns>
        public override ActionResult DeleteForm(string keyValue, bool bLogicDelete = false)
        {

            BLLFactory<Sys_VouchType>.Instance.DeleteBatch(keyValue, bLogicDelete);
            return Success("删除成功");
        }

        public ActionResult GetTypeByParent(string F_FullName)
        {
            DataTable dt = BLLFactory<Sys_VouchType>.Instance.GetTypeByParent(F_FullName);
            return Content(JsonAppHelper.ToJson(dt));
        }


    }
}