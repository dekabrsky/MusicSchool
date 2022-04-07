using MusicSchoolModel.Core.DataTransfer.Student.Request;

namespace MusicSchoolModel.Core.DTO.Teacher.Request;

public class UpdateCourseDto: UpdateStudentDto
{
    public string Name { get; set; }
    public bool IsOpen { get; set; }
}