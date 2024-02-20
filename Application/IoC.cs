using Application.Assignments.Interfaces;
using Application.Assignments.Services;
using Application.Enrollments.Interfaces;
using Application.Enrollments.Services;
using Application.Generics.Interface;
using Application.Generics.Services;
using Application.Grades.Interfaces;
using Application.Grades.Services;
using Application.Subjects.Interfaces;
using Application.Subjects.Services;
using Application.Users.Interfaces;
using Application.Users.Services;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class IoC
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddTransient<IEnrollmentService, EnrollmentService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
