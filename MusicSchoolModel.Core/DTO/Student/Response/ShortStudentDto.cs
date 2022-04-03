using System;
using MusicSchoolModel.Core.DataTransfer.Abstract;

namespace MusicSchoolModel.Core.DataTransfer.Student.Response;

public class ShortStudentDto : IShortDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedDate { get; set; }
}