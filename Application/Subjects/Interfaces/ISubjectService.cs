using Application.Generics.Interface;
using Application.Subjects.Dtos;
using Domain.Entities;

namespace Application.Subjects.Interfaces
{
    public interface ISubjectService : IGenericService<SaveSubjectDto, SubjectDto, Subject>
    {
    }
}
