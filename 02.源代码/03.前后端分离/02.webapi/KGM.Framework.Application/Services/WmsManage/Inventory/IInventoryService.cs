using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 仓库服务接口
    /// </summary>
    public interface IInventoryService : IService<InventoryEntity, InventoryGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<InventoryEntity, string> Expression(string keyValue);

        /// <summary>
        /// 获取SKU
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        String GetSkU(int len);
    }
}
