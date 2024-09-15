using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Dto;
using NET.GenericRepository;

namespace NET.Data.Providers
{
    public interface ITestProvider<Test> : IGenericProvider<Test>
    {
        Task<DBActionResult<PaginatedResult<TestDto>>> GetByPageAsync(int page, int size);

        Task<DBActionResult<Test>> UpdateTestAsync(Test test);

        Task<DBActionResult<Test>> DeleteTestAsync(int id);

    }
}