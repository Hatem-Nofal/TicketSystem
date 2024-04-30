using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Domain.Primitives;
namespace TicketSystem.Infrastructure.Data.Base;
public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");
        _context.Set<T>().Add(entity);
    }
    public void AddRange(List<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException("entity");

        _context.Set<T>().AddRange(entities);

    }
    public async Task AddRangeAsync(List<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException("entity");

        await _context.Set<T>().AddRangeAsync(entities);

    }
    public void UpdateRange(List<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException("entity");

        _context.Set<T>().UpdateRange(entities);

    }
    public void Add(List<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException("entity");
        foreach (var entity in entities)
        {
            _context.Set<T>().Add(entity);
        }
    }
    public void Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");
        _context.Set<T>().Remove(entity);
    }
    public void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public IQueryable<T> GetQuerableAsync(Expression<Func<T, bool>> predicate = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (predicate != null) query = query.Where(predicate);

        return query;
    }
    public IQueryable<T> GetQuerableAsync(Expression<Func<T, bool>> predicate = null, List<Expression<Func<T, object>>> includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        return query;
    }
    public IReadOnlyList<T> GetAll()
    {

        return _context.Set<T>().ToList();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {

        return await _context.Set<T>().ToListAsync();
    }
    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }
    public bool GetAny(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Any(predicate);
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }
}
