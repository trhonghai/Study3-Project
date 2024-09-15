using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;
using NET.Dto;

namespace NET.GenericRepository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<DBActionResult<PaginatedResult<CourseDto>>> GetAllAsync(int page, int size);
    }
}