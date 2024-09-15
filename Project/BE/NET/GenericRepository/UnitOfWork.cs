using Microsoft.EntityFrameworkCore.Storage;
using NET.Data;
using NET.Data.Providers;
using NET.Data.Providers.Concretes;
using NET.Data.Providers.Models;
using Type = System.Type;

namespace NET.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Study3DbContext _context;
        private IGenericRepository<ApplicationUser> _userRepository;

        private ITestRepository _testRepository;

        private IGenericRepository<TestPart> _testPartRepository;

        private IScriptRepository _scriptRepository;
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;

        private ITypeRepository _typeRepository;

        private ICourseRepository _courseRepository;
        private readonly Dictionary<Type, object> _providers = new();


        public UnitOfWork(Study3DbContext context)
        {
            _context = context;
        }

        public IGenericRepository<ApplicationUser> UserRepository
        {

            get
            {
                return _userRepository ??= new GenericRepository<ApplicationUser>(_context);
            }
        }

        public ITestRepository TestRepository
        {

            get
            {
                //PROVIDE THE IMPLEMENTATION FOR THE IDatabaseProvider<> INTERFACE
                return _testRepository ??= new TestRepository(new TestProvider());
            }
        }

        public ITestPartRepository TestPartRepository
        {

            get
            {
                return (ITestPartRepository)(_testPartRepository ??= new TestPartRepository(new TestPartProvider()));
            }
        }

        public IScriptRepository ScriptRepository
        {
            get
            {
                return _scriptRepository ??= new ScriptRepository(new ScriptProvider());
            }
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                return _questionRepository ??= new QuestionRepository(new QuestionProvider());
            }
        }

        public IAnswerRepository AnswerRepository
        {
            get
            {
                return _answerRepository ??= new AnswerRepository(new AnswerProvider());
            }
        }

        public ITypeRepository TypeRepository
        {
            get
            {
                return _typeRepository ??= new TypeRepository(new TypeProvider());
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                return _courseRepository ??= new CourseRepository(new CourseProvider());
            }
        }
        //COMMENTED OUT BECAUSE IT IS NOT USED
        // public GenericProvider<T> GetProvider<T>() where T : class
        // {
        //     var type = typeof(T);

        //     if (!_providers.ContainsKey(type))
        //     {
        //         var provider = new GenericProvider<T>();
        //         _providers[type] = provider;
        //     }

        //     return (GenericProvider<T>)_providers[type];
        // }



        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}