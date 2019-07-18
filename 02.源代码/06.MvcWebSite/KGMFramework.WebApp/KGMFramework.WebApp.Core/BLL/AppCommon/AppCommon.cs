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
    }
}
