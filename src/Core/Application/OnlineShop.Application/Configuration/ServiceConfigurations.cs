using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Features.Behaviours;
using System.Reflection;

namespace OnlineShop.Application.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddApplicationBaseConfigurations(this IServiceCollection services, Assembly assembly)
        {
           
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        }
    }
}
