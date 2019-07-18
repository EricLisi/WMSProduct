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
    /// 选项主表
    /// </summary>
	public class Sys_Items : BaseBLL<Sys_ItemsInfo>
    {
        public Sys_Items() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
         
        }
        /// <summary>
        /// 根据字典明细编码获取对应的字典类型
        /// </summary>
        /// <param name="itemcode"></param>
        /// <returns></returns>
        public string GetNameByCode(string itemcode)
        {
            ISys_Items dal = baseDal as ISys_Items;
            return dal.GetNameByCode(itemcode);
        }
    }
}
