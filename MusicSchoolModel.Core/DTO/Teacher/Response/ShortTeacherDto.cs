using System;
using MusicSchoolModel.Core.DataTransfer.Student.Response;

namespace MusicSchoolModel.Core.DTO.Teacher.Response;

public class ShortTeacherDto : ShortStudentDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public long? CourseId { get; set; }
    public DateTime CreatedDate { get; set; }
}