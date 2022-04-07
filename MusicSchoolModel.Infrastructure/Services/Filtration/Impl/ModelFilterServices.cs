namespace MusicSchoolModel.Infrastructure.Repositories;

public class StudentFilterService : FilterService<Core.Domain.Student.Student>, IStudentFilterService { }

public class TeacherFilterService : FilterService<Core.Domain.Teacher.Teacher>, ITeacherFilterService { }

public class CourseFilterService : FilterService<Core.Domain.Course.Course>, ICourseFilterService { }