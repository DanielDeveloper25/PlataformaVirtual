using Application.Generics.Interface;
using Application.Grades.Dtos;
using Domain.Entities;

namespace Application.Grades.Interfaces
{
    public interface IGradeService : IGenericService<SaveGradeDto, GradeDto, Grade>
    {
    }
}
