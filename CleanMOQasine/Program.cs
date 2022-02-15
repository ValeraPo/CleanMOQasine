using CleanMOQasine.API.Extensions;
using CleanMOQasine.API.Infrastructures;
using CleanMOQasine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string _connectionStringVariableName = "CONNECTION_STRING"; 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomAuth();

var connectionString = builder.Configuration.GetValue<string>(_connectionStringVariableName);
builder.Services.AddDbContext<CleanMOQasineContext>(opt
    => opt.UseSqlServer(connectionString));

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "JWT Authorization header using the Bearer scheme."

//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                          new OpenApiSecurityScheme
//                          {
//                              Reference = new OpenApiReference
//                              {
//                                  Type = ReferenceType.SecurityScheme,
//                                  Id = "Bearer"
//                              }
//                          },
//                         new string[] {}
//                    }
//                });
//});

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
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExeptionHandler>();

app.MapControllers();

app.Run();