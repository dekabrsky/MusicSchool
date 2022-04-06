using Microsoft.AspNetCore.Mvc;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.Domain.Teacher;
using MusicSchoolModel.Core.DTO.Teacher.Request;
using MusicSchoolModel.Core.Interfaces.Services;

namespace MusicSchoolModel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : BaseController<CreateTeacherDto, UpdateTeacherDto>
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service) { _service = service; }

    [HttpPost]
    public override async Task<IActionResult> Create(CreateTeacherDto data)
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
    public override async Task<IActionResult> Update(long id, UpdateTeacherDto data)
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
        string name = null,
        DateTime? createdDate = null,
        int skip = 0,
        int take = 15)
    {
        var filterable = new Filterable<Teacher>()
            .Add(x => x.Id == id, id)
            .Add(x => x.Name.Value.ToLower().Contains(name.ToLower()), name)
            .Add(x => x.CreatedDate == createdDate, createdDate);

        var teams = await _service.Query(filterable, sortDirection, sortField, skip, take);

        return Ok(teams);
    }
}
