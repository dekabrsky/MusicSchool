using MusicSchoolModel.Core.DataTransfer.Student.Request;
using MusicSchoolModel.Core.DataTransfer.Student.Response;
using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Domain.Student.Enums;

namespace MusicSchoolModel.Core.Interfaces.Services;

public interface IStudentService: IService<
    Student, 
    CreateStudentDto, 
    UpdateStudentDto, 
    FullStudentDto, 
    ShortStudentDto, 
    SortFields>
{
    
}