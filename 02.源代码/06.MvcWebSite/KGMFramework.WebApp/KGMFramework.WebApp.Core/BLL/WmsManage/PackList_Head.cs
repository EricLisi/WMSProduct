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
    /// 拣货单主表
    /// </summary>
	public class PackList_Head : BaseBLL<PackList_HeadInfo>
    {
        public PackList_Head() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        public bool Save(PackList_HeadInfo headInfo, List<PackList_BodyInfo> dInfo) {
            IPackList_Head dal = baseDal as IPackList_Head;
            return dal.Save(headInfo, dInfo);
        }

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public DataTable GetPrint(string sourceData)
        {
            IPackList_Head dal = baseDal as IPackList_Head;
            return dal.GetPrint(sourceData);
        }
    }
}
