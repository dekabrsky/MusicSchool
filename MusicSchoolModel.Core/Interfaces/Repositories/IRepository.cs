using MusicSchoolModel.Core.Domain.Abstractions;

namespace MusicSchoolModel.Core.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task Add(TEntity entity);
    Task AddList(ICollection<TEntity> entities);
    void Update(TEntity entity);
    void UpdateList(ICollection<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveList(ICollection<TEntity> entities);
    Task<TEntity> Find(params object[] keyValues);
    Task<IQueryable<TEntity>> GetAll();
    Task SaveChanges();
}
