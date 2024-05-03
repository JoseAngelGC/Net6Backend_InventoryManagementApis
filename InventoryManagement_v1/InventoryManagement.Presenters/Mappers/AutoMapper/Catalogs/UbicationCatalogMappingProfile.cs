using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class UbicationCatalogMappingProfile : Profile
    {
        public UbicationCatalogMappingProfile()
        {
            //UbicationCatalog response mapping
            CreateMap<UbicationCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.UbicationName));
            CreateMap<ResponseResult<IEnumerable<UbicationCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<UbicationCatalog>, ResponseResult<ResponseCatalogDto>>();

            //UbicationCatalog request mapping
            CreateMap<RequestCatalogDto, UbicationCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.UbicationName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestByModifyCatalogDto, UbicationCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.UbicationName, o => o.MapFrom(s => s.Name));
        }
    }
}
