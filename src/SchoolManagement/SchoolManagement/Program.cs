using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Grpc.Server;
using SchoolManagement.Grpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ITestGrpc, TestGrpcService>();
builder.Services.AddSwaggerGen();

builder.Services.AddCodeFirstGrpc();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGrpcService<TestGrpcService>();
    endpoint.MapGet("/proto/student_retrieve.proto", async context =>
    {
        var generator = new SchemaGenerator();
        var schema = generator.GetSchema<ITestGrpc>();

        //context.Response.ContentType = "application/octet-stream"; // or "text/plain"
        await context.Response.WriteAsync(schema);
    });
    // server streaming 
    endpoint.MapGrpcService<TestGrpcStreamService>();
    endpoint.MapGet("/proto/studentstream_retrieve.proto", async context =>
    {
        var generator = new SchemaGenerator();
        var schema = generator.GetSchema<ITestGrpcServerStreaming>();

        //context.Response.ContentType = "application/octet-stream"; // or "text/plain"
        await context.Response.WriteAsync(schema);
    });
});


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
