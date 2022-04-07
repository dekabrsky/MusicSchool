using MusicSchoolModel.Core.DataTransfer.Abstract;

namespace MusicSchoolModel.Core.DTO.Teacher.Request;

public class CreateCourseDto: ICreateDto
{
    public string Name { get; set; }
    public bool IsOpen { get; set; }
}