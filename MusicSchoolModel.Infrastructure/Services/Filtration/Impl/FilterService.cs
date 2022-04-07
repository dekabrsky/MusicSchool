using System.Linq;
using MusicSchoolModel.Core.Common;
using MusicSchoolModel.Core.Domain.Abstractions;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class FilterService<T> : IFilterService<T> where T : Entity
{
    public IQueryable<T> GetFilterData(IQueryable<T> data, Filterable<T> filterable)
    {
        if (!filterable.Any())
        {
            return data;
        }

        foreach (var filterExpression in filterable)
        {
            data = data.Where(filterExpression);
        }

        return data;
    }
}