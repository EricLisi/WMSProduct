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
    public interface ISetUpService : IService<SetUpEntity, SetUpGetDto>
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Func<SetUpEntity, string> Expression(string keyValue);


    }
}
