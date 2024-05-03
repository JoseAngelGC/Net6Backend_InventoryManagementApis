using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.Catalogs;
using InventoryManagement.Repositories.DataContext;
using InventoryManagement.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext service register
            var assembly = typeof(InventoryManagementContext).Assembly.FullName;
            services.AddDbContext<InventoryManagementContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionDev"),
                opt => opt.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );

            //Repositories register
            services.AddScoped(typeof(ICatalogGenericRepository<>), typeof(CatalogGenericRepository<>));
            services.AddScoped<ISpecificCatalogRepository<CurrencyTypeCatalog>, CurrencyTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<InputTypeCatalog>, InputTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<MeasureUnitCatalog>, MeasureUnitCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<OutputTypeCatalog>, OutputTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<ProductTypeCatalog>, ProductTypeCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<UbicationCatalog>, UbicationCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<ArticleBrandCatalog>, ArticleBrandCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<CategoryCatalog>, CategoryCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<SubCategoryCatalog>, SubCategoryCatalogRepository>();
            services.AddScoped<ISpecificCatalogRepository<SupplierCatalog>, SupplierCatalogRepository>();

            return services;
        }
    }
}
