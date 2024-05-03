using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class InputCatalogMappingProfile : Profile
    {
        public InputCatalogMappingProfile()
        {
            //InputTypeCatalog response mapping
            CreateMap<InputTypeCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.InputTypeName));
            CreateMap<ResponseResult<IEnumerable<InputTypeCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<InputTypeCatalog>, ResponseResult<ResponseCatalogDto>>();

            //InputTypeCatalog request mapping
            CreateMap<RequestCatalogDto, InputTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.InputTypeName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestByModifyCatalogDto, InputTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.InputTypeName, o => o.MapFrom(s => s.Name));
        }
    }
}
