using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class OutputTypeCatalogRepository : ISpecificCatalogRepository<OutputTypeCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<OutputTypeCatalog> _entity;
        public OutputTypeCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<OutputTypeCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one output type catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain output type catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.OutputTypeName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get record that match with id, code and name from output type catalog.
        /// </summary>
        /// <param name="id">Appertain output type catalog identifier value.</param>
        /// <param name="code">Appertain output type catalog code value.</param>
        /// <param name="name">Appertain output type catalog name value.</param>
        /// <returns>OutputTypeCatalog record or null value.</returns>
        public async Task<OutputTypeCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.OutputTypeName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
