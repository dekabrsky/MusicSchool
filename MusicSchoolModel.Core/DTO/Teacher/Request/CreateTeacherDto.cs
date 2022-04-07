using MusicSchoolModel.Core.DataTransfer.Abstract;

namespace MusicSchoolModel.Core.DTO.Teacher.Request;

public class CreateTeacherDto: ICreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long CourseId { get; set; }
}