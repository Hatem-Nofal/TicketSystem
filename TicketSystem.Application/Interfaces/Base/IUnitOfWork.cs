﻿using TicketSystem.Domain.Primitives;

namespace TicketSystem.Application.Interfaces.Base;
public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> CommitAsync();
    void RollBackTransaction();
    void CreateTransction();
    void CommitTransaction();
    void EndTransaction();

}
