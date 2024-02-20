using Application.Subjects.Dtos;
using FluentValidation;

namespace Application.Subjects.Validators
{
    public class SaveSubjectDtoValidator : AbstractValidator<SaveSubjectDto>
    {
        public SaveSubjectDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre de la materia es requerido");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripción es requerida");

            RuleFor(x => x.TeacherId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Debe asignar un profesor a la materia");

        }
    }
}
