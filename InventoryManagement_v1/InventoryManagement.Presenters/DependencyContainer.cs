using InventoryManagement.Adstractions.UseCasesPorts.commons;
using InventoryManagement.Dtos.Abstractions;
using InventoryManagement.Presenters.Responses;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryManagement.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            //Register automapper assemblies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IResponseOutputPort<IResponseResult>, CommonResponsePresenter>();

            return services;
        }
    }
}
