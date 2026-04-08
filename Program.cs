using L3C1WebAPI.Data;
using L3C1WebAPI.Models;
using L3C1WebAPI.Services.Implementations;
using L3C1WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Student>(
    builder.Configuration.GetSection("Student")
    );


builder.Services.AddDbContext<AppDbContext>(
   (options) => { options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")); }
);

builder.Services.AddScoped<IModuleService, ModuleService>();

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
