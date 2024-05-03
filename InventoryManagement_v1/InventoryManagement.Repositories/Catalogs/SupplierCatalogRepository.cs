using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class SupplierCatalogRepository : ISpecificCatalogRepository<SupplierCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<SupplierCatalog> _entity;
        public SupplierCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<SupplierCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one supplier catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain supplier catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.CompanyName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get the first record that match with id, code and name from supplier catalog.
        /// </summary>
        /// <param name="id">Appertain supplier catalog identifier value.</param>
        /// <param name="code">Appertain supplier catalog code value.</param>
        /// <param name="name">Appertain supplier catalog name value.</param>
        /// <returns>Supplier catalog record or null value.</returns>
        public async Task<SupplierCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.CompanyName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
