using MusicSchoolModel.Core.DataTransfer.Student.Response;

namespace MusicSchoolModel.Core.DTO.Teacher.Response;

public class ShortCourseDto : ShortStudentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}