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
using KGMFramework.WebApp.Models;
using System.Data;


namespace KGMFramework.WebApp.Areas.SystemManage.Controllers
{
    public class OrganizeController : BusinessController<Sys_Organize, Sys_OrganizeInfo>
    {
        //protected override ResultModel OnBeforeDelete(string[] arry)
        //{
        //    ResultModel result = new ResultModel();

        //    SearchCondition condition = new SearchCondition();
        //    foreach (string str in arry)
        //    {
        //        condition.AddCondition("F_CompanyId", str, SqlOperator.Equal, true, "a");
        //    }
             
        //    result.bSuccess = !BLLFactory<Asset_Information>.Instance.IsExistRecord(GetConditionStr(condition)); 
        //    result.message = result.bSuccess ? "" : "机构下存在资产,不允许删除!"; 
        //    return result;
        //}


        [HttpGet]
        public ActionResult GetTreeSelectJsonByUser(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();

            condition.AddCondition("F_ParentId", CurrentUser.F_OrganizeId, SqlOperator.Equal);
            condition.AddCondition("F_CategoryId", "Department", SqlOperator.Equal);

            var data = baseBLL.Find(GetConditionStr(condition), orderBy);

            List<object> list = new List<object>();
            foreach (Sys_OrganizeInfo item in data)
            {
                list.Add(new { id = item.F_Id, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));

            //return Content(GetTreeSelectJsonStr(data));
        }


        [HttpGet]
        public ActionResult GetTreeSelectCompanyJsonByUser(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_Id", CurrentUser.F_OrganizeId, SqlOperator.Equal, true, "a");

            var data = baseBLL.Find(GetConditionStr(condition), orderBy);
            List<object> list = new List<object>();
            foreach (Sys_OrganizeInfo item in data)
            {
                list.Add(new { id = item.F_Id, text = item.F_FullName });
            }
            return Content(JsonAppHelper.ToJson(list));

            //return Content(GetTreeSelectJsonStr(data));
        }

        [HttpGet]
        public ActionResult GetTreeSelectCompanyJson(string orderBy = " ORDER BY F_SortCode ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_CategoryId", "Group", SqlOperator.Equal, true, "a");
            condition.AddCondition("F_CategoryId", "Company", SqlOperator.Equal, true, "a");



            var data = baseBLL.Find(GetConditionStr(condition), orderBy);
            return Content(GetTreeSelectJsonStr(data));
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
                result.message = "";

                return result;
            }

            List<Sys_OrganizeInfo> orglist = BLLFactory<Sys_Organize>.Instance.GetAll();
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ParentId", "0", SqlOperator.Equal);
            Sys_OrganizeInfo oinfo = BLLFactory<Sys_Organize>.Instance.FindSingle(GetConditionStr(condition));
            List<Sys_OrganizeInfo> insertList = new List<Sys_OrganizeInfo>();

            //先写入第一层BU
            DataView dvBu = new DataView(dt);
            //去重过滤
            DataTable dtBu = dvBu.ToTable(true, new string[] { "编码", "BU", "上级机构编码", "类别" });
            for (int i = 0; i < dtBu.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                //现根据名字得到编码
                Sys_OrganizeInfo buInfo = new Sys_OrganizeInfo();
                if (dr[0].ToString() == "")
                {
                    result.bSuccess = false;
                    result.message += "第" + i + 1 + "行机构编码为空";
                    continue;
                }
                buInfo.F_Id = dr[0].ToString();
                buInfo.F_EnCode = dr[0].ToString();

                SearchCondition condition1 = new SearchCondition();
                condition1.AddCondition("F_EnCode", dr[2].ToString(), SqlOperator.Equal);
                Sys_OrganizeInfo oinfo1 = BLLFactory<Sys_Organize>.Instance.FindSingle(GetConditionStr(condition1));
                if (oinfo1 == null)
                {
                    result.bSuccess = false;
                    result.message += "第" + i + 1 + "行上级编码不存在";
                    continue;
                }
                buInfo.F_ParentId = oinfo1.F_Id;
                buInfo.F_Layers = 1;
                buInfo.F_FullName = dr[1].ToString();
                buInfo.F_CategoryId = dr[3].ToString();
                //判断code是否存在 不存在 insert
                insertList.Add(buInfo);

                //从导入的dt中 根据BU 过滤出一级部门
                //DataView dvFirst = new DataView(dt);
                //dvFirst.RowFilter = string.Format("BU='{0}'", dr[0].ToString());
                //DataTable dtFirst = dvFirst.ToTable(true,new string[]{"一级部门"});
                //foreach (DataRow drFirst in dtFirst.Rows)
                //{
                //    if (drFirst[0].ToString() == "")
                //    {
                //        continue;
                //    }
                //    string firstCode = string.Format("{0}-{1}", buCode, Common.GetPYString(drFirst[0].ToString()));
                //    Sys_OrganizeInfo firstInfo = new Sys_OrganizeInfo();
                //    firstInfo.F_Id = firstInfo.F_EnCode = firstCode;
                //    firstInfo.F_ParentId = buInfo.F_Id;
                //    firstInfo.F_Layers = 2;
                //    firstInfo.F_FullName = drFirst[0].ToString();
                //    firstInfo.F_CategoryId = "一级部门";
                //    if (!orglist.Exists(t => t.F_Id.Equals(firstCode)))
                //    {
                //        insertList.Add(firstInfo);
                //    }

                //    DataView dvSecond = new DataView(dt);
                //    dvSecond.RowFilter = string.Format("一级部门='{0}'", drFirst[0].ToString());
                //    DataTable dtSecond = dvSecond.ToTable(true, new string[] { "二级部门" });
                //    foreach (DataRow drSecond in dtSecond.Rows)
                //    {
                //        if (drSecond[0].ToString() == "")
                //        {
                //            continue;
                //        }
                //        string SecondCode = string.Format("{0}-{1}", firstCode, Common.GetPYString(drSecond[0].ToString()));
                //        Sys_OrganizeInfo SecondInfo = new Sys_OrganizeInfo();
                //        SecondInfo.F_Id = SecondInfo.F_EnCode = SecondCode;
                //        SecondInfo.F_ParentId = firstInfo.F_Id;
                //        SecondInfo.F_Layers = 3;
                //        SecondInfo.F_FullName = drSecond[0].ToString();
                //        SecondInfo.F_CategoryId = "二级部门";
                //        if (!orglist.Exists(t => t.F_Id.Equals(SecondCode)))
                //        {
                //            insertList.Add(SecondInfo);
                //        }

                //        DataView dvThird = new DataView(dt);
                //        dvThird.RowFilter = string.Format("二级部门='{0}'", drSecond[0].ToString());
                //        DataTable dtThird = dvThird.ToTable(true, new string[] { "三级部门" });
                //        foreach (DataRow drThird in dtThird.Rows)
                //        {
                //            if (drThird[0].ToString() == "")
                //            {
                //                continue;
                //            }
                //            string ThirdCode = string.Format("{0}-{1}", SecondCode, Common.GetPYString(drThird[0].ToString()));
                //            Sys_OrganizeInfo ThirdInfo = new Sys_OrganizeInfo();
                //            ThirdInfo.F_Id = ThirdInfo.F_EnCode = ThirdCode;
                //            ThirdInfo.F_ParentId = SecondInfo.F_Id;
                //            ThirdInfo.F_Layers = 4;
                //            ThirdInfo.F_FullName = drThird[0].ToString();
                //            ThirdInfo.F_CategoryId = "三级部门";
                //            if (!orglist.Exists(t => t.F_Id.Equals(ThirdCode)))
                //            {
                //                insertList.Add(ThirdInfo);
                //            }

                //            DataView dvFourth = new DataView(dt);
                //            dvFourth.RowFilter = string.Format("三级部门='{0}'", drThird[0].ToString());
                //            DataTable dtFourth = dvFourth.ToTable(true, new string[] { "四级部门" });
                //            foreach (DataRow drFourth in dtFourth.Rows)
                //            {
                //                if (drFourth[0].ToString() == "")
                //                {
                //                    continue;
                //                }
                //                string FourthCode = string.Format("{0}-{1}", ThirdCode, Common.GetPYString(drFourth[0].ToString()));
                //                Sys_OrganizeInfo FourthInfo = new Sys_OrganizeInfo();
                //                FourthInfo.F_Id = FourthInfo.F_EnCode = FourthCode;
                //                FourthInfo.F_ParentId = ThirdInfo.F_Id;
                //                FourthInfo.F_Layers = 5;
                //                FourthInfo.F_FullName = drFourth[0].ToString();
                //                FourthInfo.F_CategoryId = "四级部门";
                //                if (!orglist.Exists(t => t.F_Id.Equals(FourthCode)))
                //                {
                //                    insertList.Add(FourthInfo);
                //                }

                //                DataView dvFifth = new DataView(dt);
                //                dvFifth.RowFilter = string.Format("四级部门='{0}'", drFourth[0].ToString());
                //                DataTable dtFifth = dvFifth.ToTable(true, new string[] { "五级部门" });
                //                foreach (DataRow drFifth in dtFifth.Rows)
                //                {
                //                    if (drFifth[0].ToString() == "")
                //                    {
                //                        continue;
                //                    }
                //                    string FifthCode = string.Format("{0}-{1}", FourthCode, Common.GetPYString(drFifth[0].ToString()));
                //                    Sys_OrganizeInfo FifthInfo = new Sys_OrganizeInfo();
                //                    FifthInfo.F_Id = FifthInfo.F_EnCode = FifthCode;
                //                    FifthInfo.F_ParentId = FourthInfo.F_Id;
                //                    FifthInfo.F_Layers = 5;
                //                    FifthInfo.F_FullName = drFifth[0].ToString();
                //                    FifthInfo.F_CategoryId = "五级部门";
                //                    if (!orglist.Exists(t => t.F_Id.Equals(FifthCode)))
                //                    {
                //                        insertList.Add(FifthInfo);
                //                    }
                //                }
                //            }
                //    }
                //}

            }


            BLLFactory<Sys_Organize>.Instance.InsertRange(insertList);
            result.bSuccess = true;
            return result;
        }


    }
}