using Domain.Repositories;
using System.Data;

namespace Domain;

public interface IUnitOfWork
{
    IContactRepository Contacts { get; }
    Task CommitAsync();
    void Commit();
    void BeginTransaction(IsolationLevel isolationLevel);
    Task BeginTransactionAsync(IsolationLevel isolationLevel);
    Task RollbackAsync();
}
