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
    /// 业务类型
    /// </summary>
    public interface ISys_VouchType : IBaseDAL<Sys_VouchTypeInfo>
    {
        DataSet GetVouchTree();//获取业务类型设置树形结构
        void Save(Sys_VouchTypeInfo info, List<Sys_VouchTypeDefaultInfo> dInfo, string keyValue);//保存业务类型设置
        /// <summary>
        /// 批量删除主子表
        /// </summary>
        /// <param name="keyValue"></param>
        void DeleteBatch(string keyValue, bool bLogicDelete);
        DataTable GetTypeByParent(string F_FullName);//根据选中父节点的值获取对应的出入库类型
    }
}