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
	public class Mst_Goods : BaseBLL<Mst_GoodsInfo>
    {
        public Mst_Goods()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        public DataTable GetGoodsById(string Id)
        {
            IMst_Goods dal = baseDal as IMst_Goods;
            return dal.GetGoodsById(Id);
         
        }

        public DataTable selGoodsCategory()
        {
            IMst_Goods dal = baseDal as IMst_Goods;
            return dal.selGoodsCategory();
        }

        public string GetNameByCode(string itemcode)
        {
            IMst_Goods dal = baseDal as IMst_Goods;
            return dal.GetNameByCode(itemcode);
        }

        public DataTable GetPrint(string Id)
        {
            IMst_Goods dal = baseDal as IMst_Goods;
            return dal.GetPrint(Id);

        }
    }
}
