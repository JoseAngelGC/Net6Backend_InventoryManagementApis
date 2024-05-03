using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Adstractions.UseCasesSegregation.Catalogs
{
    public interface ICatalogQueryOperationsUseCase<T> where T : CatalogBaseEntity
    {
        Task<IEnumerable<T>> AllRecordsOrderedByIdDescAsync();
        Task<T> ItemAsync(int id);
        Task<T> ItemAsync(int id, Guid code, string name);
        Task<bool> ExistsAsync(string name);
        Task<bool> ExistsAsync(int? id, Guid? code);
    }
}
