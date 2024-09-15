
using System.Reflection.Metadata.Ecma335;
using NET.Data.Providers;

namespace NET.GenericRepository
{
    public class SqlGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IGenericProvider<T> _databaseProvider;

        public SqlGenericRepository(IGenericProvider<T> databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        public async Task<DBActionResult<T>> AddAsync(T entity)
        {
            return await _databaseProvider.Insert(entity);

        }

        public Task<DBActionResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DBActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = _databaseProvider.GetAll();
            return Task.FromResult(new DBActionResult<IEnumerable<T>>(true, result.Result));
        }

        public Task<DBActionResult<T>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task<DBActionResult<T>> UpdateAsync(int id, T entity)
        {

            return _databaseProvider.Update(id, entity);

        }


    }
}