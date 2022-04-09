using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using MusicSchoolModel.Core.Domain.Abstractions;
using MusicSchoolModel.Core.Domain.Course;
using MusicSchoolModel.Core.Domain.Student;
using MusicSchoolModel.Core.Domain.Teacher;

namespace MusicSchoolModel.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = Assembly.GetAssembly(typeof(AppDbContext));
        if (assembly != null) modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        ConfigureTriggers<Student>();
        ConfigureTriggers<Teacher>();
        ConfigureTriggers<Course>();
    }

    private void ConfigureTriggers<TEntity>()
        where TEntity : Entity
    {
        Triggers<TEntity, AppDbContext>.Inserting += entry =>
        {
            entry.Entity.CreatedDate = DateTime.Now;
            entry.Entity.ModifiedDate = DateTime.Now;
        };

        Triggers<TEntity, AppDbContext>.Updating += entry => { entry.Entity.ModifiedDate = DateTime.Now; };
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, true, cancellationToken);
    }
}