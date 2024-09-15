using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;
using NET.Dto;

namespace NET.GenericRepository
{
    public interface ITestRepository : IGenericRepository<Test>
    {
        Task<DBActionResult<PaginatedResult<TestDto>>> GetAllAsync(int page, int size);

        Task<DBActionResult<Test>> UpdateTestAsync(Test test);

        Task<DBActionResult<Test>> DeleteTestAsync(int id);
    }
}