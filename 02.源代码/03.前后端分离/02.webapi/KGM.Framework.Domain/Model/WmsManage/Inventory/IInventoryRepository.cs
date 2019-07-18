using KGM.Framework.Infrastructure;
using System.Collections.Generic;
namespace KGM.Framework.Domain
{
    public interface IInventoryRepository : IRepository<InventoryEntity>
    {
        string GetSku(int len);
    }
}
