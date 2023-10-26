using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SchiaviDelPadel.Domain;
using System.Reflection;

namespace SchiaviDelPadel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appSettings = builder.Configuration;
            builder.Services.AddDbContext<AppDbContext>(options => 
                     options.UseSqlServer(appSettings.GetConnectionString("DbConnectionString")));

            builder.Services.AddControllers();

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton(config);
            builder.Services.AddScoped<IMapper, ServiceMapper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}