using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class InputTypeCatalogRepository : ISpecificCatalogRepository<InputTypeCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<InputTypeCatalog> _entity;
        public InputTypeCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<InputTypeCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one input type catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain input type catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.InputTypeName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get record that match with id, code and name from input type catalog.
        /// </summary>
        /// <param name="id">Appertain input type catalog identifier value.</param>
        /// <param name="code">Appertain input type catalog code value.</param>
        /// <param name="name">Appertain input type catalog name value.</param>
        /// <returns>InputTypecatalog record or null value.</returns>
        public async Task<InputTypeCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.InputTypeName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
