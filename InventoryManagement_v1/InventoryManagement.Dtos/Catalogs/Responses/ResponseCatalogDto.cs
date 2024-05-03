namespace InventoryManagement.Dtos.Catalogs.Responses
{
    public class ResponseCatalogDto
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
