using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class CurrencyTypeCatalogRepository : ISpecificCatalogRepository<CurrencyTypeCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<CurrencyTypeCatalog> _entity;

        public CurrencyTypeCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<CurrencyTypeCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one currency type catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain currency type catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.CurrencyTypeName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get record that match with id, code and name from currency type catalog.
        /// </summary>
        /// <param name="id">Appertain currency type catalog identifier value.</param>
        /// <param name="code">Appertain currency type catalog code value.</param>
        /// <param name="name">Appertain currency type catalog name value.</param>
        /// <returns>CurrencyTypecatalog record or null value.</returns>
        public async Task<CurrencyTypeCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.CurrencyTypeName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
