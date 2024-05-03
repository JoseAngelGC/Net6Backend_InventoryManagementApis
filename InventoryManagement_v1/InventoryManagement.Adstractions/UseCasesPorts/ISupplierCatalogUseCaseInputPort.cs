using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Adstractions.UseCasesPorts
{
    public interface ISupplierCatalogUseCaseInputPort<T> where T : SupplierCatalog
    {
        Task<Task> ShowAllRecordsAsync();
        Task<Task> ShowRecordAsync(int id, RequestSupplierCatalogDto request);
        Task<Task> CreateRecordAsync(RequestSupplierCatalogDto request);
        Task<Task> EditRecordAsync(RequestSupplierByModifyCatalogDto request);
        Task<Task> DeleteRecordAsync(int id, RequestSupplierByModifyCatalogDto request);
    }
}
