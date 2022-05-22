using MagnifinanceTask.Infrastructure.Ioc;
using MagnifinanceTask.Infrastructure.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .InjectSqlServer(builder.Configuration.GetConnectionString("Local"))
    .InjectRepositories()
    .InjectServices()
    .InjectAutoMapper()
    .InjectSerilog(Path.Combine(Environment.CurrentDirectory, "app.log"));

builder.Services.BuildServiceProvider().MigrateDatabase();
builder.Services.BuildServiceProvider().SeedData();

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