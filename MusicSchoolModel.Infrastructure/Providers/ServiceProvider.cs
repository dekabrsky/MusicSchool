using Microsoft.Extensions.DependencyInjection;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Core.Interfaces.Services;
using MusicSchoolModel.Infrastructure.Repositories;
using MusicSchoolModel.Infrastructure.Services;

namespace MusicSchoolModel.Infrastructure.Providers;

public static class ServiceProvider
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<ITeacherRepository, TeacherRepository>();
        services.AddTransient<ICourseRepository, CourseRepository>();

        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<ITeacherService, TeacherService>();
        services.AddTransient<ICourseService, CourseService>();

        services.AddTransient<IStudentFilterService, StudentFilterService>();
        services.AddTransient<ITeacherFilterService, TeacherFilterService>();
        services.AddTransient<ICourseFilterService, CourseFilterService>();

        return services;
    }
}