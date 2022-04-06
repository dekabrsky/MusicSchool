using Microsoft.AspNetCore.Mvc;

namespace MusicSchoolModel.Api.Controllers;

public abstract class BaseController<TCreateDto, TUpdateDto> : ControllerBase
{
    public abstract Task<IActionResult> Create(TCreateDto data);
    public abstract Task<IActionResult> Get(long id);
    public abstract Task<IActionResult> Update(long id, TUpdateDto data);
    public abstract Task<IActionResult> Delete(long id);
}