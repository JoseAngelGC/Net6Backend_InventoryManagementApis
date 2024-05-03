using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class MeasureUnitCatalogRepository : ISpecificCatalogRepository<MeasureUnitCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<MeasureUnitCatalog> _entity;
        public MeasureUnitCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<MeasureUnitCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one measure unit catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain measure unit catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.MeasureUnitName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get record that match with id, code and name from measure unit catalog.
        /// </summary>
        /// <param name="id">Appertain measure unit catalog identifier value.</param>
        /// <param name="code">Appertain measure unit catalog code value.</param>
        /// <param name="name">Appertain measure unit catalog name value.</param>
        /// <returns>MeasureUnitCatalog record or null value.</returns>
        public async Task<MeasureUnitCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.MeasureUnitName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
