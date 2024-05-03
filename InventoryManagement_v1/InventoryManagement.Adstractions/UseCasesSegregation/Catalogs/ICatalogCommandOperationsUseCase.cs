using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Adstractions.UseCasesSegregation.Catalogs
{
    public interface ICatalogCommandOperationsUseCase<T> where T : CatalogBaseEntity
    {
        Task<int> CreateAsync(T entity, string userAlias);
        Task<int> EditAsync(T entity, string userAlias);
        Task<int> DeleteAsync(T entity);
    }
}
