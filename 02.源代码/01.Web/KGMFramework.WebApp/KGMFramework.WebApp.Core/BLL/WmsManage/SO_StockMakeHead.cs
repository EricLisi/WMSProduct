using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.BLL
{
    /// <summary>
    ///调拨子表
    /// </summary>
	public class SO_StockMakeHead : BaseBLL<SO_StockMakeHeadInfo>
    {
        public SO_StockMakeHead()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// 领用保存事件
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        public SO_StockMakeHeadInfo Save(SO_StockMakeHeadInfo info, List<SO_StockMakeBodyInfo> dInfo)
        {

            ISO_StockMakeHead dal = baseDal as ISO_StockMakeHead;
            return dal.Save(info, dInfo);
        }

        public void DeleteAll(string keyValue, bool bLogicDelete)
        {
            ISO_StockMakeHead dal = baseDal as ISO_StockMakeHead;
            dal.DeleteAll(keyValue, bLogicDelete);
        }
        public void Status(string F_Id, string userName,List<SO_StockMakeBodyInfo> info)
        {
            ISO_StockMakeHead dal = baseDal as ISO_StockMakeHead;
            dal.Status(F_Id,userName,info);
        }


        /// <summary>
        /// 获取子表信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetFormInfo(string ID)
        {
            ISO_StockMakeHead dal = baseDal as ISO_StockMakeHead;
            return dal.GetFormInfo(ID);
        }


        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string NoAudit(string date, string user, string Id)
        {
            ISO_StockMakeHead dal = baseDal as ISO_StockMakeHead;
            return dal.NoAudit(date, user, Id);
        }
    }
}
