using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Adstractions.Repositories
{
    public interface ISpecificCatalogRepository<T> where T : CatalogBaseEntity
    {
        Task<T> GetItemAsync(int id, Guid code, string name);
        Task<bool> ExistsAsync(string name);
    }
}
