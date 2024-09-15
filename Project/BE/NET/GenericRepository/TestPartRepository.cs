using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;

namespace NET.GenericRepository
{
    public class TestPartRepository : SqlGenericRepository<TestPart>, ITestPartRepository
    {
        private readonly ITestPartProvider<TestPart> _testPartProvider;

        public TestPartRepository(ITestPartProvider<TestPart> testPartProvider) : base(testPartProvider)

        {
            _testPartProvider = testPartProvider;
        }

        public Task<DBActionResult<TestPart>> DeleteTestPartAsync(int id)
        {
            var result = _testPartProvider.DeleteTestPartAsync(id);
            if (result.Result.IsSuccess)
            {
                return Task.FromResult(new DBActionResult<TestPart>
                {
                    IsSuccess = true,
                    Data = null,
                    ErrorMessage = string.Empty
                });
            }
            else
            {
                return Task.FromResult(new DBActionResult<TestPart>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = result.Result.ErrorMessage
                });
            }
        }

        public Task<IEnumerable<TestPart>> GetAsync(string type)
        {
            throw new NotImplementedException();
        }

        public Task<DBActionResult<TestPart>> UpdateTestPartAsync(TestPart testPart)
        {
            var result = _testPartProvider.UpdateTestPartAsync(testPart);
            if (result.Result.IsSuccess)
            {
                return Task.FromResult(new DBActionResult<TestPart>
                {
                    IsSuccess = true,
                    Data = testPart,
                    ErrorMessage = string.Empty
                });
            }
            else
            {
                return Task.FromResult(new DBActionResult<TestPart>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = result.Result.ErrorMessage
                });
            }
        }
    }

}