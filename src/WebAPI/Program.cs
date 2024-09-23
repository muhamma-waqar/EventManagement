using Infrastructure.Context;
using Infrastructure.Identity.Core.Services;
using Infrastructure.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Comman;
using E.WebApi.Swagger;
using MediatR;
using Application.Commands;
using Domain.Dependencies.Repositories;
using Infrastructure.Dependencies;
using Domain.Dependencies.Repositories.Comman;
using Infrastructure.Dependencies.Comman;
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddEventCommandHandler).Assembly));

builder.Services.AddDbContext<EventDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
           ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));
// Add CORS Origin 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwagger(builder.Configuration);
builder.Services.AddSwaggerGen();
ConfigureJwtAuthentication.ConfigureIdentityServices(builder.Services, builder.Configuration);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRedisCacheService,RedisCacheService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();
//builder.Services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
builder.Services.RegisterMyOptions<AuthenticationSettings>();
ConfigureJwtAuthentication.ConfigureLocalJwtAuthentication(builder.Services, builder.Configuration.GetMyOptions<AuthenticationSettings>());

builder.Services.AddGrpcClient<School.Student.TestGrpc.TestGrpcClient>(option =>
{
    option.Address = new Uri("https://localhost:7299/swagger/index.html");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
