using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetcoreChat.Infrastructure.Data.Repositories
{
    public interface IRepository<TElement> : ILocatable<TElement>
    {
        Task<ICollection<TElement>> GetAllAsync();
        Task<TElement> GetByIdAsync(string id);
        Task<TElement> CreateAsync(TElement element);
        Task<bool> UpdateAsync(string id, TElement element);
        Task<bool> DeleteAsync(string id);
    }
}
