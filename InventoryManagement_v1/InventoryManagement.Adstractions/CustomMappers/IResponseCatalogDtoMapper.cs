using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Adstractions.CustomMappers
{
    public interface IResponseCatalogDtoMapper
    {
        Task<ResponseCatalogDto> EntityAsync(CatalogBaseEntity baseEntity);
        Task<List<ResponseCatalogDto>> ListAsync(IEnumerable<CatalogBaseEntity> baseEntityList);
    }
}
