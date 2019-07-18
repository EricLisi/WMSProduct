using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 出库通知单主表服务接口
    /// </summary>
    public interface ISRMainService : IService<SRMainEntity, SRMainGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<SRMainEntity, string> Expression(string keyValue);
 


        /// <summary>
        /// 生成拣货单
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
       List<PackListModelDto> GeneratePackList(DataTable dt, string User, int orderType);

        /// <summary>
        /// 创建快递单订单号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        DataTable GetExpOrder(string orderNo);

        /// <summary>
        /// 回写快递单号
        /// </summary>
        /// <param name="dt"></param>
        void ReWriteLogicCode(DataTable dt);
    }
}
