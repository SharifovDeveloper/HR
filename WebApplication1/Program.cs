
using NajotTalim.HR.DataAcces;
using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces.Services;
using NajotTalim.HR.DataAccess;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContextPool<AppDbContext> (options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb")));
            builder.Services.AddControllers();
            builder.Services.AddScoped<IGenericCRUDService<EmployeeModel>, EmployeeCRUDService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmployeeRepasitory,SqlServerEmployeeRepository>();
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

            app.Use(async (context, next) =>
            {
                Console.WriteLine("SAlom");
                await next();
                await Console.Out.WriteLineAsync("Hayr");

            });
            

            app.Run();
        }
    }
}