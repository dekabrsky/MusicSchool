using Microsoft.AspNetCore.Mvc;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.Domain.Course;
using MusicSchoolModel.Core.Domain.Student.Enums;
using MusicSchoolModel.Core.DTO.Teacher.Request;
using MusicSchoolModel.Core.Interfaces.Services;

namespace MusicSchoolModel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : BaseController<CreateCourseDto, UpdateCourseDto>
{
    private readonly ICourseService _service;

    public CourseController(ICourseService service) { _service = service; }

    [HttpPost]
    public override async Task<IActionResult> Create(CreateCourseDto data)
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
    public override async Task<IActionResult> Update(long id, UpdateCourseDto data)
    {
        await _service.Update(id, data);
        return Ok();
    }
    
    [HttpPut("updateIsOpen/{id}")]
    public async Task<IActionResult> UpdateIsOpen(long id, bool isOpen)
    {
        await _service.UpdateIsOpen(id, isOpen);
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
        bool? isOpen = null,
        DateTime? byCreatedDate = null,
        int skip = 0,
        int take = 15)
    {
        var filterCollection = new Filterable<Course>()
            .Add(x => x.Id == id, id)
            .Add(x => x.Name.Value.ToLower().Contains(name.ToLower()), name)
            .Add(x => x.IsOpen == isOpen, isOpen)
            .Add(x => x.CreatedDate == byCreatedDate, byCreatedDate);

        var courses = await _service.Query(filterCollection, sortDirection, sortField, skip, take);

        return Ok(courses);
    }
}
