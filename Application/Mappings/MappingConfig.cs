using Application.Assignments.Dtos;
using Application.Enrollments.Dtos;
using Application.Grades.Dtos;
using Application.Subjects.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Assignment, AssignmentDto>().ReverseMap();
            CreateMap<Assignment, SaveAssignmentDto>().ReverseMap();

            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Enrollment, SaveEnrollmentDto>().ReverseMap();

            CreateMap<Grade, GradeDto>().ReverseMap();
            CreateMap<Grade, SaveGradeDto>().ReverseMap();

            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, SaveSubjectDto>().ReverseMap();
        }
    }
}
