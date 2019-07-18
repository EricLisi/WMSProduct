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
    /// 产品信息表
    /// </summary>
    public class Mst_Product : BaseBLL<Mst_ProductInfo>
    {
        public Mst_Product()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public DataTable GetTree()
        {
            IMst_Product dal = baseDal as IMst_Product;
            return dal.GetTree().Tables[0];
        }

        public DataTable GetPrint(string filter)
        {
            IMst_Product dal = baseDal as IMst_Product;
            return dal.GetPrint(filter);
        }

        public bool Audit(string F_Id, int state)
        {
            IMst_Product dal = baseDal as IMst_Product;
            return dal.Audit(F_Id, state);
        }

        public bool DataRecovery(string F_Id)
        {
            IMst_Product dal = baseDal as IMst_Product;
            return dal.DataRecovery(F_Id);
        }

    }
}
