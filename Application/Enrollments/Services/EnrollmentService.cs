using Application.Enrollments.Dtos;
using Application.Enrollments.Interfaces;
using Application.Generics.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Enrollments.Services
{
    public class EnrollmentService : GenericService<SaveEnrollmentDto, EnrollmentDto, Enrollment>, IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper) : base(enrollmentRepository, mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }
    }
}
