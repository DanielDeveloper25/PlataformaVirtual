using Application.Assignments.Dtos;
using FluentValidation;

namespace Application.Assignments.Validators
{
    public class SaveAssignmentDtoValidator : AbstractValidator<SaveAssignmentDto>
    {
        public SaveAssignmentDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre de la tarea es obligatorio");

            RuleFor(x => x.Instructions)
                .NotEmpty()
                .WithMessage("Las instrucciones de la tarea son obligatorias");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("La fecha de entrega debe ser una fecha futura");

            RuleFor(x => x.SubjectId)
                .GreaterThan(0)
                .WithMessage("Debe especificar la materia a la que pertenece la tarea");
        }
    }
}
