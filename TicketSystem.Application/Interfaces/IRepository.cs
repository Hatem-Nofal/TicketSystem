using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;

namespace TicketSystem.Application.Interfaces;
public interface IRepository<T> where T : Entity<T> 
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetQuerableAsync(Expression<Func<T, bool>> predicate = null);

    IQueryable<T> GetQuerableAsync(
                                            Expression<Func<T, bool>> predicate,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                            List<Expression<Func<T, object>>> includes = null,
                                            /* Expression<Func<T, TKey>> groupingKey = null,
                                             Expression<Func<IGrouping<TKey, T>, T>> resultSelector = null,*/
                                            bool disableTracking = false,
                                            string includeString = "");
    IQueryable<T> GetQuerableAsync(Expression<Func<T, bool>> predicate = null, List<Expression<Func<T, object>>> includes = null);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   List<Expression<Func<T, object>>> includes = null,
                                   bool disableTracking = true);
}
