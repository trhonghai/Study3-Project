using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;
using NET.Dto;

namespace NET.GenericRepository
{
    public class CourseRepository : SqlGenericRepository<Course>, ICourseRepository
    {
        private readonly ICourseProvider<Course> _databaseProvider;
        public CourseRepository(ICourseProvider<Course> databaseProvider) : base(databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public Task<DBActionResult<PaginatedResult<CourseDto>>> GetAllAsync(int page, int size)
        {
            var result = _databaseProvider.GetByPageAsync(page, size);
            return result;
        }


    }
}