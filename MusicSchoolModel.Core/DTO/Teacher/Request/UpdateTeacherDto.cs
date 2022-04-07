using MusicSchoolModel.Core.DataTransfer.Student.Request;

namespace MusicSchoolModel.Core.DTO.Teacher.Request;

public class UpdateTeacherDto: UpdateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? CourseId { get; set; }
}