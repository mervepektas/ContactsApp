using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public readonly ContactsDBContext _context;

    public IContactRepository Contacts { get; }

    public UnitOfWork(ContactsDBContext context,
        IContactRepository contactRepository)
    {
        _context = context;

        Contacts = contactRepository;
    }

    public void BeginTransaction(IsolationLevel isolationLevel)
    {
        _context.Database.BeginTransaction(isolationLevel);
    }

    public async Task BeginTransactionAsync(IsolationLevel isolationLevel)
    {
        if (_context.Database.CurrentTransaction is null)
            await _context.Database.BeginTransactionAsync(isolationLevel);
    }

    public void Commit()
    {
        _context.SaveChanges();
        _context.Database.CommitTransaction();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
        catch (Exception ex)
        { 
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
