using System.Reflection;
using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtencions
    {
        public static void AddAplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
