using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NET.Data.Providers.Models;
using NET.Dto;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class CourseProvider : GenericProvider<Course>, ICourseProvider<Course>
    {
        public async Task<DBActionResult<PaginatedResult<CourseDto>>> GetByPageAsync(int page, int size)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);

                using (
                    var cmd = new SqlCommand("GetCourseByPage", cn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    }
                )
                {
                    cmd.Parameters.Add(new SqlParameter("@PageNumber", System.Data.SqlDbType.Int) { Value = page });
                    cmd.Parameters.Add(new SqlParameter("@PageSize", System.Data.SqlDbType.Int) { Value = size });
                    SqlParameter output = new SqlParameter("@TotalPage", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);
                    await cn.OpenAsync();
                    var courses = new List<CourseDto>();


                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            courses.Add(new CourseDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                NoPurchase = reader.GetInt32(reader.GetOrdinal("NoPurchase")),
                                Rating = reader.GetDecimal(reader.GetOrdinal("Rating")),
                                Target = reader.GetString(reader.GetOrdinal("Target")),
                                TypeName = reader.GetString(reader.GetOrdinal("Name")),
                            });
                        }

                    }
                    int totalPages = output.Value != DBNull.Value && output.Value != null ? (int)output.Value : 0;


                    return new DBActionResult<PaginatedResult<CourseDto>>
                    {
                        IsSuccess = true,
                        Data = new PaginatedResult<CourseDto>
                        {
                            Data = courses,
                            TotalPages = totalPages
                        },
                        ErrorMessage = string.Empty,
                    };
                }

            }
            catch (Exception ex)
            {

                return new DBActionResult<PaginatedResult<CourseDto>>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}