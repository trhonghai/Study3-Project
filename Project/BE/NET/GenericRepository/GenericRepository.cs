
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NET.Data;
using NET.Data.Providers;

namespace NET.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Study3DbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(Study3DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public async Task<DBActionResult<T>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    return DBActionResult<T>.Failure("Entity not found.");
                }
                return DBActionResult<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return DBActionResult<T>.Failure(ex.Message);
            }
        }

        public async Task<DBActionResult<IEnumerable<T>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<T>().ToListAsync();
                return DBActionResult<IEnumerable<T>>.Success(entities);
            }
            catch (Exception ex)
            {
                return DBActionResult<IEnumerable<T>>.Failure(ex.Message);
            }
        }
        /// <summary>
        /// Add an entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// 
        /// </returns>
        public async Task<DBActionResult<T>> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return DBActionResult<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return DBActionResult<T>.Failure(ex.Message);
            }
        }

        public async Task<DBActionResult<T>> UpdateAsync(int id, T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return DBActionResult<T>.Success(entity);
            }
            catch (Exception ex)
            {
                return DBActionResult<T>.Failure(ex.Message);
            }
        }

        public async Task<DBActionResult<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    return DBActionResult<bool>.Failure("Entity not found.");
                }
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return DBActionResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return DBActionResult<bool>.Failure(ex.Message);
            }
        }
    }
}
