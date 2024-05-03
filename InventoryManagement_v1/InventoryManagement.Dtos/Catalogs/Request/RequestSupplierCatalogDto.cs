namespace InventoryManagement.Dtos.Catalogs.Request
{
    public class RequestSupplierCatalogDto : RequestCatalogDto
    {
        public string? CompanyEmail { get; set; }
        public string? Telephone { get; set; }
        public string? PhisicalAddress { get; set; }
    }
}
