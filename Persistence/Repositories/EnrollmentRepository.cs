using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly ApplicationContext _dbContext;

        public EnrollmentRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
