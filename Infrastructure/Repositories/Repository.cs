using AtendimentoMedico.Infraestructure.Context;
using AtendimentoMedico.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AtendimentoMedico.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().AnyAsync(expression);
        }


        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
