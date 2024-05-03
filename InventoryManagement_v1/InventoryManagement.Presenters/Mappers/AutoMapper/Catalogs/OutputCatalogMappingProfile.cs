using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class OutputCatalogMappingProfile : Profile
    {
        public OutputCatalogMappingProfile()
        {
            //OutputTypeCatalog response mapping
            CreateMap<OutputTypeCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.OutputTypeName));
            CreateMap<ResponseResult<IEnumerable<OutputTypeCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<OutputTypeCatalog>, ResponseResult<ResponseCatalogDto>>();

            //OutputTypeCatalog request mapping
            CreateMap<RequestCatalogDto, OutputTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.OutputTypeName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestByModifyCatalogDto, OutputTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.OutputTypeName, o => o.MapFrom(s => s.Name));
        }
    }
}
