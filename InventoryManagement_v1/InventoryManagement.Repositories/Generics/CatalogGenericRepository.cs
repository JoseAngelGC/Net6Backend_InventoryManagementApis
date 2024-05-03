using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.Generics
{
    internal class CatalogGenericRepository<T> : ICatalogGenericRepository<T> where T : CatalogBaseEntity
    {
        private readonly InventoryManagementContext _context;
        private readonly DbSet<T> _entity;
        public CatalogGenericRepository(InventoryManagementContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var response = _entity.AsQueryable();
            return await Task.FromResult(response);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _entity.Where(c => c.ItemId == id).SingleOrDefaultAsync();
            return response!;
        }

        public async Task<bool> ExistsAsync(int? id, Guid? code)
        {
            return await _entity.Where(c => c.ItemId == id && c.ControlCode == code).AnyAsync();
        }

        public async Task<int> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            var operationState = await _context.SaveChangesAsync();
            return operationState;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).Property(x => x.ItemId).IsModified = false;
            _context.Entry(entity).Property(x => x.ControlCode).IsModified = false;
            _context.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
            _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
            var operationState = await _context.SaveChangesAsync();
            return operationState;
        }

        public async Task<int> RemoveAsync(T entity)
        {
            _entity.Remove(entity);
            var operationState = await _context.SaveChangesAsync();
            return operationState;
        }

    }
}
