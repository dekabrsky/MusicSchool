using AutoMapper;
using MusicSchoolModel.Core.Domain.Teacher;
using MusicSchoolModel.Core.DTO.Teacher.Response;

namespace MusicSchoolModel.Infrastructure.Mapping;

public class TeacherMapper: Profile
{
    public TeacherMapper()
    {
        CreateMap<Teacher, FullTeacherDto>()
            .ForMember(x => x.FullName, 
                x => x.MapFrom(z => z.Name.FullName));

        CreateMap<Teacher, ShortTeacherDto>()
            .ForMember(x => x.FullName,
                x => x.MapFrom(z => z.Name.FullName));
    }
}