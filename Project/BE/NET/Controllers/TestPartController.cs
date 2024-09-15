using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestPartController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public TestPartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("test-part")]
        public async Task<IActionResult> PostTestPart(TestPart testPart)
        {
            try
            {
                var result = await _unitOfWork.TestPartRepository.AddAsync(testPart);
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

        [HttpPut("test-part/{id}")]
        public async Task<IActionResult> PutTestPart(int id, TestPart testPart)
        {
            try
            {
                testPart.Id = id;
                var result = await _unitOfWork.TestPartRepository.UpdateTestPartAsync(testPart);
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

        [HttpDelete("test-part/{id}")]
        public async Task<IActionResult> DeleteTestPart(int id)
        {
            try
            {
                var result = await _unitOfWork.TestPartRepository.DeleteTestPartAsync(id);
                if (result.IsSuccess)
                {
                    return Ok();
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