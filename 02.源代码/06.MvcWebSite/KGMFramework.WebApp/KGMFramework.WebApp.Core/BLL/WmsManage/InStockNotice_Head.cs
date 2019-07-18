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
    /// 入库通知单主表
    /// </summary>
	public class InStockNotice_Head : BaseBLL<InStockNotice_HeadInfo>
    {
        public InStockNotice_Head() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public InStockNotice_HeadInfo Save(InStockNotice_HeadInfo info, List<InStockNotice_BodyInfo> Binfo)
        {
            IInStockNotice_Head dal = baseDal as IInStockNotice_Head;
            return dal.Save(info, Binfo);
        }


        public string UploadExcel(DataTable dt, string user)
        {
            IInStockNotice_Head dal = baseDal as IInStockNotice_Head;
            return dal.UploadExcel(dt, user);
        }
    }
}
