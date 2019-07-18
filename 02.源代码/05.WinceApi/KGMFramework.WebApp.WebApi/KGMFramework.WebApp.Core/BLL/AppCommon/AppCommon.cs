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
    public class AppCommon : BaseBLL<AppBaseEntity>
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
        public DataSet LIST_GETDATA(string orderNo, string orderType)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.LIST_GETDATA(orderNo, orderType);
        }


         


        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataTable GetTempScan(string orderNo, string operUser)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetTempScan(orderNo, operUser);
        }

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataTable GetTempScanCy(string orderNo, string orderType)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetTempScanCy(orderNo, orderType).Tables[0];
        }

        /// <summary>
        /// 单据扫描完成
        /// </summary>
        /// <param name="dto">完成参数</param>
        /// <returns></returns>
        public DataTable TempScanFinish(FinishTempScanDto dto)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.TempScanFinish(dto).Tables[0];
        }


        ///// <summary>
        ///// 审核单据
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public DataTable VerifyList(VerifyListEntity entity)
        //{
        //    IAppCommon dal = base.baseDal as IAppCommon;
        //    return dal.VerifyList(entity).Tables[0];
        //}


        ///// <summary>
        ///// 获取打印的资产卡片信息
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public DataTable GetBarcodeInfo(VerifyListEntity entity)
        //{
        //    IAppCommon dal = base.baseDal as IAppCommon;
        //    return dal.GetBarcodeInfo(entity).Tables[0];
        //}

        ///// <summary>
        ///// 获取打印的资产卡片信息
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public DataTable GetAssetInfo(string corpId, string deptId, string status, string condition, int pageindex = -1, int pagesize = 50)
        //{
        //    IAppCommon dal = base.baseDal as IAppCommon;
        //    return dal.GetAssetInfo(corpId,deptId, status, condition, pageindex, pagesize).Tables[0];
        //}


        //public DataTable GetPreVerify(string corpId)
        //{
        //    IAppCommon dal = base.baseDal as IAppCommon;
        //    return dal.GetPreVerify(corpId).Tables[0];
        //}

        //public DataTable Asset_GetStatusReport(string corpId)
        //{
        //    IAppCommon dal = base.baseDal as IAppCommon;
        //    return dal.Asset_GetStatusReport(corpId).Tables[0];
        //}


        //public DataTable Asset_GetRecordReport(string corpId)
        //{
        //    IAppCommon dal = base.baseDal as IAppCommon;
        //    return dal.Asset_GetRecordReport(corpId).Tables[0];
        //}


        /// <summary>
        /// 获取临时扫描信息
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <returns></returns>
        public DataTable GetTempScanList(string orderNo, string orderType)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetTempScanList(orderNo, orderType).Tables[0];
        }

        /// <summary>
        /// 获取临时扫描信息
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <returns></returns>
        public DataTable GetScanCyList(string orderNo, string orderType)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.GetScanCyList(orderNo, orderType).Tables[0];
        }



        /// <summary>
        /// 保存临时扫描表
        /// </summary>
        /// <param name="dto">保存参数</param>
        /// <returns></returns>
        public DataTable SaveTempScan(SaveTempScanModel dto)
        {
            IAppCommon dal = base.baseDal as IAppCommon;
            return dal.SaveTempScan(dto).Tables[0];
        }
    }
}
