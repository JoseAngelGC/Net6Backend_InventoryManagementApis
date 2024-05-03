using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Outputs
{
    public partial class ArticleOutput
    {
        public Guid ControlCode { get; set; }
        public Guid ArticleStoreCode { get; set; }
        public Guid OutputMeasureUnitCode { get; set; }
        public int OutputQuantity { get; set; }
        public decimal? OutputCost { get; set; }
        public Guid OutputOrderCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ArticleStore ArticleStoreCodeNavigation { get; set; } = null!;
        public virtual MeasureUnitCatalog OutputMeasureUnitCodeNavigation { get; set; } = null!;
        public virtual OutputOrder OutputOrderCodeNavigation { get; set; } = null!;
    }
}
