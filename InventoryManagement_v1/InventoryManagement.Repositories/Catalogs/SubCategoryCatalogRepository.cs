﻿using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Catalogs
{
    internal class SubCategoryCatalogRepository : ISpecificCatalogRepository<SubCategoryCatalog>
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<SubCategoryCatalog> _entity;
        public SubCategoryCatalogRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<SubCategoryCatalog>();
        }

        #region Exist method with name param
        /// <summary>
        /// This method verify if exist one subcategory catalog record that match with name param value.
        /// </summary>
        /// <param name="name">Appertain subcategory catalog name value.</param>
        /// <returns>True o false value.</returns>
        public async Task<bool> ExistsAsync(string name)
        {
            return await _entity.Where(c => c.SubCategoryName!.Trim() == name.Trim()).AnyAsync();
        }
        #endregion

        #region GetItem with id,code,name params
        /// <summary>
        /// This method get the first record that match with id, code and name from subcategory catalog.
        /// </summary>
        /// <param name="id">Appertain subcategory catalog identifier value.</param>
        /// <param name="code">Appertain subcategory catalog code value.</param>
        /// <param name="name">Appertain subcategory catalog name value.</param>
        /// <returns>SubCategory catalog record or null value.</returns>
        public async Task<SubCategoryCatalog> GetItemAsync(int id, Guid code, string name)
        {
            var response = await _entity.Where(c => c.ControlCode == code &&
            c.SubCategoryName == name && c.ItemId == id).FirstOrDefaultAsync();
            return response!;
        }
        #endregion
    }
}
