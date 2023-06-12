using Domain.Abstractions;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IContactRepository : IRepository<ContactInfo>
    {
        Task<ContactInfo> FindByIdAsync(Guid? id);
    }
}
