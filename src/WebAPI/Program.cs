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

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddEventCommandHandler).Assembly));

builder.Services.AddDbContext<EventDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add CORS Origin 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:61774/")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwagger(builder.Configuration);
builder.Services.AddSwaggerGen();
ConfigureJwtAuthentication.ConfigureIdentityServices(builder.Services, builder.Configuration);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.RegisterMyOptions<AuthenticationSettings>();
ConfigureJwtAuthentication.ConfigureLocalJwtAuthentication(builder.Services, builder.Configuration.GetMyOptions<AuthenticationSettings>());
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

app.Run();
