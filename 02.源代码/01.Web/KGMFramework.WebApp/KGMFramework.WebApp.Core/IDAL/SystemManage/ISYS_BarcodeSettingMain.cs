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
    /// SYS_BarcodeSettingMain
    /// </summary>
    public interface ISYS_BarcodeSettingMain : IBaseDAL<SYS_BarcodeSettingMainInfo>
    {

        /// <summary>
        /// 删除主子表
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="bLogicDelete"></param>
        void Delete(string keyValue, bool bLogicDelete);


        void Save(SYS_BarcodeSettingMainInfo Info, List<SYS_BarcodeSettingDetailInfo> dInfo);//保存业务类型设置


       
    }
}