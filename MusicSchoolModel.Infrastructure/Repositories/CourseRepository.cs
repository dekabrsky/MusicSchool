using MusicSchoolModel.Core.Domain.Course;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Infrastructure.Database;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context) { }
}