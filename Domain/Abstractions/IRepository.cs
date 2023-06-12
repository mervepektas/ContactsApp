using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task Add(T entity);
        Task Add(IEnumerable<T> entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
