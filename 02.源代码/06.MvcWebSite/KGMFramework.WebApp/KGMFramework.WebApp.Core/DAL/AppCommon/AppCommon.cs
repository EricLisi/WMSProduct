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
    }
}