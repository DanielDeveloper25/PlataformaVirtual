using Application.Grades.Dtos;
using FluentValidation;

namespace Application.Grades.Validators
{
    public class SaveGradeDtoValidator : AbstractValidator<SaveGradeDto>
    {
        public SaveGradeDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("El id del estudiante es requerido");

            RuleFor(x => x.AssignmentId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("El id de la tarea es requerido");


            RuleFor(x => x.Score)
                 .InclusiveBetween(0, 100)
                 .WithMessage("La nota debe estar entre 0 y 100");
        }
    }
}
