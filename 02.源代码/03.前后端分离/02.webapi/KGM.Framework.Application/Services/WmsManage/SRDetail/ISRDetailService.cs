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
    public interface ISRDetailService : IService<SRDetailEntity, SRDetailGetDto>
    {
         
    }
}
