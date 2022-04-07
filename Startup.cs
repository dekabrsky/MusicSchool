using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MusicSchoolModel.Infrastructure.Mapping;
using MusicSchoolModel.Infrastructure.Providers;
using MusicSchoolModel.Infrastructure.Repositories;
using MusicSchoolModel.MusicSchoolModel.Api.Providers;

namespace MusicSchoolModel;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(
            x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            ));
        
        services.AddServices();
        services.AddApiServices();
        
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicSchool Api", Version = "v1" });
        });

        services.AddAutoMapper(x =>
        {
            x.AddProfile<StudentMapper>();
            x.AddProfile<TeacherMapper>();
            x.AddProfile<CourseMapper>();
        });
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music School api/v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
