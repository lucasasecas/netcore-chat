using System.Threading.Tasks;
using System.Collections.Generic;

namespace NetcoreChat.Infrastructure.Data.Repositories
{
    public interface ILocatable<TResult>
    {
        Task<ICollection<TResult>> FindNear(Domain.Entities.Location location, long maxDistance = 100);
    }
}
