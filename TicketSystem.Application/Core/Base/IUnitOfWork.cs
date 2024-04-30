using TicketSystem.Domain.Common.Models;

namespace TicketSystem.Application.Core.Base;
public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> CommitAsync();
    void RollBackTransaction();
    void CreateTransction();
    void CommitTransaction();
    void EndTransaction();

}
