using MusicSchoolModel.Core.DataTransfer.Student.Response;

namespace MusicSchoolModel.Core.DTO.Teacher.Response;

public class FullTeacherDto : FullStudentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? CourseId { get; set; }
    public int StudentsCount { get; set; }
    public int MaxStudentsCount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}