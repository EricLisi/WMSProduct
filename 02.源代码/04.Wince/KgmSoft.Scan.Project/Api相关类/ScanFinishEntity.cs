using System;
using System.Collections.Generic;
using System.Web;

namespace KgmSoft.Scan.Project
{
    public class ScanFinishEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public ScanFinishEntity()
		{
             
		}

        #region Property Members
        public virtual string PRODUCTNO { get; set; }
        public virtual string CYQTY { get; set; }

        public virtual string QTY { get; set; }
        public virtual string SCANQTY { get; set; }
        #endregion
    }
}
