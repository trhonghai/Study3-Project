using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class AudioProvider : IAudioProvider<Audio>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Audio>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Audio> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Audio entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Audio entity)
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<Audio>> Providers.IGenericProvider<Audio>.Insert(Audio entity)
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<Audio>> IGenericProvider<Audio>.Update(int id, Audio entity)
        {
            throw new NotImplementedException();
        }
    }
}