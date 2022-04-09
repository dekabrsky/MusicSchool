using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicSchoolModel.Core.Domain.Abstractions;
using MusicSchoolModel.Core.Interfaces.Repositories;
using MusicSchoolModel.Infrastructure.Database;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T>
    where T : Entity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task Add(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task AddList(ICollection<T> entities)
    {
        await _entities.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public void UpdateList(ICollection<T> entities)
    {
        _entities.UpdateRange(entities);
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveList(ICollection<T> entities)
    {
        _entities.RemoveRange(entities);
    }

    public async Task<T> Find(params object[] keyValues)
    {
        return await _entities.FindAsync(keyValues);
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return await Task.FromResult(_entities);
    }

    public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> sample)
    {
        return await Task.FromResult(_entities.Where(sample));
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
