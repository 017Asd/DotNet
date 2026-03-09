using Microsoft.EntityFrameworkCore;
using Employee.Data.Models;

namespace Employee.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EmployeeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}