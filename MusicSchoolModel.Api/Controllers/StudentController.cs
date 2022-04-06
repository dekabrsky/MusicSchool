using Microsoft.AspNetCore.Mvc;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.DataTransfer.Student.Request;
using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.Interfaces.Services;

namespace MusicSchoolModel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseController<CreateStudentDto, UpdateStudentDto>
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service) { _service = service; }

    [HttpPost]
    public override async Task<IActionResult> Create(CreateStudentDto data)
    {
        await _service.Create(data);
        return Ok();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> Get(long id)
    {
        return Ok(await _service.Find(id));
    }

    [HttpPut("{id}")]
    public override async Task<IActionResult> Update(long id, UpdateStudentDto data)
    {
        await _service.Update(id, data);
        return Ok();
    }

    [HttpDelete("{id}")]
    public override async Task<IActionResult> Delete(long id)
    {
        await _service.Remove(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Query(
        Sorting sortDirection = Sorting.Asc,
        SortFields sortField = SortFields.Id,
        long? id = null,
        string? name = null,
        DateTime? createdDate = null,
        int skip = 0,
        int take = 15)
    {
        var filterable = new Filterable<Student>()
            .Add(x => x.Id == id, id)
            .Add(x => x.Name.FullName.ToLower().Contains(name.ToLower()), name)
            .Add(x => x.CreatedDate == createdDate, createdDate);

        var students = await _service.Query(filterable, sortDirection, sortField, skip, take);

        return Ok(students);
    }
}