using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class ProductCatalogMappingProfile : Profile
    {
        public ProductCatalogMappingProfile()
        {
            //ProductCatalog response mapping
            CreateMap<ProductTypeCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.ProductTypeName));
            CreateMap<ResponseResult<IEnumerable<ProductTypeCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<ProductTypeCatalog>, ResponseResult<ResponseCatalogDto>>();

            //ProductCatalog request mapping
            CreateMap<RequestCatalogDto, ProductTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.ProductTypeName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestByModifyCatalogDto, ProductTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.ProductTypeName, o => o.MapFrom(s => s.Name));
        }
    }
}
