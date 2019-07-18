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
    public class WarehouseController : BusinessController<Mst_Warehouse, Mst_WarehouseInfo>
    {

        /// <summary>
        /// 提交保存前处理对象
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override ResultModel OnBeforeSubmitForm(Mst_WarehouseInfo info)
        {
            ResultModel result = new ResultModel { bSuccess = true, message = string.Empty };
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_EnCode", info.F_EnCode, SqlOperator.Equal);
            //得到勾选的货位集合 
            if (BLLFactory<Mst_Warehouse>.Instance.IsExistRecord(GetConditionStr(condition)))
            {
                result.bSuccess = false;
                result.message = "编码已经存在!";
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="Name"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public ActionResult UpMark(string keyValue, string Name, bool State)
        {
            try
            {
                Mst_WarehouseInfo info = BLLFactory<Mst_Warehouse>.Instance.FindByID(keyValue);
                Hashtable hash = new Hashtable();
                //判断是否是仓库仓库做操作
                if (Name == "F_EnabledMark")
                {
                    hash.Add("F_EnabledMark", State);
                    //如果是禁用仓库，便禁用此仓库下的货位
                    if (!State)
                    {
                        hash.Add("F_CarGoMark", State);
                        BLLFactory<Mst_Warehouse>.Instance.Update(info.F_Id, hash);
                        hash = new Hashtable();

                    }
                    else
                    {
                        BLLFactory<Mst_Warehouse>.Instance.Update(info.F_Id, hash);
                    }
                }
                else
                {
                    hash.Add("F_CarGoMark", State);
                    BLLFactory<Mst_Warehouse>.Instance.Update(info.F_Id, hash);
                }

                return Success("操作成功");
            }
            catch (Exception)
            {

                return Error("操作失败");
            }
        }


        public ActionResult WarStatus(string keyValue)
        {

            //查找库存是否有产品在此仓库中
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_WarehouseId", keyValue, SqlOperator.Equal);
            //获取次仓库产品的个数
            int count = BLLFactory<Sys_Stock>.Instance.Find(GetConditionStr(search)).Count;
            if (count > 0)
            {
                return Content("Fasle");
            }
            else
            {
                return Content("True");
            }



        }


        public bool IsNullEnCode(string EnCode)
        {
            SearchCondition conditon = new SearchCondition();
            conditon.AddCondition("F_EnCode", EnCode, SqlOperator.Equal);
            int count = BLLFactory<Mst_Warehouse>.Instance.Find(GetConditionStr(conditon)).Count;
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}