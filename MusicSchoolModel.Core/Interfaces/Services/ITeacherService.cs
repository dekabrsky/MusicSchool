using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.Domain.Teacher;
using MusicSchoolModel.Core.DTO.Teacher.Request;
using MusicSchoolModel.Core.DTO.Teacher.Response;

namespace MusicSchoolModel.Core.Interfaces.Services;

public interface ITeacherService: IService<
    Teacher, 
    CreateTeacherDto, 
    UpdateTeacherDto, 
    FullTeacherDto, 
    ShortTeacherDto, 
    SortFields>
{
    
}