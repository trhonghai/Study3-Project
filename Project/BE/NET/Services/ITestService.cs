using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Services

{
    public interface ITestService
    {
        Task<DBActionResult<IEnumerable<Test>>> GetAllAsync(int page, int size);
    }
}