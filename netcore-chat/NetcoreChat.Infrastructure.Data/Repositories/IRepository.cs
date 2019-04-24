using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetcoreChat.Infrastructure.Data.Repositories
{
    public interface IRepository<TElement, TId> 
    {
        Task<ICollection<TElement>> GetAll();
        Task<TElement> GetById(TId id);
        Task<TElement> Create(TElement element);
        Task<TElement> Update(TId id, TElement element);
        Task Delete(TId id);
    }
}
