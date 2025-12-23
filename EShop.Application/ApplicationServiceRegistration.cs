using EShop.Application.Interfaces.Security;
using EShop.Application.Security;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShop.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IPasswordHasherSecurity, PasswordHasherSecurity>();
            services.AddScoped<IJWTSecurity, JWTSecurity>();

            return services;
        }
    }
}
