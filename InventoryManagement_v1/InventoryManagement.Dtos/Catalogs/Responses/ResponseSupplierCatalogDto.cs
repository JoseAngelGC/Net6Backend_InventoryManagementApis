namespace InventoryManagement.Dtos.Catalogs.Responses
{
    public class ResponseSupplierCatalogDto : ResponseCatalogDto
    {
        public string? CompanyEmail { get; set; }
        public string? Telephone { get; set; }
        public string? PhisicalAddress { get; set; }
    }
}
