using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class ArticleBrandCatalogRepository : ISpecificCatalogRepository<ArticleBrandCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<ArticleBrandCatalog> _entity;
        public ArticleBrandCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<ArticleBrandCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one article brand catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain currency type catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.BrandName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get the first record that match with id, code and name from article brand catalog.
        /// </summary>
        /// <param name="id">Appertain article brand catalog identifier value.</param>
        /// <param name="code">Appertain article brand catalog code value.</param>
        /// <param name="name">Appertain article brand catalog name value.</param>
        /// <returns>Article brand catalog record or null value.</returns>
        public async Task<ArticleBrandCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.BrandName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
