using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class DoQuestionProvider : IDoQuestion<DoQuestion>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoQuestion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DoQuestion> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(DoQuestion entity)
        {
            throw new NotImplementedException();
        }


        Task<DBActionResult<DoQuestion>> Providers.IGenericProvider<DoQuestion>.Insert(DoQuestion entity)
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<DoQuestion>> IGenericProvider<DoQuestion>.Update(int id, DoQuestion entity)
        {
            throw new NotImplementedException();
        }
    }
}