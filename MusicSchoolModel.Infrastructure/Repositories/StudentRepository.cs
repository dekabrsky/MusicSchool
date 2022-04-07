using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Interfaces.Repositories;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class StudentRepository: BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context) { }
}