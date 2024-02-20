using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repositories
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        private readonly ApplicationContext _dbContext;

        public AssignmentRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
