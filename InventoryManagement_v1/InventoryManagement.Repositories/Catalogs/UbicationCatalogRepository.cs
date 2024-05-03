using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class UbicationCatalogRepository : ISpecificCatalogRepository<UbicationCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<UbicationCatalog> _entity;
        public UbicationCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<UbicationCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one ubication catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain ubication catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.UbicationName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method verify if exist one ubication catalog record that match with name param value.
        /// </summary>
        /// <param name="id">Appertain ubication catalog identifier value.</param>
        /// <param name="code">Appertain ubication catalog code value.</param>
        /// <param name="name">Appertain ubication catalog name value.</param>
        /// <returns>UbicationCatalog record or null value.</returns>
        public async Task<UbicationCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.UbicationName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
