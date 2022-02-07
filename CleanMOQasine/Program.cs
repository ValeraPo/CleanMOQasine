using CleanMOQasine.API.Configurations;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data;
using CleanMOQasine.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CleanMOQasineContext>(opt
    => opt.UseSqlServer(@"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=CleanMOQasine;Integrated Security=True"));
builder.Services.AddScoped<ICleaningTypeRepository, CleaningTypeRepository>();
builder.Services.AddScoped<ICleaningTypeService, CleaningTypeService>();
builder.Services.AddScoped<ICleaningAdditionRepository, CleaningAdditionRepository>();
builder.Services.AddScoped<ICleaningAdditionService, CleaningAdditionService>();
builder.Services.AddAutoMapper(typeof(AutoMapperFromApi), typeof(AutoMapperToData));
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
