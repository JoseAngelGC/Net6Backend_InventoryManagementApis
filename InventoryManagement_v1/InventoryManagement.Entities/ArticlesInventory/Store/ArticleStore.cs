using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Entities.ArticlesInventory.Inputs;
using InventoryManagement.Entities.ArticlesInventory.Outputs;

namespace InventoryManagement.Entities.ArticlesInventory.Store
{
    public partial class ArticleStore
    {
        public ArticleStore()
        {
            ArticleInputs = new HashSet<ArticleInput>();
            ArticleOutputs = new HashSet<ArticleOutput>();
        }

        public Guid ControlCode { get; set; }
        public Guid UbicationCode { get; set; }
        public Guid ArticleSupplierCode { get; set; }
        public string? Lote { get; set; }
        public int? BarCode { get; set; }
        public Guid StockMeasureUnitCode { get; set; }
        public int? InputStock { get; set; }
        public int? OutputStock { get; set; }
        public int? CurrentStock { get; set; }
        public Guid CurrencyCode { get; set; }
        public decimal? StockUnitaryPrice { get; set; }
        public decimal? StockCost { get; set; }
        public bool? InputCompleted { get; set; }
        public string? Status { get; set; }
        public Guid? LastArticleStoreMovementCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ArticleSupplier ArticleSupplierCodeNavigation { get; set; } = null!;
        public virtual CurrencyTypeCatalog CurrencyCodeNavigation { get; set; } = null!;
        public virtual MeasureUnitCatalog StockMeasureUnitCodeNavigation { get; set; } = null!;
        public virtual UbicationCatalog UbicationCodeNavigation { get; set; } = null!;
        public virtual ICollection<ArticleInput> ArticleInputs { get; set; }
        public virtual ICollection<ArticleOutput> ArticleOutputs { get; set; }
    }
}
