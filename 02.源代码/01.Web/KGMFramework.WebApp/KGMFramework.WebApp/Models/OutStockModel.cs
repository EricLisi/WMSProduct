using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    public class OutStockModel
    {
        [DataMember]
        string F_GoodsId;
        string F_GoodsName;
        string F_Id;
        string WarehouseId;
        string CargoPositionId;
        int F_AlreadyOperatedNum;
        int F_OutStockNum;
        int OutNum;
    }
}