using MusicSchoolModel.Core.Domain.Course;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.DTO.Teacher.Request;
using MusicSchoolModel.Core.DTO.Teacher.Response;

namespace MusicSchoolModel.Core.Interfaces.Services;

public interface ICourseService: IService<
    Course, 
    CreateCourseDto, 
    UpdateCourseDto, 
    FullCourseDto, 
    ShortCourseDto, 
    SortFields>
{
    
}