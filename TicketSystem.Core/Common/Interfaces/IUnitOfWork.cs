using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;

namespace TicketSystem.Domain.Common.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity, TId> Repository<TEntity, TId>() where TEntity : class,  TId where TId:notnull ;
    Task<bool> Commit();
    void RollBackTransaction();
    void CreateTransction();
    void CommitTransaction();
    void EndTransaction();

}
