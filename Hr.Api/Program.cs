
using NajotTalim.HR.DataAcces;
using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces.Services;
using NajotTalim.HR.DataAccess;
using WebApplication1.Models;
using NajotTalim.HR.DataAcces.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContextPool<AppDbContext> (options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb")));
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })

            .AddJwtBearer(options =>
            {

                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValiAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))

                };


            });
            
          
            builder.Services.AddControllers();
            builder.Services.AddScoped<IGenericCRUDService<EmployeeModel>, EmployeeCRUDService>();
            builder.Services.AddScoped<IGenericCRUDService<AddressModel>, AddressCRUDService>();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmployeeRepasitory, EmployeeRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();    
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