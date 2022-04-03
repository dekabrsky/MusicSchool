using MusicSchoolModel.Core.DataTransfer.Abstract;

namespace MusicSchoolModel.Core.DataTransfer.Student.Request;

public class CreateStudentDto: ICreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? TeacherId { get; set; }
}