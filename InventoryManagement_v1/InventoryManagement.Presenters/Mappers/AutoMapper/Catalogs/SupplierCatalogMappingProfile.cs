using AutoMapper;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class SupplierCatalogMappingProfile : Profile
    {
        public SupplierCatalogMappingProfile()
        {
            //SupplierCatalog response mapping
            CreateMap<SupplierCatalog, ResponseSupplierCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.CompanyName));
            CreateMap<ResponseResult<IEnumerable<SupplierCatalog>>, ResponseResult<IEnumerable<ResponseSupplierCatalogDto>>>();
            CreateMap<ResponseResult<SupplierCatalog>, ResponseResult<ResponseSupplierCatalogDto>>();

            //SupplierCatalog request mapping
            CreateMap<RequestSupplierCatalogDto, SupplierCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Name!.Trim()));
            CreateMap<RequestSupplierByModifyCatalogDto, SupplierCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Name));
        }
    }
}
