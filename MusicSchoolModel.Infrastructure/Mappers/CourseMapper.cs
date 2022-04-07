using AutoMapper;
using MusicSchoolModel.Core.Domain.Course;
using MusicSchoolModel.Core.DTO.Teacher.Response;

namespace MusicSchoolModel.Infrastructure.Mapping;

public class CourseMapper: Profile
{
    public CourseMapper()
    {
        CreateMap<Course, FullCourseDto>()
            .ForMember(x => x.Name, 
                x => x.MapFrom(z => z.Name.Value))
            .ForMember(x => x.IsOpen,
                x => x.MapFrom(z => z.IsOpen));

        CreateMap<Course, ShortCourseDto>()
            .ForMember(x => x.Name,
                x => x.MapFrom(z => z.Name.Value));
    }
}