using Microsoft.Extensions.DependencyInjection;
using NextWaveEdu.Devfreela.API.Constants;
using NextWaveEdu.Devfreela.Application.Services;
using NextWaveEdu.Devfreela.Application.Services.Interfaces;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

            builder.Services.AddSingleton<DevfreelaDbContext>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
