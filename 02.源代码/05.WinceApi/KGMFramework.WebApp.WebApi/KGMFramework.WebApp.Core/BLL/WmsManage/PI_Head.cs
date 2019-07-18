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
    /// 入库主表
    /// </summary>
    public class PI_Head : BaseBLL<PI_HeadInfo>
    {
        public PI_Head()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public PI_HeadInfo Save(PI_HeadInfo info, List<PI_BodyInfo> dInfo)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.Save(info, dInfo);
        }

        public void DeleteAll(string keyValue, bool bLogicDelete)
        {
            IPI_Head dal = baseDal as IPI_Head;
            dal.DeleteAll(keyValue, bLogicDelete);
        }

        public void Status(string F_Id, string userName)
        {
            IPI_Head dal = baseDal as IPI_Head;
            dal.Status(F_Id, userName);
        }

        public DataTable GetPrint(string sourceData)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.GetPrint(sourceData);
        }

        public DataTable GetAssetPicture(string id)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.GetAssetPicture(id);
        }

        public string createCode(string F_Id)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.createCode(F_Id);
        }

        public bool Check2(string F_Id)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.Check2(F_Id);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string Audit(string date, string Id, string user, List<PI_BodyInfo> dInfo)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.Audit(date, Id, user, dInfo);
        }


        /// <summary>
        ///反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string NoAudit(string date, string Id, string user)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.NoAudit(date, Id, user);
        }



        public KgmApiResultEntity DeleteOrder(string ID)
        {
            IPI_Head dal = baseDal as IPI_Head;
            return dal.DeleteOrder(ID);
        }
    }
}
