using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.Domain.Common.ValueObjects;
using MusicSchoolModel.Core.Domain.Course;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.DTO.Teacher.Request;
using MusicSchoolModel.Core.DTO.Teacher.Response;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Core.Interfaces.Services;
using MusicSchoolModel.Infrastructure.Repositories;

namespace MusicSchoolModel.Infrastructure.Services;

public class CourseService: ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICourseFilterService _filterService;

    private const string NotFoundMessage = "Курс не найден";

    public CourseService(ICourseRepository repository, ICourseFilterService filterService, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _filterService = filterService;
    }

    public async Task Create(CreateCourseDto data)
    {
        var name = new Name(data.Name);
        var isOpen = data.IsOpen;
        var course = new Course(name, isOpen);

        await _repository.Add(course);
        await _repository.SaveChanges();
    }

    public async Task Update(long id, UpdateCourseDto data)
    {
        var course = await _repository.Find(id);
        
        if (course == null)
        {
            throw new Exception(NotFoundMessage);
        }

        if (!string.IsNullOrEmpty(data.Name))
        {
            course.UpdateName(new Name(data.Name));
        }
        
        course.IsOpen = data.IsOpen;
        
        _repository.Update(course);
        await _repository.SaveChanges();
    }

    public async Task Remove(long id)
    {
        var course = await _repository.Find(id);
        if (course == null)
        {
            throw new Exception(NotFoundMessage);
        }

        _repository.Remove(course);
        await _repository.SaveChanges();
    }

    public async Task<FullCourseDto> Find(long id)
    {
        var course = await _repository.Find(id);
        if (course == null)
        {
            throw new Exception(NotFoundMessage);
        }

        var response = _mapper.Map<FullCourseDto>(course);

        return response;
    }

    public async Task<List<ShortCourseDto>> Query(
        Filterable<Course> filterable,
        Sorting sortDirection, SortFields sortField,
        int skip = 0, int take = 15)
    {
        var courses = await _repository.GetAll();
        if (courses == null || !courses.Any())
        {
            throw new Exception(NotFoundMessage);
        }

        courses = _filterService.GetFilterData(courses, filterable);

        Expression<Func<Course, object>> sortBy = x => x.Id;
        switch (sortField)
        {
            case SortFields.Id:
                sortBy = x => x.Id;
                break;
            case SortFields.Name:
                sortBy = x => x.Name;
                break;
            case SortFields.CreatedDate:
                sortBy = x => x.CreatedDate;
                break;
        }

        courses = sortDirection == Sorting.Asc
            ? courses.OrderBy(sortBy)
            : courses.OrderByDescending(sortBy);

        courses = courses.Skip(skip).Take(take);

        var response = await courses
            .ProjectTo<ShortCourseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return response;
    }

    public async Task UpdateIsOpen(long id, bool isOpen)
    {
        var course = await _repository.Find(id);
        if (course is null)
        {
            throw new Exception(NotFoundMessage);
        }
        
        course.UpdateIsOpen(isOpen);

        _repository.Update(course);
        await _repository.SaveChanges();
    }
}