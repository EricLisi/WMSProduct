using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGM.Pager.Entity;
using KGM.Framework.Commons;
using KGM.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;

namespace KGMFramework.WebApp.DALSQL
{
    /// <summary>
    /// 行政区域表
    /// </summary>
    public class AppCommon : BaseDALSQL<BaseEntity>, IAppCommon
    {
        /// <summary>
        /// 获取属性结构
        /// </summary>
        /// <param name="entity">参数对象</param>
        /// <returns></returns>
        public DataSet GetTreeInfo(TreeInfoEntity entity)
        {

            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("TABLENAME", DbType.String, entity.F_TableName));
            paramList.Add(CreateInSmartDbParameter("KEYFILED", DbType.String, entity.F_KeyFiled));
            paramList.Add(CreateInSmartDbParameter("PARENTFILED", DbType.String, entity.F_ParentFiled));
            paramList.Add(CreateInSmartDbParameter("CONDITION", DbType.String, entity.F_Condition));
            paramList.Add(CreateInSmartDbParameter("SORTCODE", DbType.String, entity.F_SortCode));
            paramList.Add(CreateInSmartDbParameter("CTYPE", DbType.String, entity.F_CType));

            return base.ExecuteDataSetByProc("[SYS_GETTREEINFO]", paramList);
        }

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataSet VerifyList(VerifyListEntity entity)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERID", DbType.String, entity.orderId));
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, entity.orderNo));
            paramList.Add(CreateInSmartDbParameter("ORDERTYPE", DbType.String, entity.orderType));
            paramList.Add(CreateInSmartDbParameter("USER", DbType.String, entity.userId));
            paramList.Add(CreateInSmartDbParameter("COMPID", DbType.String, entity.corpId));

            return base.ExecuteDataSetByProc("[ASSET_VERIFYLIST]", paramList);
        }

        /// <summary>
        /// 获取资产卡片打印信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DataSet GetBarcodeInfo(VerifyListEntity entity)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("ORDERID", DbType.String, entity.orderId));
            paramList.Add(CreateInSmartDbParameter("ORDERNO", DbType.String, entity.orderNo));
            paramList.Add(CreateInSmartDbParameter("USER", DbType.String, entity.userId));
            paramList.Add(CreateInSmartDbParameter("COMPID", DbType.String, entity.corpId));

            return base.ExecuteDataSetByProc("[ASSET_GETBARCODEINFO]", paramList);
        }


        public DataSet GetAssetInfo(string corpId, string deptId, string status, string condition, int pageindex = -1, int pagesize = 50)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("CONDITION", DbType.String, condition));
            paramList.Add(CreateInSmartDbParameter("STATUS", DbType.String, status));
            paramList.Add(CreateInSmartDbParameter("COMPID", DbType.String, corpId));
            paramList.Add(CreateInSmartDbParameter("DEPTID", DbType.String, deptId));
            paramList.Add(CreateInSmartDbParameter("PAGEINDEX", DbType.Int32, pageindex));
            paramList.Add(CreateInSmartDbParameter("PAGESIZE", DbType.Int32, pagesize));

            return base.ExecuteDataSetByProc("[ASSET_GETINFO]", paramList);
        }


        public DataSet GetPreVerify(string corpId)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("CorpId", DbType.String, corpId));

            return base.ExecuteDataSetByProc("[Asset_GetPreVerfy]", paramList);
        }

        public DataSet Asset_GetStatusReport(string corpId)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("CorpId", DbType.String, corpId));

            return base.ExecuteDataSetByProc("[Asset_GetStatusReport]", paramList);
        }

        public DataSet Asset_GetRecordReport(string corpId)
        {
            List<SmartDbParameter> paramList = new List<SmartDbParameter>();
            paramList.Add(CreateInSmartDbParameter("CorpId", DbType.String, corpId));

            return base.ExecuteDataSetByProc("[Asset_GetRecordReport]", paramList);
        }
         
    }
}