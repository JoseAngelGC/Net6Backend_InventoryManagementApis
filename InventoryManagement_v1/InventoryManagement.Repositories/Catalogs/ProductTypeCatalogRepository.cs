using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class ProductTypeCatalogRepository : ISpecificCatalogRepository<ProductTypeCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<ProductTypeCatalog> _entity;
        public ProductTypeCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<ProductTypeCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one product type catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain product type catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.ProductTypeName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method verify if exist one product type catalog record that match with name param value.
        /// </summary>
        /// <param name="id">Appertain product type catalog identifier value.</param>
        /// <param name="code">Appertain product type catalog code value.</param>
        /// <param name="name">Appertain product type catalog name value.</param>
        /// <returns>ProductTypeCatalog record or null value.</returns>
        public async Task<ProductTypeCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.ProductTypeName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
