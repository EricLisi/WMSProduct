using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;

namespace KGMFramework.WebApp.IDAL
{
    /// <summary>
    /// 调拨子表
    /// </summary>
    /// 
    
    
    public interface IAllocation_Body : IBaseDAL<Allocation_BodyInfo>
    {
        //调拨入库
        string InStock(string Batch, string id);

        //调拨出库
        string OutStock(string Batch, string id);

    }

    
}