namespace InventoryManagement.Entities.ArticlesInventory.Store
{
    public partial class InputArticleMovement
    {
        public Guid ControlCode { get; set; }
        public Guid? ArticleMovementCode { get; set; }
        public string? MovementType { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
