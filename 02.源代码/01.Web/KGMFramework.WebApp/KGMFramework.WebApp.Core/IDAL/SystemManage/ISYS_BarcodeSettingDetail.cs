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
    /// SYS_BarcodeSettingDetail
    /// </summary>
    public interface ISYS_BarcodeSettingDetail : IBaseDAL<SYS_BarcodeSettingDetailInfo>
    {
        /// <summary>
        /// 增加子表
        /// </summary>
        /// <param name="info"></param>
        /// <param name="keyValue"></param>
        void insert(SYS_BarcodeSettingDetailInfo info, string keyValue);


        //删除子表
        void deleteDeatail(string keyValue);//根据主表的分隔类型删子表的信息,清空数据


        //删除子表
        void deleteId(string keyValue);


        void insertDetail(SYS_BarcodeSettingDetailInfo info, string keyword, string keyValue);//修改子表
    }
}