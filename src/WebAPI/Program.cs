using Infrastructure.Context;
using Infrastructure.Identity.Core.Services;
using Infrastructure.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Comman;
using E.WebApi.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
