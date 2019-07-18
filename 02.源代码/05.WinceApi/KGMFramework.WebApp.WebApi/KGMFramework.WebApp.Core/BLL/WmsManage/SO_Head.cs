using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Library;

namespace KGMFramework.WebApp.BLL
{
    /// <summary>
    /// 发货单
    /// </summary>
	public class SO_Head : BaseBLL<SO_HeadInfo>
    {
        /// <summary>
        /// 
        /// </summary>
        public SO_Head()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// 保存发货单
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public KgmApiResultEntity Save(DataSet ds)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.Save(ds);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public KgmApiResultEntity DeleteById(string Id)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.DeleteById(Id);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id">单据Id</param>
        /// <param name="user">用户</param>
        /// <param name="orderType">类型</param>
        /// <returns></returns>
        public KgmApiResultEntity Verify(string Id, string user, int orderType)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.Verify(Id, user, orderType);
        }

       

    }
}
