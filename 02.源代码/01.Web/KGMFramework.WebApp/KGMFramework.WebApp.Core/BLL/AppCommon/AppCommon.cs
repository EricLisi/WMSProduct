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
    /// 行政区域表
    /// </summary>
    public class AppCommon : BaseBLL<BaseEntity>
    {
        public AppCommon()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// 获取属性结构
        /// </summary>
        /// <param name="entity">参数对象</param>
        /// <returns></returns>
        public DataTable GetTreeInfo(TreeInfoEntity entity)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetTreeInfo(entity).Tables[0];
        }


        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataTable VerifyList(VerifyListEntity entity)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.VerifyList(entity).Tables[0];
        }


        /// <summary>
        /// 获取打印的资产卡片信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataTable GetBarcodeInfo(VerifyListEntity entity)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetBarcodeInfo(entity).Tables[0];
        }

        /// <summary>
        /// 获取打印的资产卡片信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataTable GetAssetInfo(string corpId, string deptId, string status, string condition, int pageindex = -1, int pagesize = 50)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetAssetInfo(corpId,deptId, status, condition, pageindex, pagesize).Tables[0];
        }


        public DataTable GetPreVerify(string corpId)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetPreVerify(corpId).Tables[0];
        }

        public DataTable Asset_GetStatusReport(string corpId)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.Asset_GetStatusReport(corpId).Tables[0];
        }


        public DataTable Asset_GetRecordReport(string corpId)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.Asset_GetRecordReport(corpId).Tables[0];
        }
    }
}
