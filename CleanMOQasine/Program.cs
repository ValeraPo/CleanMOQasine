using CleanMOQasine.API.Extensions;
using CleanMOQasine.API.Infrastructures;
using CleanMOQasine.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string _connectionStringVariableName = "CONNECTION_STRING"; 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomAuth();
builder.Services.AddDbContext<CleanMOQasineContext>(opt
    => opt.UseSqlServer(_connectionStringVariableName));

builder.Services.RegisterCleanMOQasineServices();
builder.Services.RegisterCleanMOQasineRepositories();
builder.Services.RegisterCleanMOQasineAutomappers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExeptionHandler>();

app.MapControllers();

app.Run();