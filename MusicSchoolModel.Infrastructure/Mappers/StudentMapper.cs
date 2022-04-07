using AutoMapper;
using MusicSchoolModel.Core.DataTransfer.Student.Response;
using MusicSchoolModel.Core.Domain.Student;

namespace MusicSchoolModel.Infrastructure.Mapping;

public class StudentMapper : Profile
{
    public StudentMapper()
    {
        CreateMap<Student, FullStudentDto>()
            .ForMember(x => x.FullName,
                x => x.MapFrom(z => z.Name.FullName));

        CreateMap<Student, ShortStudentDto>()
            .ForMember(x => x.FullName,
                x => x.MapFrom(z => z.Name.FullName));
    }
}