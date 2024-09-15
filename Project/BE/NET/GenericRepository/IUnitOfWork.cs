using NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using NET.Data.Providers.Models;
using NET.Data.Providers;

namespace NET.GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<ApplicationUser> UserRepository { get; }

        ITestRepository TestRepository { get; }

        ITestPartRepository TestPartRepository { get; }

        IScriptRepository ScriptRepository { get; }

        IQuestionRepository QuestionRepository { get; }

        IAnswerRepository AnswerRepository { get; }

        ITypeRepository TypeRepository { get; }

        ICourseRepository CourseRepository { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> SaveChangesAsync();
    }
}