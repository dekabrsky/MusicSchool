using MusicSchoolModel.Core.Domain.Teacher;
using MusicSchoolModel.Core.Interfaces.Repositories;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class TeacherRepository: BaseRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext context) : base(context) { }
}