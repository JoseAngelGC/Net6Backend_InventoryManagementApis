using FluentValidation;
using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.UseCases.Catalogs;
using InventoryManagement.UseCases.Catalogs.InteractorsSegregation;
using InventoryManagement.UseCases.Catalogs.Validators;
using InventoryManagement.UseCases.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            //Register validators
            services.AddValidatorsFromAssemblyContaining<RequestByModifyCatalogDtoValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<RequestCatalogDtoValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<RequestSupplierByModifyCatalogDtoValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<RequestSupplierCatalogDtoValidator>(ServiceLifetime.Transient);

            //Register use cases (InputPort-Interactor)
            services.AddScoped<IGenericCatalogUseCaseInputPort<CurrencyTypeCatalog>, CurrencyCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<InputTypeCatalog>, InputCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<MeasureUnitCatalog>, MeasureUnitCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<OutputTypeCatalog>, OutputCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<ProductTypeCatalog>, ProductTypeCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<UbicationCatalog>, UbicationCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<ArticleBrandCatalog>, ArticleBrandCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<CategoryCatalog>, CategoryCatalogCrudInteractor>();
            services.AddScoped<IGenericCatalogUseCaseInputPort<SubCategoryCatalog>, SubCategoryCategoryCrudInteractor>();
            services.AddScoped<ISupplierCatalogUseCaseInputPort<SupplierCatalog>, SupplierCatalogCrudInteractor>();

            //Register use cases (Interface Segregation-Interactor)
            services.AddScoped(typeof(ICatalogQueryOperationsUseCase<>), typeof(CatalogQueryOperationsUseCase<>));
            services.AddScoped(typeof(ICatalogCommandOperationsUseCase<>), typeof(CatalogCommandOperationsUseCase<>));

            //Register Helpers
            services.AddScoped<IResponseResultHelpers, ResponseResultHelpers>();

            return services;
        }
    }
}
