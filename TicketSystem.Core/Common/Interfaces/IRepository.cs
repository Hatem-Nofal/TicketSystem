using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;

namespace TicketSystem.Domain.Common.Interfaces;
public interface IRepository<T, TId> where T : class, TId where TId : notnull
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
