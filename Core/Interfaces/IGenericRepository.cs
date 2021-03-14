using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task SaveChanges();
        
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetItemWithSpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec);
    }
}