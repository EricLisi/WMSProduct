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
    public class GoodsController : BusinessController<Mst_Goods, Mst_GoodsInfo>
    {
        public ActionResult Index1()
        {
            return View();
        }


        /// <summary>
        /// 提交保存前处理对象
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override ResultModel OnBeforeSubmitForm(Mst_GoodsInfo info)
        {
            ResultModel result = new ResultModel { bSuccess = true, message = string.Empty };
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_EnCode", info.F_EnCode, SqlOperator.Equal);
            //得到勾选的货位集合 
            if (BLLFactory<Mst_Goods>.Instance.IsExistRecord(GetConditionStr(condition)))
            {
                result.bSuccess = false;
                result.message = "编码已经存在!";
            }
            return result;
        }


        [HttpGet]
        public virtual ActionResult GetSelectJsonByType(string type, string orderBy = " Order By F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_EnCode", type, SqlOperator.Equal);
            Mst_CategoryInfo typeInfo = BLLFactory<Mst_Category>.Instance.FindSingle(GetConditionStr(condition));
            List<object> list = new List<object>();
            if (type == null)
            {
                return Content(JsonAppHelper.ToJson(list));
            }

            condition = new SearchCondition();
            condition.AddCondition("F_CategoryID", typeInfo.F_Id, SqlOperator.Equal);
            var data = baseBLL.Find(GetConditionStr(condition), orderBy);
            foreach (Mst_GoodsInfo item in data)
            {
                list.Add(new { id = item.F_EnCode, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));
        }


        public ActionResult GetFormJson1(string keyValue)
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_GoodsId", keyValue, SqlOperator.Equal);
            List<Sys_StockInfo> list = BLLFactory<Sys_Stock>.Instance.Find(condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty));
            return Content(JsonAppHelper.ToJson(list));
        }

        public ActionResult PrintForm()
        {
            return View();
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

                List<Mst_GoodsInfo> GoodsList = new List<Mst_GoodsInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Mst_GoodsInfo info = new Mst_GoodsInfo();
                    info.F_EnCode = dt.Rows[i]["商品编码"].ToString();
                    info.F_FullName = dt.Rows[i]["商品名称"].ToString();
                    info.F_SpecifModel = dt.Rows[i]["规格型号"].ToString();
                    info.F_Unit = dt.Rows[i]["单位"].ToString();
                    info.F_ShelfLife = dt.Rows[i]["保质期(天)"].ToString();
                    info.F_SellingPrice = dt.Rows[i]["销售价格（元）"].ToString();
                    info.F_PurchasePrice = dt.Rows[i]["采购价格（元）"].ToString();
                    info.F_BasicRate = dt.Rows[i]["基本税率"].ToString();
                    info.F_Description = dt.Rows[i]["备注"].ToString();
                    info.F_ProDate = dt.Rows[i]["生产日期"].ToDate();
                    info.F_Long = dt.Rows[i]["长度（cm）"].ToString();
                    info.F_Wide = dt.Rows[i]["宽度(cm)"].ToString();
                    info.F_Height = dt.Rows[i]["高度(cm)"].ToString();
                    info.F_NetWeight = dt.Rows[i]["净重（kg）"].ToString();
                    info.F_GrossWeight = dt.Rows[i]["毛重（kg）"].ToString();
                    info.F_Volume = dt.Rows[i]["体积（cm²）"].ToString();
                    info.F_EnabledMark = true;
                    SearchCondition search = new SearchCondition();
                    search.AddCondition("F_EnCode", dt.Rows[i]["商品编码"].ToString(), SqlOperator.Equal);
                    search.AddCondition("F_FullName", dt.Rows[i]["商品名称"].ToString(), SqlOperator.Equal);
                    List<Mst_GoodsInfo> infoList = BLLFactory<Mst_Goods>.Instance.Find(GetConditionStr(search));
                    if (infoList.Count > 0)
                    {
                        info.F_Id = infoList[0].F_Id;
                    }
                    GoodsList.Add(info);

                }
                BLLFactory<Mst_Goods>.Instance.InsertRange(GoodsList);
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

        public ActionResult GetOpenBatch(string keyValue)
        {
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_Id", keyValue, SqlOperator.Equal);
            Mst_GoodsInfo good = BLLFactory<Mst_Goods>.Instance.FindSingle((search.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty)));
            if (good.F_OpenBatch)
            {
                return Content(JsonAppHelper.ToJson(good.F_OpenBatch));
            }
            else
            {
                return Content(JsonAppHelper.ToJson(good.F_OpenBatch));
            }
        }




        /// <summary>
        /// 首页单据状态更新
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGoodsNum()
        {
            int InNum = 0, OutNum = 0, MaskNum = 0;
            SearchCondition search = new SearchCondition();
            search.AddCondition("F_State", 0, SqlOperator.Equal);
            //获取所有未审核的单据
            InNum = BLLFactory<PI_Head>.Instance.Find(GetConditionStr(search)).Count;
            SearchCondition search1 = new SearchCondition();
            search1.AddCondition("F_Status", "0", SqlOperator.Equal);
            //获取所有未审核的单据
            OutNum = BLLFactory<SO_Head>.Instance.Find(GetConditionStr(search1)).Count;

            SearchCondition search2 = new SearchCondition();
            search2.AddCondition("F_Status", "0", SqlOperator.Equal);
            //获取所有未审核的单据
            MaskNum = BLLFactory<SO_StockMakeHead>.Instance.Find(GetConditionStr(search2)).Count;


            DataTable dt = new DataTable();
            dt.Columns.Add("InNum");
            dt.Columns.Add("OutNum");
            dt.Columns.Add("MaskNum");
            DataRow dr = dt.NewRow();
            dr["InNum"] = InNum;
            dr["OutNum"] = OutNum;
            dr["MaskNum"] = MaskNum;

            dt.Rows.Add(dr);
            return Content(JsonAppHelper.ToJson(dt));
        }
        /// <summary>
        /// 首页每月出入库盘点舒朗更新
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMothNum()
        {
            //生成list保存数据源
            List<GetMothNum> list = new List<Controllers.GetMothNum>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    GetMothNum GetList = new GetMothNum();
                    GetList.Month = j;
                    GetList.Num = 0;
                    GetList.Type = i;
                    list.Add(GetList);
                }
            }



            List<PI_BodyInfo> pl = BLLFactory<PI_Body>.Instance.GetAll();
            foreach (PI_BodyInfo item in pl)
            {
                if (item.F_CreatorTime.ToString() != null && item.F_CreatorTime.ToString() != "")
                {
                    DateTime time = DateTime.Parse(item.F_CreatorTime.ToString());
                    int moth = time.Month;
                    GetMothNum num = list.Find(u => u.Type == 0 && u.Month == moth);
                    if (num != null)
                    {
                        num.Num += item.F_InStockNum;
                    }

                }

            }


            List<SO_BodyInfo> so = BLLFactory<SO_Body>.Instance.GetAll();
            foreach (SO_BodyInfo item in so)
            {
                if (item.F_CreatorTime.ToString() != null && item.F_CreatorTime.ToString() != "")
                {
                    DateTime time = DateTime.Parse(item.F_CreatorTime.ToString());
                    int moth = time.Month;
                    GetMothNum num = list.Find(u => u.Type == 1 && u.Month == moth);
                    if (num != null)
                    {
                        num.Num += item.F_OutStockNum;
                    }

                }

            }


            List<SO_ReturnedStockBodyInfo> returnStock = BLLFactory<SO_ReturnedStockBody>.Instance.GetAll();
            foreach (SO_ReturnedStockBodyInfo item in returnStock)
            {
                if (item.F_CreatorTime.ToString() != null && item.F_CreatorTime.ToString() != "")
                {
                    DateTime time = DateTime.Parse(item.F_CreatorTime.ToString());
                    int moth = time.Month;
                    GetMothNum num = list.Find(u => u.Type == 2 && u.Month == moth);
                    if (num != null)
                    {
                        num.Num += item.F_ReturnNum;
                    }

                }

            }



            List<PI_ReturnBodyInfo> plReturnStock = BLLFactory<PI_ReturnBody>.Instance.GetAll();
            foreach (PI_ReturnBodyInfo item in plReturnStock)
            {
                if (item.F_CreatorTime.ToString() != null && item.F_CreatorTime.ToString() != "")
                {
                    DateTime time = DateTime.Parse(item.F_CreatorTime.ToString());
                    int moth = time.Month;
                    GetMothNum num = list.Find(u => u.Type == 3 && u.Month == moth);
                    if (num != null)
                    {
                        num.Num += item.F_ReturnNum;
                    }

                }

            }
            return Content(JsonAppHelper.ToJson(list));
        }
    }
    public class GetMothNum
    {
        public int Month;
        public int Num;
        public int Type;
    }
}