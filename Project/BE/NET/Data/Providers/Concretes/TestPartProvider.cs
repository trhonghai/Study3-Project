using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class TestPartProvider : GenericProvider<TestPart>, ITestPartProvider<TestPart>
    {
        public async Task<DBActionResult<TestPart>> DeleteTestPartAsync(int id)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                await cn.OpenAsync();

                using (var checkCmd = new SqlCommand("FindTestPartById", cn))
                {
                    checkCmd.CommandType = CommandType.StoredProcedure;
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    using var reader = checkCmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return new DBActionResult<TestPart>
                        {
                            IsSuccess = false,
                            Data = null,
                            ErrorMessage = "TestPart not found."
                        };
                    }
                }


                using var cmd = new SqlCommand("DeleteTestPart", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", id);
                await cmd.ExecuteNonQueryAsync();

                return new DBActionResult<TestPart>
                {
                    IsSuccess = true,
                    Data = null,
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new DBActionResult<TestPart>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<DBActionResult<TestPart>> UpdateTestPartAsync(TestPart testPart)
        {
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("UpdateTestPart", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Console.WriteLine(testPart);

                cmd.Parameters.AddWithValue("@Id", testPart.Id);
                cmd.Parameters.AddWithValue("@TestId", testPart.TestId);
                cmd.Parameters.AddWithValue("@PartId", testPart.PartId);
                cmd.Parameters.AddWithValue("@NoQuestion", testPart.NoQuestion);
                cmd.Parameters.AddWithValue("@TimeLimit", testPart.TimeLimit);

                await cn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    return new DBActionResult<TestPart>
                    {
                        IsSuccess = true,
                        Data = testPart,
                        ErrorMessage = string.Empty
                    };
                }
                else
                {
                    return new DBActionResult<TestPart>
                    {
                        IsSuccess = false,
                        Data = null,
                        ErrorMessage = "No rows were updated."
                    };
                }
            }
            catch (Exception ex)
            {
                return new DBActionResult<TestPart>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
            }
        }


    }
}