// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using NET.Data.Providers.Models;
// using NET.GenericRepository;

// namespace NET.Services
// {
//     public class TestService : ITestService
//     {
//         private readonly ITestRepository _testRepository;
//         private readonly UnitOfWork _unitOfWork;

//         public TestService(ITestRepository testRepository, UnitOfWork unitOfWork)
//         {
//             _testRepository = testRepository;
//             _unitOfWork = unitOfWork;
//         }

//         public async Task<DBActionResult<IEnumerable<Test>>> GetAllAsync(int page, int size)
//         {
//             try
//             {

//                 var result = await _unitOfWork.TestRepository.GetAllAsync(page, size);
//                 return result;
//             }
//             catch (Exception ex)
//             {
//                 return new DBActionResult<IEnumerable<Test>>
//                 {
//                     IsSuccess = false,
//                     ErrorMessage = ex.Message
//                 };
//             }
//         }
//     }
// }