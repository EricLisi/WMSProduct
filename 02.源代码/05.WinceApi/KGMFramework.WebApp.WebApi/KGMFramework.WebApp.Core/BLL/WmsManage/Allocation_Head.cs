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
    /// 调拨主表
    /// </summary>
    public class Allocation_Head : BaseBLL<Allocation_HeadInfo>
    {
        public Allocation_Head()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public Allocation_HeadInfo Save(Allocation_HeadInfo info, List<Allocation_BodyInfo> dInfo)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            return dal.Save(info, dInfo);
        }

        public void DeleteAll(string keyValue, bool bLogicDelete)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            dal.DeleteAll(keyValue, bLogicDelete);
        }

        public void Status(string F_Id, string userName)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            dal.Status(F_Id, userName);
        }

        public DataTable GetPrint(string sourceData)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            return dal.GetPrint(sourceData);
        }


        public string createCode(string F_Id)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            return dal.createCode(F_Id);
        }

        public bool Check2(string F_Id)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            return dal.Check2(F_Id);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string Audit(string date, string Id, string user,List<Allocation_BodyInfo> dbInfo)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            return dal.Audit(date, Id, user, dbInfo);
        }


        /// <summary>
        ///反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string NoAudit(string date, string Id, string user)
        {
            IAllocation_Head dal = baseDal as IAllocation_Head;
            return dal.NoAudit(date, Id, user);
        }
    }
}
