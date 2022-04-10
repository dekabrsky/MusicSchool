using System;
using MusicSchoolModel.Core.DataTransfer.Student.Response;

namespace MusicSchoolModel.Core.DTO.Teacher.Response;

public class FullCourseDto : FullStudentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsOpen { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}