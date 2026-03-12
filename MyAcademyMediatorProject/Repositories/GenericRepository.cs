
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyAcademyMediatorProject.Context;

namespace MyAcademyMediatorProject.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IRepository<TEntity> where TEntity : class
    {
        public async Task CreateAsync(TEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }


        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();


        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = context.Set<TEntity>().AsNoTracking();
            foreach (var include in includes)
            {
             query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);

        }

        public Task UpdateAsync(TEntity entity)
        {
            context.Update(entity);
            return context.SaveChangesAsync();

        }
    }
}
