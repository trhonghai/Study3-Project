using Microsoft.AspNetCore.Mvc;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCourses(int page, int size)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetAllAsync(page, size);
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

        [HttpPost]
        public async Task<IActionResult> PostNewCourse(Course course)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.AddAsync(course);
                if (result.IsSuccess)
                {
                    course.Id = result.CreatedId;
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
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            try
            {
                course.Id = id;
                var result = await _unitOfWork.CourseRepository.UpdateAsync(id, course);
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
