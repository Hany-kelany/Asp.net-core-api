using Api.Data;
using Api.DTO;
using Api.Middlware;
using Api.Models;
using Api.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.
                                         UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
        
        builder.Services.AddScoped<IbaseRepository<Employee , EmployeeModel> , EmolyeeRepository>();  
        builder.Services.AddScoped<IbaseRepository<Item , ItemModel> , ItemsRepository>();

        builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseMiddleware<RequesttimeMiddleware>();

        app.MapControllers();//

        app.Run();
    }
}