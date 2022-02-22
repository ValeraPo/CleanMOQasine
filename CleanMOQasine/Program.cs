using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Infrastructures;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
string _connectionStringVariableName = "CONNECTION_STRING"; 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetValue<string>(_connectionStringVariableName);
builder.Services.AddDbContext<CleanMOQasineContext>(opt
    => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<ICleaningTypeRepository, CleaningTypeRepository>();
builder.Services.AddScoped<ICleaningTypeService, CleaningTypeService>();
builder.Services.AddScoped<ICleaningAdditionRepository, CleaningAdditionRepository>();
builder.Services.AddScoped<ICleaningAdditionService, CleaningAdditionService>();
builder.Services.AddAutoMapper(typeof(AutoMapperFromApi), typeof(AutoMapperToData));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWorkingTimeRepository, WorkingTimeRepository>();
builder.Services.AddScoped<IWorkingTimeService, WorkingTimeService>();


builder.Services.AddAutoMapper(typeof(AutoMapperToData), typeof(OrderMapper));

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