using Application.Assignments.Dtos;
using Application.Assignments.Interfaces;
using Application.Generics.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Assignments.Services
{
    public class AssignmentService : GenericService<SaveAssignmentDto, AssignmentDto, Assignment>, IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper) : base(assignmentRepository, mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }
    }
}
