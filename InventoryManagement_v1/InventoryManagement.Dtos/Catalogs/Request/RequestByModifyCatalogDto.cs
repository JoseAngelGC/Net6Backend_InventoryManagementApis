namespace InventoryManagement.Dtos.Catalogs.Request
{
    public class RequestByModifyCatalogDto
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string UserAlias { get; set; }
    }
}
