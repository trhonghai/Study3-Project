using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;

namespace NET.GenericRepository
{
    public class TypeRepository : SqlGenericRepository<Data.Providers.Models.Type>, ITypeRepository
    {
        public TypeRepository(ITypeProvider<Data.Providers.Models.Type> databaseProvider) : base(databaseProvider)
        {
        }

    }

}