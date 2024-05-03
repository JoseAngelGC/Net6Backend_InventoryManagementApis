using InventoryManagement.Adstractions.CustomMappers;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Presenters.Mappers.CustomMappers.Catalogs
{
    internal class ResponseCatalogDtoMapper : IResponseCatalogDtoMapper
    {
        private List<ResponseCatalogDto> responseCatalogDtoList;
        private ResponseCatalogDto catalogDtoEntity;
        public ResponseCatalogDtoMapper()
        {
            responseCatalogDtoList = new List<ResponseCatalogDto>();
            catalogDtoEntity = new ResponseCatalogDto();
        }

        public Task<ResponseCatalogDto> EntityAsync(CatalogBaseEntity baseEntity)
        {
            catalogDtoEntity.Id = baseEntity.ItemId;
            catalogDtoEntity.Status = baseEntity.Status;
            catalogDtoEntity.CreatedBy = baseEntity.CreatedBy;
            catalogDtoEntity.CreatedDate = baseEntity.CreatedDate;
            catalogDtoEntity.UpdatedBy = baseEntity.UpdatedBy;
            catalogDtoEntity.UpdatedDate = baseEntity.UpdatedDate;
            return Task.FromResult(catalogDtoEntity);
        }

        public async Task<List<ResponseCatalogDto>> ListAsync(IEnumerable<CatalogBaseEntity> baseEntityList)
        {
            foreach (var item in baseEntityList.ToList())
            {
                responseCatalogDtoList.Add(await EntityAsync(item));
            }
            return responseCatalogDtoList;
        }
    }
}
