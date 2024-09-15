using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;
using NET.Dto;

namespace NET.GenericRepository
{
    public class TestRepository : SqlGenericRepository<Test>, ITestRepository
    {
        private readonly ITestProvider<Test> _testProvider;



        public TestRepository(ITestProvider<Test> testProvider) : base(testProvider)
        {
            _testProvider = testProvider;
        }

        public Task<DBActionResult<Test>> DeleteTestAsync(int id)
        {
            var result = _testProvider.DeleteTestAsync(id);
            return result;
        }

        public Task<DBActionResult<PaginatedResult<TestDto>>> GetAllAsync(int page, int size)
        {

            var result = _testProvider.GetByPageAsync(page, size);

            return result;

        }

        public Task<DBActionResult<Test>> UpdateTestAsync(Test test)
        {
            var result = _testProvider.UpdateTestAsync(test);
            if (result.Result.IsSuccess)
            {
                return Task.FromResult(new DBActionResult<Test>
                {
                    IsSuccess = true,
                    Data = test,
                    ErrorMessage = string.Empty
                });
            }
            else
            {
                return Task.FromResult(new DBActionResult<Test>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = result.Result.ErrorMessage
                });
            }
        }
    }
}