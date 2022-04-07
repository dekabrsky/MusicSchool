using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.Domain.Common.ValueObjects;
using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.Domain.Teacher;
using MusicSchoolModel.Core.DTO.Teacher.Request;
using MusicSchoolModel.Core.DTO.Teacher.Response;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Core.Interfaces.Services;
using MusicSchoolModel.Infrastructure.Repositories;

namespace MusicSchoolModel.Infrastructure.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IMapper _mapper;
    private readonly ITeacherFilterService _filterService;

    private const string NotFoundMessage = "Преподаватель не найден";

    public TeacherService(ITeacherRepository repository, ITeacherFilterService filterService, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _filterService = filterService;
    }

    public async Task Create(CreateTeacherDto data)
    {
        var name = new PersonName(new Name(data.FirstName), new Name(data.LastName));
        var course = data.CourseId;
        var teacher = new Teacher(name, course);

        await _repository.Add(teacher);
        await _repository.SaveChanges();
    }

    public async Task Update(long id, UpdateTeacherDto data)
    {
        var teacher = await _repository.Find(id);
        
        if (teacher == null)
        {
            throw new Exception(NotFoundMessage);
        }

        if (!string.IsNullOrEmpty(data.FirstName) && !string.IsNullOrEmpty(data.LastName))
        {
            var name = new PersonName(new Name(data.FirstName), new Name(data.LastName));
            teacher.UpdateName(name);
        }

        if (data.CourseId != null)
        {
            teacher.CourseId = data.CourseId ?? throw new Exception();
        }

        _repository.Update(teacher);
        await _repository.SaveChanges();
    }

    public async Task Remove(long id)
    {
        var teacher = await _repository.Find(id);
        if (teacher == null)
        {
            throw new Exception(NotFoundMessage);
        }

        _repository.Remove(teacher);
        await _repository.SaveChanges();
    }

    public async Task<FullTeacherDto> Find(long id)
    {
        var teacher = await _repository.Find(id);
        if (teacher == null)
        {
            throw new Exception(NotFoundMessage);
        }

        var response = _mapper.Map<FullTeacherDto>(teacher);

        return response;
    }

    public async Task<List<ShortTeacherDto>> Query(
        Filterable<Teacher> filterable,
        Sorting sortDirection, SortFields sortField,
        int skip = 0, int take = 15)
    {
        var teachers = await _repository.GetAll();
        if (teachers == null || !teachers.Any())
        {
            throw new Exception(NotFoundMessage);
        }

        teachers = _filterService.GetFilterData(teachers, filterable);

        Expression<Func<Teacher, object>> sortBy = x => x.Id;
        switch (sortField)
        {
            case SortFields.Id:
                sortBy = x => x.Id;
                break;
            case SortFields.Name:
                sortBy = x => x.Name.FullName;
                break;
            case SortFields.CreatedDate:
                sortBy = x => x.CreatedDate;
                break;
        }

        teachers = sortDirection == Sorting.Asc
            ? teachers.OrderBy(sortBy)
            : teachers.OrderByDescending(sortBy);

        teachers = teachers.Skip(skip).Take(take);

        var response = await teachers
            .ProjectTo<ShortTeacherDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return response;
    }
}