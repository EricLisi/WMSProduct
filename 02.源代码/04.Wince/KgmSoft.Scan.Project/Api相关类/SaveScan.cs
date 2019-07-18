using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace KgmSoft.Scan.Project
{
    public class SaveScan
    {
        public string ORDERNO { get; set; }
        public string ORDERTYPE { get; set; }
        public string CWHCODE { get; set; }
        public string BARCODE { get; set; }
        public string CPOSCODE { get; set; }
        public string OPERUSER { get; set; }
        public bool BDEL { get; set; } 
        public decimal QTY { get; set; }
    }

}
