using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _ctx;

        public GenericRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }
        
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            //return (_ctx.SaveChanges() > 0);
            await _ctx.SaveChangesAsync();
        }
        public async Task DeleteAsync(T item)
        {
            _ctx.Set<T>().Remove(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task<T> GetItemWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            IQueryable<T> current = _ctx.Set<T>();
            return SpecEvaluator<T>.GetQuery(current, spec);
        }
    }
}