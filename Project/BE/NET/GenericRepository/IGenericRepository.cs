using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NET.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        Task<DBActionResult<T>> GetByIdAsync(int id);
        Task<DBActionResult<IEnumerable<T>>> GetAllAsync();
        Task<DBActionResult<T>> AddAsync(T entity);
        Task<DBActionResult<T>> UpdateAsync(int id, T entity);
        Task<DBActionResult<bool>> DeleteAsync(int id);
    }
}