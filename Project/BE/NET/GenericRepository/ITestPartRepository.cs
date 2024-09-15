using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;

namespace NET.GenericRepository
{
    public interface ITestPartRepository : IGenericRepository<TestPart>
    {

        Task<DBActionResult<TestPart>> UpdateTestPartAsync(TestPart testPart);
        Task<DBActionResult<TestPart>> DeleteTestPartAsync(int id);
    }
}