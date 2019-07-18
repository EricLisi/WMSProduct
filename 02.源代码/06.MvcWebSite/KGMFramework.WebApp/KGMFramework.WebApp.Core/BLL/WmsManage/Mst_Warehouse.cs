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
    /// 仓库信息表
    /// </summary>
	public class Mst_Warehouse : BaseBLL<Mst_WarehouseInfo>
    {
        public Mst_Warehouse() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        /// <summary>
        /// 更新仓库状态
        /// </summary>
        /// <param name="Id">仓库Id</param>
        public bool UpEnMask(string Id) {
            IMst_Warehouse dal = baseDal as IMst_Warehouse;
          return  dal.upEnMask(Id);
          
        }
    }
}
