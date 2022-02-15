using CleanMOQasine.API.Configurations;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CleanMOQasine.API.Extensions
{
    public static class IServiceProviderExtension
    {
        //Всё что связано с сервисами, лежащее в програм теперь тут
        public static void RegisterCleanMOQasineServices(this IServiceCollection services)
        {
            services.AddScoped<ICleaningTypeService, CleaningTypeService>();
            services.AddScoped<ICleaningAdditionService, CleaningAdditionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // а тут все что связано с репозиториями
        public static void RegisterCleanMOQasineRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICleaningTypeRepository, CleaningTypeRepository>();
            services.AddScoped<ICleaningAdditionRepository, CleaningAdditionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        
        // здесь лежат две строки с автомаперами.
        // может и не нужно это расширение, делающее програм аж на 1 строку меньше
        public static void RegisterCleanMOQasineAutomappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperFromApi), typeof(AutoMapperToData));
            services.AddAutoMapper(typeof(AutoMapperToData), typeof(OrderMapper));

        }

        // сюда собственно убрала AddAuthentication
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
            services.AddAuthorization(); // а этой строки не было у нас, но Антон написал у себя ее значит наверное нужно
        }
    }
}
