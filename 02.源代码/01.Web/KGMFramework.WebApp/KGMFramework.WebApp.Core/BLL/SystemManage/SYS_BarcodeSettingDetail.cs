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
    /// SYS_BarcodeSettingDetail
    /// </summary>
    public class SYS_BarcodeSettingDetail : BaseBLL<SYS_BarcodeSettingDetailInfo>
    {
        public SYS_BarcodeSettingDetail()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public void insert(SYS_BarcodeSettingDetailInfo info, string keyValue)
        {
            ISYS_BarcodeSettingDetail dal = baseDal as ISYS_BarcodeSettingDetail;
            dal.insert(info, keyValue);
        }
        /// <summary>
        /// 根据主表的分隔类型删除子表的信息
        /// </summary>
        /// <param name="keyValue"></param>
        public void deleteDeatail(string keyValue)
        {
            ISYS_BarcodeSettingDetail dal = baseDal as ISYS_BarcodeSettingDetail;
            dal.deleteDeatail(keyValue);
        }



         /// <summary>
        /// 删除子表信息
        /// </summary>
        /// <param name="keyValue"></param>
        public void deleteId(string keyValue)
        {
            ISYS_BarcodeSettingDetail dal = baseDal as ISYS_BarcodeSettingDetail;
            dal.deleteId(keyValue);
        }

    }
}
