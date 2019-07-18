using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// 扫描完成对象
    /// </summary>
    public class ScanFinishModel
    {
        public List<Mst_HistoryInfo> historylist;

        public SO_HeadInfo head;

        public List<ScanFinishEntity> ProductQty; 
        
    }
}
