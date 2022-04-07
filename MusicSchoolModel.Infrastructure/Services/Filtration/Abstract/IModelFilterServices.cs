namespace MusicSchoolModel.Infrastructure.Repositories;

public interface IStudentFilterService : IFilterService<Core.Domain.Student.Student> { }

public interface ITeacherFilterService : IFilterService<Core.Domain.Teacher.Teacher> { }

public interface ICourseFilterService : IFilterService<Core.Domain.Course.Course> { }