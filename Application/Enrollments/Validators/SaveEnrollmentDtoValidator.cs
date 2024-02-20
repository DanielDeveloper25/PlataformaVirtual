using Application.Enrollments.Dtos;
using FluentValidation;

namespace Application.Enrollments.Validators
{
    public class SaveEnrollmentDtoValidator : AbstractValidator<SaveEnrollmentDto>
    {
        public SaveEnrollmentDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty()
                .WithMessage("Debe especificar el id del estudiante");

            RuleFor(x => x.SubjectId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Debe especificar el id de la materia");
        }
    }
}
