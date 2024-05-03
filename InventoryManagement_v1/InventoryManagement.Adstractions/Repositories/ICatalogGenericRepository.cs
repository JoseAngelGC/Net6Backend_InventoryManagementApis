using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Adstractions.Repositories
{
    public interface ICatalogGenericRepository<T> where T : CatalogBaseEntity 
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int? id, Guid? code);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
    }
}
