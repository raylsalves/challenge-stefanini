using Stefanini.Challenge.Domain.Data;

namespace Stefanini.Challenge.Infra.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
