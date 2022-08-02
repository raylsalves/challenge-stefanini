using Microsoft.EntityFrameworkCore;
using Stefanini.Challenge.Domain.Data;
using Stefanini.Challenge.Infra.Data.Repositories.Interfaces;

namespace Stefanini.Challenge.Infra.Data.Repositories
{
    public class GenericReposity<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly DatabaseContext _context;

        public GenericReposity(DatabaseContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T?> GetAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
