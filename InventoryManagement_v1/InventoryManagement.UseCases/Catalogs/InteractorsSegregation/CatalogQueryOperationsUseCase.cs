using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.UseCases.Catalogs.InteractorsSegregation
{
    public class CatalogQueryOperationsUseCase<T> : ICatalogQueryOperationsUseCase<T> where T : CatalogBaseEntity
    {
        private readonly ISpecificCatalogRepository<T> _specificRepository;
        private readonly ICatalogGenericRepository<T> _genericRepository;
        public CatalogQueryOperationsUseCase(ICatalogGenericRepository<T> genericRepository, ISpecificCatalogRepository<T> specificRepository)
        {
            _genericRepository = genericRepository;
            _specificRepository = specificRepository;
        }

        public async Task<IEnumerable<T>> AllRecordsOrderedByIdDescAsync()
        {
            var getRecords = await _genericRepository.GetAllAsync();

            if (getRecords is not null)
            {
                return getRecords.OrderByDescending(x => x.ItemId).ToList();
            }
            return getRecords!;
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _specificRepository.ExistsAsync(name);
        }

        public async Task<bool> ExistsAsync(int? id, Guid? code)
        {
            return await _genericRepository.ExistsAsync(id, code);
        }

        public async Task<T> ItemAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public Task<T> ItemAsync(int id, Guid code, string name)
        {
            return _specificRepository.GetItemAsync(id, code, name);
        }
    }
}
