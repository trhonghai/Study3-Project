using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;
using NET.Dto;
using NET.GenericRepository;

namespace NET.Data.Providers
{
    public interface ICourseProvider<T> : IGenericProvider<T>
    {
        Task<DBActionResult<PaginatedResult<CourseDto>>> GetByPageAsync(int page, int size);
    }
}