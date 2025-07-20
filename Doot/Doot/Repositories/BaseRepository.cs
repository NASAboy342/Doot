using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Repositories
{
    public class BaseRepository
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
            => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
            => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
            => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task AddAsync<T>(T entity) where T : class
            => await _context.Set<T>().AddAsync(entity);

        public void Update<T>(T entity) where T : class
            => _context.Set<T>().Update(entity);

        public void Remove<T>(T entity) where T : class
            => _context.Set<T>().Remove(entity);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}