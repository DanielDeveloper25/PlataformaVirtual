using Application.Generics.Services;
using Application.Subjects.Dtos;
using Application.Subjects.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Subjects.Services
{
    public class SubjectService : GenericService<SaveSubjectDto, SubjectDto, Subject>, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper) : base(subjectRepository, mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
    }
}
