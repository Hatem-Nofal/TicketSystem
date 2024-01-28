using System.Linq.Expressions;

namespace TicketSystem.Application.Interfaces.Base;
public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Add(List<T> entities);
    IQueryable<T> GetQuerableAsync(Expression<Func<T, bool>> predicate = null);
    IQueryable<T> GetQuerableAsync(Expression<Func<T, bool>> predicate = null, List<Expression<Func<T, object>>> includes = null);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    IReadOnlyList<T> GetAll();
    void AddRange(List<T> entities);
    Task AddRangeAsync(List<T> entities);
    void UpdateRange(List<T> entities);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   List<Expression<Func<T, object>>> includes = null,
                                   bool disableTracking = true);
}
