using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.Domain.Abstractions;

namespace MusicSchoolModel.Infrastructure.Repositories;

public interface IFilterService<T> where T : Entity
{
    IQueryable<T> GetFilterData(IQueryable<T> data, Filterable<T> filterable);
}
