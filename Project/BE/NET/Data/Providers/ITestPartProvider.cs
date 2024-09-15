

using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data.Providers
{
    public interface ITestPartProvider<TestPart> : IGenericProvider<TestPart>
    {
        Task<DBActionResult<TestPart>> UpdateTestPartAsync(TestPart testPart);

        Task<DBActionResult<TestPart>> DeleteTestPartAsync(int id);
    }
}