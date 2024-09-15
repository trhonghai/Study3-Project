

using System.Collections.ObjectModel;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class PartProvider : IPartProvider<Part>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Part>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Part> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Part entity)
        {
            throw new NotImplementedException();
        }



        Task<DBActionResult<Part>> Providers.IGenericProvider<Part>.Insert(Part entity)
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<Part>> IGenericProvider<Part>.Update(int id, Part entity)
        {
            throw new NotImplementedException();
        }
    }

}