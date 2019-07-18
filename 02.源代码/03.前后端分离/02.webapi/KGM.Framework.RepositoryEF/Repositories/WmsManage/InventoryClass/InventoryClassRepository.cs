using KGM.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class InventoryClassRepository : BaseRepository<InventoryClassEntity>, IInventoryClassRepository
    {

    }
}
