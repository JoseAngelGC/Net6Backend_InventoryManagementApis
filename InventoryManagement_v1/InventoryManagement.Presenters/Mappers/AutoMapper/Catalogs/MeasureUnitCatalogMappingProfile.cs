using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class MeasureUnitCatalogMappingProfile : Profile
    {
        public MeasureUnitCatalogMappingProfile()
        {
            //MeasureUnitcatalog response mapping
            CreateMap<MeasureUnitCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.MeasureUnitName));
            CreateMap<ResponseResult<IEnumerable<MeasureUnitCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<MeasureUnitCatalog>, ResponseResult<ResponseCatalogDto>>();

            //MeasureUnitCatalog request mapping
            CreateMap<RequestCatalogDto, MeasureUnitCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.MeasureUnitName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestByModifyCatalogDto, MeasureUnitCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.MeasureUnitName, o => o.MapFrom(s => s.Name));
        }
    }
}
