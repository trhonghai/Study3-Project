using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;

namespace NET.GenericRepository
{
    public class AnswerRepository : SqlGenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(IAnswerProvider<Answer> databaseProvider) : base(databaseProvider)
        {
        }
    }
}
