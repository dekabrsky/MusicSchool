using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicSchoolModel.Core.Domain.Abstractions;

namespace MusicSchoolModel.Core.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    Task Add(T entity);
    Task AddList(ICollection<T> entities);
    void Update(T entity);
    void UpdateList(ICollection<T> entities);
    void Remove(T entity);
    void RemoveList(ICollection<T> entities);
    Task<T> Find(params object[] keyValues);
    Task<IQueryable<T>> GetAll();
    Task SaveChanges();
    Task<IQueryable<T>> Query(Expression<Func<T, bool>> sample);
}
