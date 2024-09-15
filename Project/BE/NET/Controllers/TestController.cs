using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NET.Data.Providers.Models;
using NET.Dto;
using NET.GenericRepository;
using NET.Helpers;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-user")]
        [Authorize(Roles = AppRole.User)]
        public IEnumerable<string> GetUser()
        {

            return new List<string> { "Hai", "Minh", "Huynh" };
        }


        [HttpPost]
        // [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> PostNewTest(Test test)
        {
            try
            {
                var result = await _unitOfWork.TestRepository.AddAsync(test);
                if (result.IsSuccess)
                {
                    test.Id = result.CreatedId;
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Server error");
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllTests(int page, int size)
        {
            try
            {
                var result = await _unitOfWork.TestRepository.GetAllAsync(page, size);
                if (result.IsSuccess)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Server error");
            }
        }


        [HttpPut("update/{id}")]
        // [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateTest(int id, Test test)
        {
            try
            {
                test.Id = id;
                var result = await _unitOfWork.TestRepository.UpdateTestAsync(test);
                if (result.IsSuccess)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Server error");
            }
        }

        [HttpDelete("delete/{id}")]
        // [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeleteTest(int id)
        {
            try
            {
                var result = await _unitOfWork.TestRepository.DeleteTestAsync(id);
                if (result.IsSuccess)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Server error");
            }
        }


        [HttpPost("add-type")]
        public async Task<IActionResult> AddType(Data.Providers.Models.Type type)
        {
            try
            {
                var result = await _unitOfWork.TypeRepository.AddAsync(type);
                if (result.IsSuccess)
                {
                    type.Id = result.CreatedId;
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Server error");
            }
        }

        [HttpGet("get-types")]
        public async Task<IActionResult> GetType()
        {
            try
            {
                var result = await _unitOfWork.TypeRepository.GetAllAsync();
                if (result.IsSuccess)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Server error");
            }
        }

    }
}