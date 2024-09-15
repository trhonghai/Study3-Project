using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{

    public class GenericProvider<T> : IGenericProvider<T> where T : class
    {
        public static string ConnectionString { get; set; } = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]!;
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DBActionResult<T>> Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var columns = new List<string>();
            var values = new List<object>();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == "Id")
                {
                    continue;
                }
                columns.Add(prop.Name);
                values.Add(prop.GetValue(entity) ?? DBNull.Value);
            }

            //using the store procedure to insert the data
            string procedure = $"Insert{tableName}";

            using var cn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(procedure, cn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            for (int i = 0; i < columns.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@{columns[i]}", values[i]);
            }

            SqlParameter Id = new SqlParameter("@Id", System.Data.SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };

            cmd.Parameters.Add(Id);

            cn.Open();

            await cmd.ExecuteNonQueryAsync();

            int entityId = (int)Id.Value;
            return new DBActionResult<T>
            {
                IsSuccess = (int)Id.Value > 0,
                Data = entity,
                CreatedId = entityId,
                ErrorMessage = entityId > 0 ? string.Empty : "Insert failed"
            };
        }

        public async Task<DBActionResult<T>> Update(int id, T entity)
        {
            var tableName = typeof(T).Name;
            var setClauses = new List<string>();
            var values = new List<object>();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == "Id")
                {
                    continue;
                }
                setClauses.Add($"{prop.Name} = @{prop.Name}");
                values.Add(prop.GetValue(entity) ?? DBNull.Value);
            }

            string procedure = $"Update{tableName}";

            using var cn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(procedure, cn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            for (int i = 0; i < setClauses.Count; i++)
            {
                var propertyName = typeof(T).GetProperties()[i + 1].Name;
                cmd.Parameters.AddWithValue($"@{propertyName}", values[i]);
            }

            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                cn.Open();
                var rowsAffected = await cmd.ExecuteNonQueryAsync();

                return new DBActionResult<T>
                {
                    IsSuccess = rowsAffected > 0,
                    Data = entity,
                    CreatedId = id,
                    ErrorMessage = rowsAffected > 0 ? string.Empty : "Update failed"
                };
            }
            catch (Exception ex)
            {
                // Log exception details
                return new DBActionResult<T>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }

}