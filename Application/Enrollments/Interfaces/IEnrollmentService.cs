using Application.Enrollments.Dtos;
using Application.Generics.Interface;
using Domain.Entities;

namespace Application.Enrollments.Interfaces
{
    public interface IEnrollmentService : IGenericService<SaveEnrollmentDto, EnrollmentDto, Enrollment>
    {
    }
}
