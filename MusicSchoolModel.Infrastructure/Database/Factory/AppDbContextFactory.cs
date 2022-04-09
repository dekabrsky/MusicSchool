using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicSchoolModel.Infrastructure.Database;

namespace MusicSchoolModel.Infrastructure.Repositories;

public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        return new AppDbContext(
            new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost; Database=MusicSchoolTestDb; Integrated security=true;")
                .Options
        );
    }
}