using CleanMOQasine.API.Configurations;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CleanMOQasine.API.Extensions
{
    public static class IServiceProviderExtension
    {
        public static void RegisterCleanMOQasineServices(this IServiceCollection services)
        {
            services.AddScoped<ICleaningTypeService, CleaningTypeService>();
            services.AddScoped<ICleaningAdditionService, CleaningAdditionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IWorkingTimeService, WorkingTimeService>();
        }

        public static void RegisterCleanMOQasineRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICleaningTypeRepository, CleaningTypeRepository>();
            services.AddScoped<ICleaningAdditionRepository, CleaningAdditionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IWorkingTimeRepository, WorkingTimeRepository>();
        }
         
        public static void RegisterCleanMOQasineAutomappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperFromApi), typeof(AutoMapperToData));
            services.AddAutoMapper(typeof(AutoMapperToData), typeof(OrderMapper));
        }
         
        public static void AddCustomAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            services.AddAuthorization(); 
        }

        public static void RegisterSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.EnableAnnotations();
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyAPI",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Git Repository",
                        Url = new Uri("https://github.com/ValeraPo/CleanMOQasine"),
                    }
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
        }
    }
}
