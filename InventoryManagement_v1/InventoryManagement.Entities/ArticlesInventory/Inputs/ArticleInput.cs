using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Inputs
{
    public partial class ArticleInput
    {
        public Guid ControlCode { get; set; }
        public Guid ArticleStoreCode { get; set; }
        public Guid InputMeasureUnitCode { get; set; }
        public int InputQuantity { get; set; }
        public Guid InputCurrencyCode { get; set; }
        public decimal? InputUnitaryCost { get; set; }
        public decimal? InputCost { get; set; }
        public Guid InputOrderCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ArticleStore ArticleStoreCodeNavigation { get; set; } = null!;
        public virtual CurrencyTypeCatalog InputCurrencyCodeNavigation { get; set; } = null!;
        public virtual MeasureUnitCatalog InputMeasureUnitCodeNavigation { get; set; } = null!;
        public virtual InputOrder InputOrderCodeNavigation { get; set; } = null!;
    }
}
