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
    /// SYS_BarcodeSettingMain
    /// </summary>
    public class SYS_BarcodeSettingMain : BaseBLL<SYS_BarcodeSettingMainInfo>
    {
        public SYS_BarcodeSettingMain()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }


        /// <summary>
        /// 批量删除主子表
        /// </summary>
        /// <param name="keyValue"></param>
        public void Delete(string keyValue, bool bLogicDelete)
        {
            ISYS_BarcodeSettingMain dal = baseDal as ISYS_BarcodeSettingMain;
            dal.Delete(keyValue, bLogicDelete);
        }

        /// <summary>
        /// 保存业务类型
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dInfo"></param>
        public void Save(SYS_BarcodeSettingMainInfo Info, List<SYS_BarcodeSettingDetailInfo> dInfo)
        {
            ISYS_BarcodeSettingMain dal = baseDal as ISYS_BarcodeSettingMain;
            dal.Save(Info, dInfo);
        }


      
    }
}
