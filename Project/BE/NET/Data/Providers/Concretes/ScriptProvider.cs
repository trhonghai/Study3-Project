using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.StoredProcedures;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class ScriptProvider : GenericProvider<Script>, IScriptProvider<Script>
    {

    }
}