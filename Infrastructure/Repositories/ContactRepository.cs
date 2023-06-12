using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactsDBContext _context;

    public ContactRepository(ContactsDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(ContactInfo entity)
    {
        _context.ContactInfo.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Add(IEnumerable<ContactInfo> entities)
    {
        _context.ContactInfo.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<ContactInfo> FindByIdAsync(Guid? id)
    {
        return await _context.ContactInfo.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ContactInfo>> GetAllAsync()
    {
        return await _context.ContactInfo.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public void Remove(ContactInfo entity)
    {
        var removedEntity = _context.Entry(entity);
        removedEntity.State = EntityState.Deleted;
        _context.SaveChangesAsync();
    }

    public void Update(ContactInfo entity)
    {
        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        _context.SaveChangesAsync();
    }
}
