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
    /// 资产调拨子表
    /// </summary>
	public class SO_ReturnedStockHead : BaseBLL<SO_ReturnedStockHeadInfo>
    {
        public SO_ReturnedStockHead()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        /// <summary>
        /// 产品保存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        /// <returns></returns>
        public SO_ReturnedStockHeadInfo Save(SO_ReturnedStockHeadInfo info, List<SO_ReturnedStockBodyInfo> dInfo)
        {
          ISO_ReturnedStockHead dal = baseDal as ISO_ReturnedStockHead;
         return   dal.Save(info,dInfo);
        }
        public string VerifyReturnGoods(string Id, string user) {
            ISO_ReturnedStockHead dal = baseDal as ISO_ReturnedStockHead;
            return dal.VerifyReturnGoods(Id,user);
        }
    }
}
