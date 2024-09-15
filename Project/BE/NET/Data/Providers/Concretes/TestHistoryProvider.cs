using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;
using NET.Data.Providers.StoredProcedures;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class TestHistoryProvider : ITestHistoryProvider<TestHistory>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TestHistory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TestHistory> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(TestHistory entity)
        {
            throw new NotImplementedException();
        }



        Task<IEnumerable<TestHistory>> Providers.IGenericProvider<TestHistory>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<TestHistory>> Providers.IGenericProvider<TestHistory>.Insert(TestHistory entity)
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<TestHistory>> IGenericProvider<TestHistory>.Update(int id, TestHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}