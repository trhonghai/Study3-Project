using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NET.Data.Providers.Models;
using NET.GenericRepository;
using Type = NET.Data.Providers.Models.Type;

namespace NET.Data.Providers.Concretes
{
    public class TypeProvider : GenericProvider<Type>, ITypeProvider<Type>
    {

        public override async Task<IEnumerable<Type>> GetAll()
        {
            var result = new Collection<Type>();
            try
            {
                using var cn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("GetAllTypes", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var type = new Type
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    result.Add(type);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

    }
}