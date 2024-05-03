using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Adstractions.UseCasesPorts
{
    public interface IGenericCatalogUseCaseInputPort<T> where T : CatalogBaseEntity
    {
        Task<Task> ShowAllRecordsAsync();
        Task<Task> ShowRecordAsync(int id, RequestCatalogDto request);
        Task<Task> CreateRecordAsync(RequestCatalogDto request);
        Task<Task> EditRecordAsync(RequestByModifyCatalogDto request);
        Task<Task> DeleteRecordAsync(int id, RequestByModifyCatalogDto request);
    }
}
