using System;
using MusicSchoolModel.Core.DataTransfer.Abstract;

namespace MusicSchoolModel.Core.DataTransfer.Student.Response;

public class FullStudentDto : IFullDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? TeacherId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}