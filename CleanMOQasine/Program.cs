using CleanMOQasine.API.Configurations;
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
    => opt.UseSqlServer(@"Data Source=80.78.240.16;Initial Catalog=CleanMOQasine;User ID=student;Password=qwe!23"));


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IAutoMapperFromApi, AutoMapperFromApi>();

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
