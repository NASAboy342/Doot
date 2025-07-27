using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Repositories
{
    using Microsoft.EntityFrameworkCore;
    public class BaseRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public BaseRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                return await context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllAsync<{typeof(T).Name}>: {ex.Message}", ex);
            }
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                return await context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync<{typeof(T).Name}>: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                return await context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in FindAsync<{typeof(T).Name}>: {ex.Message}", ex);
            }
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in AddAsync<{typeof(T).Name}>: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync<{typeof(T).Name}>: {ex.Message}", ex);
            }
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in RemoveAsync<{typeof(T).Name}>: {ex.Message}", ex);
            }
        }
    }
}