using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Infrastructure.Context;

namespace TicketSystem.Infrastructure.Data.Base;
public class UnitOfWork : IUnitOfWork
{
    public readonly TicketSystemDbContext _context;

    IDbContextTransaction transaction;

    public UnitOfWork(IDbContextTransaction transaction)
    {
        this.transaction = transaction;
    }

    private Hashtable _repositories;
    private bool _disposed;

    public UnitOfWork(TicketSystemDbContext context)
    {
        _context = context;


    }

    public async Task<bool> CommitAsync()
    {
        var save = await _context.SaveChangesAsync();
        if (save > 0)
            return true;
        else
            return false;
    }


    public void CommitTransaction()
    {
        transaction.Commit();
    }


    public void CreateTransction()
    {
        transaction = _context.Database.BeginTransaction();
    }


    public void RollBackTransaction()
    {
        transaction.Rollback();

    }


    public void EndTransaction()
    {
        transaction.Dispose();
        _context.ChangeTracker.Clear();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        if (_repositories == null) _repositories = new Hashtable();

        // Check type of the entity
        var type = typeof(TEntity).Name;

        // Check whether hash table contains entry with this name
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(Repository<>);
            // If we don't have a repository for this type, then create a instance of that repo
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IRepository<TEntity>)_repositories[type];
    }

}

