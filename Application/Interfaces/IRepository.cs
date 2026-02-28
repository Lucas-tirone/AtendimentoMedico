using System.Linq.Expressions;

namespace AtendimentoMedico.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);

    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
