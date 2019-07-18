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
    /// 业务类型
    /// </summary>
    public class Sys_VouchType : BaseBLL<Sys_VouchTypeInfo>
    {
        public Sys_VouchType()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
        /// <summary>
        /// 获取业务类型设置树形结构
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public DataTable GetVouchTree()
        {
            ISys_VouchType dal = baseDal as ISys_VouchType;
            return dal.GetVouchTree().Tables[0];
        }
        /// <summary>
        /// 保存业务数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="details"></param>
        public void Save(Sys_VouchTypeInfo info, List<Sys_VouchTypeDefaultInfo> dInfo, string keyValue)
        {
            ISys_VouchType dal = baseDal as ISys_VouchType;
            dal.Save(info, dInfo, keyValue);
        }

        /// <summary>
        /// 批量删除主子表
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteBatch(string keyValue, bool bLogicDelete)
        {
            ISys_VouchType dal = baseDal as ISys_VouchType;
            dal.DeleteBatch(keyValue, bLogicDelete);
        }
        /// <summary>
        /// 根据选中父节点的值获取对应的出入库类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetTypeByParent(string F_FullName)
        {
            ISys_VouchType dal = baseDal as ISys_VouchType;
            return dal.GetTypeByParent(F_FullName);
        }

    }
}
