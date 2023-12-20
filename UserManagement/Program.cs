using UserManagement.Models.Model;
using Microsoft.EntityFrameworkCore;
using UserManagement.Services.Interfaces;
using UserManagement.Services;
using UserManagement.Auth;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
AppSettings appSettings;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);

builder.Services.AddMemoryCache();
builder.Services.AddSingleton(appSettings);

builder.Services.AddDbContext<UserDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnection"), b => b.MigrationsAssembly("UserManagement"));
    //options.UseSqlServer(Configuration.GetConnectionString("YourConnection"));
});

builder.Services.AddScoped<IEpmloyeeService, EpmloyeeService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MyCorsPolicy", builder =>
    {
        builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();

        //builder
        //        .WithOrigins("http://localhost:4200/")
        //        .WithHeaders(
        //             //HeaderNames.ContentType,
        //             //HeaderNames.Cookie,
        //             HeaderNames.XRequestedWith)
        //        .WithMethods(
        //             HttpMethods.Get,
        //             HttpMethods.Post,
        //             HttpMethods.Put,
        //             HttpMethods.Delete)
        //        .AllowCredentials();
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
app.UseCors("MyCorsPolicy");
app.UseMiddleware<TokenMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
