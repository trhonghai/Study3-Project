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
    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        // [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> PostNewQuestion(Question question)
        {
            try
            {
                var result = await _unitOfWork.QuestionRepository.AddAsync(question);
                if (result.IsSuccess)
                {
                    question.Id = result.CreatedId;
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