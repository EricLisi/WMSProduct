using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;

using System;
using System.Data;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 客户服务接口
    /// </summary>
    public interface IInStockHeadService : IService<InStockHeadEntity, InStockHeadGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param> 
        /// <returns></returns>
        Func<InStockHeadEntity, string> Expression(string keyValue);

        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="User"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        ReturnModel VerifyList(string ID, string User, int orderType);

        ///// <summary>
        ///// 添加或修改入库通知单
        ///// </summary>
        ///// <param name="ds"></param>
        ///// <returns></returns>
        //ReturnModel InsUpdateBarCodeRule(DataSet ds);

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //ReturnModel DeleteBarCodeRule(string Id);
    }
}
