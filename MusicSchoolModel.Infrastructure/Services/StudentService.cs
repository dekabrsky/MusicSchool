using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.DataTransfer.Student.Request;
using MusicSchoolModel.Core.DataTransfer.Student.Response;
using MusicSchoolModel.Core.Domain.Common.ValueObjects;
using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Core.Interfaces.Services;
using MusicSchoolModel.Infrastructure.Repositories;

namespace MusicSchoolModel.Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStudentFilterService _filterService;

    private const string NotFoundMessage = "Ученик не найден";

    public StudentService(IStudentRepository repository, IStudentFilterService filterService, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _filterService = filterService;
    }

    public async Task Create(CreateStudentDto data)
    {
        var name = new PersonName(new Name(data.FirstName), new Name(data.LastName));
        var student = new Student(name);

        await _repository.Add(student);
        await _repository.SaveChanges();
    }

    public async Task Update(long id, UpdateStudentDto data)
    {
        var student = await _repository.Find(id);
        
        if (student == null)
        {
            throw new Exception(NotFoundMessage);
        }

        if (!string.IsNullOrEmpty(data.FirstName) && !string.IsNullOrEmpty(data.LastName))
        {
            var name = new PersonName(new Name(data.FirstName), new Name(data.LastName));
            student.UpdateName(name);
        }
        
        student.TeacherId = data.TeacherId;
        
        _repository.Update(student);
        await _repository.SaveChanges();
    }

    public async Task Remove(long id)
    {
        var student = await _repository.Find(id);
        if (student == null)
        {
            throw new Exception(NotFoundMessage);
        }

        _repository.Remove(student);
        await _repository.SaveChanges();
    }

    public async Task<FullStudentDto> Find(long id)
    {
        var student = await _repository.Find(id);
        if (student == null)
        {
            throw new Exception(NotFoundMessage);
        }

        var response = _mapper.Map<FullStudentDto>(student);

        return response;
    }

    public async Task<List<ShortStudentDto>> Query(
        Filterable<Student> filterable,
        Sorting sortDirection, SortFields sortField,
        int skip = 0, int take = 15)
    {
        var students = await _repository.GetAll();
        if (students == null || !students.Any())
        {
            throw new Exception(NotFoundMessage);
        }

        students = _filterService.GetFilterData(students, filterable);

        Expression<Func<Student, object>> sortBy = x => x.Id;
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

        students = sortDirection == Sorting.Asc
            ? students.OrderBy(sortBy)
            : students.OrderByDescending(sortBy);

        students = students.Skip(skip).Take(take);

        var response = await students
            .ProjectTo<ShortStudentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return response;
    }
}