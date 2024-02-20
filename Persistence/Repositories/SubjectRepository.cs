using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly ApplicationContext _dbContext;

        public SubjectRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
