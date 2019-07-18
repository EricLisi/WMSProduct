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
namespace KGMFramework.WebApp.Areas.PrintManage.Controllers
{
    public class DocumentController : BusinessController<Mst_Product, Mst_ProductInfo>
    {
        public ActionResult DataRecovery()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// 获取树形结构
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public override ActionResult GetTreeJson(string orderBy = " ORDER BY F_SortCode ")
        {
            DataTable dt = BLLFactory<Mst_Product>.Instance.GetTree();
            return Content(GetTreeJsonStr(dt));
        }

        public string GetTreeJsonStr(DataTable data)
        {
            List<Tree> list = new List<Tree>();
            foreach (DataRow row in data.Rows)
            {
                Tree t = new Tree();
                t.CODE = row[0].ToString();
                t.NAME = row[1].ToString();
                t.P_ID = row[2].ToString();
                list.Add(t);
            }
            var treeList = new List<TreeViewModel>();
            foreach (Tree item in list)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = list.Count(t => t.P_ID == item.CODE) == 0 ? false : true;
                tree.id = item.CODE;
                tree.text = item.NAME;
                tree.value = item.CODE;
                tree.parentId = item.P_ID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return treeList.TreeViewJson();
        }

        protected override string GetKeywordCondition(string keyword, string searchFiled, char mutiConditionSplitChar = '|', char filedSplitChar = '/')
        {
            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(searchFiled))
            {
                SearchCondition condition = new SearchCondition();
                string[] state = keyword.Split('&');
                keyword = keyword.Substring(0, keyword.Length - 2);
                if (state[1] == "1")
                {
                    condition.AddCondition("F_PROTOCOL_ID", keyword, SqlOperator.Like, true, "g");
                    condition.AddCondition("F_LABEL_ID", keyword, SqlOperator.Like, true, "g");
                    condition.AddCondition("F_VERSION", keyword, SqlOperator.Like, true, "g");
                    condition.AddCondition("F_COUNTRY", keyword, SqlOperator.Like, true, "g");
                    condition.AddCondition("F_DeleteMark", 1, SqlOperator.Equal, true);
                }
                else
                {
                    if (!keyword.Contains("|"))
                    {
                        condition.AddCondition("F_PROTOCOL_ID", keyword, SqlOperator.Like, true, "g");
                        condition.AddCondition("F_LABEL_ID", keyword, SqlOperator.Like, true, "g");
                        condition.AddCondition("F_VERSION", keyword, SqlOperator.Like, true, "g");
                        condition.AddCondition("F_COUNTRY", keyword, SqlOperator.Like, true, "g");
                    }
                    else
                    {
                        string[] strKeyword = keyword.Split(mutiConditionSplitChar);
                        string[] strSearchFiled = searchFiled.Split(mutiConditionSplitChar);
                        for (int i = 0; i < strKeyword.Length; i++)
                        {
                            if (strKeyword[i].Equals("undefined"))
                            {
                                continue;
                            }
                            string[] fileds = strSearchFiled[i].Split(filedSplitChar);
                            foreach (string str in fileds)
                            {
                                if (str.Equals("undefined"))
                                {
                                    continue;
                                }
                                condition.AddCondition(str, strKeyword[i], SqlOperator.Equal, true, "g" + i.ToString());
                            }
                        }
                    }
                    condition.AddCondition("F_DeleteMark", 1, SqlOperator.NotEqual, true);
                }
                return condition.BuildConditionSql().Replace("Where (1=1)  AND ", string.Empty);
            }
            return " 1 = 2 ";
        }

        public ActionResult GetPrint(string filter)
        {
            DataTable dt = BLLFactory<Mst_Product>.Instance.GetPrint(filter);
            return Content(JsonAppHelper.ToJson(dt));
        }

        public ActionResult Audit(string F_Id, int state)
        {
            bool b = BLLFactory<Mst_Product>.Instance.Audit(F_Id, state);
            return Content(JsonAppHelper.ToJson(b));
        }

        public ActionResult DataRecoveryC(string F_Id)
        {
            bool b = BLLFactory<Mst_Product>.Instance.DataRecovery(F_Id);
            return Content(JsonAppHelper.ToJson(b));
        }

        /// <summary>
        /// 导入后操作
        /// Protocol ID+ Label ID+ Version No +Country都相同 提示重复 不给导入
        /// </summary>
        /// <param name="fullFileName"></param>
        protected override ResultModel DoAfterUploadFile(string fullFileName)
        {
            bool bSuccess = true;
            string message = string.Empty;
            ResultModel result = new ResultModel();
            //读取文件 excel
            DataTable dt = KGMFramework.WebApp.Library.ExcelHelper.ExcelImport(fullFileName, 1);
            dt.Columns.Remove("审核状态");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string rowIndexInfo = string.Format("第{0}行", (i + 1).ToString());
                try
                {
                    DataRow dr = dt.Rows[i];
                    if (string.IsNullOrEmpty(dr[0].ToString()) ||
                        string.IsNullOrEmpty(dr[1].ToString()) ||
                        string.IsNullOrEmpty(dr[2].ToString()) ||
                        string.IsNullOrEmpty(dr[3].ToString())) { continue; }
                    //校验 如果存在，报错，不存在 写入
                    SearchCondition condition = new SearchCondition();
                    condition.AddCondition("F_PROTOCOL_ID", dr[0].ToString(), SqlOperator.Equal);
                    condition.AddCondition("F_LABEL_ID", dr[1].ToString(), SqlOperator.Equal);
                    condition.AddCondition("F_VERSION", dr[2].ToString(), SqlOperator.Equal);
                    condition.AddCondition("F_COUNTRY", dr[3].ToString(), SqlOperator.Equal);
                    condition.AddCondition("F_DeleteMark", false, SqlOperator.Equal);
                    if (BLLFactory<Mst_Product>.Instance.IsExistRecord(GetConditionStr(condition)))
                    {
                        bSuccess = false;
                        message += string.Format("{0}导入失败!原因:当前行信息已经存在!\t\n", rowIndexInfo);
                    }
                    else
                    {
                        Mst_ProductInfo info = new Mst_ProductInfo();
                        info.F_PROTOCOL_ID = dr[0].ToString();
                        info.F_LABEL_ID = dr[1].ToString();
                        info.F_VERSION = dr[2].ToString();
                        info.F_COUNTRY = dr[3].ToString();
                        info.F_CONTENT1 = dr[4].ToString();
                        info.F_CONTENT2 = dr[5].ToString();
                        info.F_CONTENT3 = dr[6].ToString();
                        info.F_CONTENT4 = dr[7].ToString();
                        info.F_CONTENT5 = dr[8].ToString();
                        info.F_CONTENT6 = dr[9].ToString();
                        info.F_CONTENT7 = dr[10].ToString();
                        info.F_CONTENT8 = dr[11].ToString();
                        info.F_CONTENT9 = dr[12].ToString();
                        info.F_CONTENT10 = dr[13].ToString();
                        info.F_CONTENT11 = dr[14].ToString();
                        info.F_CONTENT12 = dr[15].ToString();
                        info.F_CONTENT13 = dr[16].ToString();
                        info.F_CONTENT14 = dr[17].ToString();
                        info.F_CONTENT15 = dr[18].ToString();
                        info.F_CONTENT16 = dr[19].ToString();
                        info.F_CONTENT17 = dr[20].ToString();
                        info.F_CONTENT18 = dr[21].ToString();
                        info.F_CONTENT19 = dr[22].ToString();
                        info.F_CONTENT20 = dr[23].ToString();
                        info.F_CONTENT21 = dr[24].ToString();
                        info.F_CONTENT22 = dr[25].ToString();
                        info.F_CONTENT23 = dr[26].ToString();
                        info.F_CONTENT24 = dr[27].ToString();
                        info.F_CONTENT25 = dr[28].ToString();
                        info.F_CreatorTime = DateTime.Now;
                        info.F_CreatorUserId = CurrentUser.F_Account;
                        BLLFactory<Mst_Product>.Instance.Insert(info);
                    }
                }
                catch (Exception ex)
                {
                    bSuccess = false;
                    message += string.Format("{0}导入失败!原因:{1}!\t\n", rowIndexInfo, ex.Message);
                    LogTextHelper.Error(ex.ToString());//错误记录
                }
            }
            result.bSuccess = bSuccess;
            result.message = message;

            return result;
        }

    }
}