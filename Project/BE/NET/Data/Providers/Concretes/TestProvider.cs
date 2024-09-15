using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NET.Data.Providers.Models;
using NET.Dto;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class TestProvider : GenericProvider<Test>, ITestProvider<Test>
    {
        public async Task<DBActionResult<Test>> DeleteTestAsync(int id)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                await cn.OpenAsync();

                using (var checkCmd = new SqlCommand("FindTestById", cn))
                {
                    checkCmd.CommandType = CommandType.StoredProcedure;
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    using var reader = await checkCmd.ExecuteReaderAsync();
                    if (!reader.HasRows)
                    {
                        return new DBActionResult<Test>
                        {
                            IsSuccess = false,
                            Data = null,
                            ErrorMessage = "Test not found.",
                        };
                    }
                }

                using var cmd = new SqlCommand("DeleteTest", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", id);

                await cn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return new DBActionResult<Test>
                {
                    IsSuccess = true,
                    Data = null,
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new DBActionResult<Test>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<DBActionResult<PaginatedResult<TestDto>>> GetByPageAsync(int page, int size)
        {
            var result = new List<TestDto>();

            try
            {

                using var cn = new SqlConnection(ConnectionString);
                using (
                    var cmd = new SqlCommand("GetTestByPage", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                )
                {
                    cmd.Parameters.Add(new SqlParameter("@PageNumber", SqlDbType.Int) { Value = page });
                    cmd.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int) { Value = size });
                    SqlParameter createdId = new SqlParameter("@TotalPages", SqlDbType.Int)
                    { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(createdId);
                    await cn.OpenAsync();


                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            var test = new TestDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Year = reader.GetInt32(reader.GetOrdinal("Year")),
                                Attempts = reader.GetInt32(reader.GetOrdinal("Attempts")),
                                Month = reader.GetInt32(reader.GetOrdinal("Month")),
                                TimeLimit = reader.GetInt32(reader.GetOrdinal("TimeLimit")),
                                NoCompleted = reader.GetInt32(reader.GetOrdinal("NoCompleted")),
                                TypeName = reader.GetString(reader.GetOrdinal("Name"))

                            };
                            result.Add(test);
                        }
                    }
                    int totalPages = createdId.Value != DBNull.Value && createdId.Value != null ? (int)createdId.Value : 0;

                    Console.WriteLine($"Page: {page}, Size: {size}");
                    Console.WriteLine($"TotalPagesParam Value: {totalPages}");


                    return new DBActionResult<PaginatedResult<TestDto>>
                    {
                        IsSuccess = true,
                        Data = new PaginatedResult<TestDto>
                        {
                            Data = result,
                            TotalPages = totalPages
                        },
                        ErrorMessage = string.Empty,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DBActionResult<PaginatedResult<TestDto>>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<DBActionResult<Test>> UpdateTestAsync(Test test)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("UpdateTest", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", test.Id);
                cmd.Parameters.AddWithValue("@Title", test.Title);
                cmd.Parameters.AddWithValue("@Code", test.Code);
                cmd.Parameters.AddWithValue("@Year", test.Year);
                cmd.Parameters.AddWithValue("@Attempts", test.Attempts);
                cmd.Parameters.AddWithValue("@Month", test.Month);
                cmd.Parameters.AddWithValue("@TimeLimit", test.TimeLimit);
                cmd.Parameters.AddWithValue("@NoCompleted", test.NoCompleted);
                cmd.Parameters.AddWithValue("@TypeId", test.TypeId);

                await cn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                Console.WriteLine(rowsAffected);

                if (rowsAffected > 0)
                {
                    return new DBActionResult<Test>
                    {
                        IsSuccess = true,
                        Data = test,
                        ErrorMessage = string.Empty
                    };
                }
                else
                {
                    return new DBActionResult<Test>
                    {
                        IsSuccess = false,
                        Data = null,
                        ErrorMessage = "No rows were updated."
                    };
                }
            }
            catch (Exception ex)
            {
                return new DBActionResult<Test>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }



        #region Insert Test 
        /// <summary>
        /// Insert a Test object to the database.
        /// </summary>
        /// <param name="entity">Test object to be added</param>
        /// <returns>Returns true if add is successful, else false.</returns>
        /// <remarks>
        ///     After inserting into the datasource, the email template object will be updated
        ///     to reflect any changes made by the database. (ie: identity or computed columns)
        /// </remarks>
        /// 

        //<<===================>>
        //Commented out because it is already implemented in the base class
        //<<===================>>

        // public async Task<DBActionResult<Test>> Insert(Test entity)
        // {
        //     using var cn = new SqlConnection(ConnectionString);
        //     using var cmd = new SqlCommand("InsertTest", cn);

        //     cmd.CommandType = CommandType.StoredProcedure;

        //     cmd.Parameters.AddWithValue("@Title", entity.Title);
        //     cmd.Parameters.AddWithValue("@Code", entity.Code);
        //     cmd.Parameters.AddWithValue("@Year", entity.Year);
        //     cmd.Parameters.AddWithValue("@Attempts", entity.Attempts);
        //     cmd.Parameters.AddWithValue("@Month", entity.Month);
        //     cmd.Parameters.AddWithValue("@TimeLimit", entity.TimeLimit);
        //     cmd.Parameters.AddWithValue("@NoCompleted", entity.NoCompleted);
        //     cmd.Parameters.AddWithValue("@TypeId", entity.TypeId);

        //     SqlParameter createdId = new SqlParameter("@Id", SqlDbType.Int)
        //     { Direction = ParameterDirection.Output };
        //     cmd.Parameters.Add(createdId);

        //     cn.Open();

        //     await cmd.ExecuteNonQueryAsync();

        //     entity.Id = (int)createdId.Value;
        //     return new DBActionResult<Test>
        //     {
        //         IsSuccess = (int)createdId.Value > 0,
        //         Data = entity,
        //         CreatedId = entity.Id,
        //         ErrorMessage = entity.Id > 0 ? string.Empty : "Insert failed"
        //     };

        // }
        #endregion


    }
}