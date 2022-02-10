using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Infrastructures;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data;
using CleanMOQasine.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddDbContext<CleanMOQasineContext>(opt
    => opt.UseSqlServer(@"Data Source=80.78.240.16;Initial Catalog=CleanMOQasine;User ID=student;Password=qwe!23"));

builder.Services.AddAutoMapper(typeof(GradeMapper),
                               typeof(AutoMapperToData));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();


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
