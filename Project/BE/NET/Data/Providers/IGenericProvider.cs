using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NET.GenericRepository;

namespace NET.Data.Providers
{
    public interface IGenericProvider<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<DBActionResult<T>> Insert(T entity);
        Task<DBActionResult<T>> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}