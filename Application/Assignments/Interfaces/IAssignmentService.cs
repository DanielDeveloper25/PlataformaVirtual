using Application.Assignments.Dtos;
using Application.Generics.Interface;
using Domain.Entities;

namespace Application.Assignments.Interfaces
{
    public interface IAssignmentService : IGenericService<SaveAssignmentDto, AssignmentDto, Assignment>
    {
    }
}
