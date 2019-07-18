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
    /// 入库主表
    /// </summary>
    public class PI_ReturnHead : BaseBLL<PI_ReturnHeadInfo>
    {
        public PI_ReturnHead()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public PI_ReturnHeadInfo Save(PI_ReturnHeadInfo info, List<PI_ReturnBodyInfo> dInfo)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.Save(info, dInfo);
        }

        public void DeleteAll(string keyValue, bool bLogicDelete)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            dal.DeleteAll(keyValue, bLogicDelete);
        }

        public void Status(string F_Id, string userName)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            dal.Status(F_Id, userName);
        }

        public DataTable GetPrint(string sourceData)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.GetPrint(sourceData);
        }

        public DataTable GetAssetPicture(string id)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.GetAssetPicture(id);
        }

        public string createCode(string F_Id)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.createCode(F_Id);
        }

        public bool Check2(string F_Id)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.Check2(F_Id);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string Audit(string date, string Id, string user, List<PI_ReturnBodyInfo> dInfo)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.Audit(date, Id, user, dInfo);
        }


        /// <summary>
        ///反审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="bLogicDelete"></param>
        public string NoAudit(string date, string Id, string user)
        {
            IPI_ReturnHead dal = baseDal as IPI_ReturnHead;
            return dal.NoAudit(date, Id, user);
        }
    }
}
