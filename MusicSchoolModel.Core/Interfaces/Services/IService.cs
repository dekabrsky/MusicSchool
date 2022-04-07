using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.DataTransfer.Abstract;
using MusicSchoolModel.Core.Domain.Abstractions;

namespace MusicSchoolModel.Core.Interfaces.Services;

public interface IService<TEntity, in TCreateDto, in TUpdateDto, TFullDto, TShortDto, in TSortFields>
    where TEntity : Entity
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TFullDto : IFullDto
    where TShortDto : IShortDto
    where TSortFields : Enum
{
    Task Create(TCreateDto data);
    Task Update(long id, TUpdateDto data);
    Task Remove(long id);
    Task<TFullDto> Find(long id);

    Task<List<TShortDto>> Query(
        Filterable<TEntity> filterableCollection,
        Sorting sortDirection,
        TSortFields sortField,
        int skip = 0,
        int take = 15);
}