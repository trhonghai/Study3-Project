using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.StoredProcedures;

namespace NET.GenericRepository
{
    public class ScriptRepository : SqlGenericRepository<Script>, IScriptRepository
    {
        public ScriptRepository(IScriptProvider<Script> databaseProvider) : base(databaseProvider)
        {
        }
    }

}