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
    ///入库子表
    /// </summary>
	public class PI_ReturnBody : BaseBLL<PI_ReturnBodyInfo>
    {
        public PI_ReturnBody() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public DataTable SelReturnStock()
        {
            IPI_ReturnBody dal = baseDal as IPI_ReturnBody;
            return dal.SelReturnStock();

        }
    }
}
