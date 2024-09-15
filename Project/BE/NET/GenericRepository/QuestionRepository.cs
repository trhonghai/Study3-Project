using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers;
using NET.Data.Providers.Models;

namespace NET.GenericRepository
{
    public class QuestionRepository : SqlGenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IQuestionProvider<Question> databaseProvider) : base(databaseProvider)
        {
        }

    }

}