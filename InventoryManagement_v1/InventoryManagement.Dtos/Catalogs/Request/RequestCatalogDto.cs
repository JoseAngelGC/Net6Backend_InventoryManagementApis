namespace InventoryManagement.Dtos.Catalogs.Request
{
    public class RequestCatalogDto
    {
        public int? Id { get; set; } = default;
        public Guid? Code { get; set; } = default;
        public string Name { get; set; }
        public bool? Status { get; set; } = true;
        public string UserAlias { get; set; }
    }
}
