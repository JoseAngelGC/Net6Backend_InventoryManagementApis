namespace InventoryManagement.Entities.ArticlesInventory.Bases
{
    public abstract class CatalogBaseEntity
    {
        public int ItemId { get; set; }
        public Guid ControlCode { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
