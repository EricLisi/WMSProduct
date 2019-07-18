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
	public class Allocation_Body : BaseBLL<Allocation_BodyInfo>
    {
        public Allocation_Body() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public string InStock(string Batch, string id) {
            IAllocation_Body dal = baseDal as IAllocation_Body;
            return dal.InStock(Batch,id);
        }


        public string OutStock(string Batch, string id)
        {
            IAllocation_Body dal = baseDal as IAllocation_Body;
            return dal.OutStock(Batch, id);
        }
    }
}
