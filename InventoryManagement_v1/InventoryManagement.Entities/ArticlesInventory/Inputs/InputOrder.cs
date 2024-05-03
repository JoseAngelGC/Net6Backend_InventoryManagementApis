using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Entities.ArticlesInventory.Inputs
{
    public partial class InputOrder
    {
        public InputOrder()
        {
            ArticleInputs = new HashSet<ArticleInput>();
        }

        public Guid ControlCode { get; set; }
        public string FolioNumber { get; set; } = null!;
        public Guid InputTypeCode { get; set; }
        public Guid CurrencyCode { get; set; }
        public decimal SubtotalCost { get; set; }
        public decimal TotalCost { get; set; }
        public int? ArticleQuantity { get; set; }
        public string EntityType { get; set; } = null!;
        public string EntityCode { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual CurrencyTypeCatalog CurrencyCodeNavigation { get; set; } = null!;
        public virtual InputTypeCatalog InputTypeCodeNavigation { get; set; } = null!;
        public virtual ICollection<ArticleInput> ArticleInputs { get; set; }
    }
}
