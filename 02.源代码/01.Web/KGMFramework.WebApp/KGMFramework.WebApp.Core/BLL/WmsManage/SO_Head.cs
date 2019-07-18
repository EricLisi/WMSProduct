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
	public class SO_Head : BaseBLL<SO_HeadInfo>
    {
        public SO_Head()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }


        public SO_HeadInfo Save(SO_HeadInfo info, List<SO_BodyInfo> dInfo)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.Save(info, dInfo);
        }

        public void DeleteAll(string keyValue, bool bLogicDelete)
        {
            ISO_Head dal = baseDal as ISO_Head;
            dal.DeleteAll(keyValue, bLogicDelete);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string Audit( string Id, string user)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.Audit( Id, user);
        }

        /// <summary>
        /// 获取审核状态
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
       public string StatusSate(string KeyValue)
       {

           ISO_Head dal = baseDal as ISO_Head;
           return dal.StatusSate(KeyValue);
       }
        public DataTable GetPrint(string sourceData)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.GetPrint(sourceData);
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string NoAudit(string date, string user, string Id)
        {
            ISO_Head dal = baseDal as ISO_Head;
            return dal.NoAudit(date, user,Id);
        }
    }
}
