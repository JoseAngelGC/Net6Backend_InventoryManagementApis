using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class ArticleBrandCatalogMappingProfile : Profile
    {
        public ArticleBrandCatalogMappingProfile()
        {
            //ArticleBrandCatalog response mapping
            CreateMap<ArticleBrandCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.BrandName));
            CreateMap<ResponseResult<IEnumerable<ArticleBrandCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<ArticleBrandCatalog>, ResponseResult<ResponseCatalogDto>>();

            //ArticleBrandCatalog request mapping
            CreateMap<RequestCatalogDto, ArticleBrandCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestByModifyCatalogDto, ArticleBrandCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.Name));
        }
    }
}
