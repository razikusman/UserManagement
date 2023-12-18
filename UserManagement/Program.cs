using UserManagement.Models.Model;
using Microsoft.EntityFrameworkCore;
using UserManagement.Services.Interfaces;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<UserDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnection"), b => b.MigrationsAssembly("UserManagement"));
    //options.UseSqlServer(Configuration.GetConnectionString("YourConnection"));
});

builder.Services.AddScoped<IEpmloyeeService, EpmloyeeService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MyCorsPolicy", builder =>
    {
        builder
                .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

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
