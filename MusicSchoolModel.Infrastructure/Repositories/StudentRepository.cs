using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Infrastructure.Database;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class StudentRepository: BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context) { }
}