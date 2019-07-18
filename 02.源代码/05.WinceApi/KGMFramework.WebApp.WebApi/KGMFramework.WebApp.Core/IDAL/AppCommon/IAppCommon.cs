using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;
using KGMFramework.WebApp.Entity;

namespace KGMFramework.WebApp.IDAL
{
    /// <summary>
    /// 共通类
    /// </summary>
    public interface IAppCommon : IBaseDAL<AppBaseEntity>
    {
        DataSet LIST_GETDATA(string ORDERNO, string orderType);

    


        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        DataTable GetTempScan(string orderNo, string operUser);

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
         DataSet GetTempScanCy(string orderNo, string orderType);

        /// <summary>
        /// 单据扫描完成
        /// </summary>
        /// <param name="dto">完成参数</param>
        /// <returns></returns>
        DataSet TempScanFinish(FinishTempScanDto dto);


        /// <summary>
        /// 获取临时扫描信息
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <returns></returns>
        DataSet GetTempScanList(string orderNo, string orderType);

        /// <summary>
        /// 获取临时扫描信息
        /// </summary>
        /// <param name="orderNo">单据号</param>
        /// <param name="orderType">单据类型</param>
        /// <returns></returns>
        DataSet GetScanCyList(string orderNo, string orderType);

        /// <summary>
        /// 保存临时扫描表
        /// </summary>
        /// <param name="dto">保存参数</param>
        /// <returns></returns>
        DataSet SaveTempScan(SaveTempScanModel dto);

    }
}