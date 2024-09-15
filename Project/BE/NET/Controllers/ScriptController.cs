using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET.Data.Providers.StoredProcedures;
using NET.GenericRepository;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScriptController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScriptController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        // [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> PostNewScript(Script script)
        {
            try
            {
                var result = await _unitOfWork.ScriptRepository.AddAsync(script);
                if (result.IsSuccess)
                {
                    script.Id = result.CreatedId;
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