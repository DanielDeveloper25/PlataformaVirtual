using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repositories
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly ApplicationContext _dbContext;

        public GradeRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
