using Application.Generics.Services;
using Application.Grades.Dtos;
using Application.Grades.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Grades.Services
{
    public class GradeService : GenericService<SaveGradeDto, GradeDto, Grade>, IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IMapper mapper) : base(gradeRepository, mapper) 
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }
    }
}
