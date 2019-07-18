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

namespace KGMFramework.WebApp.Areas.SystemSecurity.Controllers
{
    public class LogController : BusinessController<Sys_Log, Sys_LogInfo>
    {
        public ActionResult RemoveLog()
        {
            return View();
        }

        /// <summary>
        /// 获取grid显示信息 分页
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="timeType">查询字段   1 今天 2 近7天 3 近1个月 4 近3个月
        /// <param name="pagination">分页默认是null</param>
        /// <param name="sortFiled">排序字段 默认F_SortCode</param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult GetGridJsonInfo(string keyword, string timeType, Pagination pagination, string sortFiled = " F_Date ")
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("F_ModuleName", keyword, SqlOperator.Like);
            if (!string.IsNullOrEmpty(timeType))
            {
                switch (timeType)
                {
                    case "1"://今天
                        condition.AddCondition("F_Date", DateTime.Now.ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual);
                        condition.AddCondition("F_Date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                        break;
                    case "2": //近7天
                        condition.AddCondition("F_Date", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual);
                        condition.AddCondition("F_Date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                        break;
                    case "3": //近1个月
                        condition.AddCondition("F_Date", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual);
                        condition.AddCondition("F_Date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                        break;
                    case "4": //近3个月
                        condition.AddCondition("F_Date", DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual);
                        condition.AddCondition("F_Date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                        break;
                }
            }
            else
            {
                //默认查7天
                condition.AddCondition("F_Date", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), SqlOperator.MoreThanOrEqual);
                condition.AddCondition("F_Date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
            }

            PagerInfo pager = GetPageInfo(pagination);
            List<Sys_LogInfo> list = baseBLL.FindWithPager(GetConditionStr(condition), pager, sortFiled);
            return GetPagerContent(list, pager);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="keepTime">0 全部删除 1 保留近三个月 2 保留近一个月 3保留近一周</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            SearchCondition condition = new SearchCondition();
            switch (keepTime)
            {
                case "0"://全部删除 
                    break;
                case "3": //保留近一周
                    condition.AddCondition("F_Date", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                    break;
                case "2": //保留近一个月 
                    condition.AddCondition("F_Date", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                    break;
                case "1": //保留近三个月
                    condition.AddCondition("F_Date", DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd"), SqlOperator.LessThan);
                    break;
            }

            baseBLL.DeleteByCondition(GetConditionStr(condition));

            return Success("清空成功。");
        }
    }
}