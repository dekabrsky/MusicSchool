using MusicSchoolModel.Core.DataTransfer.Abstract;

namespace MusicSchoolModel.Core.DataTransfer.Student.Request;

public class UpdateStudentDto: IUpdateDto
{
    public long? TeacherId { get; set; }
}